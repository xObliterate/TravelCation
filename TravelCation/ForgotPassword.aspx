<%@ Page Title="" Language="C#" MasterPageFile="~/TravelCation.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="TravelCation.ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <asp:Panel ID="panelResetPassword" runat="server" DefaultButton="btn_reset">
        <asp:UpdatePanel ID="updatePanelReset" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="container white z-depth-2">
                    <ul class="tabs blue darken-2 center">
                        <li class="tab"><a class="white-text">Forgot Password</a></li>
                    </ul>
                    <div class="container">
                        <div class="modal-content">
                            <div class="row">
                                <div class="input-field col s12">
                                    <h4 class="orange-text">Forgot Password</h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s12">
                                    <asp:TextBox ID="tb_resetEmail" runat="server" TextMode="Email" placeholder="Email"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_resetEmail" runat="server" EnableClientScript="false" ValidationGroup="validate2" ControlToValidate="tb_resetEmail" Display="Dynamic" ForeColor="Red" ErrorMessage="Email Required"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="resetEmailValidator" runat="server" ValidationGroup="validate2" ControlToValidate="tb_resetEmail" ErrorMessage="Email is not valid" Display="Dynamic" ForeColor="Red" OnServerValidate="resetEmailValidator_ServerValidate"></asp:CustomValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s12">
                                    <asp:Button ID="btn_reset" runat="server" CssClass="btn orange darken-2" ValidationGroup="validate2" Text="Reset Password" OnClick="btn_reset_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btn_reset" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
