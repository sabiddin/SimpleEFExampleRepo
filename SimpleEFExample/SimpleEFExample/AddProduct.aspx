<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="SimpleEFExample.AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
        <label for="ProductName">Name</label>
        <asp:TextBox CssClass="form-control" runat="server" ID="txtProductName" />  
    </div>
  <div class="form-group">
        <label for="CategoryName">Category</label>
      <asp:DropDownList CssClass="form-control" runat="server" ID="ddlCategories">         
      </asp:DropDownList> 
    </div>
    <div class="form-group">
        <label for="Price">Price</label>
        <asp:TextBox CssClass="form-control" runat="server" ID="txtUnitPrice" />  
    </div>
     <div class="form-group">
        <label for="InStock">In Stock</label>
        <asp:TextBox CssClass="form-control" runat="server" ID="txtInStock" />  
    </div>
    <div class="form-group">       
        <asp:CheckBox Text="Discontinued" ID="chkDiscontinued" runat="server" />
    </div>
    <asp:Button Text="Save" CssClass="btn btn-primary" ID="btnSave" OnClick="btnSave_Click" runat="server" />    
</asp:Content>
