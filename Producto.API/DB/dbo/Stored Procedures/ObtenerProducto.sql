CREATE PROCEDURE [dbo].[ObtenerProducto]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT  
        p.Id,
        p.Nombre,
        p.Descripcion,
        p.Precio,
        p.Stock,
        p.CodigoBarras,
        c.Nombre AS Categoria,
        sc.Nombre AS SubCategoria
    FROM Producto p
    INNER JOIN SubCategorias sc 
        ON p.IdSubCategoria = sc.Id
    INNER JOIN Categorias c 
        ON sc.IdCategoria = c.Id
    WHERE p.Id = @Id;
END