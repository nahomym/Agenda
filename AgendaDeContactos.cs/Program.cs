using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaDeContactos.cs
{
    class Program
    {
        public static List<Contacto> Contactos = new List<Contacto>();
        public static Contacto Contact = new Contacto();
        public static int incId = 0;
        public static bool precarga = true;

        static void Main()
        {
            Precarga();

            Console.Clear();

            ImprimeLinea("AGENDA DE CONTACTOS");
            Linea(2);
            ImprimeLinea("1. Agrega nuevo Contacto.");
            ImprimeLinea("2. Muestra todos los contactos.");
            ImprimeLinea("3. Buscar contacto por ID.");
            ImprimeLinea("4. Buscar contacto por Nombre.");
            Linea();
            ImprimeLinea("5. Salir del Sistema.");
            Linea(3);

            Console.Write("Inserta opcion: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    {
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();

                        Console.Write("Telefono: ");
                        string telefono = Console.ReadLine();

                        Console.Write("Email: ");
                        string email = Console.ReadLine();

                        AgregarContacto(nombre, telefono, email);

                        ImprimeLinea("Contacto agregado satisfactoriamente.");
                        Espera();
                        Main();
                    }
                    break;

                case "2":
                    {
                        Console.Clear();
                        ImprimeLinea("Muestra Lista de Contactos");
                        Linea();
                        MostrarContactos();
                    }
                    break;

                case "3":
                    Console.Clear();
                    Console.Write("Codigo a buscar: ");
                    int numero = int.Parse(Console.ReadLine());
                    
                    var idEncontrado = BuscaPorId(numero);

                    ImprimeLinea(idEncontrado.Id + " + " + idEncontrado.Nombre + " + " + idEncontrado.Telefono + " + " + idEncontrado.Email);

                    Espera();
                    Main();
                    break;

                case "4":
                    Console.Clear();
                    Console.Write("Nombre a buscar: ");
                    string name = Console.ReadLine();
                    
                    var nomEncontrado = BuscaPorNombre(name);

                    ImprimeLinea(nomEncontrado.Id + " + " + nomEncontrado.Nombre + " + " + nomEncontrado.Telefono + " + " + nomEncontrado.Email);

                    Espera();
                    Main();
                    break;

                case "5":
                    Environment.Exit(0);
                    break;

                default:
                    ImprimeLinea("Esta no es una opcion valida, intentelo de nuevo.");
                        Main();
                    break;
            }
        }

        public static Contacto BuscaPorId(int id)
        {
            return Contactos.FirstOrDefault(x => x.Id == id);       
        }

        public static Contacto BuscaPorNombre(string nombre)
        {
            return Contactos.FirstOrDefault(x => x.Nombre == nombre);
        }

        public static void AgregarContacto(string nombre, string telefono, string email)
        {
            incId = incId + 1;
            Contactos.Add(new Contacto(){Id = incId, Nombre = nombre, Telefono = telefono, Email = email});               
        }

        public static void MostrarContactos()
        {
            foreach (var con in Contactos)
            {
                ImprimeLinea(con.Id.ToString() + " + " + con.Nombre + " + " + con.Telefono + " + " + con.Email);
            }
            Espera();
            Main();
        }


        public static void Precarga()
        {
            while (precarga)
            {
                AgregarContacto("Nahomy Medina", "809-923-6823", "nahomymedina@gmail.com");
                AgregarContacto("Cinthia Medina", "809-820-2527", "cinthiamedina@gmail.com");
                AgregarContacto("Nohemi Medina", "809-913-6873", "nohemimedina@gmail.com");
                AgregarContacto("Nehemias Medina", "809-321-9821", "nehemiasmedina@gmail.com");

                precarga = false;
            }
        }

        public static void ImprimeLinea(string t)
        {
            Console.WriteLine(t);
        }

        public static void Linea()
        {
            Console.WriteLine();
        }

        public static void Linea(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();  
            }
            
        }

        public static void Espera()
        {
            Console.ReadKey();
        }
    }
}
