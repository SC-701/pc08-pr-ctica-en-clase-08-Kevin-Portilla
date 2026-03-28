CREATE PROCEDURE ObtenerCategorias
AS
BEGIN
	SELECT Id, Nombre
FROM Categorias
END