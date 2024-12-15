<%@ Page Title="" Language="C#" MasterPageFile="~/AltSayfa.Master" AutoEventWireup="true" CodeBehind="Kalori Hesabı.aspx.cs" Inherits="FitnessApp.Kalori_Hesabı" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Kalori Hesabı</h2>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container mt-5">
        
            <!-- Yaş -->
            <div class="form-group">
                <label for="txtYas">Yaş</label>
                <asp:TextBox ID="txtYas" CssClass="form-control" runat="server" placeholder="Yaşınızı giriniz"></asp:TextBox>
            </div>

            <!-- Cinsiyet -->
            <div class="form-group">
                <label for="ddlCinsiyet">Cinsiyet</label>
                <asp:DropDownList ID="ddlCinsiyet" CssClass="form-control" runat="server">
                    <asp:ListItem Value="Erkek">Erkek</asp:ListItem>
                    <asp:ListItem Value="Kadın">Kadın</asp:ListItem>
                </asp:DropDownList>
            </div>

            <!-- Kilo -->
            <div class="form-group">
                <label for="txtKilo">Kilo (kg)</label>
                <asp:TextBox ID="txtKilo" CssClass="form-control" runat="server" placeholder="Kilonuzu giriniz"></asp:TextBox>
            </div>

            <!-- Boy -->
            <div class="form-group">
                <label for="txtBoy">Boy (cm)</label>
                <asp:TextBox ID="txtBoy" CssClass="form-control" runat="server" placeholder="Boyunuzu giriniz"></asp:TextBox>
            </div>

            <!-- Aktivite Seviyesi -->
            <div class="form-group">
                <label for="ddlAktivite">Aktivite Seviyesi</label>
                <asp:DropDownList ID="ddlAktivite" CssClass="form-control" runat="server">
                    <asp:ListItem Value="1.2">Hareketsiz</asp:ListItem>
                    <asp:ListItem Value="1.375">Az Aktif</asp:ListItem>
                    <asp:ListItem Value="1.55">Orta Aktif</asp:ListItem>
                    <asp:ListItem Value="1.725">Çok Aktif</asp:ListItem>
                    <asp:ListItem Value="1.9">Aşırı Aktif</asp:ListItem>
                </asp:DropDownList>
            </div>

            <!-- Hesaplama Butonu -->
            <asp:Button ID="btnHesapla" CssClass="btn btn-primary" runat="server" Text="Kaloriyi Hesapla" OnClick="btnHesapla_Click" />

            <!-- Sonuç Alanı -->
            <div class="mt-4">
                <asp:Label ID="lblSonuc" runat="server" Text="" CssClass="alert alert-info" Visible="false"></asp:Label>
            </div>
        
    </div>

</asp:Content>