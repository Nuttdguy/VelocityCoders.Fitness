<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageBrokenRulesControl.ascx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.UserControls.MessageBrokenRulesControl" %>

<asp:Panel runat="server" ID="PageMessageArea" CssClass="PageMessage BorderRadiusAll" visible="false" >
  <asp:Label runat="server" ID="lblPageMessage" CssClass="showPageMessage"/>
  <asp:ListView runat="server" ID="MessageList" ItemPlaceholderID="MessageListPlaceholder">
    <LayoutTemplate>
      <ul>
        <asp:PlaceHolder runat="server" ID="MessageListPlaceholder" />
      </ul>
    </LayoutTemplate>
    <ItemTemplate>
      <li><%# Eval("PropertyName") %>: <%# Eval("Message") %></li>
    </ItemTemplate>
  </asp:ListView>
</asp:Panel>  