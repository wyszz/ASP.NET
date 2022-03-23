<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem Selected="True">1: QueryString</asp:ListItem>
                <asp:ListItem>2: 传多值</asp:ListItem>
                <asp:ListItem>3:Cookie</asp:ListItem>
                <asp:ListItem>4:Session</asp:ListItem>
                <asp:ListItem>5:Application</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <br />
            <asp:Button ID="btn_TurntoNextPage" runat="server" OnClick="btn_TurntoNextPage_Click" Text="转到下一页" />
        </div>
    </form>
</body>
</html>
