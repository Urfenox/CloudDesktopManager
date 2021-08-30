# CloudDesktopManager
CloudDesktopManager (desde ahora CDM) es un administrador tipo Copias de Seguridad, pero mas pobre... pero funciona.

## Objetivo, la razon del crearlo
Pasa que me gusta dejar archivos y carpetas sueltas en el Escritorio, y tambien pasa que tengo mi notebook y en casos estas archivos/carpetas sueltas las necesito en mi notebook, pero, estan en el pc.
Pensando en esto, y evitando utilizar copias de seguridad de los servicios de almacenamiento en nube como OneDrive, el cual esta bien, pero no quiero que se pasen algunas carpetas que pesan mas de 10GB. Entonces me puse a crear esto.
Este programa basicamente ve si hay archivos en una ruta, si los hay, entonces los sube a la ruta de un servicio de almacenamiento en la nube (rutanube = C:\Users\elsa\OneDrive), toma los archivos del escritorio y los mueve a esa ruta, luego crea un acceso directo en la ruta que se encontraban originalmente, asi sigo tendiendo mi escritorio como siempre.

Tambien esta pensado para que trabaje en conjunto, pero de manera independiente, con otras instancias en otros computadores, asi si un computador, llamemoslo PC-1 sincroniza este archivo y luego viene PC-2 y ve que hay un nuevo archivo en la nube, pues entonces lo descarga el OneDrive, y nuestro programita solo lo crea el acceso directo al la ruta que le demos.
Asi que si, la sincronizacion y trabajo es en dos rutas.

## Funcionamiento
Ve el codigo, cambiara en el futuro, hacer la documentacion seria una tortura.
Pero, basicamente hace lo siguiente:

1) Primero se deben indicar las dos rutas
    * Ruta nube: La ruta de la carpeta que esta siendo sincronizada por algun software de almacenamiento en la nube (Dropbox, OneDrive, etc)
    * Ruta local: La ruta local que el usuario quiere que se sincronize con la ruta en la nube. El escritorio por ejemplo. Quiero que el lo que este en el escritorio se mueva a la ruta en nube.
2) Al sincronizar (ya sea manual o automatico)
    * Indica cada cuantos segundos se realizara la sincronizacion (mover) de los archivos/carpetas (solo para cuando el checkbox "Sync automatico" este activo).
    #### En el caso de sincronizacion de ruta local a ruta nube
      * Se ve la ruta local en busqueda de archivos y carpetas
      * Si se encuentra un archivo se ve si este tiene la extencion .lnk. Si la tiene, se omite (pues es un acceso directo)
      * Si se encuentra un archivo que no tenga esa extencion, entonces se mueve a la ruta en la nube.
      * Lo mismo aplica para las carpetas. Los accesos directos a las carpetas son archivos, naturalmente se omiten.
      * Las carpetas se mueven a la ruta en nube (siempre y cuando no esten en la lista de omision (al igual que con las extenciones y ficheros especificos en las listas de omision))
      #### En el caso de sincronizacion de ruta nube a ruta local
      * Se ve la ruta de nube, se comprueba archivo por archivo y carpeta por carpeta. Si el archivo ya tiene un acceso directo en el escritorio, entonces este ya esta sincronizado, se omite.
      * Si el archivo o carpeta no tiene un acceso directo en el escritorio, entonces, se crea uno. Este archivo/carpeta llego desde otro lado, quiza otro computador con CDM andando.
      * OJO: Si cambias el nombre de algun acceso directo, es posible que se vuelva a crear otro. Es la forma que CDM tiene para "indexar" los archivos y carpetas.

Mientras yo lo entienda, y entienda la idea, se puede seguir mejorando.

## Proyecto
Lenguaje WindowsForms .vb (.net) Microsoft Visual Studio 2017 Community
