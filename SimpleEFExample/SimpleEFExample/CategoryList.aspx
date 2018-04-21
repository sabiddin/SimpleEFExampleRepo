<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="SimpleEFExample.CategoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    
     <asp:GridView GridLines="None" CssClass="table table-striped table-hover" AutoGenerateColumns="false" runat="server" ID="gvCategories">
        <Columns>
           <asp:BoundField  HeaderText ="ID" DataField="CategoryID"/>            
            <asp:HyperLinkField HeaderText ="Name" DataTextField="CategoryName" DataNavigateUrlFormatString="~/ProductList.aspx?CategoryID={0}" DataNavigateUrlFields="CategoryID"/>
            <asp:BoundField  HeaderText ="Description" DataField="Description"/>                        
        </Columns>
    </asp:GridView>    
</asp:Content>
