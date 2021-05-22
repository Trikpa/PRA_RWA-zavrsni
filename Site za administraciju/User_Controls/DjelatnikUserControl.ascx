<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DjelatnikUserControl.ascx.cs" Inherits="Site_za_administraciju.DjelatnikUserControl" %>

<div class="card dark-background mb-3">
	<div class="card-body text-white">
		<h5 class="card-title text-orange">
			<asp:Label ID="lblDjelatnikName" runat="server" Text="Title" />
		</h5>
		<p class="card-text text-white">
			<asp:Label ID="lblDjelatnikProjekti" runat="server" Text="Description" />
		</p>
		<asp:LinkButton ID="BtnDetalji" runat="server" CssClass="btn btn-red" OnClick="BtnDetalji_Click">Detalji</asp:LinkButton>
	</div>
</div>
