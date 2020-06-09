<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardMasterPage.Master" AutoEventWireup="true" CodeBehind="DodajTim.aspx.cs" Inherits="Site_za_administraciju.DodajTim" %>

<asp:Content ID="Content2" ContentPlaceHolderID="dashboardTitle" runat="server">
	<h3 class="text-white mb-0">Dodaj novi tim</h3>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
	<div class="row">
		<div class="col-md-6 mt-4">
			<div class="form-group row my-4">
				<label for="tbNaziv" class="col-sm-2 col-form-label text-red">Naziv</label>
				<div class="col-sm-9">
					<asp:TextBox ID="tbNaziv" runat="server" AutoCompleteType="None" CssClass="form-control"></asp:TextBox>
				</div>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
					ControlToValidate="tbNaziv"
					Display="Dynamic"
					ForeColor="DarkRed"
					Font-Bold="True"
					Font-Size="Large"
					CssClass="col-sm-1"
					Text="*" />
			</div>
			<div class="form-group row my-4">
				<label for="ddlVoditeljProjekta" class="col-sm-2 col-form-label text-red">Voditelj</label>
				<div class="col-sm-9">
					<asp:DropDownList runat="server" ID="ddlVoditeljProjekta" CssClass="form-control">
					</asp:DropDownList>
				</div>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
					ControlToValidate="ddlVoditeljProjekta"
					Display="Dynamic"
					InitialValue="-1"
					ForeColor="DarkRed"
					Font-Bold="True"
					Font-Size="Large"
					CssClass="col-sm-1"
					Text="*" />
			</div>
			<div class="form-group row my-5">
				<div class="col-sm-10">
					<asp:LinkButton ID="BtnDodaj" runat="server" CssClass="btn btn-info" OnClick="BtnDodaj_Click"><i class="fas fa-plus">&nbsp;</i>Dodaj</asp:LinkButton>
				</div>
			</div>
		</div>
		<div class="col-md-6"></div>
	</div>
</asp:Content>
