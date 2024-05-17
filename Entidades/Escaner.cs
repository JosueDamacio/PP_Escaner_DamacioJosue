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
        {
            
        }

        public Escaner(string marca, TipoDoc tipo)
        {
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

        public static bool operator != (Escaner e, Documento d)
        {
            return !(e == d);
        }

        public static bool operator +(Escaner e, Documento d)
        {
            
        }

        public static bool operator == (Escaner e, Documento d)
        {
            
        }
        #endregion

        #region Enums
        public enum Departamento
        {
            nulo, mapoteca, procesosTecnicos
        }
        public enum TipoDoc
        {
            libro, mapa
        }
        #endregion


    }
}
