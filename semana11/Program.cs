using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class DiccionarioTraductor
{
    // Archivo donde se guardarán las palabras
    static string archivoPalabras = "palabras.json";

    // Cargar el diccionario desde el archivo
    static Dictionary<string, string> LeerPalabras()
    {
        if (File.Exists(archivoPalabras))
        {
            string contenido = File.ReadAllText(archivoPalabras);
            return JsonSerializer.Deserialize<Dictionary<string, string>>(contenido);
        }
        else
        {
            return new Dictionary<string, string>();
        }
    }

    // Guardar el diccionario en el archivo
    static void GuardarPalabras(Dictionary<string, string> palabras)
    {
        string contenido = JsonSerializer.Serialize(palabras, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(archivoPalabras, contenido);
    }

    // Traducir una oración
    static void TraducirOracion(Dictionary<string, string> palabras)
    {
        Console.Write("Escriba una oración: ");
        string oracion = Console.ReadLine();
        string[] listaPalabras = oracion.Split(' ');

        Console.Write("Resultado: ");
        foreach (var p in listaPalabras)
        {
            if (palabras.ContainsKey(p.ToLower()))
                Console.Write(palabras[p.ToLower()] + " ");
            else
                Console.Write(p + " "); // Si no existe, se queda igual
        }
        Console.WriteLine();
    }

    // Agregar una palabra nueva
    static void InsertarPalabra(Dictionary<string, string> palabras)
    {
        Console.Write("Palabra en español: ");
        string espanol = Console.ReadLine().ToLower();

        if (palabras.ContainsKey(espanol))
        {
            Console.WriteLine("Ya existe esa palabra en el archivo.");
            return;
        }

        Console.Write("Su traducción al inglés: ");
        string ingles = Console.ReadLine();

        palabras[espanol] = ingles;
        GuardarPalabras(palabras);
        Console.WriteLine("Palabra guardada exitosamente.");
    }

    static void Main(string[] args)
    {
        Dictionary<string, string> palabras = LeerPalabras();

        int opcion;
        do
        {
            Console.WriteLine("\n========= MENÚ PRINCIPAL =========");
            Console.WriteLine("1. Traducir oración");
            Console.WriteLine("2. Añadir palabra nueva");
            Console.WriteLine("0. Terminar");
            Console.Write("Elija una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    TraducirOracion(palabras);
                    break;
                case 2:
                    InsertarPalabra(palabras);
                    break;
                case 0:
                    Console.WriteLine("Programa finalizado.");
                    break;
                default:
                    Console.WriteLine("Opción incorrecta.");
                    break;
            }
        } while (opcion != 0);
    }
}
