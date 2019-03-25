<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Project.NormalPage.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <%-- css --%>
    <link rel="stylesheet" type="text/css" href="/css/homeCategory.css" />
    <%--  --%>

    <div class="home-layout">
        <h5>Search result for " <span class="primary-text"><%=Request.QueryString["queryString"]%></span> "</h5>

        <div class="category-product">
            <div class="category-product-items">
                <%foreach (ChocuModel.Product product in getProductPerPage())
                    { %>
                <a target="_blank" href="/product/detail/<%=product.id%>" class="category-product-item">
                    <div class="category-product-item-image" style="background-image: url('/image?pid=<%=product.id%>&imageId=1')"></div>
                    <p><b><%=product.productName %></b></p>
                    <p>Price : <b class="primary"><%=product.price %></b> </p>
                </a>
                <% } %>
            </div>
        </div>
        <center><%=generatePagination() %></center>

    </div>

</asp:Content>
