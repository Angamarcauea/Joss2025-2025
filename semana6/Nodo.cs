using System;

namespace ListaEnlazadaEjercicios
{
    // Clase que representa un nodo individual en la lista enlazada.
    // Cada nodo contiene un dato y una referencia al siguiente nodo.
    public class Nodo
    {
        public int Dato;          // El valor entero almacenado en este nodo.
        public Nodo? Siguiente;   // Referencia al siguiente nodo en la secuencia de la lista.
                                 

        // Constructor para inicializar un nuevo nodo.
        public Nodo(int dato)
        {
            Dato = dato;
            Siguiente = null; // Un nuevo nodo no apunta a nada por defecto.
        }
    }
}