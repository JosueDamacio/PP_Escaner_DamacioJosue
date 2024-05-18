using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Documento
    {
        int anio;
        string autor;
        string barcode;
        Paso estado;
        string numNormalizado;
        string titulo;
        
        public enum Paso
        {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }
        #region Propiedades

        public int Anio {get => this.anio; }

        public string Autor {get => this.autor;}

        public string Barcode {get => this.barcode;}

        public Paso Estado {get => this.estado;}

        protected string NumNormalizado {get => this.numNormalizado;}

        public string Titulo {get => this.titulo;}
        #endregion

        #region Metodos

        public bool AvanzarEstado()
        {
            bool retorno = false;

            //obtengo los valores de paso en una matriz
            Paso[] pasos = (Paso[])Enum.GetValues(typeof(Paso));

            int pasoActual = Array.IndexOf(pasos, this.estado);

            if (pasoActual >= 0 && pasoActual < pasos.Length - 1)
            {
                this.estado = pasos[pasoActual +1];
                retorno = true;
            }
            else
            {
                return retorno;
            }
            return retorno;

        }

        public Documento(string titulo, string autor, int anio, string numNormalizado, string barcode)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
            this.estado = Paso.Inicio;
        }
        
        //le hacemos override para no repetir codigo y usarlo en clases hijas ;D
        public override string ToString()
		{
			StringBuilder informacion = new StringBuilder();
            informacion.AppendLine($"Título: {this.titulo}");
            informacion.AppendLine($"Autor: {this.autor}");
            informacion.AppendLine($"Año: {this.anio}");
            return informacion.ToString();
		}

        #endregion



    }
}
