namespace EspacioCalculadora
{
    public class Calculadora
    {
        private double dato;
        public Calculadora(double dato = 0)
        {
            this.dato = dato;
        }
        public void Sumar(double termino)
        {
            dato += termino;
        }
        public void Restar(double termino)
        {
            dato -= termino;
        }
        public void Multiplicar(double termino)
        {
            dato *= termino;
        }
        public void Dividir(double termino)
        {
            if (termino != 0)
            {
                dato /= termino;
            }
            else
            {
                Console.WriteLine("No se puede dividir por cero.");
            }
        }
        public void Limpiar()
        {
            dato = 0;
        }
        public double GetResultado()
        {
            return dato;
        }
    }

    public enum TipoOperacion
    {
        Suma,
        Resta,
        Multiplicacion,
        Division,
        Limpiar  // Representa la acción de borrar el resultado actual o el historial 
    }

    public class Operacion
    {
        private List<Operacion> Historial = new();

        public double resultadoAnterior { get; }
        public double nuevoValor { get; }
        public TipoOperacion operacion { get; }


        public Operacion(double resultadoAnterior, double nuevoValor, TipoOperacion operacion)
        {
            this.resultadoAnterior = resultadoAnterior;
            this.nuevoValor = nuevoValor;
            this.operacion = operacion;
        }
        public double Resultado
        {
            get
            {
                return operacion switch
                {
                    TipoOperacion.Suma => resultadoAnterior + nuevoValor,
                    TipoOperacion.Resta => resultadoAnterior - nuevoValor,
                    TipoOperacion.Multiplicacion => resultadoAnterior * nuevoValor,
                    TipoOperacion.Division => nuevoValor != 0 ? resultadoAnterior / nuevoValor : -1,
                    TipoOperacion.Limpiar => 0,
                    _ => resultadoAnterior
                };
            }
            /* Lógica para calcular o devolver el resultado */
        }
        // Propiedad pública para acceder al nuevo valor utilizado en la operación 

        public string ObtenerSimbolo()
        {
            return operacion switch
                {
                    TipoOperacion.Suma => "+",
                    TipoOperacion.Resta => "-",
                    TipoOperacion.Multiplicacion => "*",
                    TipoOperacion.Division => "/",
                    TipoOperacion.Limpiar => "↺",
                    _ => "?"
                };
        }

        public double NuevoValor
        {
            get { return nuevoValor; }
        } // Constructor u otros métodos necesarios para inicializar y gestionar la operación // ... 
        
    }
}