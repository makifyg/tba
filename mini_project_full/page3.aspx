<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="page3.aspx.cs" Inherits="mini_project_full.page3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-size: 300%">Page 3</div>

    <br />
    <div>
        <button id="btnAddClick" runat="server" onserverclick="btnAddClick_ServerClick">Add</button>
    </div>
    <div id="divClickCount" runat="server" style="margin-block:30px">0</div>
</asp:Content>
