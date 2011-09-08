<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentPage.aspx.cs" Inherits="DataCash3DSecure.PaymentPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body id="myBody" runat="server">
    <form id="MainForm" runat="server">
    card type:<br />
    <asp:DropDownList ID="cardType" runat="server">
        <asp:ListItem Text="visa" />
        <asp:ListItem Text="mastercard" Selected="True" />
        <asp:ListItem Text="maestro" />
        <asp:ListItem Text="switch" />
        <asp:ListItem Text="solo" />
        <asp:ListItem Text="delta" />
    </asp:DropDownList>
    <br />
    <br />
    card number:<br />
    <asp:TextBox ID="cardNumber" runat="server" Text="4444333322221111" />
    <br />
    <br />
    expiry month:
    <asp:TextBox ID="expiryMonth" runat="server" Columns="2" Text="01" />
    &nbsp;&nbsp;&nbsp;expiry year:
    <asp:TextBox ID="expiryYear" runat="server" Columns="2" Text="15" />
    <br />
    <br />
    start month:
    <asp:TextBox ID="startMonth" runat="server" Columns="2" Text="01" />
    &nbsp;&nbsp;&nbsp;start year:
    <asp:TextBox ID="startYear" runat="server" Columns="2" Text="09" />
    <br />
    <br />
    cv2<br />
    <asp:TextBox ID="secCode" runat="server" Columns="4" Text="123" />
    <br />
    <br />
    Issue Number<br />
    <asp:TextBox ID="issueNumber" runat="server" Columns="4" />
    <br />
    <br />
    Billing Address 1:
    <asp:TextBox ID="billingAddress1" runat="server" Text="Address Line 1" />
    <br />
    Billing Address 2:
    <asp:TextBox ID="billingAddress2" runat="server" Text="Address Line 2" />
    <br />
    Billing Address 3:
    <asp:TextBox ID="billingAddress3" runat="server" Text="Address Line 3" />
    <br />
    Billing Address 4:
    <asp:TextBox ID="billingAddress4" runat="server" Text="Address Line 4" />
    <br />
    Post Code:
    <asp:TextBox ID="billingAddressPostCode" runat="server" Text="GU20 6LQ" />
    <br />
    <br />
    <asp:Button ID="payBtn" runat="server" Text="Submit Order" OnClick="payBtn_Click" />
    <br />
    <asp:Panel ID="ACSFramePanel" runat="server" Visible="false">
        Please verify.....<br />
        <br />
        <iframe src="" name="ACSFrame" width="450" height="400" frameborder="0" />
    </asp:Panel>
    </form>
</body>
</html>
