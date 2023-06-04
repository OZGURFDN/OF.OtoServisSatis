﻿
                <%@ Page Title="Araç Yönetimi" Language="C#" MasterPageFile="~/OtoServisSablon.Master" AutoEventWireup="true" CodeBehind="AracYonetimi.aspx.cs" Inherits="OtoServisSatis.WebFormUI.AracYonetimi" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v22.2, Version=22.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="dgvAraclar" runat="server" GridLines="Horizontal"></asp:GridView>
    
    <hr/>
    <h1>Araç Bilgileri</h1>
    <table class="auto-style1">
        <tr>
            <td>Marka</td>
            <td>
                <asp:DropDownList ID="cmbMarkalar" runat="server" DataTextField="Adi">
                </asp:DropDownList>
            </td>
            <td></td>
            <td>
                
            </td>
        </tr>
        <tr>
            <td>Renk</td>
            <td>
                <asp:TextBox ID="txtRenk" runat="server"></asp:TextBox>
            </td>
            <td></td>
            <td>
                
            </td>
        </tr>
        <tr>
            <td>Fiyatı</td>
            <td>
                <asp:TextBox ID="txtFiyat" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Modeli</td>
            <td>
                <asp:TextBox ID="txtModeli" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Kasa Tipi</td>
            <td>
                <asp:TextBox ID="txtKasatipi" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Model Yılı</td>
            <td><asp:TextBox ID="txtYili" runat="server"></asp:TextBox></td>
            <td>
            </td>
            <td>&nbsp;</td>
        </tr>
        
        <tr>
            <td>Notlar</td>
            <td>
                <asp:TextBox ID="txtNotlar" runat="server"></asp:TextBox></td>
            <td>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:CheckBox runat="server" Text="Satışta Mı?"></asp:CheckBox>
                </td>
            <td>
            </td>
            <td>&nbsp;</td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;<asp:Button ID="btnEkle" runat="server" Text="Ekle" OnClick="btnEkle_Click" /><asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" OnClick="btnGuncelle_Click" /><asp:Button ID="btnSil" runat="server" Text="Sil" OnClick="btnSil_Click" /></td>
            <td>
                
                
                
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>


</asp:Content>
