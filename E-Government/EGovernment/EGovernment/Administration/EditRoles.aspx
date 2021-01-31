<%@ Page Title="تعديل دور" Language="C#" MasterPageFile="~/SiteAdministration.Master" AutoEventWireup="true" CodeBehind="EditRoles.aspx.cs" Inherits="EGovernment.Administration.Transactions.EditRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
      

        .control-label {
            float: right;
            top: 0px;
            right: 6px;
            font-size: large;
            font-weight: 700;
        }
    </style>
    <br />
    <br />
    <div class="form-horizontal">

        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">الأدوار</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList CssClass="btn btn-default dropdown-toggle" ID="ddlRoles" runat="server" DataSourceID="EntityDataSource1" DataTextField="Name" DataValueField="Id">
                </asp:DropDownList>
                <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=EGovernmentEntities" DefaultContainerName="EGovernmentEntities" EnableFlattening="False" EntitySetName="tblRoles" Select="it.[Id], it.[Name]">
                </asp:EntityDataSource>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-10">
                <asp:Button ID="btnEdit" runat="server" Text="تعديل" CssClass="btn btn-success" OnClick="btnEdit_Click" />
            </div>
        </div>

    </div>
</asp:Content>
