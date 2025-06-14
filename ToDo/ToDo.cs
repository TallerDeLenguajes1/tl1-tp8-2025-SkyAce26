namespace EspacioTareas
{
    public class Tarea
    {

        public int TareaID { get; set; }
        public string Descripcion { get; set; }

        public int Duracion { get; set; } // Validar que esté entre 10 y 100 
          // Puedes añadir un constructor y métodos auxiliares si lo consideras necesario 

        public Tarea(int id, string descripcion, int duracion)
        {
            TareaID = id;
            Descripcion = descripcion;
            Duracion = duracion;
        }
        public string Mostrar()
        {
            return $"ID: {TareaID}\nDescripción: {Descripcion}\nDuración: {Duracion}";
        }
    }

    public class GestorDeTareas
    {
        private int contadorID = 1;
        private List<Tarea> TareasPendientes = new();
        private List<Tarea> TareasCompletadas = new();

        public void AgregarTarea(string descripcion, int duracion)
        {
            if (duracion < 10 || duracion > 100)
            {
                Console.WriteLine("No se pudo agregar la tarea: duración inválida.");
                return;
            }

            Tarea nuevaTarea = new Tarea(contadorID++, descripcion, duracion);
            TareasPendientes.Add(nuevaTarea);
        }

        public void MoverTarea(int id)
        {
            //busco la tarea que tenga el id ingresado:
            Tarea tarea = TareasPendientes.FirstOrDefault(t => t.TareaID == id);

            if (tarea != null)
            {
                TareasCompletadas.Add(tarea);
                TareasPendientes.Remove(tarea);
                Console.WriteLine("Tarea movida exitosamente");
            }
            else
            {
                Console.WriteLine("Error en mover la tarea.");
            }
            
        }

        public void buscarTareaPorDescripcion(string descripcion)
        {
            Tarea tarea = TareasPendientes.FirstOrDefault(t => t.Descripcion == descripcion);

            if (tarea != null)
            {
                Console.WriteLine(tarea.Mostrar());
                Console.WriteLine("------------------");
            }
            else
            {
                Console.WriteLine("Error en encontrar la tarea.");
            }

        }

        public void MostrarTareasPendientes()
        {
            foreach (var tarea in TareasPendientes)
            {
                Console.WriteLine(tarea.Mostrar());
                Console.WriteLine("------------------");
            }
        }

        public void MostrarTareasCompletadas()
        {
            foreach (var tarea in TareasCompletadas)
            {
                Console.WriteLine(tarea.Mostrar());
                Console.WriteLine("------------------");
            }
        }
    }

}