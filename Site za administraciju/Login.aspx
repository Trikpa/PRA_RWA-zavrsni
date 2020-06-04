<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Site_za_administraciju.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link href="Content/bootstrap.css" rel="stylesheet" />
	<link href="Content/login.css" rel="stylesheet" />

    <title>Prijava</title>
</head>
<body class="dark-background vh-100">
    <form id="loginForm" runat="server" class="w-100 h-100  d-flex justify-content-center align-items-center">
		<div class="container login-form-dark-rounded-shadow w-50 h-auto dropShadow">
			<div class="row">
				<div class="col d-flex flex-column align-items-center">
					<div>
						<h1 class="mt-4 mb-2 display-6" id="welcome-text">Dobrodošli natrag!</h1>
					</div>
					<div>
						<asp:Label Text="" runat="server" ID="errorMessage" CssClass="text-danger" Visible="false" />
					</div>
					<div class="form-group w-50 mt-2 mb-3 d-flex flex-row">
						<asp:TextBox ID="tbUsername" runat="server" 
							CssClass="inputField span6" 
							Placeholder="Email" 
							Autofocus="true" 
							AutoComplete="off"/>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
							ControlToValidate="tbUsername" 
							Display="Dynamic" 
							ForeColor="DarkRed" 
							Font-Bold="True"
							Font-Size="Large"
							Text="*"/>
					</div>
					<div class="form-group w-50 mt-3 mb-4 d-flex flex-row">
						<asp:TextBox ID="tbPassword" runat="server" 
							CssClass="inputField span6" 
							Placeholder="Zaporka" 
							TextMode="Password"/>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
							ControlToValidate="tbPassword"
							Display="Dynamic"
							ForeColor="DarkRed"
							Font-Bold="True"
							Font-Size="Large"
							Text="*" />
					</div>
					<div class="form-check w-50">
						<asp:CheckBox ID="cbRememberMe" runat="server"
							Text="Zapamti me"
							CssClass="form-check-input text-white"
							/>
					</div>
					<div class="form-group w-50 mt-5">
						<asp:DropDownList runat="server" CssClass="form-control" ID="ddlOdabraniSite">
							<asp:ListItem Text="Site za administraciju i izvještavanje" Selected="True" Value="administracija" />
							<asp:ListItem Text="Site za evidenciju radnih sati" Value="evidencija" />
						</asp:DropDownList>
					</div>
					<div class="form-group w-50 mb-3">
						<asp:Button ID="btnLogin" runat="server" Text="Prijava" CssClass="btn-block loginButton" OnClick="BtnLogin_Click" />
					</div>
				</div>
			</div>
		</div>
    </form>
</body>
</html>
