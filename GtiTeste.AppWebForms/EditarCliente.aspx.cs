using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GtiTeste.AppWebForms
{
    public partial class EditarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                lblMensagem.Text = "";
                lblMensagemSucesso.Text = "";
                CarregarComboEstados();
                CarregarDadosTela(Session["IdEditar"].ToString());
                Session.Remove("IdEditar");
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            // Salva na base de dados
            var cliente = new ClienteService.ClienteContract();
            cliente.Endereco = new ClienteService.EnderecoContract();

            var id = new Guid(IdCliente.Value);
            cliente.Id = id;
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

            var retorno = service.Alterar(id,cliente);

            if (retorno.OperacaoValida)
            {
                lblMensagemSucesso.Text = "Cliente Alterado com sucesso!";
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

        private void CarregarDadosTela(string id)
        {
            Guid Id = new Guid(id);

            var service = new ClienteService.ClienteSvcClient();

            var cliente = service.Detalhar(Id);

            if (cliente == null)
            {
                lblMensagem.Text = "<li> Cliente não encontrado! </li>";
                divSucesso.Visible = false;
                divErro.Visible = true;
            }
            else
            {
                IdCliente.Value = cliente.Id.ToString();
                txtCpf.Text = cliente.Cpf;
                txtNome.Text = cliente.Nome;
                txtRg.Text = cliente.RG;
                txtDataExpedicao.Text = cliente.DataExpedicao.ToString("dd/MM/yyyy");
                txtOrgaoExpedicao.Text = cliente.OrgaoExpedicao;
                ddlUf.SelectedValue = cliente.UF;
                txtDataNascimento.Text = cliente.DataNascimento.ToString("dd/MM/yyyy"); ;
                ddlSexo.SelectedValue = cliente.Sexo;
                ddlEstadoCivil.SelectedValue = cliente.EstadoCivil;
                txtCEP.Text = cliente.Endereco.Cep;
                txtLogradouro.Text = cliente.Endereco.Logradouro;
                txtNumero.Text = cliente.Endereco.Numero;
                txtComplemento.Text = cliente.Endereco.Complemento;
                txtBairro.Text = cliente.Endereco.Bairro;
                txtCidade.Text =  cliente.Endereco.Cidade;
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