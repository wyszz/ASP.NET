<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="_20220420_SQLDataSource.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="TeacherID" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="TeacherID" HeaderText="TeacherID" ReadOnly="True" SortExpression="TeacherID" />
                    <asp:BoundField DataField="TeacherName" HeaderText="TeacherName" SortExpression="TeacherName" />
                    <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                    <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="QQ" HeaderText="QQ" SortExpression="QQ" />
                    <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                    <asp:BoundField DataField="Birthday" HeaderText="Birthday" SortExpression="Birthday" />
                    <asp:BoundField DataField="TitleID" HeaderText="TitleID" SortExpression="TitleID" />
                    <asp:BoundField DataField="RoleID" HeaderText="RoleID" SortExpression="RoleID" />
                    <asp:BoundField DataField="OfficeID" HeaderText="OfficeID" SortExpression="OfficeID" />
                    <asp:BoundField DataField="AuthorizedID" HeaderText="AuthorizedID" SortExpression="AuthorizedID" />
                    <asp:BoundField DataField="PhotoUrl" HeaderText="PhotoUrl" SortExpression="PhotoUrl" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ScoreDBConnectionString %>" SelectCommand="SELECT * FROM [Teacher]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
