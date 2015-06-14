<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControl.ascx.cs" Inherits="HallOfImages.Controls.UserControl" %>
<asp:Panel ID="pnlUserLogin" runat="server" Visible="false" CssClass="userStatus">
  <asp:LinkButton ID="lbLogin" runat="server" OnClick="lbLogin_Click">Log in</asp:LinkButton>
</asp:Panel>
<asp:Panel ID="pnlUserLogout" runat="server" Visible="false" CssClass="userStatus">
  <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>&nbsp;
  <asp:LinkButton ID="lbLogout" runat="server" OnClick="lbLogout_Click">Log out</asp:LinkButton>
</asp:Panel>
