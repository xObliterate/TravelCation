<%@ Page Title="" Language="C#" MasterPageFile="~/TravelCation.Master" AutoEventWireup="true" CodeBehind="HotelSearch.aspx.cs" Inherits="TravelCation.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div class="container white z-depth-2">
        <ul class="tabs orange darken-1 lighten-3 center">
            <li class="tab col s6"><a class="white-text">Hotel</a></li>
        </ul>
        <div class="form-container">
            <asp:Label ID="lbl_error" runat="server"></asp:Label>
            <asp:GridView ID="gv_hotelsearch" runat="server" CssClass="striped responsive-table" AutoGenerateColumns="False" OnSelectedIndexChanged="gv_hotelsearch_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lbl_name" runat="server" Text='<%# Eval("ServiceName")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Location">
                        <ItemTemplate>
                            <asp:Label ID="lbl_location" runat="server" Text='<%# Eval("ServiceLocation")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rating">
                        <ItemTemplate>
                            <asp:Label ID="lbl_rating" runat="server" Text='<%# Eval("ServiceRating")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
          
                    <asp:CommandField ShowSelectButton="True" />
          
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
