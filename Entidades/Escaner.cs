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
            d.AvanzarEstado();
            //..la consigna dice "cambiará el estado del documento dentro de la lista
            //de coumentos." pero no estyo seguro de como implementarlo o
            //en que caso deberia retornar true o false
        }

        public Escaner(string marca, TipoDoc tipo)
        {
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
        {
            if (e != d && d.Estado == Documento.Paso.Inicio)
            {
                d.AvanzarEstado();
                e.listDocuemnto.Add(d);
                return true;
            }
            return false;
        }

        public static bool operator ==(Escaner e, Documento d)
        {
            //si el Doc no está en la lista, devuelve false
            if (e.listDocuemnto.IndexOf(d) == -1)
            {
                return false;
            }
            return true;
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
