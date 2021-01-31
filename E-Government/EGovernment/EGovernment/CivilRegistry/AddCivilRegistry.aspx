<%@ Page Title="إضافة سجل مدني" Language="C#" MasterPageFile="~/SiteAdministration.Master" AutoEventWireup="true" CodeBehind="AddCivilRegistry.aspx.cs" Inherits="EGovernment.CivilRegistry.AddCivilRegistry" %>

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
            <asp:Label runat="server" CssClass="col-md-2 control-label">الإسم</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtName" CssClass="form-control" placeholder="أدخل اسم السجل المدني" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName"
                    CssClass="text-danger" ErrorMessage="الرجاء إدخال اسم السجل المدني" />
                <asp:TextBox ID="txtCivilRegistry" runat="server" Visible="False"></asp:TextBox>

            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">المنطقة</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtArea" CssClass="form-control" placeholder="أدخل اسم المنطقة" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtArea"
                    CssClass="text-danger" ErrorMessage="الرجاء إدخال اسم المنطقة" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">الشؤون المدنية</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList CssClass="btn btn-default dropdown-toggle" ID="ddlCivilAffairs" runat="server" DataSourceID="EntityDataSource" DataTextField="Name" DataValueField="Id"
                   >
                </asp:DropDownList>
                <asp:EntityDataSource ID="EntityDataSource" runat="server" ConnectionString="name=EGovernmentEntities" DefaultContainerName="EGovernmentEntities" EnableFlattening="False" EntitySetName="tblCivilAffairs" EntityTypeFilter="tblCivilAffair">
                </asp:EntityDataSource>
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-10">
                <asp:Button ID="btnAdd" runat="server" Text="إدخال" CssClass="btn btn-success" OnClick="btnAdd_Click" Width="100px" />
            </div>
        </div>

    </div>

</asp:Content>
