<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="_20220420_GridView.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="teacherid" HeaderText="教师编号" />
                    <asp:BoundField DataField="teachername" HeaderText="教师名" />
                    <asp:BoundField DataField="age" HeaderText="年龄" />
                    <asp:BoundField DataField="gender" HeaderText="性别" />
                    <asp:BoundField DataField="birthday" HeaderText="生日" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:BoundField DataField="QQ" HeaderText="QQ" />
                    <asp:BoundField DataField="titlename" HeaderText="职称" />
                    <asp:BoundField DataField="rolename" HeaderText="登陆身份" />
                    <asp:BoundField DataField="officename" HeaderText="所在办公室" />
                    <asp:BoundField DataField="schoolname" HeaderText="所属学院" />
                    <asp:BoundField DataField="authorizedname" HeaderText="在职状态" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
