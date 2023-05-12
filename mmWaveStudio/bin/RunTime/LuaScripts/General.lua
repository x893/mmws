--[[
<name> write2csv
<desc> Write values from a 2-d table to csv format
<in>
<t> matrix - 2-d array (i.e. table containting 1-d tables) containing the values
<s> out_file - full file path to write to.
<b> is_append - If we want to appent it to existing file
]]--
function write2csv(matrix, out_file, is_append)
	local fp
	if ((is_append ~= nil) and (is_append == true)) then
		fp = assert(io.open(out_file,"a"))	
	else
		fp = assert(io.open(out_file,"w"))
	end
	
	for row_idx=1,table.getn(matrix) do
		local line = matrix[row_idx]
		for i=1,table.getn(line) do
			line_str = tostring(line[i])
			if string.find(line_str, "\n") or string.find(line_str, ",") then
				fp:write("\"" .. line_str .. "\"" .. ",")
			else
				fp:write(line_str .. ",")
			end
		end
		fp:write("\n")
	end
	
	fp:close()
end

--[[
Function Name 	: table.print
Description		: Prints a table to output
Input 			: a table
Output 			: nil
]]--
function table.print(t)
	table.foreach(t, print)
end

--[[
Function Name 	: os.capture
Description		: Executes a shell command and returns its output as string.
Input 			: cmd - the command to execute.
Output 			: The command's output as string.
]]--
function os.capture(cmd)
  local f = assert(io.popen(cmd, 'r'))
  local s = assert(f:read('*a'))
  f:close()
  return s
end

--[[
<name> CheckFilePath
<desc> Check if a given path points to a file
<in>
<s> file_path - full file path
<out>
<b> res - true - path is a file, else false.
]]--
function CheckFilePath(file_path)
	local f=io.open(file_path,"r")
	if (f~=nil) then 
		io.close(f)
		return true
	else 
		return false 
	end
end 

--[[
<name> log
<desc> logs the message to output (and log file). displays it in the requested color.
<in>
<s> message - the message to log
<s> color - the color to use (e.g. "blue", "green", "purple", etc.)
]]--
function log(message, color)
	if (message ~= nil) then
		if (not stringx.ends(message, "\n")) then
			message = message .. "\n"
		end
	end	

	if (color == nil) then
		RSTD.Message(message)
	else
		RSTD.Log(message, color)
	end	
end

--[[
<name> CurrentScriptPath
<desc> Gets the full path of the Lua script which called this function
<in>
<b> get_folder - (optional) true - returns only the folder path; false - returns full path. default is false
]]--
function CurrentScriptPath(get_folder)
	local get_folder = get_folder or false
	local t=debug.getinfo(2,"S")
	local path = stringx.remove(t["source"], 1, 1)
	if (get_folder == true) then 
		return path:match("(.*\\)")
	else
		return path	
	end
end

--[[
<name> find
<desc> Shows where a function is defined (file and line)
<in>
<f> func - The function to locate
]]--
function find(func)
    local res = nil
    local file
    local line
    
    if (type(func) == "function") then
        file = debug.getinfo(func,"S").source
        
        if (file == "=[C]") then
            res = "That function is exported from code"
            return
        end
        
        if (stringx.starts(file,"@")) then
            file = stringx.remove(file,1,1)
        end
        line = debug.getinfo(func,"S").linedefined
        res = string.format("file \"%s\" line %d", file, line)
    elseif (type(func) == "userdata") then
        res = "That function is exported from code"
    elseif (type(func) == "table") then
        res = "That is a table"
    elseif (type(func) == "number") then
        res = "That is a number"
    elseif (type(func) == "string") then
        res = "That is a string"
    else
        res = "That function is not defined"
    end
    
    return res
end

local function look_for_func(name, func)
	local s_name = string.lower(name)
	if(string.find(s_name,_NAME) ~= nil) then 
		if (type(func) == "function") then
			file = debug.getinfo(func,"S").source
			if (stringx.starts(file,"@")) then
					file = stringx.remove(file,1,1)
			end

			res = string.format("name \"%s\" file %s", name, file)
			table.insert(_TB, res)
		end
	end
end
--[[
<name> lookfor
<desc> Looks for functions with common part of names and shows its location (name and file)
<in> part of name - string
]]--
function lookfor(name)
_NAME = string.lower(name)
_TB = {}
table.foreach(_G, look_for_func)
table.foreach(_TB, print)
end