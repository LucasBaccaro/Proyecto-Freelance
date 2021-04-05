using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace KioscoProductos
{
    public class ProductoDal
    {
        public static int Agregar(Producto pProducto)
        {
            int retorno = 0;
            using (SqlConnection conn=BDComun.obtenerConexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("insert into Producto (PRODUCTO,PRECIO) values ( '{0}','{1}')", pProducto.nombreProdu, pProducto.precioProdu), conn);
                retorno = comando.ExecuteNonQuery();
            }
            return retorno;
        }

        public static List<Producto>BuscarProducto(string pnombreProdu)
        {
            List<Producto> Lista = new List<Producto>();
            {
                using (SqlConnection conn = BDComun.obtenerConexion())
                {
                    SqlCommand comando = new SqlCommand(string.Format("Select ID,PRODUCTO,PRECIO from Producto where PRODUCTO like '%{0}%' ",pnombreProdu), conn);

                    SqlDataReader reader = comando.ExecuteReader();

                    while(reader.Read())
                    {
                        Producto pProducto = new Producto();
                        pProducto.numeroProdu = reader.GetInt32(0);
                        pProducto.nombreProdu = reader.GetString(1);
                        pProducto.precioProdu = (float) reader.GetDouble (2);
                        Lista.Add(pProducto);
                    }
                    conn.Close();
                    return Lista;
                }
            }
        }

        public static int Modificar(Producto pProducto)
        {
            int retorno = 0;
            using (SqlConnection conexion = BDComun.obtenerConexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("Update Producto set PRECIO= {0} where PRODUCTO = '{1}' ", pProducto.precioProdu, pProducto.nombreProdu), conexion);
                retorno = comando.ExecuteNonQuery();
                conexion.Close();
            }
            return retorno;
        }

        public static int Eliminar(int id_usuario)
        {
            int retorno = 0;
            using (SqlConnection conexion = BDComun.obtenerConexion())
            {

                SqlCommand comando = new SqlCommand(string.Format("Delete from Producto where ID = '{0}'", id_usuario), conexion);
                retorno = comando.ExecuteNonQuery();
                conexion.Close();
            }
            return retorno;
        }


        


    }

}
