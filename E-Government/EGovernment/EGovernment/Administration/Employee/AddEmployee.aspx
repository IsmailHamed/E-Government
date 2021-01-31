<%@ Page Title="إضافة موظف" Language="C#" MasterPageFile="~/SiteAdministration.Master" AutoEventWireup="true" Async="true" CodeBehind="AddEmployee.aspx.cs" Inherits="EGovernment.Administration.Employee.AddEmployee" %>

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


    <div class="alert warning" visible="false" id="lblErrorMSG" runat="server" style="height: 60px; padding: 0px; text-align: center">
        <h3 style="width: auto;">
            <asp:Label ID="lblErrorMSG1" runat="server" Text=""></asp:Label></h3>
    </div>

    <asp:MultiView ID="MultiView" runat="server" ActiveViewIndex="0">

        <asp:View ID="vwEmployee" runat="server">
            <br />
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">الرقم الوطني للموظف</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="EmployeeNationalNum" CssClass="form-control" placeholder="أدخل الرقم الوطني للموظف" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="EmployeeNationalNum"
                        CssClass="text-danger" ErrorMessage="الرجاء إدخال الرقم الوطني" />
                </div>
            </div>

            <br />
            &nbsp;<asp:Button ID="btnNext" runat="server" Text="التالي" CssClass="btn btn-success btnNext" OnClick="btnNext_Click" Width="100px" />
        </asp:View>

        <asp:View ID="vwContract" runat="server">
            <br />
            <div class="form-horizontal">

                <div class="alert info" role="alert">
                    <h4 class="alert-heading">بيانات الموظف</h4>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">الرقم الوطني</asp:Label>
                    <div class="col-md-10">
                        <asp:Label runat="server" CssClass="col-md-2 control-label" ID="labelNationalNum"></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">الإسم</asp:Label>
                    <div class="col-md-10">
                        <asp:Label runat="server" CssClass="col-md-2 control-label" ID="labelFirstName"></asp:Label>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">النسبة</asp:Label>
                    <div class="col-md-10">
                        <asp:Label runat="server" CssClass="col-md-2 control-label" ID="lableLastName"></asp:Label>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">اسم الأب</asp:Label>
                    <div class="col-md-10">
                        <asp:Label runat="server" CssClass="col-md-2 control-label" ID="lableFatherName"></asp:Label>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">اسم الأم</asp:Label>
                    <div class="col-md-10">
                        <asp:Label runat="server" CssClass="col-md-2 control-label" ID="lableMotherName"></asp:Label>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">عنوان السكن</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" placeholder="أدخل عنوان سكن الموظف" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAddress"
                            CssClass="text-danger" ErrorMessage="الرجاء إدخال عنوان الموظف" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">رقم الهاتف</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtPhoneNumber" CssClass="form-control" placeholder="أدخل رقم هاتف الموظف" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPhoneNumber"
                            CssClass="text-danger" ErrorMessage="الرجاء إدخال رقم هاتف الموظف" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">الإختصاص</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtSpecialization" CssClass="form-control" placeholder="أدخل إختصاص للموظف" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtSpecialization"
                            CssClass="text-danger" ErrorMessage="الرجاء إدخال إختصاص الموظف" />
                    </div>
                </div>

                <br />
                <div class="btn-group" role="group" aria-label="Basic example">
                    &nbsp;<asp:Button ID="btnNext1" runat="server" Text="التالي" CssClass="btn btn-success " OnClick="btnNext1_Click" Width="100px" />
                    &nbsp;<asp:Button ID="btnPrevious" runat="server" Text="السابق" CssClass="btn btn-info " OnClick="btnPrevious_Click" Width="100px" />
                </div>
            </div>

        </asp:View>
        <asp:View ID="vw" runat="server">
            <div class="form-horizontal">
                <br />
                <div class="alert info" role="alert">
                    <h4 class="alert-heading">بيانات الموظف</h4>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">رتبة الموظف</asp:Label>
                    <div class="col-md-10">
                        <asp:RadioButton ID="rdoIsCivilRegisterer" runat="server" Checked="true" GroupName="Status" AutoPostBack="True" Text="&nbsp;&nbsp;أمين السجل المدني " OnCheckedChanged="rdoIsCivilRegisterer_CheckedChanged" /><br />
                        <asp:RadioButton ID="rdoEmployee" runat="server" GroupName="Status" AutoPostBack="True" Text="&nbsp;&nbsp;موظف عادي " OnCheckedChanged="rdoIsCivilRegisterer_CheckedChanged" /><br />
                        <asp:RadioButton ID="rdoIsController" runat="server" GroupName="Status" AutoPostBack="True" Text="&nbsp;&nbsp;مراقب " OnCheckedChanged="rdoIsCivilRegisterer_CheckedChanged" /><br />
                        <asp:RadioButton ID="rdoManager" runat="server" GroupName="Status" AutoPostBack="True" Text="&nbsp;&nbsp;مدير" OnCheckedChanged="rdoManager_CheckedChanged" /><br />

                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">الشؤون المدنية</asp:Label>
                    <div class="col-md-10 ">
                        <asp:DropDownList CssClass="btn btn-default dropdown-toggle" ID="ddlCivilAffairs" runat="server" AutoPostBack="True"
                            DataTextField="Name" DataValueField="Id" ViewStateMode="Enabled" EnableViewState="true"
                            OnSelectedIndexChanged="ddlCivilAffairs_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCivilAffairs"
                            CssClass="text-danger" ErrorMessage="الرجاء تحديد السؤون المدنية" />
                    </div>
                </div>

                <div class="form-group" id="divCivilRegistry" runat="server">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">السجل المدني</asp:Label>
                    <div class="col-md-10">
                        <asp:DropDownList CssClass="btn btn-default dropdown-toggle" ID="ddlCivilRegistry" runat="server" AutoPostBack="True"  DataTextField="Name" DataValueField="Id" ViewStateMode="Enabled" EnableViewState="true" OnSelectedIndexChanged="ddlCivilAffairs_SelectedIndexChanged"                            >
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCivilRegistry"
                            CssClass="text-danger" ErrorMessage="الرجاء تحديد السجل المدني " />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">الصلاحيات</asp:Label>
                    <div class="col-md-10">
                        <asp:DropDownList CssClass="btn btn-default dropdown-toggle" ID="ddlRole" runat="server" DataTextField="Name" DataValueField="Id">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlRole"
                            CssClass="text-danger" ErrorMessage="الرجاء تحديد الصلاحيات" />
                    </div>
                </div>
                <div class="form-group" id="divStatus" runat="server" visible="false">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">حالة الوظف</asp:Label>
                    <div class="col-md-10">
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked="true" OnCheckedChanged="CheckBox1_CheckedChanged" Text="يعمل" AutoPostBack="True" />
                    </div>
                </div>

                <br />
                <div class="btn-group" role="group" aria-label="Basic example">
                    &nbsp;<asp:Button ID="btnAdd" runat="server" Text="إدخال" CssClass="btn btn-success" OnClick="btnAdd_Click" Width="100px" />
                    &nbsp;<asp:Button ID="btnPrevious1" runat="server" Text="السابق" CssClass="btn btn-info btnPrevious" OnClick="btnPrevious1_Click" Width="100px" />
                </div>
            </div>

        </asp:View>

    </asp:MultiView>


</asp:Content>
