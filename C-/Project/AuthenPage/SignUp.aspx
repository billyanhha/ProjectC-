<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Project.SignUp" %>

<%@ Register TagPrefix="UC" TagName="Message" Src="~/UserControl/Message.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>SignUp</title>
    <link rel="icon" href="images/page.jpg" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css" />
    <link rel="stylesheet" href="../css/styles.css" />
    <link rel="stylesheet" href="../css/authenPageStyle.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <UC:Message ID="Message" runat="server" icname="fas fa-exclamation-triangle" msg="Username has been used already" />
        <div class="login container-fluid">
            <div class="row align-items-center justify-content-center">
                <div class="col-12 col-md-4 col-lg-3 ">
                    <div>
                        <p style="font-size: 72px; font-weight: bold; color: #FFFFFF;">Chocu</p>
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" Text="Signup for better trade market place"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" Text="Username"></asp:Label>
                        <br />
                        <asp:TextBox ID="usernameTxt" required="" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RegularExpressionValidator
                            ID="RegularExpressionValidator1"
                            ControlToValidate="usernameTxt"
                            runat="server"
                            Display="Dynamic"
                            CssClass="validate"
                            ValidationExpression="^[a-zA-Z0-9]{5,}$"
                            ErrorMessage="Username must have more than 4 characters">
                        </asp:RegularExpressionValidator>
                        <br />
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" Text="Password"></asp:Label>
                        <br />
                        <asp:TextBox ID="passwordTxt" required="" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        <asp:RegularExpressionValidator
                            ID="RegularExpressionValidator2"
                            ControlToValidate="passwordTxt"
                            ValidationExpression="^[a-zA-Z0-9]{7,}$"
                            runat="server"
                            CssClass="validate"
                            ErrorMessage="Password must contain mother than 7 characters">
                        </asp:RegularExpressionValidator>
                        <br />
                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Medium" Text="Re-enter password"></asp:Label>
                        <br />
                        <asp:TextBox ID="confirmTxt" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1"
                            runat="server"
                            ControlToValidate="confirmTxt"
                            ControlToCompare="passwordTxt"
                            CssClass="validate"
                            ErrorMessage="No match">

                        </asp:CompareValidator>
                        <br />
                        <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Small" Text="By click submit , you are agreed with our term and privacy"></asp:Label>
                        <br />
                        <br />
                        <asp:Button ID="submitBtn" runat="server" OnClick="SumbitBtn_Click" Font-Bold="True" CssClass="btn btn-light btn-block" ForeColor="#189EFF" Text="Submit" />
                        <br />
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Medium" Text="Already have an account ? "></asp:Label>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="/login" Font-Bold="True" ForeColor="Black" CssClass="hyperlink" ToolTip="Lego">Login</asp:HyperLink>
                        <br />
                    </div>
                </div>
                <div class="col-12 col-md-8 col-lg-5 d-none d-md-block">
                    <img alt="logo" class="img-fluid" src="../images/login.png" />
                </div>
            </div>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:insertUser %>" DeleteCommand="DELETE FROM [users] WHERE [id] = @id" InsertCommand="INSERT INTO [users] ([username] , [password]) VALUES (@username,  @password)" SelectCommand="SELECT * FROM [users]" UpdateCommand="UPDATE [users] SET [username] = @username, [address] = @address, [phoneNumber] = @phoneNumber, [description] = @description, [active] = @active, [isAdmin] = @isAdmin, [rate] = @rate, [rate_numbers] = @rate_numbers, [avatar] = @avatar, [contentType] = @contentType, [fullname] = @fullname, [password] = @password WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="username" Type="String" />
                <asp:Parameter Name="address" Type="String" />
                <asp:Parameter Name="phoneNumber" Type="String" />
                <asp:Parameter Name="description" Type="String" />
                <asp:Parameter Name="active" Type="Boolean" />
                <asp:Parameter Name="isAdmin" Type="Boolean" />
                <asp:Parameter Name="rate" Type="Int32" />
                <asp:Parameter Name="rate_numbers" Type="Int32" />
                <asp:Parameter Name="avatar" Type="Object" />
                <asp:Parameter Name="contentType" Type="String" />
                <asp:Parameter Name="fullname" Type="String" />
                <asp:Parameter Name="password" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="username" Type="String" />
                <asp:Parameter Name="address" Type="String" />
                <asp:Parameter Name="phoneNumber" Type="String" />
                <asp:Parameter Name="description" Type="String" />
                <asp:Parameter Name="active" Type="Boolean" />
                <asp:Parameter Name="isAdmin" Type="Boolean" />
                <asp:Parameter Name="rate" Type="Int32" />
                <asp:Parameter Name="rate_numbers" Type="Int32" />
                <asp:Parameter Name="avatar" Type="Object" />
                <asp:Parameter Name="contentType" Type="String" />
                <asp:Parameter Name="fullname" Type="String" />
                <asp:Parameter Name="password" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
