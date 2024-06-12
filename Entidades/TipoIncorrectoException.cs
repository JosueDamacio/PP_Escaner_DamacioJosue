using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoIncorrectoException : Exception
    {
        string nombreClase;
        string nombreMetodo;

        public string NombreClase { get => nombreClase; }
        public string NombreMetodo { get => nombreMetodo; }

        public TipoIncorrectoException(string mensaje, string nombreClase,
            string nombreMetodo)
            : this(mensaje, nombreClase, nombreMetodo, new Exception()) { }

        public TipoIncorrectoException(string mensaje, string nombreClase,
            string nombreMetodo, Exception innerException)
            : base(mensaje, innerException)
        {
            this.nombreClase = nombreClase;
            this.nombreMetodo = nombreMetodo;
        }

        public override string ToString()
        {
            StringBuilder msg = new StringBuilder();

            msg.AppendLine($"Excepción en el método {this.NombreMetodo} de la clase {this.NombreClase}.");
            msg.AppendLine("Algo salió mal, revisa los detalles.");
            msg.AppendLine($"Detalles: {this.InnerException}");
            return msg.ToString();
        }

    }
}
