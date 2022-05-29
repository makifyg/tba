<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="mini_project_full.pages.WebForm1" ClientIDMode="Static" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/myProjectCode.js" type="text/javascript"></script>
    <style type="text/css">
        .error{
            color:red;
        }
        #btn1{
            margin-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-size:150%; margin-top:20px;">Registration</div>
    <div>user name:<input id="idUserName" runat="server" /><div id=idUserNameErr class="error"></div></div>
    <div>password: <input id="idPassword" runat="server" type="password"/><div id="idPasswordErr" class="error"></div>
    <div>birth date:<input id="idBirthDate" runat="server" type="date" /></div>
</div>
    <div id="idAddResult" runat="server"></div>
    <div id="idAddError" runat="server" class="error"></div>
    <div><button id="btn1" runat="server" onclick="if (!validateAllFields()) return false;" onserverclick="btn1_ServerClick">Register</button></div>
    
    <div style="margin-top: 20px"><a href="Login.aspx">Login</a></div>
</asp:Content>
