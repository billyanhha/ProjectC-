<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Project.NormalPage.Cart" %>

<%@ Register TagPrefix="UC" TagName="Order" Src="~/UserControl/Order.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    <%-- css --%>
    <link rel="stylesheet" type="text/css" href="/css/homeCategory.css" />
    <%--  --%>

    <div class="home-layout">
        <UC:Order ID="orderModalPage" runat="server" />
        <div class="category-product">
            <%if (getProductId() != null)
                {%>
            <h5><%=getProductId().Count %> products </h5>
            <div class="category-product-items">
                <%foreach (String productId in getProductId())
                    {%>
                <a href="/product/detail/<%=productId%>" class="category-product-item">
                    <div class="category-product-item-image" style="background-image: url('/image?pid=<%=productId%>&imageId=1')"></div>
                    <p><b><%=getProductById(productId).productName%></b></p>
                    <p>Price : <b class="primary"><%=getProductById(productId).price%></b> </p>
                </a>
                <%}%>
            </div>
            <asp:Button
                runat="server"
                ID="orderBtn" OnClick="orderBtn_Click"
                UseSubmitBehavior="false"
                ValidationGroup="-1"
                OnClientClick="return false;"
                CssClass="btn btn-warning btn-group-lg orderBtn"
                data-toggle="modal" data-target="#orderModal"
                Text="Order" />
            <% } %>
            <%else
                { %>
            <center><h4>You haven't add anything yet , <a href="/home">continue shopping</a> </h4></center>
            <% } %>
        </div>
    </div>


</asp:Content>
