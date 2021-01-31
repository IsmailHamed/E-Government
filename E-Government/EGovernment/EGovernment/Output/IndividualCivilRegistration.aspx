<%@ Page Title="قيد مدني فردي" Language="C#" MasterPageFile="~/SiteAdministration.Master" AutoEventWireup="true" CodeBehind="IndividualCivilRegistration.aspx.cs" Inherits="EGovernment.Output.IndividualCivilRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="font-family: Arial; font-size: large">
        <div style="float: right; direction: rtl">
            <h1 runat="server" style="font-size: large; font-weight: bold; font-size: xx-large">الجمهورية العربية السورية</h1>
            <span runat="server" style="font-size: large; font-weight: bold; font-size: x-large">وزارة الداخلية - الشؤون المدنية<br />
            </span>
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <h1 runat="server" style="font-size: xx-large; font-weight: bold">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;قيد مدني فردي</h1>
        <br />


        <table style="width: 100%;">
            <tr>
                <td style="width: 260px; text-align: left; font-weight: bold; font-weight: bold; font-size: x-large">بيان صادر عن أمانة:&nbsp;</td>
                <td style="width: 340px">
                    <asp:Label ID="lbl_Amana" runat="server" Text="Label"></asp:Label>
                </td>
                <td style="width: 17px">&nbsp;</td>
                <td style="width: 120px; text-align: left; font-weight: bold; font-weight: bold; font-size: x-large">في محافظة:&nbsp;</td>
                <td>
                    <asp:Label ID="lbl_Government" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="width: 340px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <table style="width: 100%;">
            <tr>
                <td style="width: 130px; text-align: left; font-weight: bold; font-weight: bold;">الاسم:&nbsp;</td>
                <td>
                    <asp:Label ID="lblFirstName" runat="server" Text="Label"></asp:Label></td>
                <td style="width: 17px">&nbsp;</td>
                <td style="width: 120px; text-align: left; font-weight: bold; font-weight: bold">الرقم الوطني:&nbsp;</td>
                <td>
                    <asp:Label ID="lblNationalNumber" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 120px; text-align: left; font-weight: bold; font-weight: bold">النسبة:&nbsp;</td>
                <td>
                    <asp:Label ID="lblLastName" runat="server" Text="Label"></asp:Label></td>
                <td style="width: 17px">&nbsp;</td>
                <td style="width: 120px; text-align: left; font-weight: bold; font-weight: bold">الجنس:&nbsp;</td>
                <td>
                    <asp:Label ID="lblGender" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 120px; text-align: left; font-weight: bold; font-weight: bold">اسم الأب:&nbsp;</td>
                <td>
                    <asp:Label ID="lblFatherName" runat="server" Text="Label"></asp:Label></td>
                <td style="width: 17px">&nbsp;</td>
                <td style="width: 120px; text-align: left; font-weight: bold; font-weight: bold">تاريخ القيد:&nbsp;</td>
                <td>
                    <asp:Label ID="lblKiedDate" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 120px; text-align: left; font-weight: bold; font-weight: bold">اسم ونسبة الأم:&nbsp;</td>
                <td>
                    <asp:Label ID="lblMotherFullName" runat="server" Text="Label"></asp:Label></td>
                <td style="width: 17px">&nbsp;</td>
                <td style="width: 120px; text-align: left; font-weight: bold; font-weight: bold">الوضع العائلي:&nbsp;</td>
                <td>
                    <asp:Label ID="lblSocialStatus" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 120px; text-align: left; font-weight: bold; font-weight: bold">الأمانة:&nbsp;</td>
                <td>
                    <asp:Label ID="lblAmana" runat="server" Text="Label"></asp:Label></td>
                <td style="width: 17px">&nbsp;</td>
                <td style="width: 120px; text-align: left; font-weight: bold; font-weight: bold;">متسلسل الاسم:&nbsp;</td>
                <td>
                    <asp:Label ID="lblNameID" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 120px; text-align: left; font-weight: bold; font-weight: bold">محل ورقم القيد:&nbsp;</td>
                <td>
                    <asp:Label ID="lblKiedPlaceAndNumber" runat="server" Text="Label"></asp:Label></td>
                <td style="width: 17px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 120px; text-align: left; font-weight: bold; font-weight: bold">محل وتاريخ الولادة:&nbsp;</td>
                <td>
                    <asp:Label ID="lblBirthdayPlace" runat="server" Text="Label"></asp:Label>
                </td>
                <td style="width: 17px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 120px; text-align: left; font-weight: bold; font-weight: bold">الدين والمذهب:&nbsp;</td>
                <td>
                    <asp:Label ID="lblRelegion" runat="server" Text="Label"></asp:Label>
                </td>
                <td style="width: 17px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 120px; text-align: left; font-weight: bold; font-weight: bold">ملاحظات:&nbsp;</td>
                <td colspan="4">
                    <asp:Label ID="lblNotes" runat="server" Text="Label"></asp:Label>
                </td>
                <td style="width: 17px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="5">أخرجت هذه البيانات من السجل مدني للمواطنين العرب السوريين وهي مطابقة لبيانات صاحبها في السجل بتاريخ إخراجها في:
                <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 120px; text-align: left; font-weight: bold; font-weight: bold">اسم المراقب:</td>
                <td>
                    <asp:Label ID="lblControllerName" runat="server" Text="Label"></asp:Label></td>
                <td style="width: 17px">&nbsp;</td>
                <td style="width: 150px; text-align: left; font-weight: bold; font-weight: bold">أمين السجل المدني:&nbsp; </td>
                <td>
                    <asp:Label ID="lblCivilRegisterer" runat="server" Text="Label"></asp:Label></td>
            </tr>
        </table>
    </div>
</asp:Content>
