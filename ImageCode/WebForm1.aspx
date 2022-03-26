<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ImageCode.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="验证码" Font-Size="30px"></asp:Label>
            <asp:TextBox ID="tbx_imgcheckingcode" runat="server" Width="70px"></asp:TextBox>
            <asp:ImageButton ID="ibtn_imgcheckingcode" src="WebForm2.aspx" runat="server" Height="40px" Width="70px" ondblclick="this.src = 'WebForm2.aspx?flag=' + javascript:changeCode()" />
            <a href="javascript:changeCode()" style="text-decoration: underline; font-size: 10px;">换一张</a>
            <%-- ondblclick 事件在用户双击元素时发生。--%>
            <img src="WebForm2.aspx" title='看不清楚，双击图片换一张。' ondblclick="this.src = 'WebForm2.aspx?flag=' + Math.random() " />
            <script type="text/javascript">
                function changeCode() {
                    document.getElementById('ibtn_imgcheckingcode').src = document.getElementById('ibtn_imgcheckingcode').src + '?';
                }
            </script>
            <asp:Button ID="Button1" runat="server" Text="验证" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
