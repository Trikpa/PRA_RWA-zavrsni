<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjektUserControl.ascx.cs" Inherits="Site_za_administraciju.ProjektUserControl" %>

<div class="card dark-background mb-3">
	<div class="card-body text-white">
		<h5 class="card-title text-orange">
			<asp:Label ID="lblProjectTitle" runat="server" Text="Title" />
		</h5>
		<p class="card-text text-white">
			<asp:Label ID="lblProjectDescription" runat="server" Text="Description" />
		</p>
		<asp:LinkButton ID="BtnDetalji" runat="server" CssClass="btn btn-red" OnClick="BtnDetalji_Click">Detalji</asp:LinkButton>
	</div>
</div>
