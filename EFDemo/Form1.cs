﻿using AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFDemo
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private CustomerRepository cr = new CustomerRepository();
        private void btnObtenerTodos_Click(object sender, EventArgs e)
        {
            var cliente = cr.ObtenerTodos();
            dgvCustomers.DataSource = cliente;
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            var cliente = cr.ObtenerPorID(txbObtenerTodos.Text);
            List<Customers> lista1 = new List<Customers>{ cliente
             };
            if ( cliente != null ) {
                llenarCampos(cliente);
            
            }
            dgvCustomers.DataSource = lista1;

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var cliente = crearCliente();
            var resultado = cr.InsertarCliente(cliente);
            MessageBox.Show($"Se inserto {resultado}");
        }

        private Customers crearCliente() { 
            var cliente = new Customers { 
              CustomerID = txbCustomerID.Text,
              CompanyName = txbCompanyName.Text,
              ContactName = txbContactName.Text,
              Address = txbAddress.Text,    
              ContactTitle  = txbContactTitle.Text,
            };
            return cliente;
        }
        private void llenarCampos(Customers customers) { 
            txbCustomerID.Text= customers.CustomerID;
            txbCompanyName.Text= customers.CompanyName;
            txbContactName.Text= customers.ContactName;
            txbContactTitle.Text= customers.ContactTitle;
            txbAddress.Text= customers.Address;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var cliente = crearCliente();
            cr.UpdateCliente(cliente);
           var resultado = cr.ObtenerPorID(cliente.CustomerID);
          
            if ( resultado != null) {
                List<Customers> lista1 = new List<Customers>{ resultado
             };
                dgvCustomers.DataSource = lista1;
            }
        }

        private void txbBorrar_Click(object sender, EventArgs e)
        {
            var eliminadas = cr.DeleteCliente(txbCustomerID.Text);
            MessageBox.Show($"Se elimino {eliminadas} filas");
        }
    }
}
