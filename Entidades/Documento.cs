using System.Text;

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

        public int Anio { get => this.anio; }

        public string Autor { get => this.autor; }

        public string Barcode { get => this.barcode; }

        public Paso Estado { get => this.estado; }

        protected string NumNormalizado { get => this.numNormalizado; }

        public string Titulo { get => this.titulo; }
        #endregion

        #region Metodos

        public bool AvanzarEstado()
        //avanza al estado sigueinte siempre que no esté en "Terminado"
        {
            
            if (this.estado == Paso.Terminado)
            {
                return false;
            }
            else
            {
                this.estado++;
                return true;
            }
        }

        public Documento(string titulo, string autor, int anio, string numNormalizado, string barcode)
        //inicializa varaibles y define estado "inicio" para todos
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
            this.estado = Paso.Inicio;
        }

        
        public override string ToString()
        //es override para no repetir codigo y usarlo en clases hijas
        //falta arreglar para evitar repetir codigo (1 linea ._.)
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