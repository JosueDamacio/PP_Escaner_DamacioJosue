using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Escaner;
using Entidades;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // LIBROS
            // Caminos felices
            Libro libro_1 = new Libro("Yerma", "García Lorca, Federico", 1995, "11111", "22222", 100);
            Libro l2 = new Libro("Bodas de sangre", "García Lorca, Federico", 1997, "11112", "22223", 200);
            Libro l3 = new Libro("Codebar repetido", "García Lorca, Federico", 2003, "11113", "22222", 3);
            Libro l4 = new Libro("ISBN repetido", "García Lorca, Federico", 2003, "11112", "22224", 2);
            Libro l5 = new Libro("Yerma", "García Lorca, Federico", 2003, "55555", "66666", 1);

            //MAPAS 
            // Caminos felices
            Mapa mapa_1 = new Mapa("Buenos Aires", "Instituto Geográfico de Buenos Aires", 2005, "", "99999", 30, 15); //450
            Mapa m2 = new Mapa("Mendoza", "Instituto Geográfico de Mendoza", 2008, "", "99990", 100, 30); //300
            Mapa m3 = new Mapa("Santa Fe", "Instituto Geográfico de Santa Fe", 2010, "", "99991", 80, 30); //2400
            Mapa m4 = new Mapa("Corrientes", "Instituto Geográfico de Corrientes", 2013, "", "99992", 50, 25); //1250
            // Barcode repetido
            Mapa m5 = new Mapa("Barcode repetido", "Instituto Geográfico", 2015, "", "99999", 40, 15);//600
            // Título - autor - superficie
            Mapa m6 = new Mapa("Buenos Aires", "Instituto Geográfico de Buenos Aires", 2005, "", "99993", 30, 15);//200

            //ESCANERS
            Escaner escanerDeLibros = new Escaner("HP", Escaner.TipoDoc.libro);
            Escaner escanerDeMapas = new Escaner("HP", Escaner.TipoDoc.mapa);

            bool pudo = escanerDeLibros + libro_1;
            pudo = escanerDeLibros + l2;
            pudo = escanerDeLibros + l3;
            pudo = escanerDeLibros + l4;
            pudo = escanerDeLibros + l5;
            pudo = escanerDeMapas + mapa_1;
            pudo = escanerDeMapas + m2;
            pudo = escanerDeMapas + m3;
            pudo = escanerDeMapas + m4;
            pudo = escanerDeMapas + m5;
            pudo = escanerDeMapas + m6;





            Console.WriteLine("ZONA DE PRUEBAS EXCEPCIONES:");
            Console.WriteLine("");
            Console.WriteLine("----------------------------");
            //ZONA DE PRUEBAS

            bool pudo1 = escanerDeLibros + l3;

            try
            {
                pudo1 = escanerDeLibros + mapa_1;
            }
            catch (TipoIncorrectoException ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("----------------------------");







            libro_1.AvanzarEstado();
            libro_1.AvanzarEstado();
            l2.AvanzarEstado();
            l2.AvanzarEstado();
            m2.AvanzarEstado();
            m3.AvanzarEstado();
            m3.AvanzarEstado();
            m3.AvanzarEstado();
            m4.AvanzarEstado();
            m4.AvanzarEstado();
            m4.AvanzarEstado();
            m4.AvanzarEstado();
            m4.AvanzarEstado();

            Informes.MostrarDistribuidos(escanerDeLibros, out int extensionLibroDistr, out int cantidadLibroDistr, out string resumenLibroDistr);
            Informes.MostrarEnEscaner(escanerDeLibros, out int extensionLibroEnEsc, out int cantidadLibroEnEsc, out string resumenLibroEnEsc);
            Informes.MostrarEnRevision(escanerDeLibros, out int extensionLibroEnRev, out int cantidadLibroEnRev, out string resumenLibroEnRev);
            Informes.MostrarTerminados(escanerDeLibros, out int extensionLibroTerminado, out int cantidadLibroTerminado, out string resumenLibroTerminado);

            Informes.MostrarDistribuidos(escanerDeMapas, out int extensionMapaDistr, out int cantidadMapaDistr, out string resumenMapaDistr);
            Informes.MostrarEnEscaner(escanerDeMapas, out int extensionMapaEnEsc, out int cantidadMapaEnEsc, out string resumenMapaEnEsc);
            Informes.MostrarEnRevision(escanerDeMapas, out int extensionMapaEnRev, out int cantidadMapaEnRev, out string resumenMapaEnRev);
            Informes.MostrarTerminados(escanerDeMapas, out int extensionMapaTerminado, out int cantidadMapaTerminado, out string resumenMapaTerminado);

            int puntos = 0;

            if (extensionLibroDistr == 0) { puntos += 3; }
            if (cantidadLibroDistr == 0) { puntos += 1; }
            if (resumenLibroDistr == "") { puntos += 1; }

            if (extensionLibroEnEsc == 0) { puntos += 3; }
            if (cantidadLibroEnEsc == 0) { puntos += 1; }
            if (resumenLibroEnEsc == "") { puntos += 1; }

            if (extensionLibroEnRev == libro_1.NumPaginas + l2.NumPaginas) { puntos += 3; }
            if (cantidadLibroEnRev == 2) { puntos += 1; }
            if (resumenLibroEnRev == libro_1.ToString() + l2.ToString()) { puntos += 1; }

            if (extensionLibroTerminado == 0) { puntos += 3; }
            if (cantidadLibroTerminado == 0) { puntos += 1; }
            if (resumenLibroTerminado == "") { puntos += 1; }

            if (extensionMapaDistr == mapa_1.Superficie) { puntos += 4; }
            if (cantidadMapaDistr == 1) { puntos += 1; }
            if (resumenMapaDistr == mapa_1.ToString()) { puntos += 1; }

            if (extensionMapaEnEsc == m2.Superficie) { puntos += 3; }
            if (cantidadMapaEnEsc == 1) { puntos += 1; }
            if (resumenMapaEnEsc == m2.ToString()) { puntos += 1; }

            if (extensionMapaEnRev == 0) { puntos += 4; }
            if (cantidadMapaEnRev == 0) { puntos += 1; }
            if (resumenMapaEnRev == "") { puntos += 1; }

            if (extensionMapaTerminado == m3.Superficie + m4.Superficie) { puntos += 3; }
            if (cantidadMapaTerminado == 2) { puntos += 1; }
            if (resumenMapaTerminado == m3.ToString() + m4.ToString()) { puntos += 1; }

            Console.WriteLine($"Puntos: {puntos} / 40");


            Console.WriteLine("LIBROS DISTRIBUIDOS");
            Console.WriteLine($"Cantidad de libros ya distribuidos: {cantidadLibroDistr}.");
            Console.WriteLine($"Cantidad de páginas ya distribuidas: {extensionLibroDistr}.");
            Console.WriteLine(resumenLibroDistr);
            Console.WriteLine("---------------------");

            Console.WriteLine("LIBROS EN ESCANER");
            Console.WriteLine($"Cantidad de libros en el escáner: {cantidadLibroEnEsc}.");
            Console.WriteLine($"Cantidad de páginas en el escáner: {extensionLibroEnEsc}.");
            Console.WriteLine(resumenLibroEnEsc);
            Console.WriteLine("---------------------");


            Console.WriteLine("LIBROS EN REVISIÓN");
            Console.WriteLine($"Cantidad de libros en el escáner: {cantidadLibroEnRev}.");
            Console.WriteLine($"Cantidad de páginas en el escáner: {extensionLibroEnRev}.");
            Console.WriteLine(resumenLibroEnRev);
            Console.WriteLine("---------------------");

            Console.WriteLine("LIBROS TERMINADOS");
            Console.WriteLine($"Cantidad de mapas en el escáner: {cantidadLibroTerminado}.");
            Console.WriteLine($"Cantidad de cm2 en el escáner: {extensionLibroTerminado}.");
            Console.WriteLine(resumenLibroTerminado);
            Console.WriteLine("---------------------");

            Console.WriteLine("MAPAS DISTRIBUIDOS");
            Console.WriteLine($"Cantidad de mapas ya distribuidos: {cantidadMapaDistr}.");
            Console.WriteLine($"Cantidad de cm2 ya distribuidos: {extensionMapaDistr}.");
            Console.WriteLine(resumenMapaDistr);
            Console.WriteLine("---------------------");

            Console.WriteLine("MAPAS EN ESCANER");
            Console.WriteLine($"Cantidad de mapas en el escáner: {cantidadMapaEnEsc}.");
            Console.WriteLine($"Cantidad de cm2 en el escáner: {extensionMapaEnEsc}.");
            Console.WriteLine(resumenMapaEnEsc);
            Console.WriteLine("---------------------");

            Console.WriteLine("MAPAS EN REVISIÓN");
            Console.WriteLine($"Cantidad de mapas en el escáner: {cantidadMapaEnRev}.");
            Console.WriteLine($"Cantidad de cm2 en el escáner: {extensionMapaEnRev}.");
            Console.WriteLine(resumenMapaEnRev);
            Console.WriteLine("---------------------");

            Console.WriteLine("MAPAS TERMINADOS");
            Console.WriteLine($"Cantidad de mapas en el escáner: {cantidadMapaTerminado}.");
            Console.WriteLine($"Cantidad de cm2 en el escáner: {extensionMapaTerminado}.");
            Console.WriteLine(resumenMapaTerminado);
            Console.WriteLine("---------------------");

            Console.ReadKey();
        }

    }
}