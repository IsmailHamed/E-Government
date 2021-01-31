<%@ Page Title="إضافةأدوار" Language="C#" MasterPageFile="~/SiteAdministration.Master" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="EGovernment.Administration.Roles" %>

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
            <asp:Label runat="server" CssClass="col-md-2 control-label">اسم الدور</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtRole" CssClass="form-control" placeholder="أدخل اسم الدور" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtRole"
                    CssClass="text-danger" ErrorMessage="الرجاء إدخال اسم الدور" />
                <asp:TextBox ID="txtRoleId" runat="server" Visible="False"></asp:TextBox>

            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">الصلاحيات</asp:Label>
            <div class="col-md-10">
                <asp:CheckBoxList ID="chklPermission" runat="server">
                    <asp:ListItem Value="إضافة مواطن">&nbsp;&nbsp;إضافة مواطن</asp:ListItem>
                    <asp:ListItem Value="بحث عن مواطن">&nbsp;&nbsp;بحث عن مواطن</asp:ListItem>
                    <asp:ListItem Value="تعديل مواطن">&nbsp;&nbsp;تعديل مواطن</asp:ListItem>
                    <asp:ListItem Value="تسجيل واقعة الزواج">&nbsp;&nbsp;تسجيل واقعة الزواج</asp:ListItem>
                    <asp:ListItem Value="تسجيل واقعة طلاق">&nbsp;&nbsp;تسجيل واقعة طلاق</asp:ListItem>
                    <asp:ListItem Value="تسجيل بيان ولادة">&nbsp;&nbsp;تسجيل بيان ولادة</asp:ListItem>
                    <asp:ListItem Value="تسجيل بيان وفاة">&nbsp;&nbsp;تسجيل بيان وفاة</asp:ListItem>
                    <asp:ListItem Value="إصدار بيان زواج">&nbsp;&nbsp;إصدار بيان زواج</asp:ListItem>
                    <asp:ListItem Value="إصدار بيان طلاق">&nbsp;&nbsp;إصدار بيان طلاق</asp:ListItem>
                    <asp:ListItem Value="إصدار بيان ولادة">&nbsp;&nbsp;إصدار بيان ولادة</asp:ListItem>
                    <asp:ListItem Value="إصدار بيان وفاة">&nbsp;&nbsp;إصدار بيان وفاة</asp:ListItem>
                    <asp:ListItem Value="إخراج قيد">&nbsp;&nbsp;إخراج قيد</asp:ListItem>
                    <asp:ListItem Value="إضافة موظف">&nbsp;&nbsp;إضافة موظف</asp:ListItem>
                    <asp:ListItem Value="بحث عن موظف">&nbsp;&nbsp;بحث عن موظف</asp:ListItem>
                    <asp:ListItem Value="تعديل بيانات موظف">&nbsp;&nbsp;تعديل بيانات موظف</asp:ListItem>
                    <asp:ListItem Value="إضافة سجل مدني">&nbsp;&nbsp;إضافة سجل مدني</asp:ListItem>
                    <asp:ListItem Value="تعديل سجل مدني">&nbsp;&nbsp;تعديل سجل مدني</asp:ListItem>
                    <asp:ListItem Value="بحث عن سجل مدني">&nbsp;&nbsp;بحث عن سجل مدني</asp:ListItem>
                    <asp:ListItem Value="التقارير الإحصائية">&nbsp;&nbsp;التقارير الإحصائية</asp:ListItem>
                    <asp:ListItem Value="تفعيل حساب مواطن">&nbsp;&nbsp;تفعيل حساب مواطن</asp:ListItem>

                </asp:CheckBoxList>

            </div>
        </div>
        <div class="form-group">
            <div class="col-md-10">
                <asp:Button ID="btnAdd" runat="server" Text="حفظ" CssClass="btn btn-success  btn-lg" OnClick="btnAdd_Click" />
            </div>
        </div>
    </div>

</asp:Content>
