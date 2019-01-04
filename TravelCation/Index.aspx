﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="~/Index.aspx.cs" Inherits="TravelCation.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <section class="slider">
        <ul class="slides">
            <li>
                <asp:Image ID="img_slide1" runat="server" ImageUrl="~/APP/Assets/IMG/slide2.jpg"/>
            </li>
        </ul>
    </section>
    <br />
    <div class="container white z-depth-3">
        <asp:Menu ID="menu" runat="server" Orientation="Horizontal" OnMenuItemClick="menu_MenuItemClick" EnableTheming="True" BackColor="#B5C7DE" DynamicHorizontalOffset="2" Font-Names="Rockwell Extra Bold" Font-Size="XX-Large" ForeColor="#284E98" StaticSubMenuIndent="10px" DynamicMenuItemStyle-ItemSpacing="100px">
            <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicMenuStyle BackColor="#B5C7DE" />
            <DynamicSelectedStyle BackColor="#507CD1" />
            <Items>
                <asp:MenuItem Text="&lt;i class=&quot;material-icons&quot;&gt;hotel&lt;/i&gt; Hotels" Value="0"></asp:MenuItem>
                <asp:MenuItem Text="&lt;i class=&quot;material-icons&quot;&gt;flight&lt;/i&gt; Flights" Value="1"></asp:MenuItem>
                <asp:MenuItem Text="&lt;i class=&quot;material-icons&quot;&gt;hotel&lt;/i&gt; &lt;i class=&quot;material-icons&quot;&gt;flight&lt;/i&gt; Flight + Hotel" Value="2"></asp:MenuItem>
                <asp:MenuItem Text="&lt;i class=&quot;material-icons&quot;&gt;event&lt;/i&gt; Attractions" Value="3"></asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticSelectedStyle BackColor="#507CD1" />
        </asp:Menu>

        <asp:MultiView ID="mv_services" ActiveViewIndex="0" runat="server">
            <asp:View ID="view_hotel" runat="server">
                <div class="row">
                    <div class="input-field col s12">
                        <i class="material-icons prefix">search</i>
                        <asp:TextBox ID="tb_hotel" CssClass="validate" placeholder="Destination, hotel name" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="input-field col s6">
                        <i class="material-icons prefix">date_range</i>
                        <asp:TextBox ID="tb_checkin" placeholder="Check in (DD/MM/YYYY)" runat="server"></asp:TextBox>
                        <ajaxtoolkit:calendarextender id="CalendarExtender_checkin" runat="server" format="dd/MM/yyyy" popupbuttonid="tb_checkin" popupposition="BottomLeft" targetcontrolid="tb_checkin" />
                    </div>

                    <div class="input-field col s6">
                        <i class="material-icons prefix">date_range</i>
                        <asp:TextBox ID="tb_checkout" placeholder="Check out (DD/MM/YYYY)" runat="server"></asp:TextBox>
                        <ajaxtoolkit:calendarextender id="CalendarExtender_checkout" runat="server" format="dd/MM/yyyy" popupbuttonid="tb_checkout" popupposition="BottomLeft" targetcontrolid="tb_checkout" />
                    </div>
                </div>
                <div class="row">
                    <div class="input-field col s4">
                        <asp:DropDownList ID="ddl_numberofrooms" CssClass="browser-default" runat="server">
                            <asp:ListItem Value="0">Rooms</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="input-field col s4">
                        <asp:DropDownList ID="ddl_adults" CssClass="browser-default" runat="server">
                            <asp:ListItem Value="0">Adults (18+)</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="input-field col s4">
                        <asp:DropDownList ID="ddl_childrens" CssClass="browser-default" runat="server">
                            <asp:ListItem Value="0">Children (0-17)</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="input-field col s12">
                        <asp:Button ID="btn_submit" CssClass="btn orange" runat="server" Text="Search" />

                    </div>
                </div>
            </asp:View>

            <asp:View ID="view2" runat="server">
                <asp:Label ID="Label1" runat="server" Text="tab 2"></asp:Label>
            </asp:View>

        </asp:MultiView>
    </div>
</asp:Content>