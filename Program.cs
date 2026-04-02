using System;
using System.Collections.Generic;

class Medicamento
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
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
                    CrearMedicamento();
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

    static void CrearMedicamento()
    {
        Medicamento m = new Medicamento();

        Console.Write("Nombre: ");
        m.Nombre = Console.ReadLine();

        Console.Write("Precio: ");
        m.Precio = double.Parse(Console.ReadLine());

        Console.Write("Cantidad: ");
        m.Cantidad = int.Parse(Console.ReadLine());

        Console.Write("Fecha de vencimiento (dd/MM/yyyy): ");
        m.FechaDeVencimiento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        m.Id = idActual++;
        lista.Add(m);

        Console.WriteLine("Medicamento Agreagado");
    }
}