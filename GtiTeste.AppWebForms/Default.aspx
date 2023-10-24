<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GtiTeste.AppWebForms.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Lista Clientes</h2>
    <br />
    <asp:Label runat="server" Style="color: red" ID="lblMensagem" Text="" />

     <div class="alert alert-success" id="divSucesso" visible="false" runat="server">
        <strong><asp:Label runat="server" Style="color: green" ID="lblMensagemSucesso" Text="" /></strong> 
    </div>
    <br />
    <asp:Button ID="btnincluir" CssClass="btn btn-info" Text="Incluir Cliente" runat="server" OnClick="btnincluir_Click" />
    <br />
    <br />

    <div class="form-group">
        <asp:GridView ID="ClienteGridView" runat="server" AutoGenerateColumns="False" class="table table-hover"
            OnRowCommand="ClienteGridView_RowCommand">
            <Columns>
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="Cpf" HeaderText="CPF" />
                <asp:BoundField DataField="RG" HeaderText="RG" />
                <asp:TemplateField HeaderText="Ações" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton class="btn btn-primary" ID="btnDetalhe" runat="server" CausesValidation="false" CommandName="Detalhe"
                            Text="Detalhe" CommandArgument='<%#Eval("Id")%>' ToolTip="Detalhe"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
                        <asp:LinkButton class="btn btn-warning" ID="btnEditar" runat="server" CausesValidation="false" CommandName="Editar"
                            Text="Editar" CommandArgument='<%#Eval("Id")%>' ToolTip="Editar"><spam class="glyphicon glyphicon-pencil"></spam></asp:LinkButton>
                        <asp:LinkButton class="btn btn-danger" ID="btnExcluir" runat="server" CausesValidation="false" CommandName="Excluir"
                            Text="Excluir" CommandArgument='<%#Eval("Id")%>' OnClientClick="return confirm('Deseja realmente excluir o cliente?');" ToolTip="Excluir"><spam class="glyphicon glyphicon-trash"></spam></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
