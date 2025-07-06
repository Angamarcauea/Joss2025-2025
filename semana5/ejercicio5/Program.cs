using System;

class Program
{
    static void Main()
    {
        // Pedir una palabra al usuario
        Console.Write("Escribe una palabra: ");
        string palabra = Console.ReadLine().ToLower(); // Convertir a minúsculas

        // Contadores para cada vocal
        int a = 0, e = 0, i = 0, o = 0, u = 0;

        // Recorrer cada letra de la palabra
        foreach (char letra in palabra)
        {
            if (letra == 'a') a++;
            else if (letra == 'e') e++;
            else if (letra == 'i') i++;
            else if (letra == 'o') o++;
            else if (letra == 'u') u++;
        }

        // Mostrar el resultado
        Console.WriteLine("\nCantidad de cada vocal:");
        Console.WriteLine($"A: {a}");
        Console.WriteLine($"E: {e}");
        Console.WriteLine($"I: {i}");
        Console.WriteLine($"O: {o}");
        Console.WriteLine($"U: {u}");
    }
}
