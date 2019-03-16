<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Project.NormalPage.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    <div class="page-layout">
        <div class="my-row">
            <div class="my-row-left">
                <div id="bgAvatar" runat="server" class="big-avatar">
                </div>
            </div>
            <div class="my-row-right">
                <h3>Username
                    <ion-icon name="hammer" class="primarycolor-text" data-toggle="tooltip" title="Setting"></ion-icon>
                </h3>
                <br />
                <div class="profile-info">
                    <div class="profile-info-item">
                        <p>Join at : <b class="primarycolor-text">2019-16-3</b></p>
                    </div>
                    <div class="profile-info-item">
                        <p>Rate : <b class="primarycolor-text" data-toggle="tooltip" title="By : ">4 / 5</b></p>
                    </div>
                    <div class="profile-info-item">
                        <p>Product : <b class="primarycolor-text">213</b></p>
                    </div>
                </div>
                <div class ="rate">
                    <input class ="form-control" type ="number" max ="5" min ="1" />
                    <button class ="btn btn-primary">Rate</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
