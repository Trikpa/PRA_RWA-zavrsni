<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardMasterPage.Master" AutoEventWireup="true" CodeBehind="Klijenti.aspx.cs" Inherits="Site_za_administraciju.Klijenti" %>

<asp:Content ID="Content2" ContentPlaceHolderID="dashboardTitle" runat="server">
	<h3 class="text-white mb-0">Klijenti</h3>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
	<div class="row">
		<div class="col-md-6" runat="server" id="projectContainer">
			<asp:PlaceHolder ID="phKlijenti" runat="server"></asp:PlaceHolder>
		</div>
		<div class="col-md-6">
			<asp:LinkButton ID="btnDodaj" runat="server" CssClass="btn btn-info" OnClick="BtnDodaj_Click"><i class="fas fa-plus">&nbsp;</i>Dodaj</asp:LinkButton>
		</div>
	</div>
</asp:Content>
