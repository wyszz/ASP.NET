<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="1: "></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="2: "></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="3: "></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="4: "></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="5: "></asp:Label>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/WebForm1.aspx">上一页</asp:HyperLink>
        </div>
    </form>
</body>
</html>
