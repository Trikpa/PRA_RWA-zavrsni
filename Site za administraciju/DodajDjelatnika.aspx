<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardMasterPage.Master" AutoEventWireup="true" CodeBehind="DodajDjelatnika.aspx.cs" Inherits="Site_za_administraciju.DodajDjelatnika" %>

<asp:Content ID="Content2" ContentPlaceHolderID="dashboardTitle" runat="server">
	<h3 class="text-white mb-0">Dodaj djelatnika</h3>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
	<div class="row">
		<div class="col-md-6 mt-4 dark-background rounded mb-3">
			<div class="form-group row my-4">
				<label for="tbIme" class="col-sm-2 col-form-label text-red">Ime</label>
				<div class="col-sm-9">
					<asp:TextBox ID="tbIme" runat="server" AutoCompleteType="None" CssClass="form-control"></asp:TextBox>
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
					<asp:TextBox ID="tbPrezime" runat="server" CssClass="form-control"></asp:TextBox>
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
					<asp:DropDownList ID="ddlTip" runat="server" CssClass="form-control">
					</asp:DropDownList>
				</div>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
					ControlToValidate="ddlTip"
					Display="Dynamic"
					ForeColor="DarkRed"
					Font-Bold="True"
					Font-Size="Large"
					CssClass="col-sm-1"
					Text="*" />
			</div>
			<div class="form-group row my-4">
				<label for="tbEmail" class="col-sm-2 col-form-label text-red">Email</label>
				<div class="col-sm-9">
					<asp:TextBox ID="tbEmail" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
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
				<label for="tbLozinka" class="col-sm-2 col-form-label text-red">Lozinka</label>
				<div class="col-sm-9">
					<asp:TextBox ID="tbLozinka" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
				</div>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
					ControlToValidate="tbLozinka"
					Display="Dynamic"
					ForeColor="DarkRed"
					Font-Bold="True"
					Font-Size="Large"
					CssClass="col-sm-1"
					Text="*" />
			</div>
			<div class="form-group row my-4">
				<label for="ddlTim" class="col-sm-2 col-form-label text-red">Tim</label>
				<div class="col-sm-9">
					<asp:DropDownList ID="ddlTimovi" runat="server" CssClass="form-control">
					</asp:DropDownList>
				</div>
			</div>
			<div class="form-group row my-4">
				<div class="col-sm-10">
					<asp:LinkButton ID="BtnDodaj" runat="server" CssClass="btn btn-info" OnClick="BtnDodaj_Click"><i class="fas fa-plus">&nbsp;Dodaj</i></asp:LinkButton>
				</div>
			</div>
		</div>
		<div class="col-md-6"></div>
	</div>
</asp:Content>
