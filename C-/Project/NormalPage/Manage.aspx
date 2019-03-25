<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Project.NormalPage.Manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">


    <div class="page-layout">
        <div class="table-responsive">
            <h5>Active user</h5>
            <asp:GridView EnableViewState="false" ID="GridView1" runat="server" CssClass="table table-hover" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" PageSize="15" AutoGenerateColumns="False" DataKeyNames="id">
                <Columns>
                    <asp:CommandField  ControlStyle-CssClass="btn btn-primary" ButtonType="Button" ShowEditButton="True" />
                    <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" InsertVisible="False" ReadOnly="True" />
                    <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
                    <asp:BoundField DataField="fullname" HeaderText="fullname" SortExpression="fullname" />
                    <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
                    <asp:CommandField ControlStyle-CssClass="btn btn-danger" ButtonType="Button" DeleteText="Ban" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConn %>"
                SelectCommand="SELECT [username], [fullname], [description], [id] FROM [users] WHERE ([ban] = @ban) and isAdmin = 0"
                DeleteCommand="UPDATE [users] SET [ban] = 1 WHERE [id] = @id"
                InsertCommand="INSERT INTO [users] ([username], [fullname], [description]) VALUES (@username, @fullname, @description)"
                UpdateCommand="UPDATE [users] SET [username] = @username, [fullname] = @fullname, [description] = @description WHERE [id] = @id">
                <DeleteParameters>
                    <asp:Parameter Name="id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="username" Type="String" />
                    <asp:Parameter Name="fullname" Type="String" />
                    <asp:Parameter Name="description" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:Parameter DefaultValue="false" Name="ban" Type="Boolean" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="username" Type="String" />
                    <asp:Parameter Name="fullname" Type="String" />
                    <asp:Parameter Name="description" Type="String" />
                    <asp:Parameter Name="id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
        <br /><br />
        <div class="table-responsive">
            <h5>Ban user</h5>
            <asp:GridView ID="GridView2" EnableViewState="false"  CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource2">
                <Columns>
                    <asp:CommandField ControlStyle-CssClass="btn btn-danger" ButtonType="Button" DeleteText="Unban" ShowDeleteButton="True" />
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
                    <asp:BoundField DataField="fullname" HeaderText="fullname" SortExpression="fullname" />
                    <asp:BoundField DataField="rate" HeaderText="rate" SortExpression="rate" />
                    <asp:BoundField DataField="rate_numbers" HeaderText="rate_numbers" SortExpression="rate_numbers" />
                    <asp:BoundField DataField="joined" HeaderText="joined" SortExpression="joined" />
                    <asp:BoundField DataField="phoneNumber" HeaderText="phoneNumber" SortExpression="phoneNumber" />
                    <asp:BoundField DataField="address" HeaderText="address" SortExpression="address" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:MyConn %>" 
                DeleteCommand="UPDATE [users] SET [ban] = 0 WHERE [id] = @id"
                InsertCommand="INSERT INTO [users] ([username], [fullname], [rate], [rate_numbers], [joined], [phoneNumber], [address]) VALUES (@username, @fullname, @rate, @rate_numbers, @joined, @phoneNumber, @address)" SelectCommand="SELECT [id], [username], [fullname], [rate], [rate_numbers], [joined], [phoneNumber], [address] FROM [users] WHERE ([ban] = @ban2)" UpdateCommand="UPDATE [users] SET [username] = @username, [fullname] = @fullname, [rate] = @rate, [rate_numbers] = @rate_numbers, [joined] = @joined, [phoneNumber] = @phoneNumber, [address] = @address WHERE [id] = @id">
                <DeleteParameters>
                    <asp:Parameter Name="id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="username" Type="String" />
                    <asp:Parameter Name="fullname" Type="String" />
                    <asp:Parameter Name="rate" Type="Int32" />
                    <asp:Parameter Name="rate_numbers" Type="Int32" />
                    <asp:Parameter DbType="Date" Name="joined" />
                    <asp:Parameter Name="phoneNumber" Type="String" />
                    <asp:Parameter Name="address" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:Parameter DefaultValue="true" Name="ban2" Type="Boolean" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="username" Type="String" />
                    <asp:Parameter Name="fullname" Type="String" />
                    <asp:Parameter Name="rate" Type="Int32" />
                    <asp:Parameter Name="rate_numbers" Type="Int32" />
                    <asp:Parameter DbType="Date" Name="joined" />
                    <asp:Parameter Name="phoneNumber" Type="String" />
                    <asp:Parameter Name="address" Type="String" />
                    <asp:Parameter Name="id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </div>



</asp:Content>
