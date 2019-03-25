<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="ManageProduct.aspx.cs" Inherits="Project.NormalPage.ManageProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">


    <div class="page-layout">
        <div class="table-responsive">
            <asp:HiddenField ID="UserId" runat="server" />
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover" AutoGenerateColumns="False" DataKeyNames="product_id" DataSourceID="SqlDataSource1" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Detail">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" Target="_blank" runat="server"    Text='<%# Eval("product_id") %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="product_id" HeaderText="Product id" InsertVisible="False" ReadOnly="True" SortExpression="product_id" />
                    <asp:BoundField DataField="product_name" HeaderText="Product name" SortExpression="product_name" />
                    <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description" />
                    <asp:TemplateField HeaderText="Price" SortExpression="price">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" type ="number" Text='<%# Bind("price") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("price") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ship_info" HeaderText="Ship info" SortExpression="ship_info" />
                    <asp:BoundField DataField="viewNumber" HeaderText="View" SortExpression="viewNumber" />
                    <asp:CheckBoxField DataField="status" HeaderText="Status" SortExpression="status" />
                    <asp:CommandField ControlStyle-CssClass="btn btn-primary" ButtonType="Button" ShowEditButton="True" >
<ControlStyle CssClass="btn btn-primary"></ControlStyle>
                    </asp:CommandField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConn %>" SelectCommand="SELECT [viewNumber], [status], [ship_info], [description], [product_name], [product_id], [price] FROM [products] WHERE ([createdBy] = @createdBy)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="UserId" Name="createdBy" PropertyName="Value" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </div>

</asp:Content>
