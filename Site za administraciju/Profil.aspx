<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardMasterPage.Master" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="Site_za_administraciju.Profil" %>

<asp:Content ID="Content2" ContentPlaceHolderID="dashboardTitle" runat="server">
	<h3 class="text-white mb-0">Profil</h3>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
	<div class="row">
		<div class="col-md-6 mt-4 dark-background rounded">
			<div class="form-group row my-4">
				<label class="col-sm-2 col-form-label text-red">Ime</label>
				<div class="col-sm-9 d-flex align-items-center">
					<asp:Label ID="lblIme" runat="server" CssClass="col-form-label text-white font-weight-bold" />
				</div>
			</div>
			<div class="form-group row my-4">
				<label class="col-sm-2 col-form-label text-red">Prezime</label>
				<div class="col-sm-9 d-flex align-items-center">
					<asp:Label ID="lblPrezime" runat="server" CssClass="col-form-label text-white font-weight-bold" />
				</div>
			</div>
			<div class="form-group row my-4">
				<label for="ddlTip" class="col-sm-2 col-form-label text-red">Tip</label>
				<div class="col-sm-9 d-flex align-items-center">
					<asp:Label Text="Tip djelatnika" ID="lblTipDjelatnika" runat="server" CssClass="col-form-label text-white font-weight-bold" />
				</div>
			</div>
			<div class="form-group row my-4">
				<label for="tbEmail" class="col-sm-2 col-form-label text-red">Email</label>
				<div class="col-sm-9">
					<asp:TextBox ID="tbEmail" runat="server" AutoCompleteType="None" CssClass="form-control" Enabled="false"></asp:TextBox>
				</div>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
					ControlToValidate="tbEmail"
					Display="Dynamic"
					ForeColor="DarkRed"
					Font-Bold="True"
					Font-Size="Large"
					CssClass="col-sm-1"
					Text="*" />
			</div>
			<div class="form-group row my-4">
				<label class="col-sm-2 col-form-label text-red">Datum zaposlenja</label>
				<div class="col-sm-9 d-flex align-items-center">
					<asp:Label ID="lblDatumZaposlenja" runat="server" CssClass="col-form-label text-white font-weight-bold" />
				</div>
			</div>
			<div class="form-group row my-4">
				<label class="col-sm-2 col-form-label text-red">Tim</label>
				<div class="col-sm-9 d-flex align-items-center">
					<asp:Label ID="lblTim" runat="server" CssClass="col-form-label text-white font-weight-bold" />
				</div>
			</div>
			<div class="form-group row my-4">
				<div class="col-sm-3">
					<asp:LinkButton ID="btnUredi" runat="server" CssClass="btn btn-info" OnClick="BtnUredi_Click"><i class="fas fa-pen">&nbsp;</i>Uredi</asp:LinkButton>
				</div>
				<div class="col-sm-3">
					<asp:LinkButton ID="btnSpremi" runat="server" CssClass="btn btn-info" OnClick="BtnSpremi_Click"><i class="fas fa-save">&nbsp;</i>Spremi</asp:LinkButton>
				</div>
				<div class="col-sm-4">
					<asp:LinkButton ID="btnPovratak" runat="server" CssClass="btn btn-info" OnClick="BtnPovratak_Click"><i class="fas fa-chevron-left">&nbsp;</i>Povratak</asp:LinkButton>
				</div>
			</div>
			<div class="form-group row mt-4">
				<div class="col-sm-3">
					<asp:LinkButton ID="btnPromijeniSifru" runat="server" CssClass="btn btn-secondary" OnClick="BtnPromijeniSifru_Click">Promijeni šifru</asp:LinkButton>
				</div>
			</div>
		</div>
		<div class="col-md-6" runat="server" visible="false" id="passwordChangeContainer">
			
		</div>
	</div>
</asp:Content>
