<%@ Page Title="تسجيل عقد الزواج" Language="C#" MasterPageFile="~/SiteAdministration.Master" AutoEventWireup="true" CodeBehind="Marriagedocument.aspx.cs" Inherits="EGovernment.Administration.Transactions.Marriagedocument" %>


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

        table {
            border-collapse: collapse;
        }

        td {
            font-size: large;
            padding-top: .5em;
            padding-bottom: .5em;
        }
    </style>
    <p>
        <div class="alert">
            <strong>
                <h3 style="width: auto;">تسجيل واقعة الزواج</h3>
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
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">

            <asp:View ID="vwHusbend" runat="server">
                <p class="alert info" style="font-size: large">بيانات الزوج</p>
                <table>
                    <tr>
                        <td style="text-align: left; font-weight: bold">الرقم الوطني:&nbsp;</td>
                        <td>
                            <asp:TextBox ID="HusbandNationalNum" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="HusbandNationalNum"></asp:RequiredFieldValidator>

                            &nbsp; </td>
                    </tr>
                </table>
                <br />
                &nbsp;<asp:Button ID="btnNext1" runat="server" Text="التالي" CssClass="btn btn-primary btnNext" OnClick="btnNext_Click" Width="75px" />

            </asp:View>
            <asp:View ID="vwWife" runat="server">
                <p class="alert info" style="font-size: large"7>بيانات الزوجة</p>
                <table>
                    <tr>
                        <td style="text-align: left; font-weight: bold">الرقم الوطني:&nbsp;</td>
                        <td>
                            <asp:TextBox ID="WifeNationalNum" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="WifeNationalNum"></asp:RequiredFieldValidator>

                            &nbsp; </td>
                    </tr>
                </table>
                <br />
                &nbsp;<asp:Button ID="btnPrevious1" runat="server" Text="السابق" Visible="true" CssClass="btn btn-primary btnPrevious" OnClick="btnPrevious_Click" Width="75px" />
                &nbsp;<asp:Button ID="btnNext2" runat="server" Text="التالي" Visible="true" CssClass="btn btn-primary btnNext" OnClick="btnNext2_Click" Width="75px" />
            </asp:View>
            <asp:View ID="vwContract" runat="server">
                <table>

                    <tr>
                        <td style="text-align: left; font-weight: bold">تاريخ حدوث الواقعة:&nbsp; </td>
                        <td>
                            <input runat="server" style="font-size: 2.2rem" type="date" id="IncidentDate" name="IncidentDate">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="IncidentDate"></asp:RequiredFieldValidator>

                            &nbsp; </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; font-weight: bold">رقم رخصة الزواج:&nbsp; </td>
                        <td>
                            <asp:TextBox ID="MarriageLicenseNumber" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="MarriageLicenseNumber"></asp:RequiredFieldValidator>
                            &nbsp; </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; font-weight: bold">تاريخ رخصة الزواج:&nbsp; </td>
                        <td>
                            <input runat="server" style="font-size: 2.2rem" type="date" id="MarriageLicenseDate" name="MarriageLicenseDate">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="MarriageLicenseDate"></asp:RequiredFieldValidator>

                            &nbsp; </td>
                    </tr>
                    <tr>

                        <td style="text-align: left; font-weight: bold">المعجل:&nbsp; </td>
                        <td>
                            <asp:TextBox ID="PreMoney" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="PreMoney"></asp:RequiredFieldValidator>
                            &nbsp; </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; font-weight: bold">المؤجل:&nbsp; </td>
                        <td>
                            <asp:TextBox ID="PostMoney" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="PostMoney"></asp:RequiredFieldValidator>
                            &nbsp; </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; font-weight: bold">
                            <p>
                                حالة المهر:&nbsp;<br />

                            </p>
                            &nbsp; </td>
                        <td>
                            <input runat="server" id="ss1" type="radio" name="MoneyStatus" value="مقبوض" checked>
                            مقبوض<br>
                            <input runat="server" id="ss2" type="radio" name="MoneyStatus" value="غير مقبوض">
                            غير مقبوض<br />
                            &nbsp; </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; font-weight: bold">الرقم الوطني للشاهد الأول:&nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtFirstWitness" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtFirstWitness"></asp:RequiredFieldValidator>

                            &nbsp; </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; font-weight: bold">الرقم الوطني للشاهد الثاني:&nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtSecondWitness" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSecondWitness"></asp:RequiredFieldValidator>

                            &nbsp; </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; font-weight: bold">السلطة التي أجازت العقد:&nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtAuthorityAuthorizedContract" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtAuthorityAuthorizedContract"></asp:RequiredFieldValidator>

                            &nbsp; </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; font-weight: bold">رقم الوثيقة:&nbsp; </td>
                        <td>
                            <asp:TextBox ID="txtDocumentNumber" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtDocumentNumber"></asp:RequiredFieldValidator>
                            &nbsp; </td>
                    </tr>

                    <tr>
                        <td style="text-align: left; font-weight: bold">ملاحظات:&nbsp; </td>
                        <td>
                            <asp:TextBox ID="txtNotes" TextMode="multiline" runat="server"></asp:TextBox>
                            &nbsp; </td>
                    </tr>
                </table>
                <br />
                &nbsp;<asp:Button ID="btnPrevious2" runat="server" Text="السابق" CssClass="btn btn-primary btnPrevious" OnClick="btnPrevious2_Click" Width="75px" />
                &nbsp;<asp:Button ID="btnAdd" runat="server" Text="إدخال" CssClass="btn btn-success" OnClick="btnAdd_Click" Width="75px" />
            </asp:View>
        </asp:MultiView>
    </p>
</asp:Content>
