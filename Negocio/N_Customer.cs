using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

using Entidades;
using Datos;

namespace Negocio
{
    public class N_Customer
    {
        D_Customer D_Cus = new D_Customer();

        public DataSet GetAll()
        {
            return D_Cus.GetAll();
        }
        public E_Customer GetOne(int CustomerId)
        {
            return D_Cus.GetOne(CustomerId);
        }
        public int Save(E_Customer oCustomer) 
        {
            return D_Cus.Save(oCustomer);
        }
        public Boolean Del(int CustomerId)
        {
            return D_Cus.Del(CustomerId);
        }
    }
}
