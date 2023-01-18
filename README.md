# ARMiniCoreBack - Alain Ruales
En el siguiente repositorio se encuentra la implementación del backend para proyecto MiniCore de contratos de usuarios para la materia de ingeriería web periodo 202310.

El proyecto de ingeniería Web fue creado con ASP.NET Core con .NET 6.

# Ejecución de proyecto
Para ejecutar el proyecto, de preferencia se debe utilizar Visual Studio 2022 con la instalación de "Desarrollo de APS.NET web"

<img src="https://user-images.githubusercontent.com/87552871/194952850-190061f6-fc18-4ae9-8d14-b0b06d1cd211.png" width=50% height=50%>

Con estas herramientas, se debe ejecutar el proyecto desde la interfaz gráfica.

![image](https://user-images.githubusercontent.com/87552871/213069092-013e7fb8-2823-4ffe-a88a-710947609164.png)

## Funcionalidad de proyecto
Este proyecto se encuentra dentro de una solución que puede ser abierta por Visual Studio. 
Dentro de esta solución, se tiene la implementación de API que es consumida por una aplicación web en Angular. El enlace de repositorio de esta aplicación es: https://github.com/AlainRuales01/AngularFrontEndMiniCore

El objetivo de esta API es recibir dos valores de fecha inicio y fecha fin, y devolver el monto total pagado por cada cliente. Las fechas son usadas para calcular el monto total pagado en base a los contratos que se encuentran dentro de este límite de tiempo.
Para el almacenamiento se utiliza Microsoft SQL Server.

![image](https://user-images.githubusercontent.com/87552871/213072031-138bf02b-e6a0-4bc4-ae71-ec831b57433e.png)
![image](https://user-images.githubusercontent.com/87552871/213072045-b2f8630a-8840-44bc-bb67-e7453dd7189b.png)


## Restaurar base de datos
Para restaurar la base de datos en Microft SQL Server es necesario simplemente ejecutar el programa dentro de Visual Studio 2022. Es importante mencionar que es necesario modificar el string de conexión hacia la base de datos en donde se desea restaurar.

![image](https://user-images.githubusercontent.com/87552871/213071602-89a2eade-d701-49aa-a235-cbb15bad6c56.png)


# Deploy en la nube
Actualmente, este proyecto se encuentra deployado en la plataforma de Smarterasp hasta el día 17 de febrero de 2023. Incluso la base de datos SQL server se encuentra en este servicio. Para poder lograr esto se siguió la siguiente guía: https://www.youtube.com/watch?v=NZOKfXfq2PQ&t=1198s

El enlace del API es: http://minicoreapi-001-site1.atempurl.com/swagger/index.html
