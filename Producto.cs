using System;
using System.Collections.Generic;
using System.Text;

namespace KioscoProductos
{
    public class Producto
    {
        public int numeroProdu { get; set; }   
        public string nombreProdu { get; set; }
        public float precioProdu{ get; set; }

        public Producto()
        {

        }
        public Producto(int pNumeroProdu,string pNombreProdu, float pPrecioProdu)
        {
            this.numeroProdu = pNumeroProdu;
            this.nombreProdu = pNombreProdu;
            this.precioProdu = pPrecioProdu;
        }

    }
}
