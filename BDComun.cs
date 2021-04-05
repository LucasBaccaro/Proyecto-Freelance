using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace KioscoProductos
{
    class BDComun
    {
        public static SqlConnection obtenerConexion()
        {
            SqlConnection conn = new SqlConnection("data source=DESKTOP-LQ6HDL0;Initial catalog = KioscoRi; user id=sa;Password=123456") ;
            SqlCommand cmd = new SqlCommand("Select ID as 'ID', PRODUCTO as 'producto' , PRECIO as 'PRECIO' from Producto", conn);


            conn.Open();
            return conn;
        }


    }
}
