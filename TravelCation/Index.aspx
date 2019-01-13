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
    <div class="form-container container z-depth-3">
        <asp:UpdatePanel ID="updatepanel" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="menu" />
            </Triggers>
            <ContentTemplate>
                <div class="row">
                    <div class="col s12">
                        <div>
                            <asp:Menu ID="menu" CssClass="tab" runat="server" Orientation="Horizontal" OnMenuItemClick="menu_MenuItemClick">
                                <Items>
                                    <asp:MenuItem Text="&lt;i class=&quot;material-icons&quot;&gt;hotel&lt;/i&gt; Hotels" Value="0"></asp:MenuItem>
                                    <asp:MenuItem Text="&lt;i class=&quot;material-icons&quot;&gt;flight&lt;/i&gt; Flights" Value="1"></asp:MenuItem>
                                    <asp:MenuItem Text="&lt;i class=&quot;material-icons&quot;&gt;flight&lt;/i&gt; Flight + Hotel &lt;i class=&quot;material-icons&quot;&gt;hotel&lt;/i&gt;" Value="2"></asp:MenuItem>
                                    <asp:MenuItem Text="&lt;i class=&quot;material-icons&quot;&gt;event&lt;/i&gt; Attractions" Value="3"></asp:MenuItem>
                                </Items>
                                <StaticSelectedStyle BackColor="#1976d2" ForeColor="Orange" />
                                <StaticMenuItemStyle BorderWidth="2" HorizontalPadding="10" BorderColor="Gray" ForeColor="DarkBlue" BackColor="white" BorderStyle="Groove" />
                                <StaticHoverStyle ForeColor="Orange" />
                            </asp:Menu>
                        </div>
                    </div>
                </div>

                <asp:MultiView ID="mv_services" runat="server" EnableViewState="false" ActiveViewIndex="0">
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
                                    <asp:ListItem Value="1" Text="1 Room"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="2 Rooms"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="3 Rooms"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="4 Rooms"></asp:ListItem>
                                    <asp:ListItem Value="5" Text="5 Rooms"></asp:ListItem>
                                    <asp:ListItem Value="6" Text="6 Rooms"></asp:ListItem>
                                    <asp:ListItem Value="7" Text="7 Rooms"></asp:ListItem>
                                    <asp:ListItem Value="8" Text="8 Rooms"></asp:ListItem>
                                    <asp:ListItem Value="9" Text="9 Rooms"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="input-field col s4">
                                <asp:DropDownList ID="ddl_adults" CssClass="browser-default" runat="server">
                                    <asp:ListItem Value="0" Text="Adults (18+)"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="1 Adult"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="2 Adults"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="3 Adults"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="4 Adults"></asp:ListItem>
                                    <asp:ListItem Value="5" Text="5 Adults"></asp:ListItem>
                                    <asp:ListItem Value="6" Text="6 Adults"></asp:ListItem>
                                    <asp:ListItem Value="7" Text="7 Adults"></asp:ListItem>
                                    <asp:ListItem Value="8" Text="8 Adults"></asp:ListItem>
                                    <asp:ListItem Value="9" Text="9 Adults"></asp:ListItem>
                                    <asp:ListItem Value="10" Text="10 Adults"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="input-field col s4">
                                <asp:DropDownList ID="ddl_childrens" CssClass="browser-default" runat="server">
                                    <asp:ListItem Value="0" Text="Children (0-17)"></asp:ListItem>
                                    <asp:ListItem Value="1"></asp:ListItem>
                                    <asp:ListItem Value="2"></asp:ListItem>
                                    <asp:ListItem Value="3"></asp:ListItem>
                                    <asp:ListItem Value="4"></asp:ListItem>
                                    <asp:ListItem Value="5"></asp:ListItem>
                                    <asp:ListItem Value="6"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="input-field col s12">
                                <asp:Button ID="btn_submitHotel" CssClass="btn orange darken-2" runat="server" Text="Search" OnClick="btn_submitHotel_Click" />
                            </div>
                        </div>
                    </asp:View>

                    <asp:View ID="view_flight" runat="server">
                        <asp:UpdatePanel ID="updatePanel_viewFlightSub_menuFlight" runat="server">
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btn_submitFlight" />
                            </Triggers>
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col s12">
                                        <asp:Menu ID="menu_flight" CssClass="tab" runat="server" Orientation="Horizontal" OnMenuItemClick="menu_flight_MenuItemClick">
                                            <Items>
                                                <asp:MenuItem Text="Round Trip" Value="0"></asp:MenuItem>
                                                <asp:MenuItem Text="One Way" Value="1"></asp:MenuItem>
                                                <asp:MenuItem Text="Multi-City" Value="2"></asp:MenuItem>
                                            </Items>
                                            <StaticSelectedStyle BackColor="#1976d2" ForeColor="Orange"/>
                                            <StaticMenuItemStyle BorderWidth="2" HorizontalPadding="10" BorderColor="Gray" ForeColor="DarkBlue" BackColor="white" BorderStyle="Groove" />
                                            <StaticHoverStyle ForeColor="Orange" />
                                        </asp:Menu>
                                    </div>
                                </div>
                                <asp:MultiView ID="mv_subFlight" runat="server" EnableViewState="false" ActiveViewIndex="0">
                                    <asp:View ID="view_subFlight" runat="server">
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
                                            <div class="input-field col s3" id="returnDate" runat="server">
                                                <i class="material-icons prefix">date_range</i>
                                                <asp:TextBox ID="tb_returnDate" runat="server" placeholder="Returning"></asp:TextBox>
                                            </div>
                                            <div class="input-field col s2">
                                                <asp:DropDownList ID="ddl_flight_adult" CssClass="browser-default" runat="server">
                                                    <asp:ListItem Value="0">Adults</asp:ListItem>
                                                    <asp:ListItem Value="1"></asp:ListItem>
                                                    <asp:ListItem Value="2"></asp:ListItem>
                                                    <asp:ListItem Value="3"></asp:ListItem>
                                                    <asp:ListItem Value="4"></asp:ListItem>
                                                    <asp:ListItem Value="5"></asp:ListItem>
                                                    <asp:ListItem Value="6"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="input-field col s2">
                                                <asp:DropDownList ID="ddl_flight_child" CssClass="browser-default" runat="server">
                                                    <asp:ListItem Value="0">Children</asp:ListItem>
                                                    <asp:ListItem Value="1"></asp:ListItem>
                                                    <asp:ListItem Value="2"></asp:ListItem>
                                                    <asp:ListItem Value="3"></asp:ListItem>
                                                    <asp:ListItem Value="4"></asp:ListItem>
                                                    <asp:ListItem Value="5"></asp:ListItem>
                                                    <asp:ListItem Value="6"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="input-field col s2">
                                                <asp:DropDownList ID="ddl_flight_infaint" CssClass="browser-default" runat="server">
                                                    <asp:ListItem Value="0">Infants</asp:ListItem>
                                                    <asp:ListItem Value="1"></asp:ListItem>
                                                    <asp:ListItem Value="2"></asp:ListItem>
                                                    <asp:ListItem Value="3"></asp:ListItem>
                                                    <asp:ListItem Value="4"></asp:ListItem>
                                                    <asp:ListItem Value="5"></asp:ListItem>
                                                    <asp:ListItem Value="6"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="input-field col s12">
                                                <asp:Button ID="btn_submitFlight" runat="server" CssClass="btn orange darken-2" Text="Search" OnClick="btn_submitFlight_Click" />
                                            </div>
                                        </div>
                                    </asp:View>
                                </asp:MultiView>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </asp:View>
                </asp:MultiView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
