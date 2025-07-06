using System;

namespace ListaEnlazadaEjercicios
{
    public static class Ejercicio02
    {
        public static void Ejecutar()
        {
            Console.WriteLine("\n--- Ejercicio 02: Invertir Lista ---");

            ListaEnlazada miLista = new ListaEnlazada();
            
            Console.WriteLine("Creando lista: 1->2->3->4->5");
            miLista.AgregarFinal(1);
            miLista.AgregarFinal(2);
            miLista.AgregarFinal(3);
            miLista.AgregarFinal(4);
            miLista.AgregarFinal(5);

            Console.Write("Original: ");
            miLista.Mostrar();

            Console.WriteLine("Invirtiendo...");
            miLista.Invertir();

            Console.Write("Invertida: ");
            miLista.Mostrar();
            
            Console.WriteLine("\nPrueba con lista vacía:");
            ListaEnlazada listaVacia = new ListaEnlazada();
            Console.Write("Original: ");
            listaVacia.Mostrar();
            listaVacia.Invertir();
            Console.Write("Invertida: ");
            listaVacia.Mostrar();

            Console.WriteLine("\nPrueba con un elemento:");
            ListaEnlazada listaUnElemento = new ListaEnlazada();
            listaUnElemento.AgregarFinal(99);
            Console.Write("Original: ");
            listaUnElemento.Mostrar();
            listaUnElemento.Invertir();
            Console.Write("Invertida: ");
            listaUnElemento.Mostrar();


            Console.WriteLine("\nFin Ejercicio 02. Presione tecla...");
            Console.ReadKey();
        }
    }
}