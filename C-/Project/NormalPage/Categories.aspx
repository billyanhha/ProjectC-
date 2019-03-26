<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="Project.NormalPage.Categories" %>



<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <%-- css --%>
    <link rel="stylesheet" type="text/css" href="/css/homeCategory.css" />
    <%--  --%>

    <div class="home-layout">
        <div class="category">
            <% foreach (ChocuModel.Category item in categories)
                { %>
            <a href="/category/<%=item.ID%>/<%=item.CategoryName%>" class="category-item <%=item.ID == id ? "category-active" : "" %>">
                <%=item.CategoryName %>
            </a>
            <%} %>
        </div>
        <div class="category-product">
            <h4 class="category-name"><%=category %></h4>
            <%if (getProductByCategory().Count == 0)
                { %>
            <br /><br />
            <h5>No product</h5>
            <% } %>
            <%else
                { %>
            <div class="category-product-items">
                <%foreach (ChocuModel.Product product in getProductByCategory())
                    { %>
                <a target="_blank" href="/product/detail/<%=product.id%>" class="category-product-item">
                    <div class="category-product-item-image" style="background-image: url('/image?pid=<%=product.id%>&imageId=1')"></div>
                    <p><b><%=product.productName %></b></p>
                    <p>Price : <b class="primarycolor-text"><%=double.Parse(product.price + "").ToString("#,###", cul.NumberFormat)%> vnd</b> </p>
                </a>
                <% } %>
            </div>
            <%} %>
        </div>
        <center><%=generatePagination() %></center>
    </div>

</asp:Content>
