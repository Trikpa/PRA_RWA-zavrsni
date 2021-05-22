﻿<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardMasterPage.Master" AutoEventWireup="true" CodeBehind="DetaljiProjekta.aspx.cs" Inherits="Site_za_administraciju.DetaljiProjekta" %>

<asp:Content ID="Content2" ContentPlaceHolderID="dashboardTitle" runat="server">
	<h3 class="text-white mb-0">Detalji projekta</h3>
</asp:Content>

<asp:Content ID="container" ContentPlaceHolderID="body" runat="server">
	<div class="row">
		<div class="col-md-6 mt-4 dark-background rounded mb-3">
			<div class="form-group row my-4">
				<label for="tbNaziv" class="col-sm-2 col-form-label text-red">Naziv</label>
				<div class="col-sm-9">
					<asp:TextBox ID="tbNaziv" runat="server" AutoCompleteType="None" CssClass="form-control" Enabled="false"></asp:TextBox>
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
				<label for="tbDatum" class="col-sm-2 col-form-label text-red">Datum otvaranja</label>
				<div class="col-sm-9">
					<asp:TextBox ID="tbDatum" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
				</div>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
					ControlToValidate="tbDatum"
					Display="Dynamic"
					ForeColor="DarkRed"
					Font-Bold="True"
					Font-Size="Large"
					CssClass="col-sm-1"
					Text="*" />
			</div>
			<div class="form-group row my-4">
				<label for="tbVoditelj" class="col-sm-2 col-form-label text-red">Voditelj</label>
				<div class="col-sm-9">
					<asp:TextBox ID="tbVoditelj" runat="server" AutoCompleteType="None" CssClass="form-control" Enabled="false"></asp:TextBox>
				</div>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
					ControlToValidate="tbVoditelj"
					Display="Dynamic"
					ForeColor="DarkRed"
					Font-Bold="True"
					Font-Size="Large"
					CssClass="col-sm-1"
					Text="*" />
			</div>
			<div class="form-group row my-4">
				<label for="tbKlijent" class="col-sm-2 col-form-label text-red">Klijent</label>
				<div class="col-sm-9">
					<asp:TextBox ID="tbKlijent" runat="server" AutoCompleteType="None" CssClass="form-control" Enabled="false"></asp:TextBox>
				</div>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
					ControlToValidate="tbKlijent"
					Display="Dynamic"
					ForeColor="DarkRed"
					Font-Bold="True"
					Font-Size="Large"
					CssClass="col-sm-1"
					Text="*" />
			</div>
			<div class="form-group row my-4">
				<label for="tbOpis" class="col-sm-2 col-form-label text-red">Opis</label>
				<div class="col-sm-9">
					<asp:TextBox ID="tbOpis" runat="server" AutoCompleteType="None" CssClass="form-control" TextMode="MultiLine" MaxLength="250"></asp:TextBox>
				</div>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
					ControlToValidate="tbOpis"
					Display="Dynamic"
					ForeColor="DarkRed"
					Font-Bold="True"
					Font-Size="Large"
					CssClass="col-sm-1"
					Text="*" />
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
			<h5 class="text-white mb-4">Djelatnici koji rade na projektu</h5>
			<asp:PlaceHolder runat="server" ID="phDjelatniciNaProjektu" />
		</div>
	</div>
</asp:Content>