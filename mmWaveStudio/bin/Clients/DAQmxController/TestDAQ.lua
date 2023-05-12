channel = 0 -- only channel 1 supported
minrange = -10
maxrange = 10
--[[
Input range			ShuntState			Shunt Resistance
5A(0.1R)              2 (0.1)                 0.1     
1A(0.5R)              3 (0.5)                 0.5    
500mA(0.1R)           2 (0.1)                 1    
100mA(0.5R)           3 (0.5)                 0.5    
]]--
shuntState      = 3 
shuntResistance = 0.5


sampleRate   = 50000
numOfSamples = 50000

daqmx.SetChannel(channel, maxrange, minrange)
daqmx.SetShunt(channel, shuntState, shuntResistance)
-- daqmx.Calibrate(channel, sampleRate)
avg, maxi, mini = daqmx.Measure(channel, sampleRate, numOfSamples)
RTTT.Message("Avg = " .. avg .. "\n")
RTTT.Message("Max = " .. maxi .. "\n")
RTTT.Message("Min = " .. mini .. "\n")