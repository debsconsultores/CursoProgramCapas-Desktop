using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class E_Customer
    {
        #region Atributos
        #endregion

        #region Constructor
        public E_Customer()
        {
            CustomerId = 0;
            NameStyle = false;
            FirstName = string.Empty;
            LastName = string.Empty;
            PasswordHash = string.Empty;
            PasswordSalt = string.Empty;
        }
        #endregion
        #region Encapsulamiento
        public int CustomerId { get; set; }
        public bool NameStyle { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string CompanyName { get; set; }
        public string SalesPerson { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime ModifiedDate { get; set; }
        #endregion
    }
}
