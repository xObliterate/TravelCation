<%@ Page Title="" Language="C#" MasterPageFile="~/TravelCation.Master" AutoEventWireup="true" CodeBehind="~/Index.aspx.cs" Inherits="TravelCation.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="slider">
        <ul class="slides">
            <li>
                <asp:Image ID="img_slide1" runat="server" ImageUrl="~/APP/Assets/IMG/slide2.jpg" />
            </li>
        </ul>
    </section>
    <br />
    <div class="form-container container transparent z-depth-3">
        <div class="row">
            <div class="col s12">
                <div class="tabs z-depth-1">
                    <asp:Menu ID="menu" CssClass="tab" runat="server" Orientation="Horizontal" OnMenuItemClick="menu_MenuItemClick">
                        <Items>
                            <asp:MenuItem Text="&lt;i class=&quot;material-icons&quot;&gt;hotel&lt;/i&gt; Hotels" Value="0"></asp:MenuItem>
                            <asp:MenuItem Text="&lt;i class=&quot;material-icons&quot;&gt;flight&lt;/i&gt; Flights" Value="1"></asp:MenuItem>
                            <asp:MenuItem Text="&lt;i class=&quot;material-icons&quot;&gt;hotel&lt;/i&gt; &lt;i class=&quot;material-icons&quot;&gt;flight&lt;/i&gt; Flight + Hotel" Value="2"></asp:MenuItem>
                            <asp:MenuItem Text="&lt;i class=&quot;material-icons&quot;&gt;event&lt;/i&gt; Attractions" Value="3"></asp:MenuItem>
                        </Items>
                        <StaticSelectedStyle BackColor="#1976d2" ForeColor="orange" />
                        <StaticMenuItemStyle BorderWidth="2" HorizontalPadding="20" BorderColor="white" BackColor="white" BorderStyle="Solid" />
                    </asp:Menu>
                </div>
            </div>
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
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender_checkin" runat="server" Format="dd/MM/yyyy" PopupButtonID="tb_checkin" PopupPosition="BottomLeft" TargetControlID="tb_checkin" />
                        </div>

                        <div class="input-field col s6">
                            <i class="material-icons prefix">date_range</i>
                            <asp:TextBox ID="tb_checkout" placeholder="Check out (DD/MM/YYYY)" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender_checkout" runat="server" Format="dd/MM/yyyy" PopupButtonID="tb_checkout" PopupPosition="BottomLeft" TargetControlID="tb_checkout" DefaultView="Days" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s4">
                            <asp:DropDownList ID="ddl_numberofrooms" CssClass="browser-default" runat="server">
                                <asp:ListItem Value="0" Text="Rooms"></asp:ListItem>
                                <asp:ListItem Value="1" Text="1 "></asp:ListItem>
                                <asp:ListItem Value="2"></asp:ListItem>
                                <asp:ListItem Value="3"></asp:ListItem>
                                <asp:ListItem Value="4"></asp:ListItem>
                                <asp:ListItem Value="5"></asp:ListItem>
                                <asp:ListItem Value="6"></asp:ListItem>
                                <asp:ListItem Value="7"></asp:ListItem>
                                <asp:ListItem Value="8"></asp:ListItem>
                                <asp:ListItem Value="9"></asp:ListItem>
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
                            <asp:Button ID="btn_submit" CssClass="btn orange darken-2" runat="server" Text="Search" OnClick="btn_submit_Click" />
                        </div>
                    </div>
                </asp:View>

                <asp:View ID="view_flight" runat="server">
                    <div class="row">
                        <div class="input-field col s6">
                            <i class="material-icons prefix">location_on</i>
                            <asp:TextBox ID="tb_flyingFrom" runat="server" placeholder="Flying From"></asp:TextBox>
                        </div>
                        <div class="input-field col s6">
                            <i class="material-icons prefix">location_on</i>
                            <asp:TextBox ID="tb_flyingTo" runat="server" placeholder="Flying To"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s3">
                            <i class="material-icons prefix">date_range</i>
                            <asp:TextBox ID="tb_departDate" runat="server" placeholder="Departing"></asp:TextBox>
                        </div>
                        <div class="input-field col s3">
                            <i class="material-icons prefix">date_range</i>
                            <asp:TextBox ID="tb_returnDate" runat="server" placeholder="Returning"></asp:TextBox>
                        </div>
                        <div class="input-field col s2">
                            <asp:DropDownList ID="ddl_flight_adult" CssClass="browser-default" runat="server">
                                <asp:ListItem Value="0">Adults</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="input-field col s2">
                            <asp:DropDownList ID="ddl_flight_child" CssClass="browser-default" runat="server">
                                <asp:ListItem Value="0">Children</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="input-field col s2">
                            <asp:DropDownList ID="ddl_flight_infaint" CssClass="browser-default" runat="server">
                                <asp:ListItem Value="0">Infants</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content
>