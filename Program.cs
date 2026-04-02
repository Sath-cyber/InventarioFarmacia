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
                    MostrarMedicamentos();
                    break;
                case 3:
                    ActualizarMedicamento();
                    break;
                case 4:
                    EliminarMedicamento();
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

        Console.WriteLine("Medicamento agregado");
    }

    static void MostrarMedicamentos()
    {
        if (lista.Count == 0)
        {
            Console.WriteLine("No hay medicamentos registrados");
            return;
        }

        Console.WriteLine("Medicamentos registrados: ");

        foreach (var m in lista)
        {
            Console.WriteLine($"ID: {m.Id}");
            Console.WriteLine($"Nombre: {m.Nombre}");
            Console.WriteLine($"Precio: {m.Precio}");
            Console.WriteLine($"Cantidad: {m.Cantidad}");
            Console.WriteLine($"Fecha de vencimiento: {m.FechaDeVencimiento:dd/MM/yyyy}");
        }
    }

    static void ActualizarMedicamento()
    {
        Console.Write("Ingrese el ID del medicamento a actualizar: ");
        int id = int.Parse(Console.ReadLine());

        var medicamento = lista.Find(m => m.Id == id);

        if (medicamento == null)
        {
            Console.WriteLine("Medicamento no encontrado");
            return;
        }

        Console.Write("Nuevo nombre: ");
        medicamento.Nombre = Console.ReadLine();

        Console.WriteLine("Nuevo precio: ");
        medicamento.Precio = double.Parse(Console.ReadLine());

        Console.WriteLine("Nueva cantidad: ");
        medicamento.Cantidad = int.Parse(Console.ReadLine());

        Console.WriteLine("Nueva fecha de vencimiento (dd/MM/yyyy): ");
        medicamento.FechaDeVencimiento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        Console.WriteLine("Datos actualizado exitosamente");
    }

    static void EliminarMedicamento()
    {
        Console.Write("Ingrese el ID del medicamento a eliminar: ");
        int id = int.Parse(Console.ReadLine());

        var medicamento = lista.Find(m => m.Id == id);

        if (medicamento == null)
        {
            Console.WriteLine("Medicamento no encontrado");
            return;
        }

        lista.Remove(medicamento);
        Console.WriteLine("Medicamento eliminado exitosamente");
    }
}