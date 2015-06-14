<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="HallOfImages.Index" %>
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
  <p><uc:UserControl ID="ctlUserControl" runat="server" /></p>
  <p align="center">
    Filter category:
    <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" 
      onselectedindexchanged="ddlCategory_SelectedIndexChanged">
    </asp:DropDownList>
  </p>
  <p align="center">
    <%--<a href="Upload.aspx">Upload your own image!</a>--%>
    <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx?url=%2fUpload.aspx">Upload your own image</asp:HyperLink>--%>
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Upload.aspx">Upload your own image</asp:HyperLink>
  </p>
  <asp:Repeater ID="rptCategoryImages" runat="server">
    <HeaderTemplate>
    </HeaderTemplate>
    <ItemTemplate>
      <%# GetHtmlForRepeaterItem(Container.DataItem) %>
    </ItemTemplate>
    <FooterTemplate>
    </FooterTemplate>
  </asp:Repeater>
  </form>
</body>
</html>
