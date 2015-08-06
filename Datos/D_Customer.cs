using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class D_Customer : CAD
    {
        public DataSet GetAll()
        {
            DataSet DS = new DataSet();

            try
            {
                SqlCommand cmd = CrearComando("Customer_Get");
                DS = GetDS(cmd, "Customer_Get");
            }
            catch (Exception Ex)
            {
                throw new Exception("Error Obteniendo todos los registros " + Ex.Message, Ex);
            }

            return DS;
        }
        public E_Customer GetOne(int CustomerId) {
            E_Customer vRes = new E_Customer();

            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd = CrearComando("Customer_Get");
                cmd.Parameters.AddWithValue("@CustomerId", CustomerId);

                AbrirConexion();
                SqlDataReader consulta = Ejecuta_Consulta(cmd);

                if (consulta.Read())
                {
                    if (consulta.HasRows)
                    {
                        vRes.CustomerId = (int)consulta["CustomerId"];
                        vRes.NameStyle = (Boolean)consulta["NameStyle"];
                        vRes.Title = Convert.ToString(consulta["Title"]);
                        vRes.FirstName = (string)consulta["FirstName"];
                        vRes.MiddleName = Convert.ToString(consulta["MiddleName"]);
                        vRes.LastName = (string)consulta["LastName"];
                        vRes.Suffix = Convert.ToString(consulta["Suffix"]);
                        vRes.CompanyName = Convert.ToString(consulta["CompanyName"]);
                        vRes.SalesPerson = Convert.ToString(consulta["SalesPerson"]);
                        vRes.EmailAddress = Convert.ToString(consulta["EmailAddress"]);
                        vRes.Phone = Convert.ToString(consulta["Phone"]);
                        vRes.PasswordHash = (string)consulta["PasswordHash"];
                        vRes.PasswordSalt = (string)consulta["PasswordSalt"];
                        vRes.ModifiedDate = (DateTime)consulta["ModifiedDate"];
                    }
                }
                consulta.Close();
                consulta.Dispose();

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
            finally
            {
                cmd.Dispose();
                CerrarConexion();
            }
            return vRes;

        }
        public int Save(E_Customer oCustomer)
        {
            SqlCommand cmd = new SqlCommand();
            int vReg = -1;
            try
            {
                cmd = CrearComando("Customer_Set");
                cmd.Parameters.AddWithValue("@CustomerId", oCustomer.CustomerId);
                cmd.Parameters["@CustomerId"].Direction = ParameterDirection.InputOutput;

                cmd.Parameters.AddWithValue("@NameStyle", oCustomer.NameStyle);
                cmd.Parameters.AddWithValue("@Title", oCustomer.Title);
                cmd.Parameters.AddWithValue("@FirstName", oCustomer.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", oCustomer.MiddleName);
                cmd.Parameters.AddWithValue("@LastName", oCustomer.LastName);
                cmd.Parameters.AddWithValue("@Suffix", oCustomer.Suffix);
                cmd.Parameters.AddWithValue("@CompanyName", oCustomer.CompanyName);
                cmd.Parameters.AddWithValue("@SalesPerson", oCustomer.SalesPerson);
                cmd.Parameters.AddWithValue("@EmailAddress", oCustomer.EmailAddress);
                cmd.Parameters.AddWithValue("@Phone", oCustomer.Phone);
                cmd.Parameters.AddWithValue("@PasswordHash", oCustomer.PasswordHash);
                cmd.Parameters.AddWithValue("@PasswordSalt", oCustomer.PasswordSalt);

                AbrirConexion();
                vReg = Ejecuta_Accion(ref cmd);
                vReg = Convert.ToInt32(cmd.Parameters["@CustomerId"].Value);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
            finally
            {
                cmd.Dispose();
                CerrarConexion();
            }
            return vReg;
        }
        public Boolean Del(int CustomerId)
        {
            SqlCommand cmd = new SqlCommand();
            Boolean vRes = false;
            int vCant = -1;

            try
            {
                cmd = CrearComando("Customer_Del");
                cmd.Parameters.AddWithValue("@CustomerId", CustomerId);

                AbrirConexion();
                vCant = Ejecuta_Accion(ref cmd);

                if (vCant > 0)
                {
                    vRes = true;
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
            finally
            {
                cmd.Dispose();
                CerrarConexion();
            }
            return vRes;
        }
        //En el próximo video haremos el evento de borrar registro.
        //En la descripción de este video están los links de descarga
        //de este proyecto, el cual ya estará con comentarios 
        //Gracias por todo, si le es de utilidad síganos
    }
}
