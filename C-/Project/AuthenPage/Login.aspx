<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Project.Login" %>

<%@ Register TagPrefix="UC" TagName="Message" Src="~/UserControl/Message.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login</title>
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
        <UC:Message ID="Message" runat="server" icname="fas fa-exclamation-triangle" msg="Username or password was wrong" />
        <div class="login container-fluid">
            <div class="row align-items-center justify-content-center">
                <div class="col-12 col-md-4 col-lg-3 ">
                    <div>
                        <p style="font-size: 72px; font-weight: bold; color: #FFFFFF;">Chocu</p>
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" Text="Trade market place"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" Text="Username"></asp:Label>
                        <br />
                        <asp:TextBox ID="usernameTxt" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="validate" ID="usernameRequired" runat="server" ControlToValidate="usernameTxt" ErrorMessage="Username must be filled !" Display="Dynamic"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" Text="Password"></asp:Label>
                        <br />
                        <asp:TextBox ID="passwordTxt" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="validate" ID="passwordRequired" runat="server" ControlToValidate="passwordTxt" ErrorMessage="Password must be filled !" Display="Dynamic"></asp:RequiredFieldValidator>
                        <br />
                        <asp:CheckBox ID="rembemberCb" runat="server" Font-Bold="True" CssClass="custom-checkbox" Font-Size="Medium" Text="Remember me" />
                        <br />
                        <asp:Button ID="LoginBtn" runat="server" Font-Bold="True" CssClass="btn btn-light btn-block loginBtn" ForeColor="#189EFF" Text="Login" OnClick="Login_Click" />
                        <br />
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Medium" Text="No account ? "></asp:Label>
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" ForeColor="Black" CssClass="hyperlink" ToolTip="Lego" NavigateUrl="/signup">Sign up</asp:HyperLink>
                        <br />
                    </div>
                </div>
                <div class="col-12 col-md-8 col-lg-5 d-none d-md-block">
                    <img alt="logo" class="img-fluid" src="../images/login.png" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
