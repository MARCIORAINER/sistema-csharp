using SistemaVendas.BLL;
using SistemaVendas.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVendas.UI
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }
        userBLL u = new userBLL();
        userDAL dal = new userDAL();



        private void btncadastrar_Click(object sender, EventArgs e)
        {

            u.nome = txtnome.Text;
            u.s_nome = txtsnome.Text;
            u.email = txtemail.Text;
            u.usuario = txtusuario.Text;
            u.senha = txtsenha.Text;
            u.contato = txtcontato.Text;
            u.endereco = txtendereco.Text;
            u.sexo = cmbsexo.Text;
            u.usuario_tipo = cmbtipousuario.Text;
            u.add_data = DateTime.Now;
            u.add_por = 1;

            bool success = dal.Insert(u);
            if (success == true)
            {
                MessageBox.Show("CADASTRO REALIZADO COM SUCESSO");
                //CHAMA O MÉTODO LIMPAR OS CAMPOS
                Limpar();
            }
            else
            {
                MessageBox.Show("NAO FOI POSSIVEL REALIZAR ESTE CADASTRO");
            }

        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            // BUSCA OS DADOS NO BANCO DE DADOS

            DataTable dt = dal.Select();
            dvgusuario.DataSource = dt;


        }

        //MÉTODO PARA LIMPAR OS CAMPOS DO FORMULÁRIO CADASTRO DE USUÁRIOS
        private void Limpar()
        {
            txtid.Text ="";
            txtnome.Text ="";
            txtsnome.Text ="";
            txtemail.Text ="";
            txtusuario.Text ="";
            txtsenha.Text ="";
            txtcontato.Text ="";
            txtendereco.Text ="";
            cmbsexo.Text ="";
            cmbtipousuario.Text ="";
            
        }

        private void cmbtipousuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dvgusuario_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            int rowIndex = e.RowIndex;
            //CAMPOS A SEREM CARREGADOS
            txtid.Text = dvgusuario.Rows[rowIndex].Cells[0].Value.ToString();
            txtnome.Text = dvgusuario.Rows[rowIndex].Cells[1].Value.ToString();
            txtsnome.Text = dvgusuario.Rows[rowIndex].Cells[2].Value.ToString();
            txtemail.Text = dvgusuario.Rows[rowIndex].Cells[3].Value.ToString();
            txtusuario.Text = dvgusuario.Rows[rowIndex].Cells[4].Value.ToString();
            txtsenha.Text = dvgusuario.Rows[rowIndex].Cells[5].Value.ToString();
            txtcontato.Text = dvgusuario.Rows[rowIndex].Cells[6].Value.ToString();
            txtendereco.Text = dvgusuario.Rows[rowIndex].Cells[7].Value.ToString();
            cmbsexo.Text = dvgusuario.Rows[rowIndex].Cells[8].Value.ToString();
            cmbtipousuario.Text = dvgusuario.Rows[rowIndex].Cells[9].Value.ToString();
        }

        private void btnatualizar_Click(object sender, EventArgs e)
        {
            //EVENTO BOTÃO ATUALIZAR , FIZ CONVERSAO DO ID E RECEBENDO COLUNAS OS DADOS DO BD

            u.id = Convert.ToInt32(txtid.Text);

            u.nome = txtnome.Text;
            u.s_nome = txtsnome.Text;
            u.email = txtemail.Text;
            u.usuario = txtusuario.Text;
            u.senha = txtsenha.Text;
            u.contato = txtcontato.Text;
            u.endereco = txtendereco.Text;
            u.sexo = cmbsexo.Text;
            u.usuario_tipo = cmbtipousuario.Text;
            u.add_data = DateTime.Now;
            u.add_por = 1;

            bool sucesso = dal.Update(u);

            if (sucesso == true)
            {
                MessageBox.Show("Cadastro Atualizado com sucesso!");
                Limpar();
            }
            else 
            {
               MessageBox.Show("Não foi possível atualizar este cadastro");
            }
            //CARREGA O DATA GRID VIEW ATUALIZADO
            DataTable dt = dal.Select();
            dvgusuario.DataSource = dt;

        }

        private void btndeletar_Click(object sender, EventArgs e)
        {
            u.id = Convert.ToInt32(txtid.Text);

            bool sucesso = dal.Delete(u);

            if (sucesso == true)
            {
                MessageBox.Show("Deletado com sucesso!");
                Limpar();
            }
            else
            {
                MessageBox.Show("Não foi possível deletar este cadastro");
            }
            //CARREGA O DATA GRID VIEW ATUALIZADO
            DataTable dt = dal.Select();
            dvgusuario.DataSource = dt;

        }
    }
}
