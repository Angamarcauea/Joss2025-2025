using System;

namespace ListaEnlazadaEjercicios
{
    // Implementa una lista enlazada simple.
    public class ListaEnlazada
    {
        public Nodo? cabeza; // Primer nodo de la lista.

        // Constructor: lista vacía.
        public ListaEnlazada()
        {
            cabeza = null;
        }

        // Agrega nodo al inicio.
        public void AgregarInicio(int dato)
        {
            Nodo nuevo = new Nodo(dato);
            nuevo.Siguiente = cabeza;
            cabeza = nuevo;
        }

        // Agrega nodo al final.
        public void AgregarFinal(int dato)
        {
            Nodo nuevo = new Nodo(dato);
            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
            }
        }

        // Cuenta elementos de la lista.
        public int Contar()
        {
            int contador = 0;
            Nodo? actual = cabeza;
            while (actual != null)
            {
                contador++;
                actual = actual.Siguiente;
            }
            return contador;
        }

        // Muestra elementos de la lista.
        public void Mostrar()
        {
            if (cabeza == null)
            {
                Console.WriteLine("Lista vacía.");
                return;
            }

            Nodo? actual = cabeza;
            while (actual != null)
            {
                Console.Write(actual.Dato + " ");
                actual = actual.Siguiente;
            }
            Console.WriteLine();
        }

        // Invierte la lista enlazada.
        public void Invertir()
        {
            if (cabeza == null || cabeza.Siguiente == null)
            {
                return; // Lista vacía o con un solo nodo.
            }

            Nodo? prev = null;
            Nodo? current = cabeza;
            Nodo? next = null;

            while (current != null)
            {
                next = current.Siguiente;
                current.Siguiente = prev;
                prev = current;
                current = next;
            }

            cabeza = prev; // 'prev' es la nueva cabeza.
        }
    }
}