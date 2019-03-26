<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="ManageProduct.aspx.cs" Inherits="Project.NormalPage.ManageProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">


    <div class="page-layout">
        <div class="table-responsive">
            <asp:HiddenField ID="UserId" runat="server" />
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover" AutoGenerateColumns="False" DataKeyNames="product_id" DataSourceID="SqlDataSource1" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" Target ="_blank" runat="server" NavigateUrl="" Text ='<%# Eval("product_id")%>' ></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="product_id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="product_id" />
                    <asp:BoundField DataField="product_name" HeaderText="Product Name" SortExpression="product_name" />
                    <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description" />
                    <asp:BoundField DataField="ship_info" HeaderText="Ship info" SortExpression="ship_info" />
                    <asp:CheckBoxField DataField="status" HeaderText="Status" SortExpression="status" />
<asp:BoundField DataField="price" HeaderText="Price" SortExpression="price"></asp:BoundField>
                    <asp:BoundField DataField="viewNumber" ReadOnly ="true" HeaderText="View" SortExpression="viewNumber" />
                    <asp:CommandField ControlStyle-CssClass ="btn btn-primary btn-sm"  ButtonType="Button" ShowEditButton="True" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConn %>" 
                SelectCommand="SELECT [product_name], [product_id], [description], [ship_info], [status], [price], [viewNumber] FROM [products]"
                 UpdateCommand="UPDATE [products] SET [product_name] = @product_name, [description] = @description, [ship_info] = @ship_info, [status] = @status, [price] = @price, [viewNumber] = @viewNumber WHERE [product_id] = @product_id" DeleteCommand="DELETE FROM [products] WHERE [product_id] = @product_id" InsertCommand="INSERT INTO [products] ([product_name], [description], [ship_info], [status], [price], [viewNumber]) VALUES (@product_name, @description, @ship_info, @status, @price, @viewNumber)">
                <DeleteParameters>
                    <asp:Parameter Name="product_id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="product_name" Type="String" />
                    <asp:Parameter Name="description" Type="String" />
                    <asp:Parameter Name="ship_info" Type="String" />
                    <asp:Parameter Name="status" Type="Boolean" />
                    <asp:Parameter Name="price" Type="Decimal" />
                    <asp:Parameter Name="viewNumber" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="product_name" Type="String" />
                    <asp:Parameter Name="description" Type="String" />
                    <asp:Parameter Name="ship_info" Type="String" />
                    <asp:Parameter Name="status" Type="Boolean" />
                    <asp:Parameter Name="price" Type="Decimal" />
                    <asp:Parameter Name="viewNumber" Type="Int32" />
                    <asp:Parameter Name="product_id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </div>

</asp:Content>
