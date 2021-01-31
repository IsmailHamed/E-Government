<%@ Page Title="بيان طلاق" Language="C#" MasterPageFile="~/SiteAdministration.Master" AutoEventWireup="true" CodeBehind="divorce.aspx.cs" Inherits="EGovernment.Output.divorce" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="float: right; direction: rtl">
        <h1 style="font-size: xx-large">الجمهورية العربية السورية</h1>
        <span style="font-size: x-large">وزارة الداخلية - الشؤون المدنية<br />
        </span>
    </div>
    <br />
    <br />
    <br />
    <br />
    <h2 class="text-center" style="font-size: xx-large">بيان طلاق</h2>
    <p class="text-left" style="font-size: medium; text-align: justify;">
        <span style="font-size: large; font-weight: bold">بيان صادر عن أمانة:</span>
        <asp:Label ID="labelIssuedBy" runat="server" Text="Label"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-size: large; font-weight: bold">في محافظة: </span>
        <asp:Label ID="labelGovernorate" runat="server" Text="Label"></asp:Label>
    </p>
    <table class="nav-justified" border="1">
        <tr>
            <td rowspan="4" class="text-center" style="height: 106px"><span style="font-size: large; font-weight: bold">بيانات الزوج</span></td>
            <td class="text-center" style="height: 40px"><span style="font-size: large; font-weight: bold">الاسم والنسبة
                <br />
                والرقم الوطني</span></td>
            <td class="text-center" style="height: 40px; width: 62px;"><span style="font-size: large; font-weight: bold">اسم الأب
                <br />
                الرقم الوطني</span></td>
            <td class="text-center" style="height: 40px"><span style="font-size: large; font-weight: bold">الدين والمذهب</span></td>
            <td class="text-center" style="height: 40px; width: 30px;"><span style="font-size: large; font-weight: bold">الجنسية</span></td>
            <td class="text-center" style="height: 40px"><span style="font-size: large; font-weight: bold">محل الطلاق</span></td>
            <td class="text-center" style="height: 40px" colspan="2"><span style="font-size: large; font-weight: bold">تاريخ الطلاق</span></td>
            <td colspan="4" class="text-center" style="height: 40px"><span style="font-size: large; font-weight: bold">محل القيد في السجل المدني</span></td>
        </tr>
        <tr>
            <td style="height: 20px">
                <asp:Label ID="labelFirstNameHusbasd" runat="server" Text="Label"></asp:Label>
                &nbsp;</td>
            <td style="height: 20px; width: 62px;">
                <asp:Label ID="labelFatherNameHusband" runat="server" Text="Label"></asp:Label>

            </td>
            <td rowspan="3" style="height: 20px">
                <asp:Label ID="labelReligionHusband" runat="server" Text="Label"></asp:Label>

            </td>
            <td rowspan="3" style="height: 64px; width: 30px;">
                <asp:Label ID="labelNationalityHusband" runat="server" Text="سوري"></asp:Label>

            </td>
            <td rowspan="6" style="height: 64px">
                <asp:Label ID="lblHusbandDivorcePlace" runat="server" Text="Label"></asp:Label>
            </td>
            <td rowspan="6" style="height: 64px" colspan="2">
                <asp:Label ID="lblHusbandDivorceDate" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="text-center" style="height: 20px"><span style="font-size: large; font-weight: bold">الأمانة</span></td>
            <td class="text-center" style="height: 20px"><span style="font-size: large; font-weight: bold">محل القيد</span></td>
            <td class="text-center" style="height: 20px"><span style="font-size: large; font-weight: bold">رقم القيد</span></td>
            <td class="text-center" style="height: 20px"><span style="font-size: large; font-weight: bold">متسلسل الإسم</span></td>
        </tr>
        <tr>
            <td style="height: 20px">
                <asp:Label ID="Label60" runat="server" Text="Label"></asp:Label>

            </td>
            <td rowspan="2" style="height: 42px; width: 62px;">
                <asp:Label ID="labelIdFatherHusband" runat="server" Text="Label"></asp:Label>

            </td>
           
            <td rowspan="2" style="height: 42px">
                <asp:Label ID="labelAlamanaHusband" runat="server" Text="Label"></asp:Label>

            </td>
            <td rowspan="2" style="height: 42px">
                <asp:Label ID="labelPlaceEntryHusband" runat="server" Text="Label"></asp:Label>

            </td>
            <td rowspan="2" style="height: 42px">
                <asp:Label ID="labelRegistrationNumberHusbans" runat="server" Text="Label"></asp:Label>

            </td>
            <td rowspan="2" style="height: 42px">
                <asp:Label ID="lblHusbandId" runat="server" Text="Label"></asp:Label>

            </td>
        </tr>
        <tr>
            <td style="height: 20px">
                <asp:Label ID="labelIdHusband" runat="server" Text="Label"></asp:Label>

            </td>
        </tr>
        <tr>
            <td rowspan="3" class="text-center" style="height: 64px"><span style="font-size: large; font-weight: bold">بيانات الزوجة&nbsp; في آخر<br />
                &nbsp;مسكن سجلت فيه</span></td>
            <td style="height: 20px">
                <asp:Label ID="labelFirstNameWife" runat="server" Text="Label"></asp:Label>

            </td>
            <td style="height: 20px; width: 62px;">
                <asp:Label ID="labelFatherNameWife" runat="server" Text="Label"></asp:Label>

            </td>
            <td rowspan="3" style="height: 20px">
                <asp:Label ID="labelReligionWife" runat="server" Text="Label"></asp:Label>

            </td>
            <td rowspan="3" style="height: 64px; width: 30px;">
                <asp:Label ID="labelNationalityWife" runat="server" Text="سورية"></asp:Label>

            </td>
          
            <td rowspan="3" style="height: 64px">
                <asp:Label ID="labelAlmanWife" runat="server" Text="Label"></asp:Label>

            </td>
            <td rowspan="3" style="height: 64px">
                <asp:Label ID="labelPlaceEntryWife" runat="server" Text="Label" style="direction: ltr"></asp:Label>

            </td>
            <td rowspan="3" style="height: 64px">
                <asp:Label ID="labelRegistrationNumberWife" runat="server" Text="Label"></asp:Label>

            </td>
            <td rowspan="3" style="height: 64px">
                <asp:Label ID="lblWifeId" runat="server" Text="Label"></asp:Label>

            </td>
        </tr>

        <tr>
            <td style="height: 20px">
                <asp:Label ID="labelLastNameWife" runat="server" Text="Label"></asp:Label>

            </td>
            <td rowspan="2" style="height: 42px; direction: rtl; width: 62px;">
                <asp:Label ID="labelIdFatherWife" runat="server" Text="Label"></asp:Label>

            </td>
           
        </tr>

        <tr>
            <td style="height: 20px">
                <asp:Label ID="labelIdWife" runat="server" Text="Label"></asp:Label>

            </td>
        </tr>
        <tr>

            <td colspan="8" rowspan="2" style="height: 42px"><span style="font-size: large; font-weight: bold">ملاحظات:&nbsp;</span><asp:Label ID="labelNotes" runat="server" Text="Label"></asp:Label>

            </td>
            <td class="text-center" style="height: 42px" colspan="2"><span style="font-size: large; font-weight: bold">اسم السلطة</span></td>
            <td class="text-center" style="height: 22px"><span style="font-size: large; font-weight: bold">رقم الوثيقة</span></td>
            <td class="text-center" style="height: 22px"><span style="font-size: large; font-weight: bold">تاريخ الوثيقة</span></td>
        </tr>
        <tr>
            <td class="text-center" style="height: 42px" colspan="2">
                <asp:Label ID="lblReference" runat="server" Text="Label"></asp:Label>

            </td>
            <td class="text-center" style="height: 22px">
                <asp:Label ID="labelDocumentNumber" runat="server" Text="Label"></asp:Label>

            </td>
            <td class="text-center" style="height: 22px; direction: ltr;">
                <asp:Label ID="DateDocument" runat="server" Text="Label"></asp:Label>

            </td>
        </tr>

    </table>

    <p>
        إلى أمين السجل المدني في :<asp:Label ID="labelIssuedBy1" runat="server" Text="Label"></asp:Label>

    </p>
    <p>
        &nbsp;تم تسجيل واقعة الطلاق العائدة للمطلقين المبينة أسماءهما ونسبتهما أعلاه وسجلت في سجل واقعات الأمانة:
                                <asp:Label ID="lbl_Amana" runat="server" Text="Label"></asp:Label>

        &nbsp; في محافظة :
                                <asp:Label ID="lbl_Government" runat="server" Text="Label"></asp:Label>

        &nbsp;بتاريخ:<asp:Label ID="lblMarrageDate" runat="server" Text="Label"></asp:Label>

        &nbsp;وبرقم:
                                <asp:Label ID="label_DocumentNumber" runat="server" Text="Label"></asp:Label>

        &nbsp;يرجى الإطلاع وإجراء المقتضى.
    </p>
    <p>
        <span style="font-size: large; font-weight: bold">اسم المراقب:&nbsp;</span><asp:Label ID="labelNameController" runat="server" Text="Label"></asp:Label>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-size: large; font-weight: bold"> أمين السجل المدني في:&nbsp;</span>
        <asp:Label ID="labelRegistrar" runat="server" Text="Label"></asp:Label>

    </p>

</asp:Content>
