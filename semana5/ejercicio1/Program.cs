﻿using System;
using System.Collections.Generic;

namespace ListasYTuplas
{
    class Curso
    {
        private List<string> asignaturas;

        public Curso()
        {
            asignaturas = new List<string>();
            asignaturas.Add("MATEMATICAS");
            asignaturas.Add("FISICA");
            asignaturas.Add("QUIMICA");
            asignaturas.Add("HISTORIA");
            asignaturas.Add("LENGUA ESPAÑOLA");
        }

        public void MostrarAsignaturasEstudio()
        {
            foreach (string asignatura in asignaturas)
            {
                Console.WriteLine("YO ESTUDIO " + asignatura);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Curso curso = new Curso();
            curso.MostrarAsignaturasEstudio();

            Console.WriteLine("\nPresiona ENTER para salir...");
            Console.ReadLine();
        }
    }
}