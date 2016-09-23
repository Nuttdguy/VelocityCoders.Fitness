<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InstructorNavigationControl.ascx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.UserControls.InstructorNavigationControl" %>


<div id="ContainerSubHeader" class="SubheaderNavigation borderRadiusTop" >
  <asp:Label runat="server" ID="UCMessage" />

  <div class="SmallPadding">
    <asp:ListView runat="server" ID="InstructorNavigationList" ItemPlaceholderID="InstructorNavigationPlaceholder">
      
      <LayoutTemplate>
        <ul>
          <asp:PlaceHolder runat="server" ID="InstructorNavigationPlaceholder" />
        </ul>
      </LayoutTemplate>

      <ItemTemplate>
        <li>
          <asp:HyperLink runat='server' ID='InstructorNavigationLink' NavigateUrl='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' >
             <%# Eval("Text") %>
          </asp:HyperLink>
        </li>
      </ItemTemplate>

    </asp:ListView>
  </div>

</div>
