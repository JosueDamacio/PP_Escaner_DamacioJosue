using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Escaner
    {
        #region Atributos
        List<Documento> listDocuemnto;
        Departamento locacion;
        string marca;
        TipoDoc tipo;
        #endregion

        #region Propiedades
        public List<Documento> ListaDocumentos
        {
            get => listDocuemnto;
        }
        public Departamento Locacion
        {
            get => locacion;
        }
        public string Marca
        {
            get => marca;
        }
        public TipoDoc Tipo
        {
            get => tipo;
        }
        #endregion

        #region Metodos

        public bool CambiarEstadoDocumento(Documento d)
        { //si la lista tiene el docimento, cambia el estado del documento
            if (ListaDocumentos.Contains(d))
            {
                d.AvanzarEstado();
                return true;
            }
            return false;
        }

        public Escaner(string marca, TipoDoc tipo)
        {
            //se crea un Escaner con un departamento dependiendo el tipo de documento
            this.marca = marca;
            this.listDocuemnto = new List<Documento>();

            if (tipo == TipoDoc.libro)
            {
                this.locacion = Departamento.procesosTecnicos;
            }
            else if (tipo == TipoDoc.mapa)
            {
                this.locacion = Departamento.mapoteca;
            }
        }

        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }

        public static bool operator +(Escaner e, Documento d)
        {   // se avanza el estado del doc y se agrega a la lista
            // si el docuemnto no está en el escaner y está en paso inicio
            if (e != d && d.Estado == Documento.Paso.Inicio)
            {
                d.AvanzarEstado();
                e.listDocuemnto.Add(d);
                return true;
            }
            else { return false; }
        }

        public static bool operator ==(Escaner e, Documento d)
        {   //se recorre la lista de documentos y si se encuentra el
            //documento devuelve true, si no la encuentra false
            foreach (Documento doc in e.listDocuemnto)
            {
                if (doc == d)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Enums
        public enum Departamento
        {
            nulo,
            mapoteca,
            procesosTecnicos
        }
        public enum TipoDoc
        {
            libro,
            mapa
        }
        #endregion

    }
}
