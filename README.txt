# CARS

## DESCRIPCIÓN

Proyecto desarrollado para la asignatura **Programación Web I**.

El proyecto implementa un servicio web SOAP para la gestión de vehículos y categorías utilizando **.NET, SQL Server y Entity Framework Core**.

El servicio permite realizar operaciones de consulta, registro, actualización y eliminación de información relacionada con vehículos.

---

# TECNOLOGÍAS UTILIZADAS

* C#
* .NET / ASP.NET Core
* SOAP
* Entity Framework Core
* SQL Server
* Visual Studio

---

# ESTRUCTURA DEL PROYECTO

```text
CARS
│
├── DATA
│   └── CARSDBCONTEXT.cs
│
├── Models
│   ├── Categoria.cs
│   └── Vehiculo.cs
│
├── Services
│   ├── IVehiculoService.cs
│   └── VehiculoService.cs
│
├── POSTMAN
│   └── CARS.postman_collection.json
│
├── SQL
│   └── BASE-CARS.sql
│
├── Properties
│
├── appsettings.json
└── Program.cs
```

---

# ESTRUCTURA DE LA BASE DE DATOS

```text
CARS
│
├── Categoria
│
└── Vehiculo
```

---

# INSTRUCCIONES DE USO

### 1. Crear la base de datos

Abrir **SQL Server Management Studio (SSMS)** y conectarse a la instancia local de SQL Server.

Ejecutar el script ubicado en:

```text
SQL/BASE-CARS.sql
```

### 2. Configurar la conexión a la base de datos

Revisar el archivo:

```text
appsettings.json
```

Cadena de conexión:

```text
Server=.;Database=CARS;Trusted_Connection=True;TrustServerCertificate=True;
```

### 3. Abrir el proyecto

Abrir la solución:

```text
CARS.slnx
```

Utilizando Visual Studio.

Esperar a que Visual Studio restaure las dependencias necesarias del proyecto.

### 4. Ejecutar el servicio SOAP

Ejecutar el proyecto desde Visual Studio.

### 5. Importar la colección de Postman

Abrir Postman.

Seleccionar la opción **Import**.

Importar el archivo ubicado en:

```text
POSTMAN/CARS.postman_collection.json
```

### 6. Ejecutar y comprobar el funcionamiento de las operaciones SOAP

Las peticiones SOAP se realizan utilizando la URL del servicio y los métodos configurados en la colección de Postman.

#### URL del Servicio:
```text
http://localhost:7098/VehiculoService.svc
```

#### Configuración de Headers en Postman:
* **Content-Type:** `text/xml; charset=utf-8`
* **SOAPAction:** `"http://tempuri.org/IVehiculoService/[NombreDelMetodo]"`

#### Métodos disponibles:
* `AgregarVehiculo`
* `EliminarVehiculo`
* `ObtenerVehiculoPorMarca`
* `ObtenerVehiculo`
* `ObtenerVehiculoPorCategoria`
* `ObtenerVehiculos`
* `ActualizarVehiculo`
* `ObtenerCategorias`

---

# ORDEN DE EJECUCIÓN

Para ejecutar correctamente el proyecto se recomienda seguir este orden:

1. Iniciar SQL Server.
2. Ejecutar el script `SQL/BASE-CARS.sql`.
3. Revisar la configuración del archivo `appsettings.json`.
4. Abrir la solución `CARS.slnx`.
5. Ejecutar el proyecto .NET desde Visual Studio.
6. Abrir Postman.
7. Importar la colección de Postman.
8. Probar las operaciones SOAP utilizando el endpoint `http://localhost:7098/VehiculoService.svc`.

---

# AUTOR

David Simba

# CURSO

3ro "B"
