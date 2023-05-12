INTERNAL_SCRIPTS_PATH = RSTD.GetApplicationDir() .. "\\LuaScripts\\"
MODULES_PATH = RSTD.GetApplicationDir() .. "\\..\\Clients\\LuaModules\\"
SCRIPTS_PATH = RSTD.GetApplicationDir() .. "\\..\\Scripts\\"

-- Add path for packages (for the require function)
package.path = package.path .. ";" .. INTERNAL_SCRIPTS_PATH .. "?.lua" .. ";" .. MODULES_PATH .. "LuaSocket\\?.lua"
package.cpath = package.cpath .. ";" .. MODULES_PATH .. "?.dll" .. ";" .. MODULES_PATH .. "LuaSocket\\?.dll"

-- Load the RSTDEx package
require 'RTTTEx'
require 'utils'
require 'stringx'

dofile(INTERNAL_SCRIPTS_PATH .. 'convertions.lua')
dofile(INTERNAL_SCRIPTS_PATH .. 'General.lua')

if (CheckFilePath(MODULES_PATH .. "LuaSocket\\socket.lua") == true) then
	require 'socket'
end

if (CheckFilePath(MODULES_PATH .. "bit.dll") == true) then
	require 'bit'
end
