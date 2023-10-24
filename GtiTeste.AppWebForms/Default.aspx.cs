using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GtiTeste.AppWebForms
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarDadosGrid();
            }
        }

        private void CarregarDadosGrid()
        {
            var service = new ClienteService.ClienteSvcClient();
            var clientes = service.ObterClientes(null, null);

            ClienteGridView.DataSource = clientes;
            ClienteGridView.DataBind();
        }

        protected void ClienteGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                // Editar
                Session.Add("IdEditar", e.CommandArgument);
                Response.Redirect("~/EditarCliente.aspx");
            }
            else if (e.CommandName == "Detalhe")
            {
                // Detalhe
                Session.Add("IdDetalhe", e.CommandArgument);
                Response.Redirect("~/DetalharCliente.aspx");
            }
            else
            {
                var idCliente = e.CommandArgument.ToString();
                var service = new ClienteService.ClienteSvcClient();

                var retorno = service.Excluir(new Guid(idCliente));

                if (retorno.OperacaoValida)
                {
                    lblMensagemSucesso.Text = "Cliente excluído com sucesso!";
                    divSucesso.Visible = retorno.OperacaoValida;
                    CarregarDadosGrid();
                }
                else
                {
                    var mensagem = string.Empty;
                    foreach (var mensagemErro in retorno.Mensagens.ToList())
                    {
                        mensagem += mensagemErro + " /n";
                    }
                    lblMensagem.Text = mensagem;
                }
            }
        }

        protected void btnincluir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IncluirCliente.aspx");
        }


    }
}