CREATE PROCEDURE ObtenerSubCategorias 
	@IdCategoria uniqueidentifier
AS
BEGIN
	SELECT Id, Nombre
FROM SubCategorias
WHERE (IdCategoria = @IdCategoria)
END