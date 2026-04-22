# Proyecto Final – Framework Integral de Automatización en .NET  - Francinni Portuguez Castro

## Descripción
Este proyecto implementa un **framework de automatización en .NET** que integra:
- Pruebas funcionales Web con **Selenium WebDriver**  
- Pruebas BDD con **Reqnroll**  
- Pruebas de API con **RestSharp**  
- Arquitectura basada en **Page Object Model (POM)**  
- **Data-driven testing** con archivos JSON  
- **Reporter ExtentReports** para evidencias de ejecución  

El sistema bajo prueba es **SauceDemo**, un sitio de e-commerce ficticio diseñado para pruebas automatizadas.

## Estructura del Proyecto
ProyectoFinal/ 
├── Pages/          
├── Reporting/      
├── StepDefinitions/
├── TestData/              
├── Tests/
├──├── API
├──├── BDD
├──├── Web
├── Utils 
└── README.md

---

##  Instalación
1. Clonar el repositorio:
   ```bash
   git clone https://github.com/fportuguezc/Soft740-FrancinniPortuguez.git

2. Restaurar
    ```bash
    dotnet restore

3. Instalar paquetes NuGet necesarios:
    ```bash
    dotnet add package Selenium.WebDriver
    dotnet add package Selenium.Support
    dotnet add package NUnit
    dotnet add package Reqnroll
    dotnet add package RestSharp
    dotnet add package ExtentReports
    dotnet add package Newtonsoft.Json

---

## Escenarios Implementados

## Web- Login válido con credenciales correctas
- Escenarios parametrizados con data-driven
- Login inválido y validación de mensaje de error
- Agregar producto al carrito y validar contador
- Eliminar producto del carrito
- Checkout exitoso con datos válidos (JSON)
- Checkout con datos incompletos y validación de error
- Validar ordenamiento de productos por precio (Low-High)

## BDD (Reqnroll) Flujo completo de compra en SauceDemo (Given-When-Then)
- Login inválido y validación de mensaje de error
- Agregar producto al carrito y validar contador
- Eliminar producto del carrito
- Checkout exitoso con datos válidos (JSON)
- Checkout con datos incompletos y validación de error
- Validar ordenamiento de productos por precio (Low-High)

## API (RestSharp)
- GET: consulta de recursos
- POST: creación de recurso
- PUT: actualización de recurso
- DELETE: eliminación de recurso

## Configuración
- Configuración por ambiente en Utilities
- Data-driven con archivos JSON en TestData/
- Screenshots automáticos en fallos (ScreenshotHelper.cs)

## Reportes
- Se genera reporte para los casos de prueba web, api y BDD utilizando la librería Extended reports. 