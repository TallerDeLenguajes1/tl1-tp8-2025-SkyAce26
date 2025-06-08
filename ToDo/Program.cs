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

gestor.MostrarTareasPendientes();

Console.WriteLine("Ingrese el id de la terea que está completada:");
int id = int.Parse(Console.ReadLine());

gestor.MoverTarea(id);

Console.WriteLine("Lista tareas pendientes:");

gestor.MostrarTareasPendientes();
Console.WriteLine("--------------------");

Console.WriteLine("Lista tareas completadas:");
gestor.MostrarTareasCompletadas();