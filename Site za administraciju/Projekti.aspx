<%@ Page Title="Projekti" Language="C#" MasterPageFile="~/DashboardMasterPage.Master" AutoEventWireup="true" CodeBehind="Projekti.aspx.cs" Inherits="Site_za_administraciju.Projekti" %>

<asp:Content ID="dashboardTitle" ContentPlaceHolderID="dashboardTitle" runat="server">
	<h3 class="text-white mb-0">Projekti</h3>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server" ClientIDMode="Static">
	<div class="row">
		<div class="col-md-6" runat="server" id="projectContainer"></div>
		<div class="col-md-6">
			<asp:Button Text="Dodaj" runat="server" CssClass="btn btn-info" />
		</div>
	</div>
</asp:Content>
