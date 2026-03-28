CREATE PROCEDURE AgregarProducto

	        @Id AS uniqueidentifier
           ,@IdSubCategoria AS uniqueidentifier
           ,@Nombre AS varchar(max)
           ,@Descripcion AS varchar(max)
           ,@Precio AS decimal(18,2)
           ,@Stock AS int
           ,@CodigoBarras AS varchar(max)
AS
BEGIN

	SET NOCOUNT ON;

    BEGIN TRANSACTION

	INSERT INTO [dbo].[Producto]
           ([Id]
           ,[IdSubCategoria]
           ,[Nombre]
           ,[Descripcion]
           ,[Precio]
           ,[Stock]
           ,[CodigoBarras])
     VALUES
           (@Id
           ,@IdSubCategoria
           ,@Nombre
           ,@Descripcion
           ,@Precio
           ,@Stock
           ,@CodigoBarras)

    SELECT @Id
    COMMIT TRANSACTION
END