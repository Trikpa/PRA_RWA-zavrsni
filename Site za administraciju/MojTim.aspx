<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardMasterPage.Master" AutoEventWireup="true" CodeBehind="MojTim.aspx.cs" Inherits="Site_za_administraciju.MojTim" %>

<asp:Content ID="Content2" ContentPlaceHolderID="dashboardTitle" runat="server">
	<h3 class="text-white mb-0">Moj tim</h3>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
	<div class="row">
		<div class="col-md-6" runat="server" id="projectContainer">
			<asp:PlaceHolder ID="phMojTim" runat="server"></asp:PlaceHolder>
		</div>
		<div class="col-md-6">
		</div>
	</div>
</asp:Content>
