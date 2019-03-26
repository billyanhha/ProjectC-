<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Project.NormalPage.Home" %>



<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <%-- css --%>
    <link rel="stylesheet" type="text/css" href="../css/homeCategory.css" />
    <%--  --%>
    <div class="home-layout">
        <div class="category">

            <% foreach (ChocuModel.Category item in categories)
                { %>
            <a href="/category/<%=item.ID%>/<%=item.CategoryName%>" class="category-item">
                <%=item.CategoryName %>
            </a>
            <%} %>
        </div>


        <% foreach (ChocuModel.Category item in categories)
            { %>
        <div class="category-product">
            <h4 class="category-name"><%=item.CategoryName %></h4>
            <div class="category-product-items">
                <%foreach (ChocuModel.Product product in getProductByCategory(item.ID))
                    { %>
                <a target="_blank" href="/product/detail/<%=product.id%>" class="category-product-item">
                    <div class="category-product-item-image" style="background-image: url('/image?pid=<%=product.id%>&imageId=1')"></div>
                    <p><b class="product-name"><%=product.productName %></b></p>
                    <p>Price : <b class="primarycolor-text"><%=double.Parse(product.price + "").ToString("#,###", cul.NumberFormat)%> vnd</b> </p>
                </a>
                <% } %>
            </div>
            <div>
                <a href="/category/<%=item.ID%>/<%=item.CategoryName%>" class="small">View full category</a>
            </div>
        </div>
        <%} %>
    </div>
</asp:Content>
