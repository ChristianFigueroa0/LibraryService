# Libray Service
## Requerimientos

- **.NET 8**: Necesario solo si deseas ejecutar la aplicación localmente sin Docker.
- **Docker**: Necesario para desplegar y ejecutar la aplicación utilizando contenedores. Si ejecutas la aplicación exclusivamente con Docker, no necesitas tener .NET 8 instalado localmente.

## Características
- **Repository Pattern**
- **Razor Pages**
- **Bootstrap**
  
## Instalación

1. Clona el repositorio:
    ```bash
    git clone https://github.com/ChristianFigueroa0/LibraryService.git
    ```

## Ejecución del Proyecto

1. Navega al directorio del proyecto en la carpeta principal y ejecuta:
    ```bash
    cd LibraryService.Web
    ```
2. Iniciar servicio:
     ```bash
    dotnet run
    ```

## Ejecución con Docker
### 1. Construir la Imagen Docker
Para construir la imagen Docker de la aplicación, ejecuta el siguiente comando en la raíz del proyecto donde se encuentra el Dockerfile. Este comando construirá la imagen y la etiquetará como `library-service`:
```bash
docker build -t library-service .
```
### 2. Ejecutar el Contenedor Docker
Una vez que la imagen ha sido construida, puedes ejecutar el contenedor con el siguiente comando. Esto iniciará la aplicación en un contenedor y mapeará el puerto 8080 del contenedor al puerto 5001 de tu máquina local:
```bash
docker run -d -p 5001:8080 --name library-service-container library-service
```
### 3. Verificar que el Contenedor está Corriendo
Para verificar que el contenedor está ejecutándose correctamente, utiliza el siguiente comando:
```bash
docker ps
```
Este comando mostrará los contenedores en ejecución. Deberías ver algo similar a lo siguiente:
```bash
CONTAINER ID   IMAGE             COMMAND                  CREATED         STATUS         PORTS                  NAMES
123abc456def   library-service   "dotnet LibraryServic…"   2 minutes ago   Up 2 minutes   0.0.0.0:5001->8080/tcp library-service-container
```
 ### 4. Acceder a la Aplicación
Puedes acceder a la aplicación desde tu navegador en la siguiente URL:
http://localhost:5001


## Pruebas unitarias
1. Navega al directorio del proyecto en la carpeta principal y ejecuta:
    ```bash
    cd LibraryService.Test
    ```
2. Iniciar servicio:
     ```bash
    dotnet test
    ```
