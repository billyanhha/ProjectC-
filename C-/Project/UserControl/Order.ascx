<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Order.ascx.cs" Inherits="Project.UserControl.Order" %>



<!-- The Modal -->
<div class="modal fade" id="orderModal">
    <div class="modal-dialog">
        <div class="modal-content">

            <!-- Modal Header -->
            <div class="modal-header">
                <h4 class="modal-title">Order Info</h4>
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>

            <!-- Modal body -->
            <div class="modal-body">
                <p class="small-description">Provide info help shop deliver faster</p>
                <div class="form-group">
                    <label>Location</label>
                    <asp:TextBox ID="location"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Location">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1"
                        ControlToValidate="location"
                        ValidationGroup="addOrder"
                        Display="Dynamic"
                        runat="server" ErrorMessage="Required">
                    </asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label>Phone</label>
                    <asp:TextBox ID="phoneContact"
                        runat="server"
                        CssClass="form-control"
                        type="number"
                        placeholder="Enter phonenumber">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator2"
                        ControlToValidate="phoneContact"
                        ValidationGroup="addOrder"
                        Display="Dynamic"
                        runat="server" ErrorMessage="Required">
                    </asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label>Other contact</label>
                    <asp:TextBox ID="otherContact"
                        runat="server"
                        CssClass="form-control"
                        TextMode ="MultiLine"
                        placeholder="Facebook , twitter , insta , etc link">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator3"
                        ControlToValidate="otherContact"
                        ValidationGroup="addOrder"
                        Display="Dynamic"
                        runat="server" ErrorMessage="Required">
                    </asp:RequiredFieldValidator>
                </div>
            </div>

            <!-- Modal footer -->
            <div class="modal-footer">
                <asp:Button runat="server" ValidationGroup="addOrder" UseSubmitBehavior="false" ID="submitOrder" OnClick="submitOrder_Click" class="btn btn-primary addOrderBtn" Text="Submit order" />
                <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
            </div>

        </div>
    </div>
</div>
