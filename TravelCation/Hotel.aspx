<%@ Page Title="" Language="C#" MasterPageFile="~/TravelCation.Master" AutoEventWireup="true" CodeBehind="Hotel.aspx.cs" Inherits="TravelCation.Hotel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div class="container white z-depth-2">
        <ul class="tabs orange darken-1 lighten-3 center">
            <li class="tab col s6"><a class="white-text">Room</a></li>
        </ul>
        <div class="form-container">
            <asp:Label ID="lbl_error" runat="server"></asp:Label>
            <asp:GridView ID="gv_hotelsearch" runat="server" CssClass="striped responsive-table" DataKeyNames="RoomID" OnRowDataBound="gv_RowDataBound" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="Image1" Height="150px" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lbl_roomID" runat="server" Text='<%# Eval("RoomID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Floor" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lbl_roomFloor" runat="server" Text='<%# Eval("RoomFloor")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="RoomNumber" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lbl_roomNumber" runat="server" Text='<%# Eval("RoomNumber")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Type">
                        <ItemTemplate>
                            <asp:Label ID="lbl_roomType" runat="server" Text='<%# Eval("RoomTypeID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Occupant">
                        <ItemTemplate>
                            <asp:Label ID="lbl_roomOccupant" runat="server" Text='<%# Eval("RoomOccupant")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Available" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lbl_roomAvailable" runat="server" Text='<%# Eval("RoomAvailable")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rate">
                        <ItemTemplate>
                            <asp:Label ID="lbl_roomRate" runat="server" Text='<%# Eval(string.Format("{0:C}","DailyRoomRate"))%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="btn_select" CssClass="btn orange darken-2" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:Button>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
