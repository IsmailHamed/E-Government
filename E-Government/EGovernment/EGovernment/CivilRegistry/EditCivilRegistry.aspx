<%@ Page Title="تعديل السجلات المدنية" Language="C#" MasterPageFile="~/SiteAdministration.Master" AutoEventWireup="true" CodeBehind="EditCivilRegistry.aspx.cs" Inherits="EGovernment.CivilRegistry.EditCivilRegistry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .btn {
            float: right;
        }

        .control-label {
            float: right;
            top: 0px;
            right: 6px;
            font-size: large;
            font-weight: 700;
        }
    </style>
    <br />
    <div class="form-horizontal">

        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">الشؤون المدنية</asp:Label>
            <div class="col-md-10 ">
                <asp:DropDownList CssClass="btn btn-default dropdown-toggle" ID="ddlCivilAffairs" runat="server" AutoPostBack="True"
                    DataTextField="Name" DataValueField="Id" ViewStateMode="Enabled" EnableViewState="true"
                    OnSelectedIndexChanged="ddlCivilAffairs_SelectedIndexChanged">
                </asp:DropDownList>
               <br />
                <br />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCivilAffairs"
                    CssClass="text-danger" ErrorMessage="الرجاء تحديد الشؤون المدنية" />
            </div>
        </div>

        <div class="form-group" id="divCivilRegistry" runat="server">
            <asp:Label runat="server" CssClass="col-md-2 control-label">السجل المدني</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList CssClass="btn btn-default dropdown-toggle" ID="ddlCivilRegistry" runat="server" AutoPostBack="True"
                    DataTextField="Name" DataValueField="Id" ViewStateMode="Enabled" EnableViewState="true">
                </asp:DropDownList>
               <br />
                <br />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCivilRegistry"
                    CssClass="text-danger" ErrorMessage="الرجاء تحديد السجل المدني " />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-10">
                <asp:Button ID="btnEdit" runat="server" Text="تعديل" CssClass="btn btn-success" OnClick="btnEdit_Click" />
            </div>
        </div>
        <div class="form-group">
            <div class="alert warning" visible="false" id="lblNoData" runat="server" style="height: 60px; padding: 0px; text-align: center">
                <strong>
                    <h3>
                        <asp:Label ID="lblNoData1" runat="server" Text="لا يوجد بيانات حتى الآن"></asp:Label>
                    </h3>
                </strong>
            </div>
        </div>


    </div>

</asp:Content>
