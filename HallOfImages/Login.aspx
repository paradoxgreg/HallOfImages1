<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HallOfImages.Login" %>
<%@ Register TagPrefix="uc" TagName="UserControl" Src="~/Controls/UserControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
  <head id="Head1" runat="server">
    <title>Log in</title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
  </head>
  <body>
    <form id="form1" runat="server">
      <p class="title">HALL OF IMAGES</p>
      <uc:UserControl ID="ctlUserControl" runat="server" />
      <p><a href="Index.aspx">Back to home page</a></p>
      <p class="header">LOG IN</p>
      <!--
      <p align="center">
        <asp:LinkButton ID="lbLoginAsStandard" runat="server" OnClick="lbLoginAsStandard_Click">Simulate log in as standard user</asp:LinkButton>
      </p>
      <p align="center">OR</p>
      -->
      <p>&nbsp;</p>
      <p align="center">
        <asp:LinkButton ID="lbLoginAsAdmin" runat="server" OnClick="lbLoginAsAdmin_Click">Simulate log in as administrator</asp:LinkButton>
      </p>
    </form>
  </body>
</html>
