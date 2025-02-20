﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FitnessApp.Register" %>

<!DOCTYPE html>
<html lang="tr">
<head>
	<title>Kullanıcı Kayıt</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="icon" type="image/png" href="Login_v1/images/icons/favicon.ico"/>
	<link rel="stylesheet" type="text/css" href="Login_v1/vendor/bootstrap/css/bootstrap.min.css">
	<link rel="stylesheet" type="text/css" href="Login_v1/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
	<link rel="stylesheet" type="text/css" href="Login_v1/vendor/animate/animate.css">
	<link rel="stylesheet" type="text/css" href="Login_v1/vendor/css-hamburgers/hamburgers.min.css">
	<link rel="stylesheet" type="text/css" href="Login_v1/vendor/select2/select2.min.css">
	<link rel="stylesheet" type="text/css" href="Login_v1/css/util.css">
	<link rel="stylesheet" type="text/css" href="Login_v1/css/main.css">
	<meta name="robots" content="noindex, follow">
</head>
<body>

	<div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100">
				<div class="login100-pic js-tilt" data-tilt>
					<img src="Login_v1/images/img-01.png" alt="IMG">
				</div>

				<form class="login100-form validate-form" runat="server">
					<span class="login100-form-title">
						Kullanıcı Kaydı
					</span>

					<!-- Kullanıcı Adı Field -->
					<div class="wrap-input100 validate-input" data-validate="Kullanıcı Adı Gereklidir">
						<asp:TextBox ID="txtKullaniciAdi" runat="server" CssClass="input100" placeholder="Kullanıcı Adı"></asp:TextBox>
						<span class="focus-input100"></span>
						<span class="symbol-input100">
							<i class="fa fa-user" aria-hidden="true"></i>
						</span>
					</div>

					<!-- E-Mail Field -->
					<div class="wrap-input100 validate-input" data-validate="Geçerli Mail tipi: ex@abc.xyz">
						<asp:TextBox ID="txtMail" runat="server" CssClass="input100" placeholder="Mail"></asp:TextBox>
						<span class="focus-input100"></span>
						<span class="symbol-input100">
							<i class="fa fa-envelope" aria-hidden="true"></i>
						</span>
					</div>

					<!-- Password Field -->
					<div class="wrap-input100 validate-input" data-validate="Şifre Gereklidir">
						<asp:TextBox ID="txtSifre" runat="server" CssClass="input100" TextMode="Password" placeholder="Şifre"></asp:TextBox>
						<span class="focus-input100"></span>
						<span class="symbol-input100">
							<i class="fa fa-lock" aria-hidden="true"></i>
						</span>
					</div>

					<div class="container-login100-form-btn">
                        <asp:Button ID="btnRegister" runat="server" CssClass="login100-form-btn" Text="Kayıt Ol" OnClick="btnRegister_Click" />
					</div>

					<p style="align-content:center; margin-top:30px;"><asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label></p>
					<p style="align-content:center; margin-top:30px;"><asp:Label ID="Label2" runat="server" ForeColor="Black"></asp:Label></p>
					<p style="align-content:center; margin-top:50px;"><asp:Label ID="Label3" runat="server" ForeColor="Black"></asp:Label></p>

					<div class="text-center p-t-136">
						<a class="txt2" href="Login.aspx">
							Giriş Yap
							<i class="fa fa-long-arrow-right m-l-5" aria-hidden="true"></i>
						</a>
					</div>
				</form>
			</div>
		</div>
	</div>

	<script src="Login_v1/vendor/jquery/jquery-3.2.1.min.js"></script>
	<script src="Login_v1/vendor/bootstrap/js/popper.js"></script>
	<script src="Login_v1/vendor/bootstrap/js/bootstrap.min.js"></script>
	<script src="Login_v1/vendor/select2/select2.min.js"></script>
	<script>
        $('.js-tilt').tilt({
            scale: 1.1
        })
    </script>
	<script src="Login_v1/js/main.js"></script>
</body>
</html>

