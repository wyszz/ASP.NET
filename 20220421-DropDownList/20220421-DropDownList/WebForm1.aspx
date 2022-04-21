<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="_20220421_DropDownList.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 123px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">省</td>
                    <td>
                        <asp:DropDownList ID="ddl_Province" runat="server" AutoPostBack="True" Height="30px" OnSelectedIndexChanged="ddl_Province_SelectedIndexChanged" Width="115px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">市</td>
                    <td>
                        <asp:DropDownList ID="ddl_City" runat="server" AutoPostBack="True" Height="30px" OnSelectedIndexChanged="ddl_City_SelectedIndexChanged" Width="115px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">区/县</td>
                    <td>
                        <asp:DropDownList ID="ddl_Area" runat="server" AutoPostBack="True" Height="30px" OnSelectedIndexChanged="ddl_Area_SelectedIndexChanged" Width="115px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">邮政编码</td>
                    <td>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
