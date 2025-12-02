SELECT TOP (1000) [IdCategoria]
      ,[Nombre]
      ,[Descripcion]
      ,[Activo]
  FROM [PanaderiaDB].[dbo].[Categorias]


  
INSERT INTO Categorias (Nombre, Descripcion, Activo)
VALUES 
('Postres', 'Categoría de postres dulces', 1),
('Panes', 'Categoría de panes variados', 1),
('Salados', 'Categoría de productos salados', 1),
('Bebidas', 'Categoría de bebidas frías y calientes', 1);
