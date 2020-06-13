<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardMasterPage.Master" AutoEventWireup="true" CodeBehind="PromijeniSifru.aspx.cs" Inherits="Site_za_administraciju.PromijeniSifru" %>

<asp:Content ID="Content2" ContentPlaceHolderID="dashboardTitle" runat="server">
	<h3 class="text-white mb-0">Promjena lozinke</h3>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
	<div class="form-group row my-4">
		<label for="tbTrenutnaLozinka" class="col-sm-3 col-form-label text-red">Trenutna lozinka</label>
		<div class="col-sm-5  d-flex align-items-center">
			<asp:TextBox ID="tbTrenutnaLozinka" runat="server" AutoCompleteType="None" TextMode="Password" CssClass="form-control"></asp:TextBox>
		</div>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
			ControlToValidate="tbTrenutnaLozinka"
			Display="Dynamic"
			ForeColor="DarkRed"
			Font-Bold="True"
			Font-Size="Large"
			CssClass="col-sm-1"
			Text="*" />
		<asp:CustomValidator ID="cvTrenutnaLozinka" runat="server"
			ErrorMessage="Trenutna lozinka nije ispravna"
			ForeColor="DarkRed"
			Font-Bold="True"
			Font-Size="Large"
			CssClass="col-sm-1"
			Text="*"
			ControlToValidate="tbTrenutnaLozinka"
			OnServerValidate="CvTrenutnaLozinka_ServerValidate" />
	</div>
	<div class="form-group row mt-4 mb-3">
		<label for="tbNovaLozinka" class="col-sm-3 col-form-label text-red">Nova lozinka</label>
		<div class="col-sm-5  d-flex align-items-center">
			<asp:TextBox ID="tbNovaLozinka" runat="server" AutoCompleteType="None" MaxLength="50" TextMode="Password" CssClass="form-control"></asp:TextBox>
		</div>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
			ControlToValidate="tbNovaLozinka"
			Display="Dynamic"
			ForeColor="DarkRed"
			Font-Bold="True"
			Font-Size="Large"
			CssClass="col-sm-1"
			Text="*" />
		<asp:RegularExpressionValidator ID="LengthValidator" runat="server"
			ErrorMessage="Zaporka mora biti dugačka 8 znakova ili više"
			ControlToValidate="tbNovaLozinka"
			ValidationExpression="^[a-zA-Z0-9'@&#.\s]{7,50}$"
			ForeColor="DarkRed"
			Font-Bold="True"
			Font-Size="Large"
			CssClass="col-sm-1"
			Text="*" />
	</div>
	<div class="form-group row">
		<label for="tbNovaLozinkaPonovno" class="col-sm-3 col-form-label text-red">Nova lozinka ponovno</label>
		<div class="col-sm-5  d-flex align-items-center">
			<asp:TextBox ID="tbNovaLozinkaPonovno" runat="server" AutoCompleteType="None" TextMode="Password" CssClass="form-control"></asp:TextBox>
		</div>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
			ControlToValidate="tbNovaLozinkaPonovno"
			Display="Dynamic"
			ForeColor="DarkRed"
			Font-Bold="True"
			Font-Size="Large"
			CssClass="col-sm-1"
			Text="*" />
		<asp:CompareValidator ID="CompareValidator1" runat="server"
			ControlToValidate="tbNovaLozinkaPonovno"
			ControlToCompare="tbNovaLozinka"
			Type="String"
			Operator="Equal"
			Display="Dynamic"
			ForeColor="DarkRed"
			Font-Bold="True"
			Font-Size="Large"
			CssClass="col-sm-1"
			ErrorMessage="Lozinke nisu iste"
			Text="*" />
		<asp:CompareValidator ID="CompareValidator2" runat="server"
			ControlToValidate="tbNovaLozinka"
			ControlToCompare="tbTrenutnaLozinka"
			Type="String"
			Operator="NotEqual"
			Display="Dynamic"
			ForeColor="White"
			Font-Bold="True"
			Font-Size="Large"
			CssClass="col-sm-1"
			ErrorMessage="Nova lozinka ne može biti ista kao trenutna lozinka"
			Text="*" />
	</div>
	<div>
		<asp:ValidationSummary ID="ValidationSummary1" runat="server"
			ForeColor="DarkRed"
			Font-Bold="true"
			Font-Size="Large" />
	</div>
	<div class="form-group row mt-4">
		<div class="col-sm-3">
			<asp:LinkButton ID="btnAzurirajSifru" runat="server" CssClass="btn btn-info" OnClick="BtnAzurirajSifru_Click">Ažuriraj šifru</asp:LinkButton>
		</div>
		<div class="col-sm-3">
			<asp:LinkButton ID="btnOdustani" runat="server" CssClass="btn btn-secondary" OnClick="BtnOdustani_Click" CausesValidation="false" >Odustani</asp:LinkButton>
		</div>
	</div>
</asp:Content>
