<%@ Page Title="بيان ولادة" Language="C#" MasterPageFile="~/SiteAdministration.Master" AutoEventWireup="true" CodeBehind="Birth.aspx.cs" Inherits="EGovernment.Output.Birth" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="float: right; direction: rtl">
        <h1 runat="server" style="font-size: xx-large">الجمهورية العربية السورية</h1>
        <span runat="server" style="font-size: x-large">وزارة الداخلية - الشؤون المدنية<br />
        </span>
    </div>
    <br />
    <br />
    <br />
    <br />
    <h2 runat="server" class="text-center" style="font-size: xx-large">بيان ولادة</h2>
    <p runat="server" class="text-center" style="font-size: medium; text-align: justify;">
        <span style="font-size: large; font-weight: bold">بيان صادر عن أمانة:</span>
        <asp:Label ID="labelIssuedBy" runat="server" Text="Label"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="font-size: large; font-weight: bold">في محافظة:</span>
        <asp:Label ID="labelGovernorate" runat="server" Text="Label"></asp:Label>
    </p>
    <table class="nav-justified" border="1">
        <tr>
            <td runat="server" class="text-center" style="height: 40px; font-weight: bold" rowspan="2">اسم المولود ونسبته<br />
                والرقم الوطني</td>
            <td class="text-center" style="height: 40px; font-weight: bold" rowspan="2">اسم الأب
                <br />
                الرقم الوطني</td>
            <td class="text-center" style="height: 40px; font-weight: bold" rowspan="2">اسم الأم
                <br />
                الرقم الوطني</td>
            <td class="text-center" style="height: 40px; font-weight: bold" rowspan="2">محل&nbsp;
                الولادة</td>
            <td class="text-center" style="height: 40px; font-weight: bold" rowspan="2">تاريخ الولادة</td>
            <td class="text-center" style="height: 40px; font-weight: bold" rowspan="2">الجنس</td>
            <td colspan="4" class="text-center" style="height: 40px"><strong>محل القيد في السجل المدني</strong></td>
        </tr>
        <tr>
            <td class="text-center" style="height: 40px"><strong>الأمانة</strong></td>
            <td class="text-center" style="height: 40px"><strong>محل القيد</strong></td>
            <td class="text-center" style="height: 40px; font-weight: 700;">رقم القيد</td>
            <td class="text-center" style="height: 40px; font-weight: 700;">متسلسل الإسم</td>
        </tr>
        <tr>
            <td style="height: 20px">&nbsp;<asp:Label ID="labelFirstNameHusbasd" runat="server" Text="Label"></asp:Label>

            </td>
            <td style="height: 20px">
                <asp:Label ID="labelFatherNameHusband" runat="server" Text="Label"></asp:Label>

            </td>
            <td style="height: 20px">
                <asp:Label ID="labelMotherNameHusband" runat="server" Text="Label"></asp:Label>

            </td>
            <td rowspan="3">
                <asp:Label ID="labelPlaceBirthHusband" runat="server" Text="Label"></asp:Label>

            </td>
            <td rowspan="3">
                <asp:Label ID="Birthday" runat="server" Text="Label"></asp:Label>

            </td>
            <td rowspan="3" style="height: 71px">
                <asp:Label ID="Gender" runat="server" Text="Label"></asp:Label>

            </td>
            <td class="text-center" rowspan="3">
                <asp:Label ID="labelAlamanaHusband" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="text-center" rowspan="3">
                <asp:Label ID="labelPlaceEntryHusband" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="text-center" rowspan="3">
                <asp:Label ID="labelRegistrationNumberHusbans" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="text-center" rowspan="3">
                <asp:Label ID="lblHusbandId" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 20px">
                <asp:Label ID="labelLastNameHusband" runat="server" Text="Label"></asp:Label>

            </td>
            <td rowspan="2" style="height: 48px">
                <asp:Label ID="labelIdFatherHusband" runat="server" Text="Label"></asp:Label>

            </td>
            <td rowspan="2" style="height: 48px">
                <asp:Label ID="labelIdMotherHusband" runat="server" Text="Label"></asp:Label>

            </td>
        </tr>
        <tr>
            <td style="height: 25px">
                <asp:Label ID="labelIdHusband" runat="server" Text="Label"></asp:Label>

            </td>
        </tr>
        <tr>
            <td style="height: 43px" colspan="10"><strong>ملاحظات:</strong>&nbsp;<asp:Label ID="labelNotes" runat="server" Text="Label"></asp:Label>
            </td>

        </tr>

    </table>

    <p>
        إلى أمين السجل المدني في :<asp:Label ID="labelIssuedBy1" runat="server" Text="Label"></asp:Label>

    </p>
    <p>
        &nbsp;تم تسجيل واقعة الولادة في سجل واقعات الأمانة:
        <asp:Label ID="lbl_Amana" runat="server" Text="Label"></asp:Label>

        &nbsp; في محافظة :
                                <asp:Label ID="lbl_Government" runat="server" Text="Label"></asp:Label>

        &nbsp;بتاريخ:<asp:Label ID="lblMarrageDate" runat="server" Text="Label"></asp:Label>

        &nbsp;وبرقم:
                                <asp:Label ID="label_DocumentNumber" runat="server" Text="Label"></asp:Label>

        &nbsp;يرجى الإطلاع وإجراء المقتضى.
    </p>
    <p>
        <strong>اسم المراقب:</strong><asp:Label ID="labelNameController" runat="server" Text="Label"></asp:Label>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
     <strong>أمين السجل المدني:</strong>
        <asp:Label ID="labelRegistrar" runat="server" Text="Label"></asp:Label>

    </p>
</asp:Content>
