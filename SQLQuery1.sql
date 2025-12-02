CREATE PROCEDURE SP_ListarCategorias
AS
BEGIN
    SET NOCOUNT ON;

    SELECT IdCategoria, Nombre
    FROM Categorias
    WHERE Activo = 1
    ORDER BY Nombre;
END;
GO
