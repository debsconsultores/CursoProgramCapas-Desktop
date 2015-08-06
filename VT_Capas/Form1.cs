using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using Entidades;

namespace VT_Capas
{
    public partial class Form1 : Form
    {
        P_Customer oCliente = new P_Customer();  //Instancia de la Capa de Presentación
        E_Customer oCliente_Ent = new E_Customer();  //Instancia de la capa de Entidad. 
        public Form1()
        {
            InitializeComponent();
        }
        private void IniDG()
        {
            try
            {
                DGCostumer.DataSource = oCliente.GetAll().Tables[0];
                DGCostumer.Refresh();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IniDG();
        }

        private void txtCustomerId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return) {
                int CustId = Convert.ToInt32(txtCustomerId.Text);
                try
                {
                    oCliente_Ent = oCliente.GetOne(CustId);
                    chkNameStyle.Checked = oCliente_Ent.NameStyle;
                    txtTitle.Text = oCliente_Ent.Title;
                    txtFirstName.Text = oCliente_Ent.FirstName;
                    txtMiddleName.Text = oCliente_Ent.MiddleName;
                    txtLastName.Text = oCliente_Ent.LastName;
                    txtSuffiix.Text = oCliente_Ent.Suffix;
                    txtCompanyName.Text = oCliente_Ent.CompanyName;
                    txtSalesPerson.Text = oCliente_Ent.SalesPerson;
                    txtEmailAddress.Text = oCliente_Ent.EmailAddress;
                    txtPhone.Text = oCliente_Ent.Phone;
                    txtPasswordHash.Text = oCliente_Ent.PasswordHash;
                    txtPasswordSalt.Text = oCliente_Ent.PasswordSalt;
                }
                catch (Exception Ex) {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DGCostumer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)DGCostumer.Rows[e.RowIndex].Cells[0].Value;
            txtCustomerId.Text = Convert.ToString(id);
            txtCustomerId_KeyPress(sender, new KeyPressEventArgs((char)Keys.Return));
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            /*
             Para grabar, primero se inicializa la entidad oCliente_Ent, la cual se enviará al evento Save de la capa
             * de presentación
             */
            oCliente_Ent.CustomerId = Convert.ToInt32((txtCustomerId.Text == string.Empty) ? null : txtCustomerId.Text);
            //Si el valor de txtCustomerId es vacío, se inicializa con valor null, de lo contrario
            //se pone el valor del textbox (txtCustomerId)
            oCliente_Ent.NameStyle = chkNameStyle.Checked;
            //Y así con todos los valores del formulario (objetos) que estén
            //relacionados con las propiedades de la entidad
            oCliente_Ent.Title = txtTitle.Text;
            oCliente_Ent.FirstName = txtFirstName.Text;
            oCliente_Ent.MiddleName = txtMiddleName.Text;
            oCliente_Ent.LastName = txtLastName.Text;
            oCliente_Ent.Suffix = txtSuffiix.Text;
            oCliente_Ent.CompanyName = txtCompanyName.Text;
            oCliente_Ent.SalesPerson = txtSalesPerson.Text;
            oCliente_Ent.EmailAddress = txtEmailAddress.Text;
            oCliente_Ent.Phone = txtPhone.Text;
            oCliente_Ent.PasswordHash = txtPasswordHash.Text;
            oCliente_Ent.PasswordSalt = txtPasswordSalt.Text;

            int vCustid = -1; //Valor del CustId, si es -1 se asume que NO PUDO GRABAR REGISTRO
            try
            {
                vCustid = oCliente.Save(oCliente_Ent);  //Se ejecuta el método Save de la capa de presentación
                //Se envía como parámetro la entidad oCliente_Ent
            }
            catch (Exception Ex)
            {
                vCustid = -1; //Si hubo error se pone -1
                MessageBox.Show("Error Grabando Registro" + Ex.Message);
            }

            /*Si se grabó bien vCust tiene un valor diferente de -1 */
            if (vCustid != -1)
            {
                /*El valor de CustomerId se coloca en el textbox (por si se hizo insert)
                 y el CustomerId de la entidad también se inicializa*/
                txtCustomerId.Text = Convert.ToString(vCustid);
                oCliente_Ent.CustomerId = vCustid;
                MessageBox.Show("Registro grabado satisfactoriamente");
            }
            else {
                MessageBox.Show("Hubo un error grabando datos");
            }

            //Inicializar DataGridView y enviar el evento KeyPress del txtCustomerId
            IniDG();
            txtCustomerId_KeyPress(sender, new KeyPressEventArgs((char)Keys.Return));
            //Ahora se realizará la prueba

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int vCustId = Convert.ToInt32((txtCustomerId.Text == string.Empty) ? "0" : txtCustomerId.Text);

            if (vCustId == 0) 
            {
                MessageBox.Show("No ha seleccionado registro a Borrar");
                return;
            }

            if (MessageBox.Show("Procede a Eliminar un registro. ¿Continuar?", "Mucho Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            try
            {
                if (oCliente.Del(vCustId))
                {
                    MessageBox.Show("Eliminado Satisfactoriamente");
                    IniDG();
                }
                else
                {
                    MessageBox.Show("Error Eliminando Registro");
                }
            }
            catch (Exception Ex) {
                MessageBox.Show(Ex.Message);
            }
        }

    }
}
