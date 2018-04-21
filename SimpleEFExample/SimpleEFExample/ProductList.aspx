<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="SimpleEFExample.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label Text="" ID="lblMessage" runat="server" />
    <asp:GridView GridLines="None" CssClass="table table-striped table-hover" AutoGenerateColumns="false" runat="server" ID="gvProducts">
        <Columns>
           <asp:BoundField  HeaderText ="ID" DataField="ProductID"/>
            <asp:BoundField  HeaderText ="Name" DataField="ProductName"/>
            <asp:BoundField  HeaderText ="Price" DataField="UnitPrice"/>
            <asp:BoundField  HeaderText ="In Stock" DataField="UnitsInStock"/> 
            <asp:HyperLinkField Text="Edit" DataNavigateUrlFormatString="~/AddProduct.aspx?ProductID={0}&Action=Edit" DataNavigateUrlFields="ProductID"/>
            <asp:HyperLinkField Text="Delete" DataNavigateUrlFormatString="~/AddProduct.aspx?ProductID={0}&Action=Delete" DataNavigateUrlFields="ProductID"/>
        </Columns>
    </asp:GridView>
    <asp:Button Text="Add Product" CssClass="btn btn-primary" ID="btnAddProduct" OnClick="btnAddProduct_Click"
        runat="server" />
</asp:Content>
