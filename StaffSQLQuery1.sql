CREATE PROC StaffAdd
@StaffID int,
@FirstName varchar(50),
@LastName varchar(50),
@ADD1 varchar(50),
@ADD2 varchar(50),
@ADD3 varchar(50),
@ADD4 varchar(50),
@NIC varchar(50),
@Mobile int,
@Land int,
@Email varchar(50),
@Title varchar(10),
@Posision varchar(50),
@Note varchar(250),
@Gender varchar(10),
@Password varchar(50)
AS
	INSERT INTO tblStaff(StaffID,FirstName,LastName,ADD1,ADD2,ADD3,ADD4,NIC,Mobile,Land,Email,Title,Posision,Note,Gender,Password)
	VALUES (@StaffID,@FirstName,@LastName,@ADD1,@ADD2,@ADD3,@ADD4,@NIC,@Mobile,@Land,@Email,@Title,@Posision,@Note,@Gender,@Password)