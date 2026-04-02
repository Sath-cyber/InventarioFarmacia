using System;
using System.Collections.Generic;
using System.Globalization;

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
            Console.Clear();
            Console.WriteLine("==================================");
            Console.WriteLine("     [Inventario de Farmacia]     ");
            Console.WriteLine("==================================");
            Console.WriteLine("1. Crear medicamento");
            Console.WriteLine("2. Ver medicamentos");
            Console.WriteLine("3. Actualizar medicamento");
            Console.WriteLine("4. Eliminar medicamento");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opcion: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opcion invalida.");
                Pausa();
                continue;
            }

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
                case 5:
                    Console.WriteLine("Saliendo del programa");
                    break;
                default:
                    Console.WriteLine("Opcion no valida, intente con las opciones vistas en pantalla");
                    Pausa();
                    break;
            }

        } while (opcion != 5);
    }

    static void CrearMedicamento()
    {
        Console.Clear();
        Console.WriteLine("=== [Registrar Medicamento] ===");

        Medicamento m = new Medicamento();

        Console.Write("Nombre: ");
        m.Nombre = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(m.Nombre))
        {
            Console.WriteLine("El nombre no puede estar vacio, inserte un nombre");
            Pausa();
            return;
        }

        Console.Write("Precio: ");
        if (!double.TryParse(Console.ReadLine(), out double precio))
        {
            Console.WriteLine("Precio invalido, inserte un valor correcto para el precio");
            Pausa();
            return;
        }

        Console.Write("Cantidad: ");
        if (!int.TryParse(Console.ReadLine(), out int cantidad))
        {
            Console.WriteLine("Cantidad invalida, inserte un valor correcto para la cantidad");
            Pausa();
            return;
        }

        Console.Write("Fecha de vencimiento (dd/MM/yyyy): ");
        if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha))
        {
            Console.WriteLine("Fecha invalida, inserte una fecha valida para el medicamento");
            Pausa();
            return;
        }

        m.Precio = precio;
        m.Cantidad = cantidad;
        m.FechaDeVencimiento = fecha;
        m.Id = idActual++;

        lista.Add(m);

        Console.WriteLine("Medicamento agregado exitosamente");
        Pausa();
    }

    static void MostrarMedicamentos()
    {
        Console.Clear();
        Console.WriteLine("=== [Medicamentos Registrados] ===");

        if (lista.Count == 0)
        {
            Console.WriteLine("No hay medicamentos registrados actualmente");
            Pausa();
            return;
        }

        foreach (var m in lista)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"ID: {m.Id}");
            Console.WriteLine($"Nombre: {m.Nombre}");
            Console.WriteLine($"Precio: {m.Precio}");
            Console.WriteLine($"Cantidad: {m.Cantidad}");
            Console.WriteLine($"Fecha de vencimiento: {m.FechaDeVencimiento:dd/MM/yyyy}");
        }

        Console.WriteLine("----------------------------------");
        Pausa();
    }

    static void ActualizarMedicamento()
    {
        Console.Clear();
        Console.WriteLine("=== [Actualizar datos del medicamento] ===");

        Console.Write("Ingrese el ID del medicamento a actualizar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID invalido, por favor ingrese un ID valido");
            Pausa();
            return;
        }

        var medicamento = lista.Find(m => m.Id == id);

        if (medicamento == null)
        {
            Console.WriteLine("Medicamento no encontrado");
            Pausa();
            return;
        }

        Console.Write("Nuevo nombre: ");
        string nuevoNombre = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(nuevoNombre))
        {
            Console.WriteLine("El nombre no puede estar vacio");
            Pausa();
            return;
        }

        Console.Write("Nuevo precio: ");
        if (!double.TryParse(Console.ReadLine(), out double nuevoPrecio))
        {
            Console.WriteLine("Precio invalido, por favor intente un valor correcto");
            Pausa();
            return;
        }

        Console.Write("Nueva cantidad: ");
        if (!int.TryParse(Console.ReadLine(), out int nuevaCantidad))
        {
            Console.WriteLine("Cantidad invalida, por favor intente una cantidad correcta");
            Pausa();
            return;
        }

        Console.Write("Nueva fecha de vencimiento (dd/MM/yyyy): ");
        if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime nuevaFecha))
        {
            Console.WriteLine("Fecha invalida, por favor intente una fecha correcta");
            Pausa();
            return;
        }

        medicamento.Nombre = nuevoNombre;
        medicamento.Precio = nuevoPrecio;
        medicamento.Cantidad = nuevaCantidad;
        medicamento.FechaDeVencimiento = nuevaFecha;

        Console.WriteLine("Datos de medicamento actualizados exitosamente");
        Pausa();
    }

    static void EliminarMedicamento()
    {
        Console.Clear();
        Console.WriteLine("=== [Eliminar Medicamento Registrado] ===");

        Console.Write("Ingrese el ID del medicamento a eliminar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID invalido, por favor inserte un ID valido");
            Pausa();
            return;
        }

        var medicamento = lista.Find(m => m.Id == id);

        if (medicamento == null)
        {
            Console.WriteLine("Medicamento no encontrado");
            Pausa();
            return;
        }

        Console.Write($"Seguro que desea eliminar '{medicamento.Nombre}'? (s/n): ");
        string respuesta = (Console.ReadLine() ?? "").ToLower();

        if (respuesta == "s")
        {
            lista.Remove(medicamento);
            Console.WriteLine("Medicamento eliminado exitosamente");
        }
        else
        {
            Console.WriteLine("Operacion cancelada");
        }

        Pausa();
    }

    static void Pausa()
    {
        Console.WriteLine("\nPresione una tecla para volver al menu...");
        Console.ReadKey();
    }
}