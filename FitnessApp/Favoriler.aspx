<%@ Page Title="" Language="C#" MasterPageFile="~/AltSayfa.Master" AutoEventWireup="true" CodeBehind="Favoriler.aspx.cs" Inherits="FitnessApp.Favoriler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Favoriler</h2>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container mt-5">
        <div class="row">
            <asp:Repeater ID="FavoritesRepeater" runat="server">
                <ItemTemplate>
                    <div class="col-md-4"> <!-- Ekranı üç sütuna böler -->
                        <div class="card mb-4">
                            <img class="card-img-top" src='<%#"assets/images/" + Eval("Name").ToString().Trim().ToLower().Replace(" ","-") +".gif"%>' alt="Egzersiz Görseli">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Name") %></h5>
                                <p class="card-text">Tür: <%# Eval("Type") %></p>
                                <p class="card-text">Kas Grubu: <%# Eval("Muscle") %></p>
                                <p class="card-text">Ekipman: <%# Eval("Equipment") %></p>
                                <p class="card-text">Zorluk: <%# Eval("Difficulty") %></p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>                       