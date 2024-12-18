Prueba Técnica Backend - .NET Core 7.0

Este repositorio contiene el backend desarrollado en .NET Core 7.0 para la prueba técnica. Proporciona APIs RESTful con autenticación JWT, manejo de entidades y empleados, y conexión a una base de datos MySQL.

Requisitos Previos

Instalaciones Necesarias:

.NET SDK 7.0

MySQL Server

Git

Variables de Entorno:
Configura las siguientes variables de entorno para el proyecto:

ConnectionStrings:DefaultConnection: Cadena de conexión para la base de datos MySQL.

Jwt:Key: Clave secreta para la generación de tokens JWT.

Ejemplo:

{
    "ConnectionStrings": {
        "DefaultConnection": "server=localhost;port=3306;database=PruebaTecnicaDB;user=root;password=tu_password"
    },
    "Jwt": {
        "Key": "clave_secreta_para_tokens"
    }
}

Instrucciones de Instalación y Ejecución

1. Clonar el Repositorio

Ejecuta el siguiente comando para clonar este repositorio:

git clone https://github.com/RuaJean/.net-Core.git
cd .net-Core

2. Configurar la Base de Datos

Accede a tu servidor MySQL.

Ejecuta el script SQL que se encuentra en el archivo db_script.sql del proyecto para crear las tablas necesarias:

CREATE DATABASE IF NOT EXISTS PruebaTecnicaDB;
USE PruebaTecnicaDB;

-- Crear tablas
CREATE TABLE Entidades (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion TEXT,
    FechaCreacion DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Empleados (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Cargo VARCHAR(50),
    EntidadId INT,
    FechaCreacion DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (EntidadId) REFERENCES Entidades(Id) ON DELETE CASCADE
);

CREATE TABLE Usuarios (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    NombreUsuario VARCHAR(50) UNIQUE NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    Rol ENUM('Usuario', 'Administrador') DEFAULT 'Usuario',
    FechaCreacion DATETIME DEFAULT CURRENT_TIMESTAMP
);

3. Restaurar Dependencias

Ejecuta el siguiente comando para restaurar las dependencias del proyecto:

dotnet restore

4. Configurar el Proyecto

Verifica y configura el archivo appsettings.json en la raíz del proyecto:

{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=PruebaTecnicaDB;user=root;password=tu_password"
  },
  "Jwt": {
    "Key": "clave_secreta_para_tokens"
  }
}

5. Ejecutar la Aplicación

Inicia la aplicación con el siguiente comando:

dotnet run

6. Acceder al Swagger

Una vez que la aplicación esté ejecutándose, accede a la documentación Swagger para probar las APIs:

http://localhost/swagger

Puntos Clave

Autenticación JWT:

Obtén un token desde el endpoint /api/Auth/login y úsalo para autenticarte en los endpoints protegidos.

Agrega el token como encabezado en las solicitudes:

Authorization: Bearer {token}

Endpoints Importantes:

Entidades: /api/Entidades

Empleados: /api/Empleados

Despliegue

El backend está configurado para CI/CD en Azure. Cualquier cambio en la rama principal activa automáticamente el pipeline de integración continua, realizando pruebas, compilando el proyecto y desplegándolo en producción.

Contribuciones

Si deseas contribuir, realiza un fork del repositorio, crea una rama con tus cambios y envía un pull request. ¡Las contribuciones son bienvenidas!

Licencia

Este proyecto está licenciado bajo la MIT License.
