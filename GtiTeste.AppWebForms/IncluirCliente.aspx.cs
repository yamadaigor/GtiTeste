using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GtiTeste.AppWebForms
{
    public partial class IncluirCliente : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblMensagem.Text = "";
                lblMensagemSucesso.Text = "";
                CarregarComboEstados();
                LimparCampos();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            // Salva na base de dados
            var cliente = new ClienteService.ClienteContract();
            cliente.Endereco = new ClienteService.EnderecoContract();

            cliente.Id = Guid.NewGuid();
            cliente.Cpf = txtCpf.Text;
            cliente.Nome = txtNome.Text;
            cliente.RG = txtRg.Text;
            cliente.DataExpedicao = string.IsNullOrEmpty(txtDataExpedicao.Text) ? DateTime.MinValue : DateTime.Parse(txtDataExpedicao.Text);
            cliente.OrgaoExpedicao = txtOrgaoExpedicao.Text;
            cliente.UF = ddlUf.SelectedValue.ToString();
            cliente.DataNascimento = string.IsNullOrEmpty(txtDataNascimento.Text) ? DateTime.MinValue : DateTime.Parse(txtDataNascimento.Text);
            cliente.Sexo = ddlSexo.SelectedValue.ToString();
            cliente.EstadoCivil = ddlEstadoCivil.SelectedValue.ToString();
            cliente.Endereco.Id = cliente.Id;
            cliente.Endereco.Cep = txtCEP.Text;
            cliente.Endereco.Logradouro = txtLogradouro.Text;
            cliente.Endereco.Numero = txtNumero.Text;
            cliente.Endereco.Complemento = txtComplemento.Text;
            cliente.Endereco.Bairro = txtBairro.Text;
            cliente.Endereco.Cidade = txtCidade.Text;
            cliente.Endereco.UF = ddlUfEndereco.SelectedValue.ToString();

            var service = new ClienteService.ClienteSvcClient();

            var retorno = service.Incluir(cliente);

            if (retorno.OperacaoValida)
            {
                lblMensagemSucesso.Text = "Cliente Incluído com sucesso!";
                LimparCampos();
            }
            else
            {
                var mensagem = string.Empty;
                foreach (var mensagemErro in retorno.Mensagens.ToList())
                {
                    mensagem += $"<li> {mensagemErro} </li>";
                }
                lblMensagem.Text = mensagem;
            }
            divSucesso.Visible = retorno.OperacaoValida;
            divErro.Visible = !retorno.OperacaoValida;
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
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

        private void LimparCampos()
        {
            txtCpf.Text =
            txtNome.Text =
            txtRg.Text =
            txtDataExpedicao.Text =
            txtOrgaoExpedicao.Text =
            txtDataNascimento.Text =
            txtCEP.Text =
            txtLogradouro.Text =
            txtComplemento.Text =
            txtBairro.Text =
            txtCidade.Text = string.Empty;
            ddlUf.SelectedIndex =
            ddlSexo.SelectedIndex =
            ddlEstadoCivil.SelectedIndex =
            ddlUfEndereco.SelectedIndex = 0;
        }
    }
}