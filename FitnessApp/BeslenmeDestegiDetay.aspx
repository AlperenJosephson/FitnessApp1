<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BeslenmeDestegiDetay.aspx.cs" Inherits="FitnessApp.BeslenmeDestegiDetay" MasterPageFile="~/AltSayfa.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- CSS Dosyaları -->
    <link rel="stylesheet" href="Content/styles.css" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Beslenme Desteği</h2>

    <meta charset="utf-8">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <!--<title>FitKAL </title> -->
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- <link rel="manifest" href="site.webmanifest"> -->
    <link rel="shortcut icon" type="image/x-icon" href="assets/img2/favicon.png">
    <!-- Place favicon.ico in the root directory -->
    
  <!-- CSS here -->
  <link rel="stylesheet" href="assets/css2/bootstrap.min.css">
  <link rel="stylesheet" href="assets/css2/owl.carousel.min.css">
  <link rel="stylesheet" href="assets/css2/slicknav.css">
  <link rel="stylesheet" href="assets/css2/animate.min.css">
  <link rel="stylesheet" href="assets/css2/magnific-popup.css">
  <link rel="stylesheet" href="assets/css2/fontawesome-all.min.css">
  <link rel="stylesheet" href="assets/css2/themify-icons.css">
  <link rel="stylesheet" href="assets/css2/themify-icons.css">
  <link rel="stylesheet" href="assets/css2/slick.css">
  <link rel="stylesheet" href="assets/css2/nice-select.css">
  <link rel="stylesheet" href="assets/css2/style.css">
  <link rel="stylesheet" href="assets/css2/responsive.css">

  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="article-detail">
        <asp:Image ID="articleImage" runat="server" style ="width: 500px; height: auto; display: block; margin: 20px auto; border-radius: 8px; box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);" CssClass ="article-image" />
        <h2 id="articleTitle" runat="server"></h2> <!-- Başlık için -->
        <p id="articleContent" runat="server"></p> <!-- İçerik için -->
    </div>
</asp:Content>
