<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="ProductOrder.aspx.cs" Inherits="Project.NormalPage.ProductOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="page-layout">
        <%if (getTotalOrderProduct() == 0)
            { %>
            <h5>No order for this product</h5>
        <%} %>
        <div class="table-responsive">
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:GridView ID="GridView1" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="User ID">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="" Text='<%# Eval("user_id") %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="order_id" HeaderText="Order id" SortExpression="order_id" />
                    <asp:BoundField DataField="product_id" HeaderText="Product id" SortExpression="product_id" />
                    <asp:BoundField DataField="username" HeaderText="User name" SortExpression="username" />
                    <asp:BoundField DataField="ship_location" HeaderText="Ship to" SortExpression="ship_location" />
                    <asp:BoundField DataField="phoneContact" HeaderText="Phone" SortExpression="phoneContact" />
                    <asp:BoundField DataField="otherContact" HeaderText="Other Contact" SortExpression="otherContact" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConn %>" SelectCommand="SELECT orders_products.order_id, orders_products.product_id, orders_users.user_id, users.username, orders.ship_location, orders.phoneContact, orders.otherContact FROM orders_products INNER JOIN orders ON orders_products.order_id = orders.order_id INNER JOIN orders_users ON orders.order_id = orders_users.order_id INNER JOIN users ON orders_users.user_id = users.id WHERE (orders_products.product_id = @product )">
                <SelectParameters>
                    <asp:ControlParameter ControlID="HiddenField1" Name="product" PropertyName="Value" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </div>


</asp:Content>
