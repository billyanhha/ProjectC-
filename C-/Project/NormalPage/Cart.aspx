<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Project.NormalPage.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    <%-- css --%>
    <link rel="stylesheet" type="text/css" href="/css/homeCategory.css" />
    <%--  --%>

    <div class="home-layout">
        <div class="category-product">
            <h5><%=getProductId().Count %> products </h5>
            <div class="category-product-items">
                <%if (getProductId() != null)
                    { %>
                <%foreach (String productId in getProductId())
                    { %>
                <a href="/product/detail/<%=productId%>" class="category-product-item">
                    <div class="category-product-item-image" style="background-image: url('/image?pid=<%=productId%>&imageId=1')"></div>
                    <p><b><%=getProductById(productId).productName%></b></p>
                    <p>Price : <b class="primary"><%=getProductById(productId).price%></b> </p>
                </a>
                <% } %>
                <% } %>
                <%else
                    { %>
                <h3>No cart item yet , <a href="/home">continue shopping</a> </h3>
                <% } %>
            </div>
        </div>
    </div>


</asp:Content>
