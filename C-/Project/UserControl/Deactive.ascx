<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Deactive.ascx.cs" Inherits="Project.UserControl.Deactive" %>

<div class="setting-item">
    <div class="form-group">
        <label for="exampleInputEmail1">Enter your password</label>
        <asp:TextBox ID="passwordDeactive" required="" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator
            ID="RequiredFieldValidator1"
            runat="server"
            Display="Dynamic"
            ControlToValidate="passwordDeactive"
            ErrorMessage="Required">
        </asp:RequiredFieldValidator>
    </div>
    <asp:Button ID="deactiveAccount"  OnClick="deactiveAccount_Click" runat="server" CssClass="btn btn-primary btn-sm" Text="Deactive" />
</div>
