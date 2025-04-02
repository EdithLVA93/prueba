# 🚗 Sistema de Parqueadero

## 📂 Descripción
Este proyecto es una aplicación para gestionar el ingreso y salida de vehículos en un parqueadero. 
Permite registrar entradas, calcular tarifas según el tiempo estacionado y aplicar descuentos de supermercados aliados.

## 📁 Estructura del Proyecto
El sistema sigue la **Arquitectura Limpia**, separando responsabilidades en capas:

- **Presentación:** API en .NET Core (C#)
- **Core:** Lógica de negocio
- **Infraestructura:** Acceso a datos con Entity Framework y SQL Server
- **Compartido:** Utilidades y configuraciones comunes
- **Frontend:** Aplicación en Angular

## ⚙ Tecnologías Usadas
- **Backend:** .NET Core 8, C#, Entity Framework Core
- **Base de Datos:** SQL Server
- **Frontend:** Angular
- **Seguridad:** JWT para autenticación

---

## 🚀 Instalación y Configuración

### 1⃣ Clonar el repositorio

```bash
git clone https://github.com/EdithLVA93/prueba.git
cd prueba
vs-code
```


### 2⃣ Configurar la Base de Datos
- Crear una base de datos en **SQL Server**
- Ejecutar los scripts de `PruebaParqueaderoDataBase.sql` para crear las tablas necesarias
- Ejecutar los scripts de `Scripts SP Consulta y Creaacion.sql` para crear los procedimeitntos almacenados

📌 **Configuración en `appsettings.json`**
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=PruebaParqueadero;Integrated Security=True;TrustServerCertificate=True;"
}
```

### 3⃣ Ejecutar la API
```bash
cd PruebaParqueaderobknd
dotnet restore
dotnet run
```
La API se ejecutará en **http://localhost:7043/**

### 4⃣ Ejecutar el Frontend
```bash
cd parqueadero-app
npm install
ng serve
```
La aplicación estará disponible en **http://localhost:4200/**

---

## 🔧 Endpoints Principales (API REST)

| Método  | Endpoint                        					          | Descripción                                         |
|---------|-----------------------------------------------------|-----------------------------------------------------|
| POST    | `/api/vehiculos/registrar-ingreso`        			    | Registra la entrada de un vehículo                  |
| POST    | `/api/vehiculos/liquidar-salida`         			      | Calcula el pago y registra salida                   |
| GET     | `/api/vehiculos/ListadoVehiculos?inicio=xx&fin=xx`  | Lista vehículos estacionados en un rango de tiempo  |
| POST    | `/api/tiposvehiculo/Insertar`                  		  | Crea un nuevo tipo de vehículo                      |
| GET     | `/api/tiposvehiculo`                  				      | Lista todos los tipos de vehículo                   |
| POST    | `/api/supermercados/Insertar`                 		  | Crea un nuevo supermercado aliado                   |
| GET     | `/api/supermercados`                  				      | Lista todos los supermercados aliados               |


---

## 🔧 Mejoras Futuras
- Implementación de pagos en línea
- Soporte para múltiples tarifas según el tipo de vehículo
- Panel de administración con estadísticas
- Creación de supermercados desde el front
- Creación de tipos de vehiculos/liquidar-salida desde el front
- Administración de usuaruios y roles
- JWT

---

## 📄 Licencia
Este proyecto es de uso libre bajo la licencia **MIT**.

📌 **Autor:** [Edith Varela Ayala](https://github.com/EdithLVA93)

