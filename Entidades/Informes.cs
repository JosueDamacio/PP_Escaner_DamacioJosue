using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Documento;

namespace Entidades
{
    public static class Informes
    {
        #region Métodos

        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.Distribuido, out extension, out cantidad, out resumen);
        }

        private static void MostrarDocumentosPorEstado(Escaner e, Paso estado, out int extension,
            out int cantidad,out string resumen)
        {
            int totalExtension = 0;
            int totalCantidad = 0;

            StringBuilder sbResumen = new StringBuilder();
            // este foreach recorrerá la lista de documentos de escaner y agregará a sbResumen
            // segun el estado que se le pase por parametro
            foreach (Documento doc in e.ListaDocumentos)
            {
                if (doc.Estado == estado)
                {
                    totalCantidad++;
                    sbResumen.AppendLine(doc.ToString());
                    if (doc is Libro l)
                    {
                        totalExtension += l.NumPaginas;
                    }
                    else if (doc is Mapa m)
                    {
                        totalExtension += m.Superficie;
                    }
                }
            }
            if (totalCantidad != 0)
            {
                extension = totalExtension;
                cantidad = totalCantidad;
                resumen = sbResumen.ToString();
            }
            else
            {
                extension = 0;
                cantidad = 0;
                resumen = "";
            }
        }

        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.EnEscaner, out extension, out cantidad, out resumen);
        }

        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.EnRevision, out extension, out cantidad, out resumen);
        }

        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.Terminado, out extension, out cantidad, out resumen);
        }

        #endregion

    }
}
