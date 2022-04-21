<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="_20220421_DataList.WebForm1" %>

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
            height: 24px;
        }
        .auto-style3 {
            width: 118px;
        }
        .auto-style4 {
            height: 24px;
            width: 118px;
        }
        .auto-style5 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                <HeaderTemplate>
                    教师信息：
                </HeaderTemplate>
                <ItemTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style5" colspan="2">
                                <asp:Image ID="Image1" runat="server" Height="160px" ImageUrl='<%# Eval("photourl") %>' Width="130px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">教师姓名</td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("teachername") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">年龄</td>
                            <td class="auto-style2">
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("age") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">职称</td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("titlename") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">所属教研室</td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("officename") %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </form>
</body>
</html>
