using EspacioCalculadora;


Calculadora calcu = new Calculadora();
int opcion;
double valor;
bool seguir = true;

List<Operacion> Historial = new List<Operacion>();

while (seguir)
{
    Console.WriteLine($"\nResultado actual: {calcu.GetResultado()}");
    Console.WriteLine("Ingrese el numero de la operacion que quiera realizar:");
    Console.WriteLine("1-Sumar.");
    Console.WriteLine("2-Restar.");
    Console.WriteLine("3-Multiplicar.");
    Console.WriteLine("4-Dividir.");
    Console.WriteLine("5-Limpiar.");
    Console.WriteLine("6-Salir.");

    while (!int.TryParse(Console.ReadLine(), out opcion))
    {
        Console.WriteLine("Opción inválida, elija un número entre 1 y 6.");
    }

    if (opcion == 6)
    {
        Console.WriteLine("Saliendo de la calculadora...");
        seguir = false;
        break;
    }

    Console.WriteLine("Ingrese el numero al cual se le realizarà la operaciòn elegida:");
    while (!double.TryParse(Console.ReadLine(), out valor))
    {
        Console.WriteLine("Numero invàlido, ingrese otro.");
    }

    double resultadoAnterior = calcu.GetResultado();

    switch (opcion)
    {
        case 1:
            calcu.Sumar(valor);
            Historial.Add(new Operacion(resultadoAnterior, valor, TipoOperacion.Suma));
            break;
        case 2:
            calcu.Restar(valor);
            Historial.Add(new Operacion(resultadoAnterior, valor, TipoOperacion.Resta));
            break;
        case 3:
            calcu.Multiplicar(valor);
            Historial.Add(new Operacion(resultadoAnterior, valor, TipoOperacion.Multiplicacion));
            break;
        case 4:
            calcu.Dividir(valor);
            Historial.Add(new Operacion(resultadoAnterior, valor, TipoOperacion.Division));
            break;
        case 5:
            calcu.Limpiar();
            Historial.Add(new Operacion(resultadoAnterior, 0, TipoOperacion.Limpiar));
            Console.WriteLine("Calculadora reiniciada.");
            break;
    }
}

Console.WriteLine("\n--- Historial de operaciones ---");
foreach (var op in Historial)
{
    Console.WriteLine($"{op.operacion}: {op.resultadoAnterior} {op.ObtenerSimbolo()} {op.nuevoValor} (Resultado anterior {op.ObtenerSimbolo()} resultado actual)\n Resultado = {op.Resultado}\n");
}

    
