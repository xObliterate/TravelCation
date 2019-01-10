<%@ Page Title="" Language="C#" MasterPageFile="~/TravelCation.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="TravelCation.APP.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <div class="container white z-depth-2">
        <ul class="tabs blue darken-2 center">
            <li class="tab"><a class="white-text">Change Password</a></li>
        </ul>
        <div class="col s12">
            <div class="container">
                <div class="modal-content">
                    <h3>
                        <asp:Label ID="lbl_msg" runat="server"></asp:Label>
                    </h3>
                    <asp:Panel ID="changePwPanel" runat="server" DefaultButton="btn_changePw">
                        <div class="row">
                            <div class="input-field col s12">
                                <asp:Label ID="lbl_email" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="input-field col s12">
                                <asp:TextBox ID="tb_password" CssClass="validate" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_password" CssClass="rfv" EnableClientScript="false" ControlToValidate="tb_password" Display="Dynamic" placeholder="Password" ForeColor="Red" runat="server" ErrorMessage="You can't leave this empty."></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="input-field col s12">
                                <asp:Button ID="btn_changePw" CssClass="btn orange darken-2" runat="server" Text="Submit" OnClick="btn_change_Click"></asp:Button>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
