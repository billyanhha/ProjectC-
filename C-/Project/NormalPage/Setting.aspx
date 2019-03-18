<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="Project.NormalPage.Setting" %>

<%@ Register Src="~/UserControl/EditProfile.ascx" TagPrefix="UC" TagName="UCEdit" %>
<%@ Register Src="~/UserControl/ChangePassword.ascx" TagPrefix="UC" TagName="UcChangePassword" %>
<%@ Register TagPrefix="UC" TagName="Message" Src="~/UserControl/Message.ascx" %>
<%@ Register TagPrefix="UC" TagName="Deactive" Src="~/UserControl/Deactive.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    <UC:Message ID="Message" runat="server" icname="fas fa-exclamation-triangle" msg="Wrong password" />


    <link rel="stylesheet" href="../css/setting.css" />
    <div class="page-layout">
        <div class="menu">
            <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" CssClass="menuSetting" OnMenuItemClick="Menu1_MenuItemClick">
                <DynamicSelectedStyle BackColor="#FFCC66" />
                <Items>
                    <asp:MenuItem Text="Edit profile" Value="0"></asp:MenuItem>
                    <asp:MenuItem Text="Change password" Value="1"></asp:MenuItem>
                    <asp:MenuItem Text="Deactive account" Value="2"></asp:MenuItem>
                </Items>
                <StaticSelectedStyle BackColor="#F2F3F5" />
            </asp:Menu>
        </div>
        <asp:MultiView ID="SettingView" runat="server">
            <asp:View ID="Edit" runat="server">
                <UC:UCEdit runat="server" ID="SettingEdit" />
            </asp:View>
            <asp:View ID="Change" runat="server">
                <UC:UcChangePassword runat="server" ID="SettingChangePassword" />
            </asp:View>
            <asp:View ID="Deactive" runat="server">
                <UC:Deactive runat="server" ID="SettingDeactive" />
            </asp:View>
        </asp:MultiView>
    </div>
    <asp:MultiView ID="TabSetting" runat="server"></asp:MultiView>
</asp:Content>
