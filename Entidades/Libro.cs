using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Documento
    {
        int numPaginas;

        #region Propiedades

        public string ISBN
        {
            get => NumNormalizado;
        }
        public int NumPaginas
        {
            get => this.numPaginas;
        }

        #endregion

        #region Metodos

        public Libro(string titulo, string autor, int anio, string numNormalizado, string barcode, int numPaginas)
            : base(titulo, autor, anio, numNormalizado, barcode)
        {
            this.numPaginas = numPaginas;
        }

        public static bool operator !=(Libro l1, Libro l2)
        {
            return !(l1 == l2);
        }

        public static bool operator ==(Libro l1, Libro l2)
        {
            return l1.Barcode == l2.Barcode || l1.ISBN == l2.ISBN ||
                l1.Titulo == l2.Titulo && l1.Autor == l2.Autor;
        }


        public override string ToString()
        {
            StringBuilder informacion = new StringBuilder();
            informacion.Append(base.ToString());
            informacion.AppendLine($"ISBN: {this.ISBN}");
            informacion.AppendLine($"Cód. de barras: {this.Barcode}");
            informacion.AppendLine($"Número de páginas: {this.numPaginas}.");
            return informacion.ToString();
        }


        #endregion


    }
}
