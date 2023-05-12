-------------------------------------------------------------------------------------------------------------------------------
--[[Functions Declaratrion]]--
--[[
	function shellprint()	
		printing in lua shell
--]]

shellprint = function(...)

	local f,t = ipairs(arg)
	local s = ""
	
	for i=1, t.n do
		if (t[i] == nil) then
			s = s.. "nil"
		else
		s = s .. tostring(t[i])
		end
		
		--if (i ~= #arg) then
		if (i ~= t.n) then
			s = s .. "\t"
		end
	end
	
	s = s .. "\n"
	return s
end

--[[
	function tableshellprint()	
		printing table's keys and values
--]]
tableshellprint = function(t)
	local s = ""
	
	for k,v in pairs(t) do
		s = s .. k .. "\t" .. v .. "\n"
	end	
	
	return s
end


--[[
	function print()	
		redirect the print function to print to RTTT output window
--]]

print = function(...)

	local f,t = ipairs(arg)
	
	for i=1, t.n do
		if (t[i] == nil) then
			RTTT.Message("nil")
		else
			RTTT.Message(tostring(t[i]))
		end
		
		--if (i ~= #arg) then
		if (i ~= t.n) then
			RTTT.Message("\t")
		end
	end
	
	RTTT.Message("\n")
end

--[[
	function printf()	
		imitate c printf
		param - 
			1. s - list of params to format		
--]]

function printf(...) 	
	print(string.format(...))       
end

--[[
	function MakeTableString()
		Concat all TableDefinedInDotNet members a string
		Seperated by space 		
--]]


function MakeTableString()
    strTable = "";
	for aKey, aValue in pairs( TableDefinedInDotNet ) do  strTable = strTable .. ' ' .. aKey end	
	return strTable;	
end

--[[
	function MakeTableTypeMembersString(typeToFindInTable)
		Concat all TableDefinedInDotNet members a string
		Seperated by space and have the type typeToFindInTable	
		param - 
			1. typeToFindInTable - the type of the member in the the table
			   need to be count 
--]]


function MakeTableTypeMembersString(typeToFindInTable)	
    strTable = "";
    for aKey, aValue in pairs( TableDefinedInDotNet ) do 
		if type( rawget( TableDefinedInDotNet, aKey ) ) == typeToFindInTable then
			 strTable = strTable .. ' ' .. aKey 
		end 
	end;	
	return strTable;	
end
