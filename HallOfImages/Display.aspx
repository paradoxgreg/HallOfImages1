<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Display.aspx.cs" Inherits="HallOfImages.Display" %>
<%@ Register TagPrefix="uc" TagName="UserControl" Src="~/Controls/UserControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
  <head id="Head1" runat="server">
    <title>Hall of Images</title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
  </head>
  <body>
    <form id="form1" runat="server">
      <p class="title">HALL OF IMAGES</p>
      <uc:UserControl ID="ctlUserControl" runat="server" />
      <p><a href="Index.aspx">Back to home page</a></p>
      <asp:Panel ID="pnlImage" runat="server" style="text-align:center;">
        <asp:Label ID="lblImage" runat="server" Text=""></asp:Label>
      </asp:Panel>
      <p align="center" style="margin-top:7px;">
        <asp:Label ID="lblHtmlComments" runat="server" Text=""></asp:Label>
      </p>
      <asp:Panel ID="pnlEdit" runat="server" style="text-align:center;" Visible="false">
        <hr />
        <asp:LinkButton ID="lbDelete" runat="server" onclick="lbDelete_Click">Delete this image</asp:LinkButton>
        <p align="center"><asp:Label ID="lblError" runat="server" Text=""></asp:Label></p>
      </asp:Panel>
    </form>
  </body>
</html>
