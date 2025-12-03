# Sistema de Pagos 💰

Sistema web académico para la gestión de pagos y usuarios con control de roles. Permite registrar, consultar y administrar información financiera según los permisos de cada usuario.

## 🌐 Demo en Vivo

**[https://laempresawebapp-e9c7fkdzg6apdgae.brazilsouth-01.azurewebsites.net](https://laempresawebapp-e9c7fkdzg6apdgae.brazilsouth-01.azurewebsites.net)**

## 📋 Características

- ✅ Autenticación y gestión de usuarios
- ✅ Sistema de roles (Administrador, Supervisor, Usuario)
- ✅ Registro y seguimiento de pagos
- ✅ Consultas filtradas por permisos
- ✅ Interfaz responsiva
- ✅ Reportes según rol

## 🛠️ Tecnologías

- **Backend**: ASP.NET Core, Entity Framework Core, SQL Server
- **Frontend**: Razor Pages/MVC, Bootstrap, JavaScript
- **Despliegue**: Azure App Service, Azure SQL Database

## 📦 Instalación

```bash
# Clonar repositorio
git clone https://github.com/AlfredoV4rta/SistemaDePagos.git
cd SistemaDePagos

# Configurar appsettings.json con tu cadena de conexión

# Restaurar y ejecutar
dotnet restore
dotnet ef database update
dotnet run
```

## 👥 Roles

- **Administrador**: Acceso completo y gestión de usuarios
- **Supervisor**: Consulta de pagos departamentales y reportes
- **Usuario**: Consulta de información personal

## 👨‍💻 Autor

**Alfredo Varta** - [@AlfredoV4rta](https://github.com/AlfredoV4rta)

---

⭐ Si este proyecto te fue útil, dale una estrella en GitHub
