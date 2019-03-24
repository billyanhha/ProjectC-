<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Project.NormalPage.Home" %>



<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/home.css" />
    <div class="home-layout">
        <div class="category">
            <div class="category-item">
                Clothe
            </div>
            <div class="category-item">
                Sport
            </div>
            <div class="category-item">
                Fashion
            </div>
            <div class="category-item">
                Vehicle
            </div>
            <div class="category-item">
                Gaming
            </div>
            <div class="category-item">
                Electronic
            </div>
            <div class="category-item">
                Kids stuff
            </div>
        </div>
        <div class="category-product">
            <h3 class="category-name">Gaming</h3>
            <div class="category-product-items">
                <%for (int i = 0; i < 8; i++)
                    { %>
                <div class="category-product-item">
                    <img class="category-product-item-image" src="../images/default_user.png" />
                    <p><b class="product-name">Product name</b></p>
                    <p>Price : <b class="primarycolor-text">xx</b> </p>
                </div>
                <% } %>
            </div>
        </div>
    </div>
</asp:Content>
