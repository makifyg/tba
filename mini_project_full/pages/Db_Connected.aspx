<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Db_Connected.aspx.cs" Inherits="mini_project_full.Db3" ClientIDMode="Static"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-size: 150%">השיטה "המקושרת"</div>

    <div class="sectionDiv">
        <div>Animals Table:</div>
        <div id="idAnimalsTable" runat="server">Animals Table:</div>
    </div>

    <div class="sectionDiv">
        <div>Execute Scalar: Get Count:</div>
        <textarea id="idSelectCount" runat="server" rows="2" cols="70">Select count(*) from animals where type='mamals'</textarea>
        <div>
            <button id="btnSelectCount" runat="server" onserverclick="btnSelectCount_ServerClick">Run</button>
        </div>
        <div id="idSelectCountResult" runat="server"></div>
    </div>

    <div class="sectionDiv">
        <div>Add animal:</div>
        Animal name:
        <input id="inAnimalNameToAdd" runat="server" placeholder="name" />
        Animal type:
        <input id="inAnimalTypeToAdd" runat="server" placeholder="type" />
        <div>
            <button id="btnAdd" runat="server" onserverclick="btnAdd_ServerClick">Run</button></div>
        <div id="idAddResult" runat="server"></div>
    </div>

    <div class="sectionDiv">
        <div>Update animal:</div>
        <div>Animal name:   
            <input id="idNameToUpdate" runat="server" placeholder="animal name to update" class="animalNameInput" />
        </div>
        <div>Animal type:
            <input id="idTypeToUpdate" runat="server" placeholder="new type" />
        </div>
        <div>Size:
            <input id="idUpdateSize" runat="server" placeholder="new size" />
        </div>
        <div>Endangered?
            <input id="idUpdateEndangered" runat="server" placeholder="new endangered" />
        </div>
        <div>Estimatation:
            <input id="idUpdateEstimation" runat="server" placeholder="new estimation" />
        </div>
        <div><button id="btnUpdate" runat="server" onserverclick="btnUpdate_ServerClick">Run</button></div>
        <div id="idUpdateResult" runat="server"></div>
    </div>

    <div class="sectionDiv">
        <div>Delete Animal:</div>
        Animal name:
        <input id="idNameToDelete" runat="server" placeholder="animal name to delete" class="animalNameInput" />
        <div><button id="btnDelete" runat="server" onserverclick="btnDelete_ServerClick">Run</button></div>
        <div id="idDeleteResult" runat="server"></div>
    </div>

</asp:Content>
