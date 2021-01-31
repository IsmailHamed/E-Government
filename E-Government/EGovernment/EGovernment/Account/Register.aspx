<%@ Page Title="تسجيل" Language="C#" MasterPageFile="~/SiteAdministration.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="EGovernment.Account.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .control-label {
            float: right;
        }
    </style>

    <h2>تسجيل</h2>
    <div class="form-horizontal">
        <h4>إنشاء حساب جديد</h4>
        <hr />
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>

        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">الرقم الوطني</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtNationalNumber" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNationalNumber"
                    CssClass="text-danger" ErrorMessage="الرجاء إدخال الرقم الوطني" />

            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">اسم المستخدم</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName" ID="rfvUserName"
                    CssClass="text-danger" ErrorMessage="الرجاء إدخال اسم المستخدم" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">كلمة المرور</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="الرجاء إدخال كلمة مرور" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">تأكيد كلمة المرور</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="الرجاء تأكيد كلمة المرور" />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="كلمة المرور غير متطابقة" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="تسجيل" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
