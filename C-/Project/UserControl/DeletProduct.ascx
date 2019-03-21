<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeletProduct.ascx.cs" Inherits="Project.UserControl.DeletProduct" %>


<div class="modal" id="deleteModal">
    <div class="modal-dialog">
        <div class="modal-content">

            <!-- Modal Header -->
            <div class="modal-header">
                <h4 class="modal-title">Confirm</h4>
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>

            <!-- Modal body -->
            <div class="modal-body">
                Are you sure to delete
            </div>

            <!-- Modal footer -->
            <div class="modal-footer">
                <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                <asp:Button ID="Button1" ValidateRequestMode ="Disabled"  OnClick ="deleteButtonModal_Click" CssClass="btn btn-primary" runat="server" Text="Delete" UseSubmitBehavior="False" />
            </div>

        </div>
    </div>
</div>
