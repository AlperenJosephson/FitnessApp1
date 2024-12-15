<%@ Page Title="" Language="C#" MasterPageFile="~/AltSayfa.Master" AutoEventWireup="true" CodeBehind="Sağlık Takibi.aspx.cs" Inherits="FitnessApp.Sağlık_Takibi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Sağlık Takibi</h2>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container mt-4">
        <!-- Veri Giriş Alanları -->
        <div class="row mb-4">
            <div class="col-md-3">
                <label>Kilo (kg):</label>
                <asp:TextBox ID="txtKilo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <label>Boy (cm):</label>
                <asp:TextBox ID="txtBoy" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <label>Adım Sayısı:</label>
                <asp:TextBox ID="txtAdimSayisi" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <label>Egzersiz Adı:</label>
                <asp:TextBox ID="txtEgzersizAdi" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row mb-4">
            <div class="col-md-3">
                <label>Egzersiz Süresi (dk):</label>
                <asp:TextBox ID="txtEgzersizSuresi" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3 mt-4">
                <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" CssClass="btn btn-primary" OnClick="btnKaydet_Click" />
            </div>
        </div>

        <!-- Sağlık Verilerinin Listelenmesi -->
        <h4>Sağlık Verileriniz</h4>
        <asp:Repeater ID="RepeaterSaglikTakibi" runat="server">
            <HeaderTemplate>
                <table class="table table-striped">
                    <tr>
                        <th>Tarih</th><th>Kilo</th><th>Boy</th><th>Adım Sayısı</th><th>Egzersiz Adı</th><th>Egzersiz Süresi</th><th>VKE</th>
                    </tr>
            </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Tarih") %></td>
                        <td><%# Eval("Kilo") %> kg</td>
                        <td><%# Eval("Boy") %> cm</td>
                        <td><%# Eval("AdimSayisi") %></td>
                        <td><%# Eval("EgzersizAdi") %></td>
                        <td><%# Eval("EgzersizSuresi") %> dk</td>
                        <td><%# Eval("VKE") %></td>
                    </tr>
                </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        
        <asp:Label ID="lblGeriBildirim" runat="server" CssClass="alert alert-info" Visible="false"></asp:Label>


    </div>
</asp:Content>