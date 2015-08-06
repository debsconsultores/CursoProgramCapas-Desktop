-- =============================================
-- Author:		Ing. Daniel Bojorge
-- Create date: 23/03/2014
-- Description:	Grabar registros en Customer
--
-- =============================================
ALTER PROCEDURE [dbo].[Customer_Del]
	@CustomerId integer
AS
BEGIN
	BEGIN TRAN
	BEGIN TRY
		DELETE FROM SalesLT.Customer WHERE CustomerID = @CustomerId;
		COMMIT
	END TRY
	BEGIN CATCH
		ROLLBACK
	END CATCH
END
