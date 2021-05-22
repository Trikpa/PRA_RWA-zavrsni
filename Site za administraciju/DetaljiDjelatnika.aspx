<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardMasterPage.Master" AutoEventWireup="true" CodeBehind="DetaljiDjelatnika.aspx.cs" Inherits="Site_za_administraciju.DetaljiDjelatnika" %>

<asp:Content ID="Content2" ContentPlaceHolderID="dashboardTitle" runat="server">
	<h3 class="text-white mb-0">Detalji</h3>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
	<div class="row">
		<div class="col-md-6 mt-4 dark-background rounded mb-3">
			<div class="form-group row my-4">
				<label for="tbIme" class="col-sm-2 col-form-label text-red">Ime</label>
				<div class="col-sm-9">
					<asp:TextBox ID="tbIme" runat="server" AutoCompleteType="None" CssClass="form-control" Enabled="false"></asp:TextBox>
				</div>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
					ControlToValidate="tbIme"
					Display="Dynamic"
					ForeColor="DarkRed"
					Font-Bold="True"
					Font-Size="Large"
					CssClass="col-sm-1"
					Text="*" />
			</div>
			<div class="form-group row my-4">
				<label for="tbPrezime" class="col-sm-2 col-form-label text-red">Prezime</label>
				<div class="col-sm-9">
					<asp:TextBox ID="tbPrezime" runat="server" AutoCompleteType="None" CssClass="form-control" Enabled="false"></asp:TextBox>
				</div>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
					ControlToValidate="tbPrezime"
					Display="Dynamic"
					ForeColor="DarkRed"
					Font-Bold="True"
					Font-Size="Large"
					CssClass="col-sm-1"
					Text="*" />
			</div>
			<div class="form-group row my-4">
				<label for="ddlTip" class="col-sm-2 col-form-label text-red">Tip</label>
				<div class="col-sm-9">
					<asp:DropDownList ID="ddlTip" runat="server" CssClass="form-control" Enabled="false" >
					</asp:DropDownList>
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
				<label for="tbDatumZaposlenja" class="col-sm-2 col-form-label text-red">Datum zaposlenja</label>
				<div class="col-sm-9 d-flex align-items-center">
					<asp:TextBox ID="tbDatumZaposlenja" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
				</div>
			</div>
			<div class="form-group row my-4">
				<label for="ddlTim" class="col-sm-2 col-form-label text-red">Tim</label>
				<div class="col-sm-9">
					<asp:DropDownList ID="ddlTim" runat="server" CssClass="form-control" Enabled="false">
					</asp:DropDownList>
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
		</div>
		<div class="col-md-6 mt-n4">
			<h5 class="text-white mb-4">Projekti na kojima radi</h5>
			<asp:PlaceHolder runat="server" ID="phProjektiDjelatnika" />
		</div>
	</div>
</asp:Content>
