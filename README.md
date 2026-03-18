# 🛒 DSW_ECOMMERCE

## 📌 Descripción
Proyecto grupal sobre un Sistema de Ecommerce desarrollado en equipo, orientado a la gestión de productos, categorías, usuarios y ventas.

---

## 🛠 Tecnologías utilizadas
- Backend: C#, HTML y CSS
- Base de datos: SQL Server
- Control de versiones: Git

---

## 🗄 Base de Datos
El sistema cuenta con una base de datos relacional compuesta por las siguientes entidades:

- **Categoria**
- **Producto**
- **Usuario**
- **Venta**
- **DetalleVenta**

### 🔗 Relaciones principales
- Un producto pertenece a una categoría  
- Una venta está asociada a un usuario  
- Una venta contiene múltiples productos (DetalleVenta)  

### ⚙️ Características técnicas
- Uso de claves primarias con identidad (IDENTITY)  
- Implementación de claves foráneas para mantener la integridad referencial  
- Manejo de tipos de datos adecuados (varchar, decimal, datetime)  
- Inserción de datos iniciales para pruebas  

---

## ⚙️ Funcionalidades principales
- Registro y gestión de productos  
- Gestión de categorías  
- Registro de usuarios  
- Registro de ventas  
- Detalle de productos por venta  

---

## 🧠 Consultas y manejo de datos
- Consultas básicas para la gestión de productos, usuarios y ventas  
- Estructura preparada para consultas relacionales entre tablas  
- Manejo de inserción y consulta de datos en SQL Server  

---
