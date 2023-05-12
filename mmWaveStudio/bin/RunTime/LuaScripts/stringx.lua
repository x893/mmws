stringx = {}

--[[
Function Name 	: stringx.remove
Description		: Remove characters in a given string from start_idx to end_idx including (indexes are 1-based)
Input 			: s - the string
				  start_idx - index of char to start the removing from
				  end_idx - index of char to remove until (inc.)
Output  		: the modified string
]]--
function stringx.remove(s, start_idx, end_idx)
	if ((start_idx < 1) or (end_idx > #s)) then
		error("stringx.remove(): given indexes were out of range\n")
	elseif (end_idx < start_idx) then
		error("stringx.remove(): end_idx must be greater than start_idx\n")
	end
	
	local s1 = s:sub(0, start_idx - 1)
	local s2 = s:sub(end_idx + 1, #s)

	return (s1 .. s2)
end

--[[
Function Name 	: stringx.trim
Description		: Remove trailing and leading whitespace from string.
Input 			: s - the string
Output  		: the modified string
]]--
function stringx.trim(s)
  return (s:gsub("^%s*(.-)%s*$", "%1"))
end

--[[
Function Name 	: stringx.ltrim
Description		: Remove leading whitespace from string.
Input 			: s - the string
Output  		: the modified string
]]--
function stringx.ltrim(s)
  return (s:gsub("^%s*", ""))
end

--[[
Function Name 	: stringx.rtrim
Description		: Remove trailing whitespace from string.
Input 			: s - the string
Output  		: the modified string
]]--
function stringx.rtrim(s)
  local n = #s
  while n > 0 and s:find("^%s", n) do n = n - 1 end
  return s:sub(1, n)
end

--[[
Function Name 	: split
Description		: splits a text according to given seperator
Input			: text - a text line 
				  sep - the seperator (supports regular expressions)
				  plain (bool) - if true, turns off regular expressions support (optional, defaults to false)
				  ignore_empty - if true, will not include empty results
Output  		: A new table containing all the split sub-texts
Example 		: t = utils.split(line, "	", false)
]]--
function stringx.split(text, sep, plain, ignore_empty)
	plain = plain or false
	ignore_empty = ignore_empty or false
	return utils.split(text, sep, plain, ignore_empty)
end

--[[
Function Name 	: stringx.starts
Description		: Checks if a string starts with another string
Input 			: s - the entire string
				  start_s - the starting string
Output  		: true/false
]]--
function stringx.starts(s,start_s)
   return string.sub(s,1,string.len(start_s))==start_s
end

--[[
Function Name 	: stringx.ends
Description		: Checks if a string ends with another string
Input 			: s - the entire string
				  end_s - the ending string
Output  		: true/false
]]--
function stringx.ends(s,end_s)
   return end_s=='' or string.sub(s,-string.len(end_s))==end_s
end

--[[
Function Name 	: stringx.last_of
Description		: Returnes position of the last occurance a sub-string in a string
Input 			: s - the entire string
				  sub - the sbu-string to search for
Output  		: Start index of the last occurance of sub-string
]]--
function stringx.last_of(text, sub)
	local search_pos=1
    local res
	while true do
		local match_start, match_end=string.find(text, sub, search_pos, true)
        if match_start and match_end >= match_start then
			res = match_start
			search_pos=match_end+1            
		else            
			break
		end
	end
	return res
end
