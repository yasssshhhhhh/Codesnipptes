--use EmployeeDB
--select * from Users where User_id = 'Yash' and Password = 'NotPass123'
--"select * from Users where User_id = '{0}' and Password = '{1}'",User_id, Password

alter procedure Userslist @User_id 
as
begin
	select * from Users where User_id = 'Yash' and Password = 'NotPass123'
end;

--exec Userslist
use Db1
exec sp_configure 'external scripts enabled',1;
reconfigure with override;

Execute sp_execute_external_script
@language = N'python',
@script = N'print("hello World")'


Execute sp_execute_external_script
@language = N'python',
@script = N'print("hello world")
print(InputdataSet.User_id)
print(InputdataSet.Password)',
@input_data_1 = N'select * from Users;'

EXECUTE sp_execute_external_script @language = N'Python'
    , @script = N'OutputDataSet = InputDataSet;'
    , @input_data_1 = N'SELECT * FROM PythonTestData;'
WITH RESULT SETS(([NewColName] INT NOT NULL));


--To read contents of a file
EXECUTE sp_execute_external_script @language = N'Python'
    , @script ='hellofile = open("C:\\Users\\yash\\repos\\hello.txt")
	hellocontent = hellofile.read()
	print(hellocontent)'