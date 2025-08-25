using System;
using System.Collections.Generic;
using System.Linq;

namespace VacunacionCovid
{
    class Programa
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Registro de Vacunación COVID-19 ===\n");

            int poblacionTotal = 500;
            int dosisPfizer = 75;
            int dosisAstraZeneca = 75;

            // Crear listado general de ciudadanos
            var ciudadanos = CrearPoblacion(poblacionTotal);
            var grupoPfizer = SeleccionarVacunados(dosisPfizer, poblacionTotal);
            var grupoAstraZeneca = SeleccionarVacunados(dosisAstraZeneca, poblacionTotal);

            // Operaciones de conjuntos
            var vacunados = grupoPfizer.Union(grupoAstraZeneca).ToHashSet();
            var sinVacuna = ciudadanos.Except(vacunados).ToHashSet();
            var dobleDosis = grupoPfizer.Intersect(grupoAstraZeneca).ToHashSet();
            var unicamentePfizer = grupoPfizer.Except(grupoAstraZeneca).ToHashSet();
            var unicamenteAstra = grupoAstraZeneca.Except(grupoPfizer).ToHashSet();

            // Resumen general
            Console.WriteLine($"Población total registrada: {poblacionTotal}");
            Console.WriteLine($"Personas vacunadas con Pfizer: {grupoPfizer.Count}");
            Console.WriteLine($"Personas vacunadas con AstraZeneca: {grupoAstraZeneca.Count}");
            Console.WriteLine($"Total de personas vacunadas: {vacunados.Count}");
            Console.WriteLine($"Personas aún sin vacuna: {sinVacuna.Count}");
            Console.WriteLine($"Con ambas dosis: {dobleDosis.Count}");
            Console.WriteLine($"Solo con Pfizer: {unicamentePfizer.Count}");
            Console.WriteLine($"Solo con AstraZeneca: {unicamenteAstra.Count}\n");

            // Listados
            MostrarListado(">> Lista Pfizer", grupoPfizer);
            MostrarListado(">> Lista AstraZeneca", grupoAstraZeneca);
            MostrarListado(">> Personas con las dos vacunas", dobleDosis);
            MostrarListado(">> Solo Pfizer", unicamentePfizer);
            MostrarListado(">> Solo AstraZeneca", unicamenteAstra);
            MostrarListado(">> Personas sin vacunar", sinVacuna);

            Console.WriteLine("\n=== Fin del registro ===");
        }

        // Genera ciudadanos con nombres únicos
        static HashSet<string> CrearPoblacion(int cantidad)
        {
            var lista = new HashSet<string>();
            for (int i = 1; i <= cantidad; i++)
                lista.Add($"Persona {i}");
            return lista;
        }

        // Selecciona vacunados al azar
        static HashSet<string> SeleccionarVacunados(int cantidad, int limite)
        {
            var seleccionados = new HashSet<string>();
            Random aleatorio = new Random();
            while (seleccionados.Count < cantidad)
            {
                int num = aleatorio.Next(1, limite + 1);
                seleccionados.Add($"Persona {num}");
            }
            return seleccionados;
        }

        // Imprime un listado sencillo
        static void MostrarListado(string titulo, HashSet<string> grupo)
        {
            Console.WriteLine(titulo);
            Console.WriteLine(string.Join(", ", grupo));
            Console.WriteLine();
        }
    }
}
