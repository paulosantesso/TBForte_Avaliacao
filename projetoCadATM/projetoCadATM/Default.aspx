<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--Dados--%>
            <table>
                <tr>
                    <td>ID</td>
                    <td>
                        <asp:TextBox ID="txtID" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Código de Equipamento TECBAN(PC)</td>
                    <td>
                        <asp:TextBox ID="txtPC" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Nome</td>
                    <td>
                        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Ponto de Atendimento(PA)</td>
                    <td>
                        <asp:TextBox ID="txtPA" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Endereço</td>
                    <td>
                        <asp:TextBox ID="txtEndereco" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Bairro</td>
                    <td>
                        <asp:TextBox ID="txtBairro" runat="server"></asp:TextBox></td>
                    <td>Complemento</td>
                    <td>
                        <asp:TextBox ID="txtComplemento" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>UF</td>
                    <td>
                        <asp:DropDownList ID="ddlUF" runat="server" DataTextField="Nome" DataValueField="Sigla" OnSelectedIndexChanged="ddlUF_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td>Cidade</td>
                    <td>
                        <asp:DropDownList ID="ddlCidade" runat="server" DataTextField="Nome" DataValueField="ID"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>CEP</td>
                    <td>
                        <asp:TextBox ID="txtCEP" runat="server"></asp:TextBox></td>
                    <td>Ponto de Referência</td>
                    <td>
                        <asp:TextBox ID="txtPontoRef" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Latitude</td>
                    <td>
                        <asp:TextBox ID="txtLatitude" runat="server"></asp:TextBox></td>
                    <td>Longitude</td>
                    <td>
                        <asp:TextBox ID="txtLongitude" runat="server"></asp:TextBox></td>
                </tr>
            </table>
            <br />
            <%--Comandos--%>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" OnClick="btnPesquisar_Click" Width="100px" />
                    </td>
                    <td>
                        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" Width="100px" />
                    </td>
                    <td>
                        <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" Width="100px" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
