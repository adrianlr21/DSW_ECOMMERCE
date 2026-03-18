create database DSW_Ecommerce
use DSW_Ecommerce


create table Categoria(
IdCategoria int primary key identity,
Nombre varchar(50),
FechaCreacion datetime default getdate()
)
select*from Categoria
insert into Categoria(Nombre) values
('Prueba')



create table Producto(
IdProducto int primary key identity,
Nombre varchar(50),
Descripcion varchar(1000),
IdCategoria int references Categoria(IdCategoria),
Precio decimal(10,2),
PrecioOferta decimal(10,2),
Cantidad int,
Imagen varchar(max),
FechaCreacion datetime default getdate()
)
select*from Producto



create table Usuario(
IdUsuario int primary key identity,
NombreCompleto varchar(50),
Correo varchar(50),
Clave varchar(50),
Rol varchar(50),
FechaCreacion datetime default getdate()
)
select*from Usuario
insert into Usuario(NombreCompleto,Correo,Clave,Rol) values
('administrador','admin@example.com','123','Administrador')



create table Venta(
IdVenta int primary key identity,
IdUsuario int references Usuario(IdUsuario),
Total decimal(10,2),
FechaCreacion datetime default getdate()
)
select*from Venta



create table DetalleVenta(
IdDetalleVenta int primary key identity,
IdVenta int references Venta(IdVenta),
IdProducto int references Producto(IdProducto),
Cantidad int,
Total decimal(10,2)
)
select*from DetalleVenta



