using System;
using System.Collections.Generic;

// Representa un nodo en el árbol binario
class ElementoArbol
{
    public string Nombre;
    public ElementoArbol Izquierdo;
    public ElementoArbol Derecho;

    public ElementoArbol(string nombre)
    {
        Nombre = nombre;
    }
}

// Clase que maneja las operaciones del catálogo
class GestorCatalogo
{
    private ElementoArbol _nodoRaiz;

    // Agrega un nuevo título al árbol de forma recursiva
    public void Agregar(string nombre)
    {
        _nodoRaiz = InsertarEnArbol(_nodoRaiz, nombre);
    }

    private ElementoArbol InsertarEnArbol(ElementoArbol nodoActual, string nombre)
    {
        if (nodoActual == null)
        {
            return new ElementoArbol(nombre);
        }

        if (string.Compare(nombre, nodoActual.Nombre, StringComparison.OrdinalIgnoreCase) < 0)
        {
            nodoActual.Izquierdo = InsertarEnArbol(nodoActual.Izquierdo, nombre);
        }
        else if (string.Compare(nombre, nodoActual.Nombre, StringComparison.OrdinalIgnoreCase) > 0)
        {
            nodoActual.Derecho = InsertarEnArbol(nodoActual.Derecho, nombre);
        }
        return nodoActual;
    }

    // Elimina un título del árbol
    public void Borrar(string nombre)
    {
        _nodoRaiz = EliminarDeArbol(_nodoRaiz, nombre);
    }

    private ElementoArbol EliminarDeArbol(ElementoArbol nodoActual, string nombre)
    {
        if (nodoActual == null) return null;

        int comparacion = string.Compare(nombre, nodoActual.Nombre, StringComparison.OrdinalIgnoreCase);

        if (comparacion < 0)
        {
            nodoActual.Izquierdo = EliminarDeArbol(nodoActual.Izquierdo, nombre);
        }
        else if (comparacion > 0)
        {
            nodoActual.Derecho = EliminarDeArbol(nodoActual.Derecho, nombre);
        }
        else
        {
            // Casos de eliminación
            if (nodoActual.Izquierdo == null)
            {
                return nodoActual.Derecho;
            }
            if (nodoActual.Derecho == null)
            {
                return nodoActual.Izquierdo;
            }

            ElementoArbol sucesor = EncontrarMinimo(nodoActual.Derecho);
            nodoActual.Nombre = sucesor.Nombre;
            nodoActual.Derecho = EliminarDeArbol(nodoActual.Derecho, sucesor.Nombre);
        }
        return nodoActual;
    }

    // Encuentra el elemento más pequeño en un subárbol
    private ElementoArbol EncontrarMinimo(ElementoArbol nodo)
    {
        while (nodo.Izquierdo != null)
        {
            nodo = nodo.Izquierdo;
        }
        return nodo;
    }

    // Búsqueda iterativa de un título
    public bool ConsultarIterativo(string nombre)
    {
        ElementoArbol nodoActual = _nodoRaiz;
        while (nodoActual != null)
        {
            int comparacion = string.Compare(nombre, nodoActual.Nombre, StringComparison.OrdinalIgnoreCase);
            if (comparacion == 0) return true;
            if (comparacion < 0)
            {
                nodoActual = nodoActual.Izquierdo;
            }
            else
            {
                nodoActual = nodoActual.Derecho;
            }
        }
        return false;
    }

    // Búsqueda recursiva de un título
    public bool ConsultarRecursivo(string nombre)
    {
        return BuscarEnArbolRecursivo(_nodoRaiz, nombre);
    }

    private bool BuscarEnArbolRecursivo(ElementoArbol nodoActual, string nombre)
    {
        if (nodoActual == null) return false;
        int comparacion = string.Compare(nombre, nodoActual.Nombre, StringComparison.OrdinalIgnoreCase);
        if (comparacion == 0) return true;
        if (comparacion < 0)
        {
            return BuscarEnArbolRecursivo(nodoActual.Izquierdo, nombre);
        }
        else
        {
            return BuscarEnArbolRecursivo(nodoActual.Derecho, nombre);
        }
    }

    // Recorrido Inorden para obtener los títulos ordenados
    public List<string> ObtenerListaOrdenada()
    {
        var lista = new List<string>();
        RecorridoInorden(_nodoRaiz, lista);
        return lista;
    }

    private void RecorridoInorden(ElementoArbol nodoActual, List<string> lista)
    {
        if (nodoActual == null) return;
        RecorridoInorden(nodoActual.Izquierdo, lista);
        lista.Add(nodoActual.Nombre);
        RecorridoInorden(nodoActual.Derecho, lista);
    }
}

// Clase principal que ejecuta la aplicación
class Aplicacion
{
    static void Main(string[] args)
    {
        var gestor = new GestorCatalogo();

        // Cargar títulos iniciales de revistas de Ecuador
        string[] catalogoInicial = {
            "Vistazo", "Cosas", "Ekos",
            "Hogar", "Familia",
            "Gestión", "Revista Diners", "Siente",
            "Expresiones", "Revista Clave", "La Onda"
        };
        foreach (var titulo in catalogoInicial)
        {
            gestor.Agregar(titulo);
        }

        while (true)
        {
            Console.WriteLine("\n--- Menú ---");
            Console.WriteLine("1. Agregar título");
            Console.WriteLine("2. Eliminar título");
            Console.WriteLine("3. Buscar (Iterativo)");
            Console.WriteLine("4. Buscar (Recursivo)");
            Console.WriteLine("5. Mostrar títulos");
            Console.WriteLine("6. Salir");
            Console.Write("\nSeleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Título a agregar: ");
                    string nuevoTitulo = Console.ReadLine();
                    gestor.Agregar(nuevoTitulo);
                    Console.WriteLine("Título agregado.");
                    break;
                case "2":
                    Console.Write("Título a eliminar: ");
                    string tituloAEliminar = Console.ReadLine();
                    if (gestor.ConsultarIterativo(tituloAEliminar))
                    {
                        gestor.Borrar(tituloAEliminar);
                        Console.WriteLine("Título eliminado.");
                    }
                    else
                    {
                        Console.WriteLine("Título no encontrado.");
                    }
                    break;
                case "3":
                    Console.Write("Título a buscar: ");
                    string tituloBusquedaIterativa = Console.ReadLine();
                    bool encontradoIterativo = gestor.ConsultarIterativo(tituloBusquedaIterativa);
                    if (encontradoIterativo)
                    {
                        Console.WriteLine("Título encontrado.");
                    }
                    else
                    {
                        Console.WriteLine("Título no encontrado.");
                    }
                    break;
                case "4":
                    Console.Write("Título a buscar: ");
                    string tituloBusquedaRecursiva = Console.ReadLine();
                    bool encontradoRecursivo = gestor.ConsultarRecursivo(tituloBusquedaRecursiva);
                    if (encontradoRecursivo)
                    {
                        Console.WriteLine("Título encontrado.");
                    }
                    else
                    {
                        Console.WriteLine("Título no encontrado.");
                    }
                    break;
                case "5":
                    Console.WriteLine("\n--- Catálogo ---");
                    var listaOrdenada = gestor.ObtenerListaOrdenada();
                    if (listaOrdenada.Count > 0)
                    {
                        foreach (var titulo in listaOrdenada)
                        {
                            Console.WriteLine($" - {titulo}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("El catálogo está vacío.");
                    }
                    break;
                case "6":
                    Console.WriteLine("Saliendo...");
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}