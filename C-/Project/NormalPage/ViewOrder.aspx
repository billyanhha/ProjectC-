<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="ViewOrder.aspx.cs" Inherits="Project.NormalPage.ViewOrder" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="page-layout">
        <center><h4 runat="server" id ="noOrder" style ="display: none" >You haven't add anything yet , <a href="/home">continue shopping</a> </h4></center>
        <asp:GridView ID="OrderList" class="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="order_id" OnRowCancelingEdit="OrderList_RowCancelingEdit" OnRowDeleting="OrderList_RowDeleting" OnRowUpdating="OrderList_RowUpdating" OnRowEditing="OrderList_RowEditing">
            <Columns>
                <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-primary btn-sm" ShowEditButton="True">
                    <ControlStyle CssClass="btn btn-primary btn-sm"></ControlStyle>
                </asp:CommandField>
                <asp:BoundField DataField="order_id" HeaderText="ID" ReadOnly="True" />
                <asp:TemplateField HeaderText="Ship location">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ship_location") %>' CssClass="form-control"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ship_location") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" type="number" runat="server" Text='<%# Bind("phoneContact") %>' CssClass="form-control"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("phoneContact") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Other contact">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("otherContact") %>' CssClass="form-control"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("otherContact") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ControlStyle-CssClass="btn btn-danger btn-sm" ShowDeleteButton="True">
                    <ControlStyle CssClass="btn btn-danger btn-sm"></ControlStyle>
                </asp:CommandField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
