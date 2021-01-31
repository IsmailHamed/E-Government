<%@ Page Title="تسجيل وفاة" Language="C#" MasterPageFile="~/SiteAdministration.Master" AutoEventWireup="true" CodeBehind="DeathDocument.aspx.cs" Inherits="EGovernment.Administration.Transactions.Death" %>

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
        .auto-style1 {
            width: 176px;
        }
    </style>
    <p>
        <div class="alert">
            <strong>
                <h3 style="width: auto;">تسجيل وفاة</h3>
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
                <td style="text-align: left; font-weight: bold" class="auto-style1">الرقم الوطني للمتوفى: </td>
                <td>
                    <asp:TextBox ID="DeadNationalNumber" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="DeadNationalNumber"></asp:RequiredFieldValidator>

                </td>
            </tr>

          

            <tr>
                <td style="text-align: left; font-weight: bold" class="auto-style1">رقم ضبط الشرطة: </td>
                <td>
                    <asp:TextBox ID="PoliceReportNum" runat="server"></asp:TextBox>

                </td>
            </tr>
            
            <tr>
                <td style="text-align: left; font-weight: bold" class="auto-style1">محل الوفاة: </td>
                <td>
                    <asp:TextBox ID="DeadPlace" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="DeadPlace"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td style="text-align: left; font-weight: bold" class="auto-style1">تاريخ الوفاة: </td>
                <td>
                    <input runat="server" style="font-size: 2.2rem" type="date" id="DeadDate" name="IncidentDate">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="DeadDate"></asp:RequiredFieldValidator>

                </td>
            </tr>

            <tr>
                <td style="text-align: left; font-weight: bold" class="auto-style1">اسم الطبيب الشرعي: </td>
                <td>
                    <asp:TextBox ID="DoctorName" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="text-align: left; font-weight: bold" class="auto-style1">سبب الوفاة:&nbsp; </td>
                <td>
                    <asp:TextBox ID="DeadReason" TextMode="multiline" runat="server"></asp:TextBox>
                    &nbsp; </td>
            </tr>
                <tr>
                <td style="text-align: left; font-weight: bold" class="auto-style1">ملاحظات:&nbsp; </td>
                <td>
                    <asp:TextBox ID="Notes" TextMode="multiline" runat="server"></asp:TextBox>
                    &nbsp; </td>
            </tr>
        </table>
        <br />
        &nbsp;<asp:Button ID="btnNext1" runat="server" Text="إدخال" CssClass="btn btn-primary btnNext" OnClick="btnNext_Click" Width="175px" />
    </p>

</asp:Content>
