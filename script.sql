USE [master]
GO
/****** Object:  Database [dbventas]    Script Date: 28/02/2023 2:08:56 ******/
CREATE DATABASE [dbventas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbventas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\dbventas.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'dbventas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\dbventas_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [dbventas] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbventas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbventas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbventas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbventas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbventas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbventas] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbventas] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [dbventas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbventas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbventas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbventas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbventas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbventas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbventas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbventas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbventas] SET  ENABLE_BROKER 
GO
ALTER DATABASE [dbventas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbventas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbventas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbventas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbventas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbventas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbventas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbventas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbventas] SET  MULTI_USER 
GO
ALTER DATABASE [dbventas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbventas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbventas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbventas] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [dbventas] SET DELAYED_DURABILITY = DISABLED 
GO
USE [dbventas]
GO
/****** Object:  Table [dbo].[articulo]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[articulo](
	[idarticulo] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](1024) NULL,
	[imagen] [image] NULL,
	[idcategoria] [int] NOT NULL,
	[idpresentacion] [int] NOT NULL,
 CONSTRAINT [PK_articulo] PRIMARY KEY CLUSTERED 
(
	[idarticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[categoria](
	[idcategoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](256) NULL,
 CONSTRAINT [PK_categoria] PRIMARY KEY CLUSTERED 
(
	[idcategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cliente](
	[idcliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellidos] [varchar](40) NULL,
	[sexo] [varchar](1) NULL,
	[fecha_nacimiento] [date] NULL,
	[tipo_documento] [varchar](20) NOT NULL,
	[num_documento] [varchar](11) NOT NULL,
	[direccion] [varchar](100) NULL,
	[telefono] [varchar](10) NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[idcliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[detalle_ingreso]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_ingreso](
	[iddetalle_ingreso] [int] IDENTITY(1,1) NOT NULL,
	[idingreso] [int] NOT NULL,
	[idarticulo] [int] NOT NULL,
	[precio_compra] [money] NOT NULL,
	[precio_venta] [money] NOT NULL,
	[stock_inicial] [int] NOT NULL,
	[stock_actual] [int] NOT NULL,
	[fecha_produccion] [date] NOT NULL,
	[fecha_vencimiento] [date] NOT NULL,
 CONSTRAINT [PK_detalle_ingreso] PRIMARY KEY CLUSTERED 
(
	[iddetalle_ingreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[detalle_venta]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_venta](
	[iddetalle_venta] [int] IDENTITY(1,1) NOT NULL,
	[idventa] [int] NOT NULL,
	[iddetalle_ingreso] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio_venta] [money] NOT NULL,
	[descuento] [money] NOT NULL,
 CONSTRAINT [PK_detalle_venta] PRIMARY KEY CLUSTERED 
(
	[iddetalle_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ingreso]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ingreso](
	[idingreso] [int] IDENTITY(1,1) NOT NULL,
	[idtrabajador] [int] NOT NULL,
	[idproveedor] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo_comprobante] [varchar](20) NOT NULL,
	[serie] [varchar](4) NOT NULL,
	[correlativo] [varchar](7) NOT NULL,
	[igv] [decimal](4, 2) NOT NULL,
	[estado] [varchar](7) NOT NULL,
 CONSTRAINT [PK_ingreso] PRIMARY KEY CLUSTERED 
(
	[idingreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[presentacion]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[presentacion](
	[idpresentacion] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](256) NULL,
 CONSTRAINT [PK_presentacion] PRIMARY KEY CLUSTERED 
(
	[idpresentacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[proveedor](
	[idproveedor] [int] IDENTITY(1,1) NOT NULL,
	[razon_social] [varchar](150) NOT NULL,
	[sector_comercial] [varchar](50) NOT NULL,
	[tipo_documento] [varchar](20) NOT NULL,
	[num_documento] [varchar](11) NOT NULL,
	[direccion] [varchar](100) NULL,
	[telefono] [varchar](10) NULL,
	[email] [varchar](50) NULL,
	[url] [varchar](100) NULL,
 CONSTRAINT [PK_proveedor] PRIMARY KEY CLUSTERED 
(
	[idproveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[trabajador]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[trabajador](
	[idtrabajador] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[apellidos] [varchar](40) NOT NULL,
	[sexo] [varchar](1) NOT NULL,
	[fecha_nac] [date] NOT NULL,
	[num_documento] [varchar](8) NOT NULL,
	[direccion] [varchar](100) NULL,
	[telefono] [varchar](10) NULL,
	[email] [varchar](50) NULL,
	[acceso] [varchar](20) NOT NULL,
	[usuario] [varchar](20) NOT NULL,
	[password] [varchar](20) NOT NULL,
 CONSTRAINT [PK_trabajador] PRIMARY KEY CLUSTERED 
(
	[idtrabajador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[venta]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[venta](
	[idventa] [int] IDENTITY(1,1) NOT NULL,
	[idcliente] [int] NOT NULL,
	[idtrabajador] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo_comprobante] [varchar](20) NOT NULL,
	[serie] [varchar](4) NOT NULL,
	[correlativo] [varchar](7) NOT NULL,
	[igv] [decimal](4, 2) NOT NULL,
 CONSTRAINT [PK_venta] PRIMARY KEY CLUSTERED 
(
	[idventa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[articulo]  WITH CHECK ADD  CONSTRAINT [FK_articulo_categoria] FOREIGN KEY([idcategoria])
REFERENCES [dbo].[categoria] ([idcategoria])
GO
ALTER TABLE [dbo].[articulo] CHECK CONSTRAINT [FK_articulo_categoria]
GO
ALTER TABLE [dbo].[articulo]  WITH CHECK ADD  CONSTRAINT [FK_articulo_presentacion] FOREIGN KEY([idpresentacion])
REFERENCES [dbo].[presentacion] ([idpresentacion])
GO
ALTER TABLE [dbo].[articulo] CHECK CONSTRAINT [FK_articulo_presentacion]
GO
ALTER TABLE [dbo].[detalle_ingreso]  WITH CHECK ADD  CONSTRAINT [FK_detalle_ingreso_articulo] FOREIGN KEY([idarticulo])
REFERENCES [dbo].[articulo] ([idarticulo])
GO
ALTER TABLE [dbo].[detalle_ingreso] CHECK CONSTRAINT [FK_detalle_ingreso_articulo]
GO
ALTER TABLE [dbo].[detalle_ingreso]  WITH CHECK ADD  CONSTRAINT [FK_detalle_ingreso_ingreso] FOREIGN KEY([idingreso])
REFERENCES [dbo].[ingreso] ([idingreso])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalle_ingreso] CHECK CONSTRAINT [FK_detalle_ingreso_ingreso]
GO
ALTER TABLE [dbo].[detalle_venta]  WITH CHECK ADD  CONSTRAINT [FK_detalle_venta_detalle_ingreso] FOREIGN KEY([iddetalle_ingreso])
REFERENCES [dbo].[detalle_ingreso] ([iddetalle_ingreso])
GO
ALTER TABLE [dbo].[detalle_venta] CHECK CONSTRAINT [FK_detalle_venta_detalle_ingreso]
GO
ALTER TABLE [dbo].[detalle_venta]  WITH CHECK ADD  CONSTRAINT [FK_detalle_venta_venta] FOREIGN KEY([idventa])
REFERENCES [dbo].[venta] ([idventa])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalle_venta] CHECK CONSTRAINT [FK_detalle_venta_venta]
GO
ALTER TABLE [dbo].[ingreso]  WITH CHECK ADD  CONSTRAINT [FK_ingreso_proveedor] FOREIGN KEY([idproveedor])
REFERENCES [dbo].[proveedor] ([idproveedor])
GO
ALTER TABLE [dbo].[ingreso] CHECK CONSTRAINT [FK_ingreso_proveedor]
GO
ALTER TABLE [dbo].[ingreso]  WITH CHECK ADD  CONSTRAINT [FK_ingreso_trabajador] FOREIGN KEY([idtrabajador])
REFERENCES [dbo].[trabajador] ([idtrabajador])
GO
ALTER TABLE [dbo].[ingreso] CHECK CONSTRAINT [FK_ingreso_trabajador]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [FK_venta_cliente] FOREIGN KEY([idcliente])
REFERENCES [dbo].[cliente] ([idcliente])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [FK_venta_cliente]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [FK_venta_trabajador] FOREIGN KEY([idtrabajador])
REFERENCES [dbo].[trabajador] ([idtrabajador])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [FK_venta_trabajador]
GO
/****** Object:  StoredProcedure [dbo].[prueba]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prueba]
@textobuscar varchar(50)
as
SELECT dbo.articulo.idarticulo, dbo.articulo.codigo, dbo.articulo.nombre,
dbo.articulo.descripcion, dbo.articulo.imagen, dbo.articulo.idcategoria,
dbo.categoria.nombre AS Categoria, dbo.articulo.idpresentacion, 
dbo.presentacion.nombre AS Presentacion
FROM dbo.articulo INNER JOIN dbo.categoria 
ON dbo.articulo.idcategoria = dbo.categoria.idcategoria 
INNER JOIN dbo.presentacion 
ON dbo.articulo.idpresentacion = dbo.presentacion.idpresentacion
where dbo.articulo.nombre like @textobuscar + '%' OR dbo.articulo.codigo like @textobuscar + '%'
order by dbo.articulo.idarticulo desc
GO
/****** Object:  StoredProcedure [dbo].[spanular_ingreso]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spanular_ingreso]
@idingreso int
as
update ingreso set estado='ANULADO'
where idingreso=@idingreso


GO
/****** Object:  StoredProcedure [dbo].[spbuscar_articulo_nombre]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_articulo_nombre]
@textobuscar varchar(50)
as
SELECT dbo.articulo.idarticulo, dbo.articulo.codigo, dbo.articulo.nombre,
dbo.articulo.descripcion, dbo.articulo.imagen, dbo.articulo.idcategoria,
dbo.categoria.nombre AS Categoria, dbo.articulo.idpresentacion, 
dbo.presentacion.nombre AS Presentacion
FROM dbo.articulo INNER JOIN dbo.categoria 
ON dbo.articulo.idcategoria = dbo.categoria.idcategoria 
INNER JOIN dbo.presentacion 
ON dbo.articulo.idpresentacion = dbo.presentacion.idpresentacion
where dbo.articulo.nombre like @textobuscar + '%'
order by dbo.articulo.idarticulo desc


GO
/****** Object:  StoredProcedure [dbo].[spbuscar_categoria]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spbuscar_categoria]
@textobuscar varchar(50)
as
select * from categoria
where nombre like @textobuscar + '%' --Alt +39

GO
/****** Object:  StoredProcedure [dbo].[spbuscar_cliente_apellidos]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_cliente_apellidos]
@textobuscar varchar(50)
as
select * from cliente
where apellidos like @textobuscar + '%'


GO
/****** Object:  StoredProcedure [dbo].[spbuscar_cliente_num_documento]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_cliente_num_documento]
@textobuscar varchar(50)
as
select * from cliente
where num_documento like @textobuscar + '%'


GO
/****** Object:  StoredProcedure [dbo].[spbuscar_ingreso_fecha]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spbuscar_ingreso_fecha]
@textobuscar varchar(50),
@textobuscar2 varchar(50)
as
SELECT ingreso.idingreso,
(trabajador.apellidos +' '+ trabajador.nombre) as Trabajador, 
proveedor.razon_social	as proveedor,
ingreso.fecha, ingreso.tipo_comprobante, 
ingreso.serie, ingreso.correlativo,
ingreso.estado, sum(detalle_ingreso.precio_compra*
detalle_ingreso.stock_inicial) as Total,ingreso.igv as Impuesto
FROM detalle_ingreso INNER JOIN ingreso 
ON detalle_ingreso.idingreso = ingreso.idingreso 
INNER JOIN proveedor 
ON ingreso.idproveedor = proveedor.idproveedor 
INNER JOIN dbo.trabajador 
ON ingreso.idtrabajador = trabajador.idtrabajador
group by
ingreso.idingreso,
trabajador.apellidos +' '+ trabajador.nombre, 
proveedor.razon_social,
ingreso.fecha, ingreso.tipo_comprobante, 
ingreso.serie, ingreso.correlativo,
ingreso.estado,ingreso.igv
having ingreso.fecha>=@textobuscar and ingreso.fecha<=@textobuscar2


GO
/****** Object:  StoredProcedure [dbo].[spbuscar_presentacion_nombre]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_presentacion_nombre]
@textobuscar varchar(50)
as
select * from presentacion
where nombre like @textobuscar + '%' --Alt + 39


GO
/****** Object:  StoredProcedure [dbo].[spbuscar_proveedor_num_documento]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_proveedor_num_documento]
@textobuscar varchar(20)
as
SELECT * FROM proveedor
where num_documento like @textobuscar + '%'


GO
/****** Object:  StoredProcedure [dbo].[spbuscar_proveedor_razon_social]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_proveedor_razon_social]
@textobuscar varchar(50)
as
select * from proveedor
where razon_social like @textobuscar + '%'


GO
/****** Object:  StoredProcedure [dbo].[spbuscar_trabajador_apellidos]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_trabajador_apellidos]
@textobuscar varchar(50)
as
select * from trabajador
where apellidos like @textobuscar +'%'
order by apellidos asc


GO
/****** Object:  StoredProcedure [dbo].[spbuscar_trabajador_num_documento]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_trabajador_num_documento]
@textobuscar varchar(50)
as
select * from trabajador
where num_documento like @textobuscar +'%'
order by apellidos asc


GO
/****** Object:  StoredProcedure [dbo].[spbuscar_venta_fecha]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spbuscar_venta_fecha]
@textobuscar varchar(50),
@textobuscar2 varchar(50)
as
select v.idventa,
(t.apellidos+' '+t.nombre) as Trabajador,
(c.apellidos+' '+c.nombre) as Cliente,
v.fecha,v.tipo_comprobante,v.serie,v.correlativo,
sum((d.cantidad*d.precio_venta)-d.descuento) as Total,v.igv as Impuesto
from detalle_venta d inner join venta v
on d.idventa=v.idventa
inner join cliente c
on v.idcliente=c.idcliente
inner join trabajador t
on v.idtrabajador=t.idtrabajador
group by v.idventa,
(t.apellidos+' '+t.nombre),
(c.apellidos+' '+c.nombre),
v.fecha,v.tipo_comprobante,v.serie,v.correlativo,v.igv
having v.fecha>=@textobuscar and v.fecha<=@textobuscar2


GO
/****** Object:  StoredProcedure [dbo].[spbuscararticulo_venta_codigo]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscararticulo_venta_codigo]
@textobuscar varchar(50)
as
select d.iddetalle_ingreso,a.Codigo,a.Nombre,
c.nombre as Categoria,p.nombre as Presentacion,
d.stock_actual,d.precio_compra,d.precio_venta,
d.fecha_vencimiento
from articulo a inner join categoria c
on a.idcategoria=c.idcategoria
inner join presentacion p
on a.idpresentacion=p.idpresentacion
inner join detalle_ingreso d
on a.idarticulo=d.idarticulo
inner join ingreso i
on d.idingreso=i.idingreso
where a.codigo=@textobuscar
and d.stock_actual>0
and i.estado<>'ANULADO'


GO
/****** Object:  StoredProcedure [dbo].[spbuscararticulo_venta_nombre]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscararticulo_venta_nombre]
@textobuscar varchar(50)
as
select d.iddetalle_ingreso,a.Codigo,a.Nombre,
c.nombre as Categoria,p.nombre as Presentacion,
d.stock_actual,d.precio_compra,d.precio_venta,
d.fecha_vencimiento
from articulo a inner join categoria c
on a.idcategoria=c.idcategoria
inner join presentacion p
on a.idpresentacion=p.idpresentacion
inner join detalle_ingreso d
on a.idarticulo=d.idarticulo
inner join ingreso i
on d.idingreso=i.idingreso
where a.nombre like @textobuscar + '%'
and d.stock_actual>0
and i.estado<>'ANULADO'


GO
/****** Object:  StoredProcedure [dbo].[spdisminuir_stock]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spdisminuir_stock]
@iddetalle_ingreso int,
@cantidad int
as
update detalle_ingreso set stock_actual=stock_actual-@cantidad
where iddetalle_ingreso=@iddetalle_ingreso


GO
/****** Object:  StoredProcedure [dbo].[speditar_articulo]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_articulo]
@idarticulo int,
@codigo varchar(50),
@nombre varchar(50),
@descripcion varchar(1024),
@imagen image,
@idcategoria int,
@idpresentacion int
as
update articulo set codigo=@codigo,nombre=@nombre,descripcion=@descripcion,
imagen=@imagen,idcategoria=@idcategoria,idpresentacion=@idpresentacion
where idarticulo=@idarticulo


GO
/****** Object:  StoredProcedure [dbo].[speditar_categoria]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Procedimiento Editar
create proc [dbo].[speditar_categoria]
@idcategoria int,
@nombre varchar(50),
@descripcion varchar(256)
as
update categoria set nombre=@nombre,
descripcion=@descripcion
where idcategoria=@idcategoria


GO
/****** Object:  StoredProcedure [dbo].[speditar_cliente]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_cliente]
@idcliente int,
@nombre varchar(50),
@apellidos varchar(40),
@sexo varchar(1),
@fecha_nacimiento date,
@tipo_documento varchar(20),
@num_documento varchar(11),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50)
as
update cliente set nombre=@nombre,apellidos=@apellidos,sexo=@sexo,
fecha_nacimiento=@fecha_nacimiento,tipo_documento=@tipo_documento,
num_documento=@num_documento,direccion=@direccion,
telefono=@telefono,email=@email
where idcliente=@idcliente


GO
/****** Object:  StoredProcedure [dbo].[speditar_presentacion]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_presentacion]
@idpresentacion int,
@nombre varchar(50),
@descripcion varchar(256)
as
update presentacion set nombre=@nombre, descripcion=@descripcion
where idpresentacion=@idpresentacion


GO
/****** Object:  StoredProcedure [dbo].[speditar_proveedor]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_proveedor]
@idproveedor int,
@razon_social varchar(150),
@sector_comercial varchar(50),
@tipo_documento varchar(20),
@num_documento varchar(11),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50),
@url varchar(100)
as
update proveedor set razon_social=@razon_social,sector_comercial=@sector_comercial,
tipo_documento=@tipo_documento,num_documento=@num_documento,
direccion=@direccion,telefono=@telefono,email=@email,
url=@url
where idproveedor=@idproveedor


GO
/****** Object:  StoredProcedure [dbo].[speditar_trabajador]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_trabajador]
@idtrabajador int,
@nombre varchar(20),
@apellidos varchar(40),
@sexo varchar(1),
@fecha_nacimiento date,
@num_documento varchar(8),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50),
@acceso varchar(20),
@usuario varchar(20),
@password varchar(20)
as
update trabajador set nombre=@nombre,apellidos=@apellidos,
sexo=@sexo,fecha_nac=@fecha_nacimiento,num_documento=@num_documento,
direccion=@direccion,telefono=@telefono,email=@email,
acceso=@acceso,usuario=@usuario,password=@password
where idtrabajador=@idtrabajador


GO
/****** Object:  StoredProcedure [dbo].[speliminar_articulo]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_articulo]
@idarticulo int
as
delete from articulo
where idarticulo=@idarticulo


GO
/****** Object:  StoredProcedure [dbo].[speliminar_categoria]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Procedimiento Eliminar
create proc [dbo].[speliminar_categoria]
@idcategoria int
as
delete from categoria
where idcategoria=@idcategoria


GO
/****** Object:  StoredProcedure [dbo].[speliminar_cliente]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_cliente]
@idcliente int
as
delete from cliente
where idcliente=@idcliente


GO
/****** Object:  StoredProcedure [dbo].[speliminar_presentacion]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_presentacion]
@idpresentacion int
as
delete from presentacion
where idpresentacion=@idpresentacion


GO
/****** Object:  StoredProcedure [dbo].[speliminar_proveedor]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_proveedor]
@idproveedor int
as
delete from proveedor
where idproveedor=@idproveedor


GO
/****** Object:  StoredProcedure [dbo].[speliminar_trabajador]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_trabajador]
@idtrabajador int
as
delete from trabajador
where idtrabajador=@idtrabajador


GO
/****** Object:  StoredProcedure [dbo].[speliminar_venta]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_venta]
@idventa int
as
delete from venta
where idventa=@idventa


GO
/****** Object:  StoredProcedure [dbo].[spinsertar_articulo]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_articulo]
@idarticulo int output,
@codigo varchar(50),
@nombre varchar(50),
@descripcion varchar(1024),
@imagen image,
@idcategoria int,
@idpresentacion int
as
Begin
Begin Transaction InsertArt
Begin Try 
insert into articulo (codigo,nombre,descripcion,imagen,idcategoria,idpresentacion)
values (@codigo,@nombre,@descripcion,@imagen,@idcategoria,@idpresentacion)

Select SCOPE_IDENTITY()
Commit Transaction InsertArt
End Try

Begin Catch 
Rollback Transaction InsertArt
End Catch
End 




GO
/****** Object:  StoredProcedure [dbo].[spinsertar_categoria]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Procedimiento Insertar
CREATE proc [dbo].[spinsertar_categoria]
@idcategoria int output,
@nombre varchar(50),
@descripcion varchar(256)
as
Begin
Begin Transaction InsertCat
Begin Try 
insert into categoria (nombre,descripcion)
values (@nombre,@descripcion)

Select SCOPE_IDENTITY()
Commit Transaction InsertCat
End Try

Begin Catch 
Rollback Transaction InsertCat
End Catch
End 

GO
/****** Object:  StoredProcedure [dbo].[spinsertar_cliente]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_cliente]
@idcliente int output,
@nombre varchar(50),
@apellidos varchar(40),
@sexo varchar(1),
@fecha_nacimiento date,
@tipo_documento varchar(20),
@num_documento varchar(11),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50)
as 
Begin
Begin Transaction InsertCliente
Begin Try 
insert into cliente (nombre,apellidos,sexo,fecha_nacimiento,
tipo_documento,num_documento,direccion,telefono,email)
values (@nombre,@apellidos,@sexo,@fecha_nacimiento,
@tipo_documento,@num_documento,@direccion,@telefono,@email)

Select SCOPE_IDENTITY()
Commit Transaction InsertCliente
End Try

Begin Catch 
Rollback Transaction InsertCliente
End Catch
End 
GO
/****** Object:  StoredProcedure [dbo].[spinsertar_detalle_ingreso]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_detalle_ingreso]
@iddetalle_ingreso int output,
@idingreso int,
@idarticulo int,
@precio_compra money,
@precio_venta money,
@stock_inicial int,
@stock_actual int,
@fecha_produccion date,
@fecha_vencimiento date
as 
Begin
Begin Transaction InsertDI
Begin Try 
insert into detalle_ingreso (idingreso,idarticulo,precio_compra,
precio_venta,stock_inicial,stock_actual,fecha_produccion,
fecha_vencimiento)
values (@idingreso,@idarticulo,@precio_compra,
@precio_venta,@stock_inicial,@stock_actual,@fecha_produccion,
@fecha_vencimiento)
Select SCOPE_IDENTITY()
Commit Transaction InsertDI
End Try

Begin Catch 
Rollback Transaction InsertDI
End Catch
End 

GO
/****** Object:  StoredProcedure [dbo].[spinsertar_detalle_venta]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_detalle_venta]
@iddetalle_venta int output,
@idventa int,
@iddetalle_ingreso int,
@cantidad int,
@precio_venta money,
@descuento money
as
Begin
Begin Transaction InsertDV
Begin Try 
insert into detalle_venta (idventa,iddetalle_ingreso,cantidad,
precio_venta,descuento)
values (@idventa,@iddetalle_ingreso,@cantidad,
@precio_venta,@descuento)
Select SCOPE_IDENTITY()
Commit Transaction InsertDV
End Try

Begin Catch 
Rollback Transaction InsertDV
End Catch
End 

GO
/****** Object:  StoredProcedure [dbo].[spinsertar_ingreso]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_ingreso]
@idingreso int=null output,
@idtrabajador int,
@idproveedor int,
@fecha date,
@tipo_comprobante varchar(20),
@serie varchar(4),
@correlativo varchar(7),
@igv decimal(4,2),
@estado varchar(7)
as
Begin
Begin Transaction InsertI
Begin Try 
insert into ingreso (idtrabajador,idproveedor,fecha,tipo_comprobante,
serie,correlativo,igv,estado)
values (@idtrabajador,@idproveedor,@fecha,@tipo_comprobante,
@serie,@correlativo,@igv,@estado)
--Obtener el código autogenerado
SET @idingreso=@@IDENTITY
Select SCOPE_IDENTITY()
Commit Transaction InsertI
End Try

Begin Catch 
Rollback Transaction InsertI
End Catch
End 


GO
/****** Object:  StoredProcedure [dbo].[spinsertar_presentacion]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_presentacion]
@idpresentacion int output,
@nombre varchar(50),
@descripcion varchar(256)
as
Begin
Begin Transaction InsertPres
Begin Try 
insert into presentacion (nombre,descripcion)
values (@nombre,@descripcion)

Select SCOPE_IDENTITY()
Commit Transaction InsertPres
End Try

Begin Catch 
Rollback Transaction InsertPres
End Catch
End 
GO
/****** Object:  StoredProcedure [dbo].[spinsertar_proveedor]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_proveedor]
@idproveedor int output,
@razon_social varchar(150),
@sector_comercial varchar(50),
@tipo_documento varchar(20),
@num_documento varchar(11),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50),
@url varchar(100)
as
Begin
Begin Transaction InsertProv
Begin Try 
insert into proveedor (razon_social,sector_comercial,tipo_documento,
num_documento,direccion,telefono,email,url)
values (@razon_social,@sector_comercial,@tipo_documento,
@num_documento,@direccion,@telefono,@email,@url)
Select SCOPE_IDENTITY()
Commit Transaction InsertProv
End Try

Begin Catch 
Rollback Transaction InsertProv
End Catch
End 

GO
/****** Object:  StoredProcedure [dbo].[spinsertar_trabajador]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Insertar
CREATE proc [dbo].[spinsertar_trabajador]
@idtrabajador int output,
@nombre varchar(20),
@apellidos varchar(40),
@sexo varchar(1),
@fecha_nacimiento date,
@num_documento varchar(8),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50),
@acceso varchar(20),
@usuario varchar(20),
@password varchar(20)
as
Begin
Begin Transaction InsertTrab
Begin Try 
insert into trabajador (nombre,apellidos,sexo,fecha_nac,
num_documento,direccion,telefono,email,acceso,usuario,password)
values (@nombre,@apellidos,@sexo,@fecha_nacimiento,
@num_documento,@direccion,@telefono,@email,@acceso,@usuario,
@password)
Select SCOPE_IDENTITY()
Commit Transaction InsertTrab
End Try

Begin Catch 
Rollback Transaction InsertTrab
End Catch
End 

GO
/****** Object:  StoredProcedure [dbo].[spinsertar_venta]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_venta]
@idventa int=null output,
@idcliente int,
@idtrabajador int,
@fecha date,
@tipo_comprobante varchar(20),
@serie varchar(4),
@correlativo varchar(7),
@igv decimal(4,2)
as
Begin
Begin Transaction InsertV
Begin Try 
insert into venta (idcliente,idtrabajador,fecha,tipo_comprobante,
serie,correlativo,igv)
values (@idcliente,@idtrabajador,@fecha,@tipo_comprobante,
@serie,@correlativo,@igv)
--Obtenemos el código autogenerado
set @idventa=@@IDENTITY
Select SCOPE_IDENTITY()
Commit Transaction InsertV
End Try

Begin Catch 
Rollback Transaction InsertV
End Catch
End 
GO
/****** Object:  StoredProcedure [dbo].[splogin]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[splogin]
@usuario varchar(20),
@password varchar(20)
as
select idtrabajador,apellidos,nombre,acceso
from trabajador
where usuario=@usuario and password=@password


GO
/****** Object:  StoredProcedure [dbo].[spmostrar_articulo]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_articulo]
as
SELECT top 100 dbo.articulo.idarticulo, dbo.articulo.codigo, dbo.articulo.nombre,
dbo.articulo.descripcion, dbo.articulo.imagen, dbo.articulo.idcategoria,
dbo.categoria.nombre AS Categoria, dbo.articulo.idpresentacion, 
dbo.presentacion.nombre AS Presentacion
FROM dbo.articulo INNER JOIN dbo.categoria 
ON dbo.articulo.idcategoria = dbo.categoria.idcategoria 
INNER JOIN dbo.presentacion 
ON dbo.articulo.idpresentacion = dbo.presentacion.idpresentacion
order by dbo.articulo.idarticulo desc


GO
/****** Object:  StoredProcedure [dbo].[spmostrar_categoria]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_categoria]
as
select top 200 * from categoria
order by idcategoria desc


GO
/****** Object:  StoredProcedure [dbo].[spmostrar_cliente]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_cliente]
as
select top 100 * from cliente
order by apellidos asc


GO
/****** Object:  StoredProcedure [dbo].[spmostrar_detalle_ingreso]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_detalle_ingreso]
@textobuscar int
as
select d.idarticulo,a.nombre as Articulo,d.precio_compra,
d.precio_venta,d.stock_inicial,d.fecha_produccion,
d.fecha_vencimiento,(d.stock_inicial*d.precio_compra) as Subtotal
from detalle_ingreso d inner join articulo a
on d.idarticulo=a.idarticulo
where d.idingreso=@textobuscar


GO
/****** Object:  StoredProcedure [dbo].[spmostrar_detalle_venta]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_detalle_venta]
@textobuscar int
as
select d.iddetalle_ingreso,a.nombre as Artículo,
d.cantidad,d.precio_venta,d.descuento,
((d.precio_venta*d.cantidad)-d.descuento) as Subtotal
from detalle_venta d inner join detalle_ingreso di
on d.iddetalle_ingreso=di.iddetalle_ingreso
inner join articulo a
on di.idarticulo=a.idarticulo
where d.idventa=@textobuscar


GO
/****** Object:  StoredProcedure [dbo].[spmostrar_ingreso]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spmostrar_ingreso]
as
select top 100 i.idingreso,(t.apellidos+' '+t.nombre) as Trabajador,
p.razon_social as Proveedor,i.fecha,i.tipo_comprobante,
i.serie,i.correlativo,i.estado,
sum(d.precio_compra*d.stock_inicial) as Total,i.igv as Impuesto
from detalle_ingreso d inner join ingreso i
on d.idingreso=i.idingreso
inner join proveedor p
on i.idproveedor=p.idproveedor
inner join trabajador t
on i.idtrabajador=t.idtrabajador
group by
i.idingreso,t.apellidos+' '+t.nombre,
p.razon_social,i.fecha,i.tipo_comprobante,
i.serie,i.correlativo,i.estado,i.igv
order by i.idingreso desc


GO
/****** Object:  StoredProcedure [dbo].[spmostrar_presentacion]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_presentacion]
as
select top 100 * from presentacion
order by idpresentacion desc


GO
/****** Object:  StoredProcedure [dbo].[spmostrar_proveedor]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_proveedor]
as
select top 100 * from proveedor
order by razon_social asc


GO
/****** Object:  StoredProcedure [dbo].[spmostrar_trabajador]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_trabajador]
as
select top 100 * from trabajador
order by apellidos asc


GO
/****** Object:  StoredProcedure [dbo].[spmostrar_venta]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spmostrar_venta]
as
select top 100 v.idventa,
(t.apellidos+' '+t.nombre) as Trabajador,
(c.apellidos+' '+c.nombre) as Cliente,
v.fecha,v.tipo_comprobante,v.serie,v.correlativo,
sum((d.cantidad*d.precio_venta)-d.descuento) as Total,v.igv as Impuesto
from detalle_venta d inner join venta v
on d.idventa=v.idventa
inner join cliente c
on v.idcliente=c.idcliente
inner join trabajador t
on v.idtrabajador=t.idtrabajador
group by v.idventa,
(t.apellidos+' '+t.nombre),
(c.apellidos+' '+c.nombre),
v.fecha,v.tipo_comprobante,v.serie,v.correlativo,v.igv
order by v.idventa desc


GO
/****** Object:  StoredProcedure [dbo].[spreporte_factura]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spreporte_factura]
@idventa int
as
select 
v.idventa,(t.apellidos+' '+t.nombre) as Trabajador,
(c.apellidos+' '+c.nombre) as Cliente,
c.direccion,c.telefono,c.num_documento,
v.fecha,v.tipo_comprobante,v.serie,v.correlativo,
v.igv,a.nombre,dv.precio_venta,dv.cantidad,dv.descuento,
(dv.cantidad*dv.precio_venta-dv.descuento) as Total_Parcial
 from detalle_venta dv inner join detalle_ingreso di
on dv.iddetalle_ingreso=di.iddetalle_ingreso
inner join articulo a
on a.idarticulo=di.idarticulo
inner join venta v
on v.idventa=dv.idventa
inner join cliente c
on v.idcliente=c.idcliente
inner join trabajador t
on t.idtrabajador=v.idtrabajador
where v.idventa=@idventa


GO
/****** Object:  StoredProcedure [dbo].[spstock_articulos]    Script Date: 28/02/2023 2:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spstock_articulos]
as
SELECT dbo.articulo.codigo, dbo.articulo.nombre,
dbo.categoria.nombre AS Categoria,
sum(dbo.detalle_ingreso.stock_inicial) as Cantidad_Ingreso,
sum(dbo.detalle_ingreso.stock_actual) as Cantidad_Stock,
(sum(dbo.detalle_ingreso.stock_inicial)-
sum(dbo.detalle_ingreso.stock_actual)) as Cantidad_Venta
FROM dbo.articulo INNER JOIN dbo.categoria 
ON dbo.articulo.idcategoria = dbo.categoria.idcategoria 
INNER JOIN dbo.detalle_ingreso 
ON dbo.articulo.idarticulo = dbo.detalle_ingreso.idarticulo 
INNER JOIN dbo.ingreso 
ON dbo.detalle_ingreso.idingreso = dbo.ingreso.idingreso
where ingreso.estado<>'ANULADO'
group by dbo.articulo.codigo, dbo.articulo.nombre,
dbo.categoria.nombre

GO
USE [master]
GO
ALTER DATABASE [dbventas] SET  READ_WRITE 
GO
