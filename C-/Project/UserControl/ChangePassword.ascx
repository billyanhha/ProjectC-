<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.ascx.cs" Inherits="Project.UserControl.ChangePassword" %>

<div class="setting-item">

    <div class="form-group">
        <label for="exampleInputEmail1">Old password</label>
        <asp:TextBox ID="oldPassword" required="" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator
            ID="RequiredFieldValidator1"
            runat="server"
            Display="Dynamic"
            ValidationGroup="changePw"
            ControlToValidate="oldPassword"
            ErrorMessage="Required">
        </asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="exampleInputEmail1">New password</label>
        <asp:TextBox ID="passwordTxt" required="" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        <asp:RegularExpressionValidator
            ID="RegularExpressionValidator2"
            ControlToValidate="passwordTxt"
            ValidationExpression="^[a-zA-Z0-9]{7,}$"
            Display="Dynamic"
            runat="server"
            ValidationGroup="changePw"
            CssClass="validate"
            ErrorMessage="Password must contain mother than 6 characters">
        </asp:RegularExpressionValidator>
    </div>

    <div class="form-group">
        <label for="exampleInputEmail1">Confirm password</label>
        <asp:TextBox ID="confirmTxt" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1"
            runat="server"
            ControlToValidate="confirmTxt"
            ControlToCompare="passwordTxt"
            ValidationGroup="changePw"
            Display="Dynamic"
            CssClass="validate"
            ErrorMessage="No match">
        </asp:CompareValidator>
    </div>
    <asp:Button ID="changePwBtn"
         ValidationGroup="changePw"
        UseSubmitBehavior ="false"
        OnClick="changePwBtn_Click" runat="server" CssClass="btn btn-primary btn-sm changeBtn" Text="Submit change" />
</div>
