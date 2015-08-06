using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

using Entidades;
using Negocio;

namespace VT_Capas
{
    public class P_Customer
    {
        N_Customer N_Cus = new N_Customer();

        public DataSet GetAll()
        {
            return N_Cus.GetAll();
        }
        public E_Customer GetOne(int CustomerId)
        {
            return N_Cus.GetOne(CustomerId);
        }
        public int Save(E_Customer oCustomer)
        {
            return N_Cus.Save(oCustomer);
        }
        public Boolean Del(int CustomerId)
        {
            return N_Cus.Del(CustomerId);
        }
    }
}
