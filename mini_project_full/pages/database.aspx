<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="database.aspx.cs" Inherits="mini_project_full.pages.database" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        div{
            border1:solid;
            margin:20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div><a href="Db_NotConnected.aspx">Not Connected</a></div>
    <div><a href="Db_Connected.aspx">Connected</a></div>
    <div><a href="DB_Advance.aspx">Advance</a></div>
</asp:Content>
