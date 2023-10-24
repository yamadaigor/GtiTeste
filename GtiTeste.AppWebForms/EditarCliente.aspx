<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="EditarCliente.aspx.cs" Inherits="GtiTeste.AppWebForms.EditarCliente" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Alterar Cliente</h2>
     <hr />
     <br />

      <div class="alert alert-success" id="divSucesso" visible="false" runat="server">
        <strong><asp:Label runat="server" Style="color: green" ID="lblMensagemSucesso" Text="" /></strong> 
    </div>

    <div class="alert alert-danger" id="divErro" visible="false" runat="server">
        <strong>Ops, Algo deu errado.</strong>
        <ul>
            <asp:Label runat="server" Style="color:red" Id="lblMensagem" Text=""/>
        </ul>
    </div>
    
    <div class="form-horizontal">
        <asp:HiddenField Id="IdCliente" runat="server" />
        <div class="form-group">
            <asp:Label ID="lblCpf" runat="server" class="control-label col-md-1">CPF</asp:Label>
            <div class="col-md-2">
                <asp:TextBox ID="txtCpf" runat="server" class="form-control"></asp:TextBox>
            </div>

            <asp:Label ID="lblNome" runat="server" class="control-label col-md-1">Nome</asp:Label>
            <div class="col-md-4">
                <asp:TextBox ID="txtNome" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">

            <asp:Label ID="lblRg" runat="server" class="control-label col-md-1">RG</asp:Label>
            <div class="col-md-2">
                <asp:TextBox ID="txtRg" runat="server" class="form-control"></asp:TextBox>
            </div>

            <asp:Label ID="lblDataExpedicao" runat="server" class="control-label col-md-2">Data Expedição</asp:Label>
            <div class="col-md-2">
                <asp:TextBox ID="txtDataExpedicao" runat="server" class="form-control"></asp:TextBox>
            </div>

            <asp:Label ID="lblOrgaoExpedicao" runat="server" class="control-label col-md-2">Orgão Expedição</asp:Label>
            <div class="col-md-1">
                <asp:TextBox ID="txtOrgaoExpedicao" runat="server" class="form-control"></asp:TextBox>
            </div>

            <asp:Label ID="lblUf" runat="server" class="control-label col-md-1">UF</asp:Label>
            <div class="col-md-1">
                <asp:DropDownList runat="server"  class="form-control" Id="ddlUf"></asp:DropDownList>
            </div>
        </div>

        <div class="form-group">

            <asp:Label ID="lblSexo" runat="server" class="control-label col-md-1">Sexo</asp:Label>
            <div class="col-md-2">
                  <asp:DropDownList runat="server"  class="form-control" Id="ddlSexo">
                    <asp:ListItem Text="Feminino" Value="Feminino"></asp:ListItem>
                    <asp:ListItem Text="Masculino" Value="Masculino"></asp:ListItem>
                    <asp:ListItem Text="Outro" Value="Outro"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <asp:Label ID="lblDataNascimento" runat="server" class="control-label col-md-2">Data Nascimento</asp:Label>
            <div class="col-md-2">
                <asp:TextBox ID="txtDataNascimento" runat="server" class="form-control"></asp:TextBox>
            </div>

            <asp:Label ID="lblEstadoCivil" runat="server" class="control-label col-md-2">Estado Civil</asp:Label>
            <div class="col-md-2">
                   <asp:DropDownList runat="server"  class="form-control" Id="ddlEstadoCivil">
                    <asp:ListItem Text="Solteiro" Value="Solteiro"></asp:ListItem>
                    <asp:ListItem Text="Casado" Value="Casado"></asp:ListItem>
                    <asp:ListItem Text="Divorciado" Value="Divorciado"></asp:ListItem>
                    <asp:ListItem Text="Viúvo" Value="Viuvo"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <h1>Endereço</h1>
        <hr />
        <br />

        <div class="form-group">

            <asp:Label ID="lblCep" runat="server" class="control-label col-md-1">CEP</asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="txtCEP" runat="server" class="form-control"></asp:TextBox>
            </div>

            <asp:Label ID="lblLogradouro" runat="server" class="control-label col-md-1">Logradouro</asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="txtLogradouro" runat="server" class="form-control"></asp:TextBox>
            </div>

            <asp:Label ID="lblNumero" runat="server" class="control-label col-md-1">Número</asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="txtNumero" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">

            <asp:Label ID="lblComplemento" runat="server" class="control-label col-md-1">Compl.</asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="txtComplemento" runat="server" class="form-control"></asp:TextBox>
            </div>

            <asp:Label ID="lblBairro" runat="server" class="control-label col-md-1">Bairro</asp:Label>
            <div class="col-md-2">
                <asp:TextBox ID="txtBairro" runat="server" class="form-control"></asp:TextBox>
            </div>

            <asp:Label ID="lblCidade" runat="server" class="control-label col-md-1">Cidade</asp:Label>
            <div class="col-md-2">
                <asp:TextBox ID="txtCidade" runat="server" class="form-control"></asp:TextBox>
            </div>

            <asp:Label ID="lblUfEndereco" runat="server" class="control-label col-md-1">UF</asp:Label>
            <div class="col-md-1">
                <asp:DropDownList runat="server"  class="form-control" Id="ddlUfEndereco"></asp:DropDownList>
            </div>

        </div>
        <br>
        <div class="form-group">
            <div class="col-md-offset-4 col-md-4">
                <asp:Button ID="btnSalvar" CssClass="btn btn-Primary" Text="Salvar" runat="server" OnClick="btnSalvar_Click" />
                <asp:Button ID="btnVoltar" CssClass="btn btn-info" Text="Voltar" runat="server" OnClick="btnVoltar_Click" />
            </div>
        </div>
    </div>

     <script>
        $(function () {
            $('#<%=txtDataExpedicao.ClientID%>').datepicker(
                      {
                          dateFormat: 'dd/mm/yy',
                          changeMonth: true,
                          changeYear: true,
                          yearRange: '1950:2100'
                      });
              });
              $(function () {
                  $('#<%=txtDataNascimento.ClientID%>').datepicker(
                      {
                          dateFormat: 'dd/mm/yy',
                          changeMonth: true,
                          changeYear: true,
                          yearRange: '1950:2100'
                      });
              });
     </script>

</asp:Content>
