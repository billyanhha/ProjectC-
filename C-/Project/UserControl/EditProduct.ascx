<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditProduct.ascx.cs" Inherits="Project.UserControl.EditProduct" %>

<div class="modal" id="myModal">
    <div class="modal-dialog">
        <div class="modal-content">
            <!-- Modal Header -->
            <div class="modal-header">
                <h4 class="modal-title">Edit product</h4>
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>

            <!-- Modal body -->
            <div class="modal-body">

                <div class="form-group">
                    <label runat="server" id="test" for="exampleInputEmail1">Product name</label>
                    <asp:TextBox ID="productName"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Enter product name">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1"
                        ValidationGroup="edit"
                        ControlToValidate="productName"
                        Display="Dynamic"
                        runat="server" ErrorMessage="Required">
                    </asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="exampleInputEmail1">Price</label>
                    <asp:TextBox
                        ID="price"
                        runat="server"
                        type="number"
                        CssClass="form-control"
                        placeholder="Enter price">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator5"
                        ControlToValidate="price"
                        Display="Dynamic"
                        ValidationGroup="edit"
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
                        ValidationGroup="edit"
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
                        ValidationGroup="edit"
                        Display="Dynamic"
                        runat="server" ErrorMessage="Required">
                    </asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="exampleInputEmail1">Category</label>
                    <asp:DropDownList ID="categoryDropDown" CssClass="custom-select" runat="server" DataSourceID="Category" DataTextField="category_name" DataValueField="category_id"></asp:DropDownList>
                    <asp:SqlDataSource ID="Category" runat="server" ConnectionString="<%$ ConnectionStrings:Category %>" SelectCommand="SELECT * FROM [category] order by category_id"></asp:SqlDataSource>
                </div>
                <div class="form-group">
                    <label for="exampleInputEmail1">Product image</label>
                    <br />
                    <div>
                        <asp:FileUpload ID="fileImages"
                            AllowMultiple="true"
                            accept="image/*"
                            CssClass="multiFileUpload"
                            runat="server" />

                        <%-- preview image --%>
                        <div class="preview-image">
                        </div>

                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator4"
                            ControlToValidate="fileImages"
                            Display="Dynamic"
                            ValidationGroup="edit"
                            runat="server"
                            ErrorMessage="You have to prodive images as evidence">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
                <asp:Button ValidationGroup="edit" runat="server" ID="editProductBtn" CssClass="btn btn-primary btn-block addProductBtn" Text="Edit product" OnClick="editProductBtn_Click" UseSubmitBehavior="False" />

            </div>


        </div>
    </div>
</div>
