<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Material_Web.aspx.cs" Inherits="WebApplication.Material_Web" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Consultar" OnClick="Button1_Click" />

        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
        <div>

            Descripcion: <asp:TextBox ID="Descipcion" runat="server"></asp:TextBox>
            Marca: <asp:TextBox ID="Marca" runat="server"></asp:TextBox>
            Presentacion: <asp:TextBox ID="Presentacion" runat="server"></asp:TextBox>
            Tipo: <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
        </div>

    </form>
</body>
</html>
