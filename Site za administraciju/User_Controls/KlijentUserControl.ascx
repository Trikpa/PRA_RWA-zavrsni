<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KlijentUserControl.ascx.cs" Inherits="Site_za_administraciju.User_Controls.KlijentUserControl" %>

<div class="card dark-background mb-3">
	<div class="card-body text-white">
		<h5 class="card-title text-orange">
			<asp:Label ID="lblKlijentName" runat="server" Text="Title" />
		</h5>
		<asp:LinkButton ID="BtnDetalji" runat="server" CssClass="btn btn-red" OnClick="BtnDetalji_Click">Detalji</asp:LinkButton>
	</div>
</div>
