--------------------------------------------------------------------------------------------------------------------------------
--[[			utils.lua 								                      	
		Goal - Genaral utility functions
--]]
--------------------------------------------------------------------------------------------------------------------------------

-------------------------[[Module Declaratrion]]-------------------------
LuaDebuggerHelper = LuaDebuggerHelper or {}

-------------------------------[[Private]]-------------------------------


-------------------------------[[Public]]--------------------------------

local function getinfo(level,field)
	level = level + 1  --to get to the same relative level as the caller
	if not field then return debug.getinfo(level) end
	
	local what
	
	if field == 'name' or field == 'namewhat' then
		what = 'n'
	elseif field == 'what' or field == 'source' or field == 'linedefined' or field == 'lastlinedefined' or field == 'short_src' then
		what = 'S'
	elseif field == 'currentline' then
		what = 'l'
	elseif field == 'nups' then
		what = 'u'
	elseif field == 'func' then
		what = 'f'
	else
		return debug.getinfo(level,field)
	end
	
	local ar = debug.getinfo(level,what)
	
	if ar then return ar[field] else return nil end
end

--[[
Function Name 	: capture_vars
Description		: Gets all variables, file and line in the given stack level relative to the offset by ref
Input 			: ref - the stack offset, level - the stack level, line - the current line
Output  		: All varialbes + file&line
]]--
function LuaDebuggerHelper.capture_vars(ref,level,line)
	--get vars, file and line for the given level relative to debug_hook offset by ref
	
	local lvl = ref + level                --NB: This includes an offset of +1 for the call to here
	
	--{{{  capture variables
	
	local ar = debug.getinfo(lvl, "f")
	if not ar then return {},'?',0 end
	
	local vars = {__UPVALUES__={}, __LOCALS__={}}
	local i
	
	local func = ar.func
	if func then
	i = 1
	while true do
		local name, value = debug.getupvalue(func, i)
		if not name then break end
		if string.sub(name,1,1) ~= '(' then  --NB: ignoring internal control variables
		vars[name] = value
		vars.__UPVALUES__[i] = name
		end
		i = i + 1
	end
	vars.__ENVIRONMENT__ = getfenv(func)
	end
	
	vars.__GLOBALS__ = getfenv(0)
	
	i = 1
	while true do
	local name, value = debug.getlocal(lvl, i)
	if not name then break end
	if string.sub(name,1,1) ~= '(' then    --NB: ignoring internal control variables
		vars[name] = value
		vars.__LOCALS__[i] = name
	end
	i = i + 1
	end
	
	vars.__VARSLEVEL__ = level
	
	if func then
	--NB: Do not do this until finished filling the vars table
	setmetatable(vars, { __index = getfenv(func), __newindex = getfenv(func) })
	end
	
	--NB: Do not read or write the vars table anymore else the metatable functions will get invoked!
	
	--}}}
	
	local file = getinfo(lvl, "source")
	if string.find(file, "@") == 1 then
	file = string.sub(file, 2)
	end
	if IsWindows then file = string.lower(file) end
	
	if not line then
	line = getinfo(lvl, "currentline")
	end
	
	return vars,file,line	
end

--[[ 
	Returns the list of argument names defined for the provided function.
]]-- 
function debug.getparams(f)
	local res = pcall(function () coroutine.create(f) end)
	if (res == false) then
		return nil
	end
		
	local co = coroutine.create(f)
	local params = {}
	debug.sethook(co, function()
		local i,k=1, debug.getlocal(co,2,1)
		while k do
			if (k ~= "(*temporary)") then
				table.insert(params,k)
			end
			i= i+1;
			k=debug.getlocal(co,2,i)
		end		
		error("~~end~~")
	end, "c")
	local res, err = coroutine.resume(co)
	if res then
		error("The function provided defies the laws of the universe.", 2)
	elseif (string.sub(tostring(err), -7) ~= "~~end~~") then
		error("The function failed with the error: " .. tostring(err), 2)
	end
	return params
end
