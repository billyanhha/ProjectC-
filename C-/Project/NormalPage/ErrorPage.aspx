<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="Project.NormalPage.ErrorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="row error-body no-margin">
        <div class="col-12 col-md-2">
            <img alt="404" src="../images/tải xuống.png" />
        </div>
        <div class="col-12 col-md-3">
            <h1 runat="server" id ="errMsg">Not available</h1>
            <%--<h5>We are trying to solve this problem</h5>--%>
        </div>
    </div>
</asp:Content>
