# AFTask

Steps to execute the program through Hadoop HDFS
1.Open Hadoop Command line and Create a folder named AFTask in the "Input" directory of Hadoop using the hadoop command 'hadoop fs -mkdir Input/AFTask'.
If Input directory is not present create the Input directory using the same command 'hadoop fs -mkdir Directoryname'.

2.Copy the csv files Practices.csv(T201202ADD_REXT.CSV) and Prescriptions.csv(T201109PDP_IEXT.CSV) files to the Input/AFTask folder using the command
'hadoop fs -copyFromLocal C:\Practices.csv Input/AFTask''

3.Run the DataAnalysis.exe file which is present in the debug folder

4.After the file is executed the results will be stored in the Output folder.The Practices result can be found in Output/AFTaskPractices, 
Prescriptions result can be found in Output/AFTaskPrescriptions and the Total Cost result can be found in Output/AFTaskTotalCost

6.The results for number of practices can be seen by excuting the Hadoop Command 'hadoop fs -cat Output/AFTaskPractices/part-00000' 
in the hadoop command line and similary other results can be seen.

PS: Hadoop Emulator should be available for executing the hadoop tasks