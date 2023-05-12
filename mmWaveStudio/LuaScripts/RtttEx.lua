--------------------------------------------------------------------------------------------------------------------------------
--[[						RtttEx.lua 								                      	
		Goal -   Extended Functions for RTTT
--]]
--------------------------------------------------------------------------------------------------------------------------------

require "CsvHandler"

--[[Package Declaratrion]]--
local P  = {}
RtttEx   = P 
RTTTEX   = RtttEx

local CsvHandler = CsvHandler
local RTTT       = RTTT
local ipairs     = ipairs

--no more external access after this point
setfenv(1, P)

VarDisplayType = {DEFAULT = 0, DECIMAL = 1, DECIMAL_SIGNED = 2, INTEGER = 3, HEX = 4, BINARY = 5, DB10 = 6, DB20 = 7, MIXED = 8}

--[[-----------------------------------------------------------------------------------------------------------------------------------------------]]

--[[Functions Declaratrion]]--

--[[
	function ConstructCsv()
		- Construct a csv matrix  from RTTT	Folder
		-  params -
			1. matrix (O) - a matrix to hold the data
			2. node_path (I) - the RTTT folder node
			3. display_type (I) - the display type to write the values in.
--]]	
local function ConstructMatrix(matrix, node_path, var_display_type) 
     local t   = {};
	 local row = {};	
	 
	 -- header
	 row[#row+1] = "Path" .. "," .. "Name" .. "," .. "Value"
	 matrix[#matrix+1] = row
	 row = {}
     
	 -- nodes
     t = RTTT.GetFolder(node_path);	 

	  for key,value in ipairs(t) do 
	    row[#row+1] = node_path .. "/" .. value .. "," .. value .."," ..  RTTT.GetVarDisplay(node_path .. "/" .. value , var_display_type)
	    matrix[#matrix+1] = row
		row = {}
	  end
end


--[[
	function ExportToCsv() 	
		- Exports an RTTT folder to CSV file
		- params
			1. node_path (I) - The RTTT folder node
			2. file_name (I) - The CSV file path to write to.
			3. display_type (I) - The display type to write the values in.
	Example:
		RtttEx.ExportToCsv("/ApplierExport/Applier Variables/Simple Types", "c:\\lua\\test.csv", RtttEx.VarDisplayType.DECIMAL)
		RtttEx.ExportToCsv("/ApplierExport/Applier Variables/Simple Types", "c:\\lua\\test.csv") -- will save default types
--]]
function ExportToCsv(node_path , file_name, var_display_type)
	local fp 	 = nil; -- ptr to the CSV file
	local matrix = {};
	
	if (var_display_type == nil) then
		var_display_type = VarDisplayType.DEFAULT
	end
	
	ConstructMatrix (matrix, node_path, var_display_type);
	CsvHandler.WriteCsv(file_name, matrix)
end;

--[[
	function AddModulesPath() 	
		- Adds a path contianing modules to the package.path variable to be able to use the modules inside.
		- parama
			modules_path (I) - The full path containing the modules
	Example:
		RtttEx.AddModulesPath("c:\\lua\\modules")
--]]
function AddModulesPath(modules_path)
	if (string.find(package.path, modules_path .. "\\%?%.lua") == nil) then
		package.path = string.format("%s;%s\\?.lua", package.path, modules_path)
	end
end
