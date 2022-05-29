<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="database.aspx.cs" Inherits="mini_project_full.pages.database" ClientIDMode="Static" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        body{
            direction:ltr;
        }
        .borderd{
            border:groove;
            margin:20px;
            width:600px;
            direction:rtl;
        }
        label{
            width: 200px;
            display: inline-block;
            margin-right:10px;
        }
        input{
            width: 200px;
            direction:ltr;
        }
        .doublewidth{
            width: 400px;
        }
        h1{
            margin-left:10px;
            direction:ltr;
        }
        button{
            margin:20px;
            direction:ltr;
            margin-right:200px;
        }
        table{
            direction:ltr;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="animalsTableId" runat="server" class="borderd"/>    
    <div id="insertDivId" runat="server" class="borderd">
        <h1>Insert</h1>
        <div><label>שם החיה:</label><input id="insertAnimalNameId" runat="server" type="text" /></div>
        <div><label>סוג חיה:</label><input id="insertAnimalTypeId" runat="server" type="text" /></div>
        <button id="btnInsertId" runat="server" onserverclick="btnInsertId_ServerClick">Insert</button>
        <div id="insertResultId" runat="server"/>
    </div>
    <div id="updateDivId" runat="server" class="borderd">
        <h1>Update</h1>
        <div><label>שם החיה:</label><input id="updateAnimalNameId" runat="server" type="text" /></div>
        <div><label>סוג חיה:</label><input id="updateAnimalTypeId" runat="server" type="text" /></div>
        <div><label>גודל:</label><input id="updateAnimalSizeId" runat="server" type="text" /></div>
        <div><label>אומדן מס' פריטים:</label><input id="updateAnimalEstimationId" runat="server" type="number" /></div>
        <div><label>האם בסכנת הכחדה?:</label><input id="updateAnimalEndangeredId" runat="server" type="checkbox" /></div>
        <button id="btnUpdateId" runat="server" onserverclick="btnUpdateId_ServerClick">Update</button>
        <div id="updateResultId" runat="server" />
    </div>
    <div id="deleteDivId" runat="server" class="borderd">
        <h1>Delete</h1>
        <div><label>שם החיה:</label><input id="deleteAnimalNameId" runat="server" type="text" /></div>
        <button id="btnDeleteId" runat="server" onserverclick="btnDeleteId_ServerClick">Delete</button>
        <div id="deleteResultId" runat="server" />
    </div>
    <div id="selectDivId" runat="server" class="borderd">
        <h1>Select</h1>
        <div><label>שאילתת select:</label><input id="selectQueryId" runat="server" value="select name, type from animals where type='birds'" class="doublewidth"/></div>
        <button id="btnSelectId" runat="server" onserverclick="btnSelectId_ServerClick">Select</button>
        <div id="selectResultId" runat="server" />
    </div>
    <div id="SelectCountDivId" runat="server" class="borderd">
        <h1>Select Count</h1>
        <div><label>where:</label><input id="selectCountWhereId" runat="server" value="type = 'birds'" class="doublewidth"/></div>
        <button id="btnSelectCountId" runat="server" onserverclick="btnSelectCountId_ServerClick">Select Count</button>
        <div id="selectCountResultId" runat="server" />
    </div>
</asp:Content>
