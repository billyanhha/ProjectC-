<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Project.NormalPage.AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="page-layout white-background">
        <h3>Add product</h3>
        <br />
        <div class="form-group">
            <label runat ="server" id="test" for="exampleInputEmail1">Product name</label>
            <asp:TextBox ID="productName"
                runat="server"
                CssClass="form-control"
                placeholder="Enter product name">
            </asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator1"
                ControlToValidate="productName"
                Display="Dynamic"
                runat="server" ErrorMessage="Required">
            </asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="exampleInputEmail1">Description</label>
            <asp:TextBox
                ID="productDes"
                runat="server"
                TextMode="multiline"
                CssClass="form-control"
                placeholder="Tell about your product">
            </asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator2"
                ControlToValidate="productDes"
                Display="Dynamic"
                runat="server" ErrorMessage="Required">
            </asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="exampleInputEmail1">Ship info</label>
            <asp:TextBox
                ID="shipInfo"
                runat="server"
                TextMode="multiline"
                CssClass="form-control"
                placeholder="Ship info">
            </asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator3"
                ControlToValidate="shipInfo"
                Display="Dynamic"
                runat="server" ErrorMessage="Required">
            </asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="exampleInputEmail1">Category</label>
            <asp:DropDownList ID="DropDownList1" CssClass="custom-select" runat="server" DataSourceID="Category" DataTextField="category_name" DataValueField="category_id"></asp:DropDownList>
            <asp:SqlDataSource ID="Category" runat="server" ConnectionString="<%$ ConnectionStrings:Category %>" SelectCommand="SELECT * FROM [category] order by category_id"></asp:SqlDataSource>
        </div>
        <div class="form-group">
            <label for="exampleInputEmail1">Product image</label>
            <br />
            <div>
                <asp:FileUpload ID="fileImages"
                    AllowMultiple="true"
                    accept="image/*"
                    CssClass ="multiFileUpload"
                    runat="server" />


                <div class="preview-image">
                </div>

                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator4"
                    ControlToValidate="fileImages"
                    Display="Dynamic"
                    runat="server" ErrorMessage="You have to prodive images as evidence">
                </asp:RequiredFieldValidator>
            </div>
        </div>
        <asp:Button runat="server" OnClick="addProduct_Click" ID="addProduct" CssClass="btn btn-primary btn-block addProductBtn" Text="Add product" />
    </div>


</asp:Content>
