<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="Project.NormalPage.ProductDetail" %>



<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <link rel="stylesheet" href="../../css/productDetail.css" />
    <div class="page-layout white-background ">
        <div class="row no-margin product-detail">
            <div class="col-12 col-md-5">
                <div id="product" class="carousel slide" data-ride="carousel">
                    <!-- Indicators -->
                    <ul class="carousel-indicators">
                        <li data-target="#product" data-slide-to="0" class="active"></li>
                        <li data-target="#product" data-slide-to="1"></li>
                        <li data-target="#product" data-slide-to="2"></li>
                    </ul>

                    <!-- The slideshow -->
                    <div class="carousel-inner">
                        <div class="carousel-item active">
                            <div class="carousel-innter_image" style="background-image: url(../../images/default_user.png)">
                            </div>
                        </div>
                        <div class="carousel-item">
                            <div class="carousel-innter_image" style="background-image: url(../../images/login.png)">
                            </div>
                        </div>
                        <div class="carousel-item">
                            <div class="carousel-innter_image" style="background-image: url(../../images/page.jpg)">
                            </div>
                        </div>
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
                    <p class="big-text">
                        Product name
                    </p>
                    <div class="dropdown show">
                        <i runat="server" id="editProduct" class="fas fa-wrench editIcon" style ="" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"></i>
                        <div class="dropdown-menu" aria-labelledby="editProduct">
                            <a class="dropdown-item" href="#">Edit product</a>
                            <a class="dropdown-item" href="#">Switch status</a>
                        </div>
                    </div>
                </div>
                <p><span class="small-description">Category : </span><a href="#">Category</a></p>
                <p class="normal-text"><b>15</b> views - <b class="primarycolor-text">0 </b>order</p>
                <hr />
                <div class="product-description">
                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
                </div>
                <hr />
                <div class="product-ship">
                    Lorem Ipsum is simply dummy tsheets containing like Aldus PageMaker including versions of Lorem Ipsum.
                </div>
                <hr />
                <p><span class="small-description">Status : </span><span class="status sold">Sold</span> <span class="status selling">Selling</span></p>
                <div runat ="server" id="order" class ="orderDiv" style ="">
                    <asp:Button ID="orderBtn" runat="server" CssClass="btn btn-outline-primary btn-block" Text="Order" />
                    <p class="small-description">* Order to let owner know you interested in the product</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
