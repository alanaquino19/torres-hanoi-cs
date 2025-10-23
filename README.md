# Torres de Hanói en C#

Juego de consola "Torres de Hanói" para dos jugadores en C#. Implementa la mecánica por turnos, validación de movimientos y representación visual en la consola. Proyecto pensado para prácticas y demostración de estructuras de datos stack.

---

## Contenido del proyecto

1. **Juego por turnos**: Dos jugadores alternan turnos hasta completar la torre C.  
2. **Validación de movimientos**: Solo se permite mover el disco superior y no se puede colocar uno mayor sobre uno menor.  
3. **Interfaz de consola**: Visualización de las tres torres y contador de movimientos.  
4. **Código didáctico**: Facilita comprensión y reutilización.

---

## Archivos incluidos

- `TorresHanoi.csproj`: Archivo de proyecto (.NET 9).  
- `Program.cs`: Código fuente principal del juego.  
- `README.md`: Archivo con explicaciones e instrucciones.

---

## Compilación y ejecución

Este proyecto usa .NET 9. Para compilar y ejecutar localmente:

1. Asegúrate de tener instalado el SDK de .NET 9.  
2. Desde la carpeta del proyecto, compila:

   ```bash
   dotnet build
   ```

3. Ejecuta la aplicación:

   ```bash
   dotnet run --project TorresHanoi.csproj
   ```

O, si prefieres crear el ejecutable:

   ```bash
   dotnet publish -c Release -r win-x64 --self-contained false -o ./publish
   ```

y luego ejecuta el binario resultante en ./publish.


---

## Ejemplo de uso

Al ejecutar la aplicación el programa solicitará:

1. Nombre del Jugador 1.
2. Nombre del Jugador 2.
3. Movimientos indicando torre origen y torre destino (A, B, C).
4. El objetivo es mover todos los discos desde la torre A hasta la torre C siguiendo las reglas.

---

## Autor

Alan Aquino, estudiante de Ingeniería en Informática.

---

## Licencia

Este proyecto se distribuye bajo la licencia MIT. Consulta el archivo LICENSE para más detalles.

