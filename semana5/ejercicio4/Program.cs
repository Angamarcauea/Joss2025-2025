using System;

class Program
{
    static void Main()
    {
        // Pedir al usuario que escriba una palabra
        Console.Write("Escribe una palabra: ");
        string palabra = Console.ReadLine();

        // Convertimos la palabra a minúsculas para que no importe mayúsculas o minúsculas
        palabra = palabra.ToLower();

        // Invertimos la palabra
        char[] letras = palabra.ToCharArray();
        Array.Reverse(letras);
        string palabraInvertida = new string(letras);

        // Comparamos la palabra original con la invertida
        if (palabra == palabraInvertida)
        {
            Console.WriteLine("La palabra es un palíndromo.");
        }
        else
        {
            Console.WriteLine("La palabra no es un palíndromo.");
        }
    }
}
