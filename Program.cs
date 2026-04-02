using System;
using System.Collections.Generic;

class Medicamento
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Cantidad { get; set; }
    public DateTime FechaDeVencimiento { get; set; }

}

class Program
{
    static List<Medicamento> lista = new List<Medicamento>();
    static int idActual = 1;

    static void Main()
    {
        int opcion;

        do
        {
            Console.WriteLine("1. Crear medicamento");
            Console.WriteLine("2. Ver medicamentos");
            Console.WriteLine("3. Actualizar medicamento");
            Console.WriteLine("4. Eliminar medicamento");
            Console.WriteLine("5. Salir");
            Console.WriteLine("Opcion: ");

            int.TryParse(Console.ReadLine(), out opcion);

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Pendiente...");
                    break;
                case 2:
                    Console.WriteLine("Pendiente...");
                    break;
                case 3:
                    Console.WriteLine("Pendiente...");
                    break;
                case 4:
                    Console.WriteLine("Pendiente...");
                    break;
            }
        } while (opcion != 5);
    }
}