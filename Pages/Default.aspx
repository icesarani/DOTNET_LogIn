<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication7.Pages.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblError" runat="server"></asp:Label>
            <br />
            <asp:Label Text="User" runat="server"></asp:Label>
            <br />
            <asp:TextBox runat="server" ID="inUser"></asp:TextBox>
            <br />
            <asp:Label Text="Password" runat="server"></asp:Label>
            <br />
            <asp:TextBox runat="server" ID="inPass"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="BtnSendLogIn" Text="Log In" OnClick="ValidateCredentials" runat="server" />
        </div>
    </form>
</body>
</html>
