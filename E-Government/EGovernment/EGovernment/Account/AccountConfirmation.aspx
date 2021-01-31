<%@ Page Title="تفعيل حساب" Language="C#" MasterPageFile="~/SiteAdministration.Master" AutoEventWireup="true" CodeBehind="AccountConfirmation.aspx.cs" Inherits="EGovernment.Account.AccountConfirmation" %>

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
        <div class="alert warning" visible="false" id="lblErrorMSG" runat="server" style="height: 60px; padding: 0px; text-align: center">
            <h3 style="width: auto;">
                <asp:Label ID="lblErrorMSG1" runat="server" Text=""></asp:Label></h3>
        </div>
        <div class="alert info" role="alert">
            <h4 class="alert-heading">حسابات المواطن</h4>
        </div>

        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">الرقم الوطني للمواطن</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="CitizenNationalNum" CssClass="form-control" placeholder="أدخل الرقم الوطني للمواطن" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CitizenNationalNum"
                    CssClass="text-danger" ErrorMessage="الرجاء إدخال الرقم الوطني" />
            </div>
        </div>
        <div class="form-group" id="Accounts" runat="server" visible="false">
            <asp:Label runat="server" CssClass="col-md-2 control-label">حسابات المواطن</asp:Label>
            <div class="col-md-10 ">
                <asp:DropDownList CssClass="btn btn-default dropdown-toggle" ID="ddlAccounts" runat="server" AutoPostBack="True"
                    ViewStateMode="Enabled" EnableViewState="true"
                    OnSelectedIndexChanged="ddlAccounts_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlAccounts"
                    CssClass="text-danger" ErrorMessage="الرجاء تحديد حساب المواطن" />
            </div>
        </div>
        <br />
        <br />
        <br />
        <p>
            <div class="btn-group" role="group" aria-label="Basic example">
                &nbsp;<asp:Button ID="btnSearch" runat="server" Text="بحث" CssClass="btn btn-info" OnClick="btnSearch_Click" Width="100px" />
                &nbsp;<asp:Button ID="btnActive" runat="server" Text="تفعيل" CssClass="btn btn-success" Visible="false" OnClick="btnActive_Click" Width="100px" />
                &nbsp;<asp:Button ID="btnDisActive" runat="server" Text="إلغاء التفعيل" CssClass="btn btn-danger" Visible="false" OnClick="btnDisActive_Click" Width="100px" />

            </div>
        </p>
    </div>

</asp:Content>
