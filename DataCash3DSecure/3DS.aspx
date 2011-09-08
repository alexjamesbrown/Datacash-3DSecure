<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="3DS.aspx.cs" Inherits="DataCash3DSecure.ThreeDS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body id="myBody" runat="server">
    <form id="MainForm" runat="server">
    <h1>
        We can "pretty it up"</h1>
    <h2>
        Just make sure the "Panel" and iFrame below are somewhere in the form tag....</h2>
    <asp:Panel ID="ACSFramePanel" runat="server" Visible="false">
        Please verify.....<br />
        <br />
        <iframe src="" name="ACSFrame" width="450" height="400" frameborder="0"></iframe>
    </asp:Panel>
    </form>
</body>
</html>
