-- =============================================
-- Author:		Ing. Daniel Bojorge
-- Create date: 23/03/2014
-- Description:	Grabar registros en Customer
--
-- =============================================
CREATE PROCEDURE [dbo].[Customer_Set]
	@CustomerId integer = null output,
	@NameStyle bit = 0,
	@Title nvarchar(8) = null,
	@FirstName nvarchar(50),
	@MiddleName nvarchar(50)=null,
	@LastName nvarchar(50),
	@Suffix nvarchar(10)=null,
	@CompanyName nvarchar(128)=null,
	@SalesPerson nvarchar(256) = null,
	@EmailAddress nvarchar(50)= null,
	@Phone nvarchar(25)=null,
	@PasswordHash nvarchar(128),
	@PasswordSalt nvarchar(10)
AS
BEGIN
	/*Iniciamos Revisando si el registro ya existe*/
	Declare @Nuevo bit = 0;
	Declare @IdTmp int;
	
	IF @CustomerId is not null
	BEGIN
		Select @IdTmp=CustomerId 
			from SalesLT.Customer
			Where CustomerID = @CustomerId ;
		
		IF @IdTmp is null
			Set @Nuevo = 1;
	END
	
	BEGIN TRAN
	BEGIN TRY
	IF @Nuevo = 1  --Registro es nuevo
	BEGIN
		Insert into SalesLT.Customer
			(NameStyle,Title,FirstName,MiddleName,LastName,Suffix,
			CompanyName,SalesPerson,EmailAddress,Phone,
			PasswordHash,PasswordSalt)
			values 
			(@NameStyle,@Title,@FirstName,@MiddleName,@LastName,@Suffix,
			@CompanyName,@SalesPerson,@EmailAddress,@Phone,
			@PasswordHash,@PasswordSalt);
			
		Set @CustomerId = @@IDENTITY;
	END
	ELSE
	BEGIN
		UPDATE SalesLT.Customer Set
			NameStyle = @NameStyle,
			Title = @Title,
			FirstName = @FirstName,
			MiddleName = @MiddleName,
			LastName = @LastName,
			Suffix = @Suffix,
			CompanyName = @CompanyName,
			SalesPerson = @SalesPerson,
			EmailAddress = @EmailAddress,
			Phone = @Phone,
			PasswordHash = @PasswordHash,
			PasswordSalt = @PasswordSalt,
			ModifiedDate = GETDATE()
		WHERE CustomerID = @CustomerId
			
	END
		COMMIT
	END TRY
	BEGIN CATCH
		ROLLBACK
	END CATCH
END