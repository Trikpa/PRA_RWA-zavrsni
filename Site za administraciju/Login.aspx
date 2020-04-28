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
		<div class="container login-form-dark-rounded-shadow w-50 h-50 dropShadow">
			<div class="row">
				<div class="col d-flex flex-column align-items-center">
					<div>
						<h1 class="mt-4 mb-5 display-4" id="welcome-text">Dobrodošli natrag!</h1>
					</div>
					<div class="form-group w-50 my-5">
						<input
							type="text"
							name="username"
							id="txtUsername"
							class="inputField"
							placeholder="Korisničko ime"
							required
							autocomplete="off"
							autofocus />
					</div>
					<div class="form-group w-50 mt-3 mb-4">
						<input
							type="password"
							name="password"
							id="txtPassword"
							class="inputField"
							placeholder="Zaporka"
							required />
					</div>
					<div class="form-group w-50 my-5">
						<input type="submit" value="Prijava" class="btn-block loginButton">
					</div>
				</div>
			</div>
		</div>
    </form>
</body>
</html>
