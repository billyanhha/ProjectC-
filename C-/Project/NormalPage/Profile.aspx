<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Project.NormalPage.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    <div class="page-layout">
        <div class="modal fade" id="changeModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Change avatar</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <asp:FileUpload
                            ID="avatarFile"
                            runat="server"
                            type="file"
                            name="avatar"
                            accept="image/*"
                            class="form-control-file uploadAvatar"
                            Style="margin-top: 10px" />
                        <img id="image_upload_preview" src="" class="preImage" />
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="changeAvaButton" OnClick="changeAvaButton_Click" runat="server" CssClass="btn btn-primary submitChangeAva" Text="Submit" />
                    </div>
                </div>
            </div>
        </div>
        <div class="my-row">
            <div class="my-row-left">
                <div id="bgAvatar" runat="server" class="big-avatar">
                    <div
                        runat="server"
                        id="openChangeAvaModal"
                        data-toggle="modal" data-target="#changeModal"
                        class="changeAvatar">
                        <p class="uploadText">Upload</p>
                    </div>
                </div>
            </div>
            <div class="my-row-right">
                <h3>
                    <span runat="server" id="usernameLabel">Username</span>
                    <a
                        href="/user/setting"
                        data-toggle="tooltip"
                        title="Setting">
                        <i runat="server"
                            id="settingIcon"
                            class="fas fa-cog primarycolor-text"></i>
                    </a>
                </h3>
                <br />
                <h6 runat="server" id="fullnameLabel"></h6>
                <br />
                <span><i class="fas fa-map-marker-alt location"></i><b class="primarycolor-text date" runat="server" id="addressLabel"></b></span>
                <br />
                <br />
                <div class="profile-info">
                    <div class="profile-info-item">
                        <p class="profile-info-item-detail">Be our member at : <b class="primarycolor-text date" runat="server" id="joinedDateLabel"></b></p>
                    </div>
                    <div class="profile-info-item">
                        <p class="profile-info-item-detail">Rate : <b runat="server" id="ratedLabel" class="primarycolor-text" data-toggle="tooltip" title="By : "></b></p>
                    </div>
                    <div class="profile-info-item">
                        <p class="profile-info-item-detail">Product : <b runat="server" id="productLabel" class="primarycolor-text"></b></p>
                    </div>
                    <br />
                    <div class="profile-info-item">
                        <p class="profile-info-item-detail">Contact : <b runat="server" id="phoneNumber" class="primarycolor-text"></b></p>
                    </div>
                </div>
                <br />
                <p class="profile-info-item-detail">*** <b runat="server" class="wrap" id="description"></b></p>
                <div runat="server" id="rateDiv">
                    <div class="rate">
                        <asp:TextBox runat="server" CssClass="form-control" ViewStateMode ="Disabled" ID ="score" type="number" max="5" min="1" />
                        <asp:Button ID="rateBtn" OnClick ="rateBtn_Click" runat="server" CssClass="btn btn-primary" Text="Rate" />
                    </div>
                    <p class="small-description">* Rate user score from 1 to 5</p>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
