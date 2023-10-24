using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GtiTeste.AppWebForms
{
    public partial class DetalharCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarComboEstados();
                CarregarDadosTela(Session["IdDetalhe"].ToString());
                Session.Remove("IdDetalhe");
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        private void CarregarDadosTela(string id)
        {
            Guid Id = new Guid(id);

            var service = new ClienteService.ClienteSvcClient();

            var cliente = service.Detalhar(Id);

            if (cliente == null)
            {
                lblMensagem.Text = "Cliente não encontrado!";
            }
            else
            {
                txtCpf.Text = cliente.Cpf;
                txtNome.Text = cliente.Nome;
                txtRg.Text = cliente.RG;
                txtDataExpedicao.Text = cliente.DataExpedicao.ToString("yyyy/MM/dd");
                txtOrgaoExpedicao.Text = cliente.OrgaoExpedicao;
                ddlUf.SelectedValue = cliente.UF;
                txtDataNascimento.Text = cliente.DataNascimento.ToString("yyyy/MM/dd"); ;
                ddlSexo.SelectedValue = cliente.Sexo;
                ddlEstadoCivil.SelectedValue = cliente.EstadoCivil;
                txtCEP.Text = cliente.Endereco.Cep;
                txtLogradouro.Text = cliente.Endereco.Logradouro;
                txtNumero.Text = cliente.Endereco.Numero;
                txtComplemento.Text = cliente.Endereco.Complemento;
                txtBairro.Text = cliente.Endereco.Bairro;
                txtCidade.Text = cliente.Endereco.Cidade;
                ddlUfEndereco.SelectedValue = cliente.Endereco.UF;
            }
        }

        private void CarregarComboEstados()
        {
            var serviceClient = new ClienteService.ClienteSvcClient();
            var estados = serviceClient.ObterEstados();

            ddlUf.DataValueField = "Sigla";
            ddlUf.DataTextField = "Sigla";
            ddlUf.Items.Add(new ListItem() { Text = "Selecione...", Value = "" });
            ddlUf.DataSource = estados;
            ddlUf.DataBind();

            ddlUfEndereco.DataValueField = "Sigla";
            ddlUfEndereco.DataTextField = "Sigla";
            ddlUfEndereco.Items.Add(new ListItem() { Text = "Selecione...", Value = "" });
            ddlUfEndereco.DataSource = estados;
            ddlUfEndereco.DataBind();
        }
    }
}