-- =============================================
-- Author:		Ing. Daniel Bojorge
-- Create date: 23/03/2014
-- Description:	Devuelve todos los registros de Customer
--
-- =============================================
CREATE PROCEDURE [dbo].[Customer_Get]
	@CustomerId integer = null
AS
BEGIN
	IF @CustomerId IS NULL
	BEGIN
		--Devolver todos los registros
		Select *
			From SalesLT.Customer
	END
	ELSE
	BEGIN
		SELECT *
			FROM SalesLT.Customer
			WHERE CustomerID = @CustomerId
	END
END
