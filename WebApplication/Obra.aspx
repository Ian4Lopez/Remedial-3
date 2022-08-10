<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Obra.aspx.cs" Inherits="WebApplication.Obra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="Material_Web.aspx"> Material</a>
            <a href="Proveedor.aspx"> Proveedor</a>
            <a href="Consulta.aspx"> Consulta</a>
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Consultar Obras" OnClick="Button1_Click" />
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>

        <div>
            <div>
            Nombre Obra: <asp:TextBox ID="Nombre" runat="server"></asp:TextBox>
            </div>
            <div>
                Direccion: <asp:TextBox ID="Direccion" runat="server"></asp:TextBox>
            </div>
            <div>
                Fecha Inicio: <asp:TextBox ID="Fecha1" type="date" runat="server"></asp:TextBox>
            </div>
            <div>
                Fecha Final: <asp:TextBox ID="Fecha2" type="date" runat="server"></asp:TextBox>
            </div>
            <div>
                Dueño: <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
            </div>
             <div>
                Encargado: <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
            </div>

            <asp:Button ID="Button2" runat="server" Text="Insertar Obra" OnClick="Button2_Click" />
        </div>
        
         <div>
            <h4>Eliminar Obra </h4>
                SeleccionarObra: <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList>
             <asp:Button ID="Button3" runat="server" Text="Eliminar Obra" OnClick="Button3_Click" />
        </div>
    </form>
</body>
</html>
