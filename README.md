# AFTask

CI : [![Build status](https://ci.appveyor.com/api/projects/status/lhc9167efjh6stws?svg=true)](https://ci.appveyor.com/project/rpavankumar-reddy/aftask)
CodeCoverage: [![codecov](https://codecov.io/gh/rpavankumar-reddy/AFTask/branch/master/graph/badge.svg)](https://codecov.io/gh/rpavankumar-reddy/AFTask)



Steps to execute the program through Hadoop HDFS

1.Open Hadoop Command line and Create a folder named AFTask in the "Input" directory of Hadoop using the hadoop command 'hadoop fs -mkdir Input/AFTask'.
If Input directory is not present create the Input directory using the same command 'hadoop fs -mkdir Directoryname'.

2.Copy the csv files Practices.csv(T201202ADD_REXT.CSV) and Prescriptions.csv(T201109PDP_IEXT.CSV) files to the Input/AFTask folder using the command
'hadoop fs -copyFromLocal C:\Practices.csv Input/AFTask''

3.Run the DataAnalysis.exe file which is present in the debug folder

4.After the file is executed the results will be stored in the Output folder.The Practices result can be found in Output/AFTask/Practices, 
Prescriptions result can be found in Output/AFTask/Prescriptions and the Total Cost result can be found in Output/AFTask/TotalCost

5.The results for number of practices can be seen by excuting the Hadoop Command 'hadoop fs -cat Output/AFTask/Practices/part-00000' 
in the hadoop command line and similary other results can be seen.

PS: Hadoop Emulator should be available in the local system for executing the hadoop tasks