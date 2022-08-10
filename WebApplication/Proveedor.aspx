<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Proveedor.aspx.cs" Inherits="WebApplication.Proveedor" %>

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
            <a href="Consulta.aspx"> Consulta</a>
        </div>
        <div>

            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Consultar" OnClick="Button1_Click" />
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
        <div>
            <div>
                Recibio: <asp:TextBox ID="recibio" runat="server"></asp:TextBox>
            </div>
            <div>
                Entrega: <asp:TextBox ID="entrega" runat="server"></asp:TextBox>
            </div>
            <div>
                Cantidad: <asp:TextBox ID="cantidad" runat="server"></asp:TextBox>
            </div>
            <div>
                Fecha_Entrega: <asp:TextBox ID="fecha" type="Date" runat="server"></asp:TextBox>
            </div>
            <div>
                Precio:$ <asp:TextBox ID="Precio" runat="server"></asp:TextBox>
            </div>
            <div>
                Obra: <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
            </div>
            <div>
                Material: <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
            </div>
            <div>
                Proveedor: <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList>
            </div>

            <asp:Button ID="Button2" runat="server" Text="Insertar Nuevo" OnClick="Button2_Click" />

        </div>
    </form>
</body>
</html>
