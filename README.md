# SmileSoft 🦷

SmileSoft es un sistema de gestión  para clínicas odontológicas, diseñado para optimizar la administración de pacientes, turnos, profesionales y servicios. El proyecto cuenta con interfaces diferenciadas según el rol del usuario para ofrecer una experiencia a medida.

## ✨ Características Principales

-   **Gestión de Pacientes:** Administración completa de los datos personales y de contacto de los pacientes, incluyendo su historia clínica y la asignación de tutores para menores de 16 años.
-   **Administración de Turnos (Atenciones):** Programación, seguimiento y registro de atenciones. Cada atención cuenta con un estado (ej: Otorgada, Finalizada, Cancelada), observaciones clínicas, profesional a cargo y tipo de tratamiento.
-   **Manejo de Odontólogos:** Registro y gestión de los profesionales de la clínica.
-   **Gestión de Obras Sociales y Planes:** Administración de las obras sociales con las que trabaja la clínica y sus respectivos tipos de planes, que pueden ser asignados a los pacientes.
-   **Control de Usuarios por Roles:** Sistema de autenticación y autorización con tres niveles de acceso:
    -   **Administrador:** Control total del sistema.
    -   **Secretario/a:** Gestión de pacientes y turnos.
    -   **Odontólogo:** Acceso a su agenda y a las historias clínicas de sus pacientes.
    -   **Paciente**: 
-   **Interfaces Diferenciadas:**
    -   Una **aplicación de escritorio (Windows Forms)** robusta para el personal administrativo (Administrador y Secretario/a).
    -   Una **aplicación web (Blazor)** moderna y accesible para que los odontólogos puedan consultar su información desde cualquier lugar, y para que los pacientes puedan solicitar turnos desde ese portal, así como también consultar sus turnos previos.

## 🏗️ Arquitectura y Tecnologías

El sistema está construido sobre una arquitectura de cliente-servidor con las siguientes tecnologías:

-   **Backend:** API REST desarrollada con .NET, utilizando Minimal APIs para los endpoints.
-   **Acceso a Datos:** Entity Framework Core como ORM para la interacción con la base de datos.
-   **Frontend (Administrativo):** Aplicación de escritorio con Windows Forms (.NET).
-   **Frontend (Odontólogos):** Aplicación web interactiva con Blazor.
-   **Base de Datos:** Diseñado para ser compatible con SQL Server.

## 📚 Modelo de Dominio

Las entidades principales que modelan el negocio de la clínica son:

-   **Paciente:** Contiene la información personal, número de historia clínica y puede tener un `Tutor` y un `TipoPlan`.
-   **Atención:** Es el corazón del sistema. Vincula a un `Paciente`, un `Odontólogo` y un `TipoAtencion`. Registra `fecha/hora`, `estado` y `observaciones`.
-   **Odontólogo:** Profesional que realiza las atenciones.
-   **Usuario:** Define el acceso al sistema. Cada `Usuario` tiene un rol (`Admin`, `Secretario`, `Odontologo`).
-   **ObraSocial:** Entidad que agrupa diferentes `TiposDePlan`.
-   **TipoPlan:** Plan específico de una `ObraSocial` al que un paciente puede estar afiliado.
-   **TipoAtencion:** Define los tratamientos que ofrece la clínica, con una `descripcion` y una `duracion` estimada.

## 🚀 Cómo Empezar

Para poner en marcha el proyecto en un entorno de desarrollo local, se deben seguir estos pasos:


### Instalación y Configuración

1.  **Clonar el repositorio:**
    ```bash
    git clone https://github.com/maraglianovittorio/SmileSoft.git
    cd SmileSoft
    ```

2.  **Configurar la base de datos:**
    -   Abrir el archivo `appsettings.json` en el proyecto de la API.
    -   Modificar la cadena de conexión (`DefaultConnection`) para que apunte a tu instancia local de SQL Server.

3.  **Ejecutar la aplicación:**
    -   Establecer el proyecto de la **API** y el de **Windows Forms** o **Blazor** para la UI como proyecto de inicio y ejecutarlos.

## 👥 Usuarios de Prueba

Se puede acceder al sistema utilizando las siguientes credenciales preconfiguradas:

| Rol | Usuario | Contraseña |
| :--- | :--- | :--- |
| **Administrador** | `admin` | `Admin123` |
| **Secretario/a** | `secretario` | `secretario123` |
| **Odontólogo 1** | `odontologo1` | `Odonto123` |
| **Odontólogo 2** | `odontologo2` | `Odonto123` |
| **Paciente 1** | `mrusso` | `Paciente123` |
| **Paciente 2** | `cquintana` | `Paciente123` |
| **Paciente 3** | `fmallo` | `Paciente123` |

Las funcionalidades del odontólogo y de los pacientes están implementadas en Blazor, mientras que las del secretario y el administrador en Windows Forms.

## 🔗 Repositorio

El código fuente completo está disponible en GitHub:
**https://github.com/maraglianovittorio/SmileSoft**

---