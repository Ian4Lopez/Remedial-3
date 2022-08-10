<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="WebApplication.Consulta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="Material_Web.aspx"> Material</a>
            <a href="Obra.aspx"> Obra</a>
            <a href="Proveedor.aspx"> Proveedor</a>
        </div>
        <div>

            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <div>
                <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
             </div>
            <asp:Button ID="Button1" runat="server" Text="Buscar Obrars" OnClick="Button1_Click" />
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
         </div>
    </form>
</body>
</html>
