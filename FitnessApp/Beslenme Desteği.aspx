<%@ Page Title="" Language="C#" MasterPageFile="~/AltSayfa.Master" AutoEventWireup="true" CodeBehind="Beslenme Desteği.aspx.cs" Inherits="FitnessApp.Beslenme_Desteği" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Content/styles.css" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="articles-list">
        <h2>Sağlıklı Yemek Tarifleri ve Atıştırmalıklar</h2>
        <asp:Repeater ID="ArticlesRepeater" runat="server">
            <ItemTemplate>
                <div class="article-item">
                    <h3>
                        <a href="BeslenmeDestegiDetay.aspx?id=<%# Eval("Id") %>">
                            <%# Eval("Title") %>
                        </a>
                    </h3>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>



