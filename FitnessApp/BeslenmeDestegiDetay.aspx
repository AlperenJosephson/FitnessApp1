<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BeslenmeDestegiDetay.aspx.cs" Inherits="FitnessApp.BeslenmeDestegiDetay" MasterPageFile="~/Anasayfa.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="article-detail">
        <h2 id="articleTitle" runat="server"></h2> <!-- Başlık için -->
        <p id="articleContent" runat="server"></p> <!-- İçerik için -->
    </div>
</asp:Content>
