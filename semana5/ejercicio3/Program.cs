using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Crear una lista con las letras del abecedario (A-Z)
        List<char> abecedario = new List<char>();
        for (char letra = 'A'; letra <= 'Z'; letra++)
        {
            abecedario.Add(letra);
        }

        Console.WriteLine("Abecedario completo:");
        foreach (char letra in abecedario)
        {
            Console.Write(letra + " ");
        }

        // Eliminar letras en posiciones múltiplos de 3 (como C, F, I, ...)
        // Recorremos al revés para que no cambien los índices al eliminar
        for (int i = abecedario.Count - 1; i >= 0; i--)
        {
            // (i + 1) es la posición real (1, 2, 3...), no el índice
            if ((i + 1) % 3 == 0)
            {
                abecedario.RemoveAt(i);
            }
        }

        // Mostrar la lista después de eliminar
        Console.WriteLine("\n\nAbecedario sin las letras en posiciones múltiplos de 3:");
        foreach (char letra in abecedario)
        {
            Console.Write(letra + " ");
        }

        Console.WriteLine(); // salto de línea final
    }
}
