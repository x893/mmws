--------------------------------------------------------------------------------------------------------------------------------
--[[						Csv_Handler.lua 								                      	
		Goal -   Read and write value from and to a csv file
--]]
--------------------------------------------------------------------------------------------------------------------------------

--[[Package Declaratrion]]--
local P    = {}
CsvHandler = P 

local RTTT     = RTTT
local io       = io
local assert   = assert
local ipairs   = ipairs
local tostring = tostring

--no more external access after this point
setfenv(1, P)

--[[-----------------------------------------------------------------------------------------------------------------------------------------------]]

--[[Functions Declaratrion]]--
 

 --[[
	function ReadCsv()
		- Construct a csv matrix  build from the csv's lines
	params - 	
		1. file_name - csv file.		
	return - 
		1. matrix - a matrix containing the data read from the csv file.
--]]	

function ReadCsv (file_name)  
  local fp     = assert(io.open (file_name)) 
  local matrix = {}
  local row    = {}    
  
  for line in fp:lines() do   
    for value in line:gmatch("[^,]*") do 
		if (value ~= "") then
			row[#row+1] = value				
		end
    end
	
    matrix[#matrix+1] = row 	
	row = {}	
  end  
  
  fp:close()    
  return matrix;  
end 

--------------------------------------------------------------------------------------------------------------------------------
--[[
	function WriteCsv()
		- Write a given matrix to a given csv file
	params - 
		1. file_name  - csv file to be construct.		
		2. matrix     - matrix (2D array) contianing data to be written.		
--]]	

function WriteCsv (file_name, matrix) 
  local fp = assert(io.open(file_name,"w+")) 
  for i,row in ipairs(matrix) do 
    for i,value in ipairs(row) do 
      fp:write(tostring(value)..",") 
    end 
    fp:write "\n" 
  end 
  fp:close()
end 

--[[-----------------------------------------------------------------------------------------------------------------------------------------------]]

--[[
Example:
	matrix = ReadCsv ("c:\\00\\read_me.csv");	
	matrix[1][4] = 33;
	matrix[2][4] = 95;	
	WriteCsv("c:\\00\\write_me.csv" , matrix);
]]--
