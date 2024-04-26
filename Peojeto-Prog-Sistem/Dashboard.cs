﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Web.UI.WebControls;

namespace Peojeto_Prog_Sistem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            
        }

        private void patrimonioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroPatrimonio cp = new CadastroPatrimonio();
            cp.Show();
        }

        private void Locados_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroManutencao cm = new CadastroManutencao();
            cm.Show();
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroFornecedor cf = new CadastroFornecedor();
            cf.Show();
        }

        private void setoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setor mfcs = new setor();
            mfcs.ShowDialog();
        }

        private void cadastrarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CadastroManutencao cm = new CadastroManutencao();
                cm.ShowDialog();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaManutencao conManu = new ConsultaManutencao();
            conManu.ShowDialog();
        }

        private void statusDePatrimônioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatusPatrimonio statusPatrimonio = new StatusPatrimonio();
            statusPatrimonio.ShowDialog();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //Usando apenas DataTable (sem uso de List<>)
            DataTable listDesc = Banco.BuscarDescricao();
            foreach (DataRow item in listDesc.Rows)
            {
                cbxPatrimonio.Items.Add(item[0].ToString());
            }
        }

        private void cbxPatrimonio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Usando apenas DataTable (sem uso de List<>)
            string descricaoPatri = cbxPatrimonio.SelectedItem.ToString();

            DataTable dtQuantidade = Banco.DashboardBuscarPatrimonioEspecifico(descricaoPatri);
            tbxQuantidade.Text = Convert.ToString(dtQuantidade.Rows.Count);

            DataTable dtQuantAloc = Banco.DashboardBuscarQuantAloc(descricaoPatri);
            tbxLocados.Text = Convert.ToString(dtQuantAloc.Rows.Count);

        }




    }
}
