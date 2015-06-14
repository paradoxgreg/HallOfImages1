<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="HallOfImages.Upload" %>
<%@ Register TagPrefix="uc" TagName="UserControl" Src="~/Controls/UserControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
  <head id="Head1" runat="server">
    <title>Upload File</title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
  </head>
  <body>
    <form id="form1" runat="server">
      <p class="title">HALL OF IMAGES</p>
      <uc:UserControl ID="ctlUserControl" runat="server" />
      <p><a href="Index.aspx">Back to home page</a></p>
      <p class="header">UPLOAD FILE</p>
      <!--<p align="center">Upload an image, select a category, and optionally add comments:</p>-->
      <p align="center"><asp:FileUpload ID="fuImage" runat="server" /></p>
      <p align="center">Category:<br />
        <asp:DropDownList ID="ddlCategory" runat="server">
        </asp:DropDownList>
      </p>
      <p align="center">Comments:<br />
        <asp:TextBox ID="txtComments" runat="server"></asp:TextBox>
      </p>
      <p align="center">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
          onclick="btnSubmit_Click" />
      </p>
      <p align="center">
        <asp:Label ID="lblError" runat="server" Text="Label" Visible="false"></asp:Label>
      </p>
      <asp:Panel ID="pnlResults" runat="server" Visible="false">
        <hr />

      </asp:Panel>
    </form>
  </body>
</html>
