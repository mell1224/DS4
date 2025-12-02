
ALTER PROCEDURE SP_ListarProductos
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        p.IdProducto,
        p.IdCategoria,
        c.Nombre AS Categoria, -- ✅ Cambiado aquí
        p.Nombre,
        p.Descripcion,
        p.PrecioVenta,
        p.ImagenURL,
        p.Stock,
        p.Activo
    FROM Productos p
    JOIN Categorias c ON p.IdCategoria = c.IdCategoria
    ORDER BY p.Nombre;
END;
