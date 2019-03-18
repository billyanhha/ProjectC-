<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditProfile.ascx.cs" Inherits="Project.UserControl.EditProfile" %>

<div class="setting-item">
    <div class="form-group">
        <label for="exampleInputEmail1">Fullname</label>
        <asp:TextBox ID="fullname" runat="server" CssClass="form-control fullname" placeholder="Enter name"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="exampleInputEmail1">About your self</label>
        <asp:TextBox
            ID="des"
            runat="server"
            TextMode="multiline"
            CssClass="form-control aboutme"
            placeholder="Tell about urself">
        </asp:TextBox>
    </div>
    <div class="form-group">
        <label for="exampleInputEmail1">Phone number</label>
        <asp:TextBox ID="phoneTxt"
            runat="server"
            type="number"
            CssClass="form-control phonenum" placeholder="Enter phonenumber"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="exampleInputEmail1">Address</label>
        <asp:TextBox ID="addressTxt"
            runat="server"
            CssClass="form-control addressC" placeholder="Enter address"></asp:TextBox>
    </div>
    <asp:Button runat="server" OnClick ="edit" ID="EditSubmitBtn" CssClass="btn btn-primary btn-sm editBtn"  Text="Submit edit" />
</div>
