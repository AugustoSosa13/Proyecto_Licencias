# Proyecto_Final - API de Licencias

Este proyecto consiste en el desarrollo de una API en C# con Entity Framework que permite gestionar licencias, almacenando la información en una base de datos SQL Server.  
La API sigue buenas prácticas de programación, aplicando patrones de diseño y documentación de endpoints con Swagger.

---

## Funcionalidades principales

La API permite:

- Guardar, editar y eliminar licencias en una base de datos SQL Server.
- Validar y controlar que todos los campos sean obligatorios y tengan el formato correcto.
- Exponer endpoints REST documentados con Swagger.
- Probar los endpoints mediante Postman.

---

## Base de datos

Motor: SQL Server, se usa un servidor de testing local.
Se utiliza una tabla propia para almacenar la información de las licencias.  

Campos de la tabla:

- DNI: debe tener entre 8 y 9 caracteres 
- Fecha de inicio de la licencia 
- Fecha de fin de la licencia  
- Tipo de licencia: ordinaria o extraordinaria 
- Provincia 
- Localidad 
- Dirección
- Orden del Día (OD): alfanumérico, entre 6 y 10 caracteres 
Ningún registro puede guardarse si falta un campo o no cumple las validaciones.

---

## Endpoints

La API expone 4 endpoints principales:

1. GET /api/licencias
   Devuelve el listado completo de licencias.

2. POST /api/licencias
   Inserta una nueva licencia en la base de datos.  
   - Si faltan campos, devuelve un mensaje indicando el campo que falta.  
   - Si se inserta correctamente, devuelve un mensaje de éxito.

3. PUT /api/licencias/id
   Modifica una licencia existente.

4. DELETE /api/licencias/id
   Elimina una licencia existente.

Todos los endpoints están documentados en Swagger.

---

## Tecnologías utilizadas

- Lenguaje: C#  
- Framework: .NET con Entity Framework  
- Base de datos: SQL Server  
- Documentación: Swagger  
- Testeo: Postman  
