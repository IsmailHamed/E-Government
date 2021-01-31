<%@ Page Title="تسجيل ولادة" Language="C#" MasterPageFile="~/SiteAdministration.Master" AutoEventWireup="true" CodeBehind="BirthDocument.aspx.cs" Inherits="EGovernment.Administration.Transactions.Birth" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        div.ex1 {
            float: right;
            font-family: 'Traditional Arabic';
            font-size: x-large;
        }

        div.ex2 {
            /*clear: both;
            float: right;*/
            font-family: 'Traditional Arabic';
            font-size: large;
        }

        .ErrorMessage {
            color: Red;
        }

        td {
            font-size: large;
        }
    </style>
    <p>
        <div class="alert">
            <strong>
                <h3 style="width: auto;">تسجيل ولادة</h3>
            </strong>
        </div>
    </p>

    <p>
        <div class="alert warning" visible="false" id="lblErrorMSG" runat="server" style="height: 60px; padding: 0px; text-align: center">
            <strong>
                <h3 style="width: auto;">
                    <asp:Label ID="lblErrorMSG1" runat="server" Text=""></asp:Label></h3>
            </strong>
        </div>
    </p>
    <p>
        <table>
            <tr>
                <td style="text-align: left; font-weight: bold">اسم المولود: </td>
                <td>
                    <asp:TextBox ID="ChildName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ChildName"></asp:RequiredFieldValidator>

                </td>
            </tr>

            <tr>
                <td style="text-align: left; font-weight: bold">جنس المولود: </td>
                <td>
                    <input runat="server" id="male" type="radio" name="gender" value="male" checked>
                    ذكر<br>
                    <input runat="server" type="radio" name="gender" value="female" id="female">
                    أنثى<br>
                </td>
            </tr>

            <tr>
                <td style="text-align: left; font-weight: bold">الرقم الوطني للأب: </td>
                <td>
                    <asp:TextBox ID="FatherNationalNumber" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="FatherNationalNumber"></asp:RequiredFieldValidator>

                </td>
            </tr>

            <tr>
                <td style="text-align: left; font-weight: bold">الرقم الوطني للأم: </td>
                <td>
                    <asp:TextBox ID="MotherNationalNumber" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="MotherNationalNumber"></asp:RequiredFieldValidator>

                </td>
            </tr>


            <tr>
                <td style="text-align: left; font-weight: bold">مدة الحمل: </td>
                <td>
                    <asp:TextBox ID="Pregnancy" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="Pregnancy"></asp:RequiredFieldValidator>

                </td>
            </tr>

            <tr>
                <td style="text-align: left; font-weight: bold">مكان الولادة: </td>
                <td>
                    <input runat="server" id="ss1" type="radio" name="BirthPlace" value="منزل" checked>
                    منزل<br>
                    <input runat="server" id="ss2" type="radio" name="BirthPlace" value="مشفى">
                    مشفى<br>
                    <input runat="server" id="ss3" type="radio" name="BirthPlace" value="عيادة">
                    عيادة<br>
                </td>
            </tr>
            <tr>

                <td></td>
            </tr>
            <tr>
                <td style="text-align: left; font-weight: bold">نوع الولادة : </td>
                <td>
                    <input runat="server" id="ss4" type="radio" name="BirthType" value="طبيعية" checked>
                    طبيعية<br>
                    <input runat="server" id="ss5" type="radio" name="BirthType" value="قيصرية">
                    قيصرية<br>
                    <input runat="server" id="ss6" type="radio" name="BirthType" value="تدخل">
                    تدخل<br>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; font-weight: bold">محل الولادة: </td>
                <td>
                    <asp:TextBox ID="BirthPlace1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="BirthPlace1"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td style="text-align: left; font-weight: bold">تاريخ الولادة: </td>
                <td>
                    <input runat="server" style="font-size: 2.2rem" type="date" id="IncidentDate" name="IncidentDate">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="IncidentDate"></asp:RequiredFieldValidator>

                </td>
            </tr>

            <tr>
                <td style="text-align: left; font-weight: bold">اسم الطبيب: </td>
                <td>
                    <asp:TextBox ID="Doctor" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="text-align: left; font-weight: bold">ملاحظات:&nbsp; </td>
                <td>
                    <asp:TextBox ID="txtNotes" TextMode="multiline" runat="server"></asp:TextBox>
                    &nbsp; </td>
            </tr>
        </table>
        <br />
        &nbsp;<asp:Button ID="btnNext1" runat="server" Text="إدخال" CssClass="btn btn-primary btnNext" OnClick="btnNext_Click" Width="75px" />
    </p>
</asp:Content>
