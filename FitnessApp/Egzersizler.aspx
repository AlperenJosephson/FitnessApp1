﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AltSayfa.Master" AutoEventWireup="true" CodeBehind="Egzersizler.aspx.cs" Inherits="FitnessApp.Egzersizler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">

    <h2>Egzersiz Hareketleri</h2>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <div class="section-tittle text-center">
                <!-- <span>FEATURED TOURS Packages</span> -->
                <h2>EGZERSİZLER</h2>
            </div>
        </div>
    </div>
    
    <div class="container mt-5">
        <div class="row">
            <asp:Repeater ID="ExercisesRepeater" runat="server">
                <ItemTemplate>
                    <div class="col-md-4"> <!-- Ekranı üç sütuna böler -->
                        <div class="card mb-4">
                            <img class="card-img-top" src="assets/200w.gif" alt="Egzersiz Görseli">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Name") %></h5>
                                <p class="card-text">Tür: <%# Eval("Type") %></p>
                                <p class="card-text">Kas Grubu: <%# Eval("Muscle") %></p>
                                <p class="card-text">Ekipman: <%# Eval("Equipment") %></p>
                                <p class="card-text">Zorluk: <%# Eval("Difficulty") %></p>
                                <!-- <p class="card-text">Talimatlar: <%# Eval("Instructions") %></p> -->
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <!--
    <div class="row">
        <div class="col-xl-4 col-lg-4 col-md-6">
            <div class="single-place mb-30">
                <div class="place-img">
                    <img src="assets/img2/service/services1.jpg" alt="">
                </div>
                <div class="place-cap">
                    <div class="place-cap-top">
                        <span><i class="fas fa-star"></i><span>8.0 Superb</span> </span>
                        <h3><a href="#">The Dark Forest Adventure</a></h3>
                        <p class="dolor">$1870 <span>/ Per Person</span></p>
                    </div>
                    <div class="place-cap-bottom">
                        <ul>
                            <li><i class="far fa-clock"></i>3 Days</li>
                            <li><i class="fas fa-map-marker-alt"></i>Los Angeles</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    -->
</asp:Content>



