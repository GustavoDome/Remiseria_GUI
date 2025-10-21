# Remiseria_GUI
 Programa para una empresa, proyecto de Practicas Profesionalizantes ll

Crear contenedor docker: 
docker run --name remiseria-db -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgres -e POSTGRES_DB=Remiseria -v remiseria_data:/var/lib/postgresql/data -p 5432:5432 -d postgres:16

Luego de haber creado el contenedor, se tiene que autorizar por parte del firewall asi que dentro de una carpeta donde deberia estar la otra carpeta se ejecuta este comando en el powershell (como administrador):

Get-ChildItem -Path . -Recurse | Unblock-File

luego buscar el archivo ejecutable "progama.exe" ubicado en: ..\Remiseria_GUI\Programa\bin\Debug

por ultimo, El usuario por defecto es:

Usuario: admin

Contraseña: 123
