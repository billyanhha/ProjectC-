<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="Project.NormalPage.ProductDetail" %>
<%@ Register TagPrefix ="UC" TagName="EditProduct" Src ="~/UserControl/EditProduct.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <link rel="stylesheet" href="../../css/productDetail.css" />
    <UC:EditProduct runat ="server"  id ="editModal" />
    <div class="page-layout white-background ">
        <h3 runat="server" id="noProduct">No product</h3>
        <div class="row no-margin product-detail" id="productDetail" style="" runat="server">
            <div class="col-12 col-md-5">
                <div id="product" class="carousel slide" data-ride="carousel">
                    <!-- Indicators -->
                    <ul class="carousel-indicators">
                        <%for (int i = 0; i < getProductImage(); i++)
                            {%>
                        <li data-target="#product" data-slide-to="<%= i %>" class="<%= i == 0 ? "active" : "" %>" k></li>
                        <% } %>
                    </ul>

                    <!-- The slideshow -->

                    <div class="carousel-inner">
                        <%for (int i = 1; i <= getProductImage(); i++)
                            {%>
                        <div class="carousel-item <%= i == 1 ? "active" : ""%>">
                            <div class="carousel-innter_image" style="background-image: url('/image?pid=<%=id%>&imageId=<%=i%>')">
                            </div>
                        </div>
                        <% } %>
                    </div>


                    <!-- Left and right controls -->
                    <a class="carousel-control-prev" href="#product" data-slide="prev">
                        <span class="carousel-control-prev-icon carousel-common-icon"></span>
                    </a>
                    <a class="carousel-control-next" href="#product" data-slide="next">
                        <span class="carousel-control-next-icon carousel-common-icon"></span>
                    </a>
                </div>
            </div>
            <div class="col-12 col-md-7 detail-right">
                <div class="detail-right-header">
                    <p runat="server" id="productName" class="big-text">
                        Product name
                    </p>
                    <div class="dropdown show">
                        <i runat="server" id="editProduct" class="fas fa-wrench editIcon" style="" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"></i>
                        <div class="dropdown-menu" aria-labelledby="editProduct">
                            <button type="button" class="btn dropdown-item" data-toggle="modal" data-target="#myModal">
                                Edit product
                            </button>
                            <a class="dropdown-item" href="#">Switch status</a>
                        </div>
                    </div>
                </div>
                <p><span class="small-description">Category : </span><a runat="server" id="productCategory" href="#">Category</a></p>
                <p class="normal-text">
                    <b runat="server" id="productView">15</b> views - 
                    <b class="primarycolor-text" runat="server" id="productOrder">0 </b>order
                </p>
                <hr />
                <div class="product-description" runat="server" id="productDescription">
                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
                </div>
                <hr />
                <div class="product-ship" runat="server" id="productShipInfo">
                    Lorem Ipsum is simply dummy tsheets containing like Aldus PageMaker including versions of Lorem Ipsum.
                </div>
                <hr />
                <p>
                    <span class="small-description">Status : </span>
                    <span runat="server" id="sold" class="status sold">Sold</span>
                    <span runat="server" id="selling" class="status selling">Selling</span>
                </p>
                <div runat="server" id="order" class="orderDiv" style="">
                    <asp:Button ID="orderBtn" runat="server" CssClass="btn btn-outline-primary btn-block" Text="Order" />
                    <p class="small-description">* Order to let owner know you interested in the product</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
