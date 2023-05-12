--[[
Function Name 	: dec2hex
Description		: Convert deciaml to hex
Input 			: decimal value (number or string)
Output  		: value in hex (string)
]]--
function dec2hex(value)
	if type(value) == "string" then
		value = tonumber(value);
	end
	local hex_val = string.format("0x%X", value);
	return hex_val;
end

--[[
Function Name 	: hex2dec
Description		: Convert hex to decimal
Input 			: hex value (Input must be prefixed with 0x, can be number or string)
Output  		: value in decimal (number)
]]--
function hex2dec(value)
	value = tonumber(value, 10);
	return value
end

--[[
Function Name 	: bin2dec
Description		: Convert binary to decimal
Input 			: binary value (number or string)
Output  		: value in decimal (number)
]]--
function bin2dec(bin_val)
	local dec_val = 0
	local bin_str = tostring(bin_val)
	bin_str = string.reverse(bin_str)
	
	for i=1, #bin_str do
		local bit = bin_str:sub(i,i)
		
		if ((bit ~= '0') and (bit ~= '1')) then
			error(string.format("bin2dec: '%s' isn't a binary format", bin_val))
		end
		
		dec_val = dec_val + (bit * math.pow(2,i-1))
	end
	
	return dec_val
end

--[[
Function Name 	: bin2hex
Description		: Convert binary to hex
Input 			: binary value (number or string)
Output  		: value in hex (string)
]]--
function bin2hex(bin_val)
	local hex_val = nil
	local dec_val = bin2dec(bin_val)
	
	if (dec_val ~= nil) then
		hex_val = dec2hex(dec_val)
	end
	
	return hex_val
end
