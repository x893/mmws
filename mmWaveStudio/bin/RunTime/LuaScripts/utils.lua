--------------------------------------------------------------------------------------------------------------------------------
--[[			utils.lua 								                      	
		Goal - Genaral utility functions
--]]
--------------------------------------------------------------------------------------------------------------------------------

-------------------------[[Module Declaratrion]]-------------------------
utils = utils or {}

-------------------------------[[Private]]-------------------------------


-------------------------------[[Public]]--------------------------------

--[[
Function Name 	: deepcopy
Description		: This function returns a deep copy of a given table. The function below also copies the metatable 
				  to the new table if there is one, so the behaviour of the copied table is the same as the original. 
				  But the 2 tables share the same metatable, you can avoid this by changing this 'getmetatable(object)' 
				  to '_copy( getmetatable(object) )'. 
Input 			: A table
Output  		: A new table which is a deep copy of the given table.
Example 		: t2 = deepcopy(t1)
]]--
function utils.deepcopy(object)
    local lookup_table = {}
    local function _copy(object)
        if type(object) ~= "table" then
            return object
        elseif lookup_table[object] then
            return lookup_table[object]
        end
        local new_table = {}
        lookup_table[object] = new_table
        for index, value in pairs(object) do
            new_table[_copy(index)] = _copy(value)
        end
        return setmetatable(new_table, getmetatable(object))
    end
    return _copy(object)
end

--[[
Function Name 	: split
Description		: splits a text according to given seperator
Input			: text - a text line 
				  sep - the seperator (supports regular expressions)
				  plain (bool) - if true, turns off regular expressions support
Output  		: A new table containing all the split sub-texts
Example 		: t = utils.split(line, "	", false)
]]--
function utils.split(text, sep, plain, ignore_empty)
	local res={}
	local searchPos=1
	local part=""
	while true do
		local matchStart, matchEnd=string.find(text, sep, searchPos, plain)
		if matchStart and matchEnd >= matchStart then
			part = string.sub(text, searchPos, matchStart-1)
			if (not (ignore_empty and utils.IsAllWhiteSapce(part))) then
				-- insert string up to separator into result
				table.insert(res, part)
			end

			-- continue search after separator
			searchPos=matchEnd+1
		else
			part = string.sub(text, searchPos)
			if (not (ignore_empty and utils.IsAllWhiteSapce(part))) then
				-- insert whole reminder as result
				table.insert(res, part)
			end
			break
		end
	end
	return res
end

--[[
Function Name 	: SplitVectorFile
Description		: Takes a BinarySplitter vector output file and Creates files for each given offset, containing the vector[offset] samples.
Input			: file_name - the BinarySplitter vector file name;	
				  offsets - a table containting all the required offsets.
Output  		: A file containing the samples of each vector[offset]
Example 		: utils.SplitVectorFile("C:\\03\\Buffer_Out[0]__SymbolsFFT__sign_imag.txt" , {3,25})
]]--
function utils.SplitVectorFile(file_name, offsets)

	--[[Open file and read data to lua table]]--
	vector_data = {}
	vector_data_row = {}

	local count = 1
	for line in io.lines(file_name) do 
		vector_data_row = utils.split(line, "	", false)
		table.insert(vector_data, vector_data_row)
		count = count + 1
	end

	--[[Print relevant data to output file]]--
	for offset_idx = 1, table.getn(offsets)	do 
		output_file = string.gsub(file_name , ".txt",  "_" .. tostring(offsets[offset_idx]) .. ".txt")

		fpo = io.open(output_file,"w") 

		if (fpo == nil) 	then
			print("Can't open output file\n")
			return
		end
		
		for i = 1, table.getn(vector_data) do 
			fpo:write(vector_data[i][offsets[offset_idx] + 1], "\n") 
		end
		
		fpo:close()
	end
end

function utils.IsCharWhiteSpace(ch)
	local w = {0x20, 0x09, 0x0a, 0x0b, 0x0c, 0x0d} -- space, tab, newline, vertical tab, feed, carriage return
	
	for j=1,#w do
		if (string.byte(ch) == w[j]) then
			return true
		end
	end
	
	return false
end

function utils.IsAllWhiteSapce(str)
	if (str == "") then
		return true
	end
	
	for i=1,#str do
		if (not utils.IsCharWhiteSpace(str:sub(i,i))) then
			return false
		end
	end
	
	return true
end
