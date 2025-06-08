namespace EspacioTareas
{
    public class Tarea
    {

        public int TareaID { get; set; }
        public string Descripcion { get; set; }

        private int duracion;

        public int Duracion
        {
            get { return duracion; }

            set
            {
                if (value >= 10 && value <= 100)
                {
                    duracion = value;
                }
                else
                {
                    Console.WriteLine("Duración inválida, debe estar entre 10 y 100 días");
                }
            }
        } // Validar que esté entre 10 y 100 
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

        public void MostrarTareasPendientes()
        {
            foreach (var tarea in TareasPendientes)
            {
                Console.WriteLine(tarea.Mostrar());
                Console.WriteLine("------------------");
            }
        }
    }

}