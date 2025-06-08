using EspacioTareas;

GestorDeTareas gestor = new GestorDeTareas();

string[] descripciones = { "Revisión de código", "Informe mensual", "Optimización", "Diseño de interfaz", "Pruebas unitarias" };

Random random = new Random();
int cantidad = random.Next(1, 5);
int duracion;

for (int i = 0; i < cantidad; i++)
{
    Console.WriteLine("Ingrese la duración de la tarea:");
    while (!int.TryParse(Console.ReadLine(), out duracion))
    {
        Console.WriteLine("Duración incorrecta, debe estár entre 10 y 100.");
    }
    gestor.AgregarTarea(descripciones[i], duracion);
}
bool seguir = true;
int opcion;

while (seguir)
{
    Console.WriteLine();
    Console.WriteLine("Ingrese el numero de la operacion que quiera realizar:\n");
    Console.WriteLine("1-Mostrar lista de tareas pendientes.");
    Console.WriteLine("2-Mostrar lista de tareas completadas.");
    Console.WriteLine("3-Mover tarea a la lista de tareas completadas.");
    Console.WriteLine("4-Buscar tarea por descripción en la lista de tareas pendientes.");
    Console.WriteLine("5-Salir.\n");

    while (!int.TryParse(Console.ReadLine(), out opcion))
    {
        Console.WriteLine("Opción inválida, elija un número entre 1 y 6.");
    }

    if (opcion == 5)
    {
        seguir = false;
        break;
    }

    switch (opcion)
    {
        case 1:
            gestor.MostrarTareasPendientes();
            break;
        case 2:
            gestor.MostrarTareasCompletadas();
            break;
        case 3:
            Console.WriteLine("Ingrese el id de la terea que está completada:");
            int id = int.Parse(Console.ReadLine());
            gestor.MoverTarea(id);
            break;
        case 4:
            Console.WriteLine("Ingrese la descripción de la tarea que quiere buscar en pendientes:");
            string descripcion = Console.ReadLine();
            gestor.buscarTareaPorDescripcion(descripcion);
            break;
    }

}
