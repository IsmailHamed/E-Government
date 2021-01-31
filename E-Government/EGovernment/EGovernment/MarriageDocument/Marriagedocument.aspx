<%@ Page Title="بيان زواج" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Marriagedocument.aspx.cs" Inherits="EGovernment.MarriageDocument.Marriagedocument" %>


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
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">

            <asp:View ID="vwHusbend" runat="server">
                <div class="alert">
                    <strong>
                        <h3 style="width: auto;">تسجيل واقعة الزواج</h3>
                    </strong>
                </div>

                <p class="alert info">بيانات الزوج</p>
                <table>
                    <tr>
                        <td style="text-align: left">الرقم الوطني: </td>
                        <td>
                            <asp:TextBox ID="NationalNumber" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="NationalNumber"></asp:RequiredFieldValidator>
                           
                        </td>
                    </tr>
                </table>
                <br />
                &nbsp;<asp:Button ID="btnNext1" runat="server" Text="التالي" CssClass="btn btn-primary btnNext" OnClick="btnNext_Click" Width="75px" />

            </asp:View>
            <asp:View ID="vwWife" runat="server">
                <table>
                    <tr>
                        <td style="text-align: left">الإسم: </td>
                        <td>
                            <asp:TextBox ID="txtFirstNameWife" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtFirstNameWife"></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">النسبة:</td>
                        <td>
                            <asp:TextBox ID="txtLastNameWife" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtLastNameWife"></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">الرقم الوطني: </td>
                        <td>
                            <asp:TextBox ID="txtIdWife" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtIdWife"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtIdWife" Operator="DataTypeCheck" Type="Integer" ErrorMessage="الرجاء إدخال الرقم الوطني"></asp:CompareValidator>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">اسم الأب: </td>
                        <td>
                            <asp:TextBox ID="txtFatherNameWife" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtFatherNameWife"></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">الرقم الوطني: </td>
                        <td>
                            <asp:TextBox ID="txtIdFatherWife" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtIdFatherWife"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="txtIdFatherWife" Operator="DataTypeCheck" Type="Integer" ErrorMessage="الرجاء إدخال الرقم الوطني"></asp:CompareValidator>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">اسم الأم: </td>
                        <td>
                            <asp:TextBox ID="txtMotherNameWife" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMotherNameWife"></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">الرقم الوطني: </td>
                        <td>
                            <asp:TextBox ID="txtIdMotherWife" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtIdMotherWife"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator7" runat="server" ControlToValidate="txtIdMotherWife" Operator="DataTypeCheck" Type="Integer" ErrorMessage="الرجاء إدخال الرقم الوطني"></asp:CompareValidator>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">محل الولادة: </td>
                        <td>
                            <asp:TextBox ID="txtPalceBirthWife" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPalceBirthWife"></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">تاريخ الولادة: </td>
                        <td>
                            <input runat="server" style="font-size: 2.3rem" type="date" id="BirthWife" name="Birthday">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="BirthWife"></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">الدين: </td>
                        <td>
                            <asp:TextBox ID="txtReligionWife" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtReligionWife"></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">الجنسية: </td>
                        <td>
                            <asp:TextBox ID="txtNationalityWife" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNationalityWife"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">الأمانة: </td>
                        <td>
                            <asp:TextBox ID="txtAlmanWife" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtAlmanWife"></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">محل القيد: </td>
                        <td>
                            <asp:TextBox ID="txtPlaceEntryWife" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPlaceEntryWife"></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">رقم القيد: </td>
                        <td>
                            <asp:TextBox ID="txtRegistrationNumberWife" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtRegistrationNumberWife"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <br />
                &nbsp;<asp:Button ID="btnPrevious1" runat="server" Text="السابق" Visible="true" CssClass="btn btn-primary btnPrevious" OnClick="btnPrevious_Click" Width="75px" />
                &nbsp;<asp:Button ID="btnNext2" runat="server" Text="التالي" Visible="true" CssClass="btn btn-primary btnNext" OnClick="btnNext2_Click" Width="75px" />
            </asp:View>
            <asp:View ID="vwContract" runat="server">
                <table>
                    <tr>
                        <td style="text-align: left">بيان صادر عن أمانة : </td>
                        <td>
                            <asp:TextBox ID="txtIssuedBy" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtIssuedBy"></asp:RequiredFieldValidator>
                        </td>
                        <td style="text-align: left">&nbsp;&nbsp;&nbsp;في محافظة : </td>
                        <td>&nbsp;&nbsp;
                            <asp:TextBox ID="txtGovernorate" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtGovernorate"></asp:RequiredFieldValidator>

                            &nbsp;&nbsp;&nbsp;
                        </td>
                        <td style="text-align: left">&nbsp;&nbsp;الرقم الأسري: </td>
                        <td>&nbsp;&nbsp;
                            <asp:TextBox ID="txtFamilyNumber" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtFamilyNumber"></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">تاريخ العقد: </td>
                        <td>
                            <input runat="server" style="font-size: 2.3rem" type="date" id="DateContract" name="Birthday">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="DateContract"></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">السلطة التي أجازت العقد:</td>
                        <td>
                            <asp:TextBox ID="txtAuthorityAuthorizedContract" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtAuthorityAuthorizedContract"></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">رقم الوثيقة: </td>
                        <td>
                            <asp:TextBox ID="txtDocumentNumber" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtDocumentNumber"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">تاريخ الوثيقة: </td>
                        <td>
                            <input runat="server" style="font-size: 2.3rem" type="date" id="DateDocument" name="Birthday">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="DateDocument"></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">ملاحظات: </td>
                        <td>
                            <asp:TextBox ID="txtNotes" TextMode="multiline" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNotes"></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">اسم المراقب: </td>
                        <td>
                            <asp:TextBox ID="txtNameController" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNameController"></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">أمين السجل المدني في: </td>
                        <td>
                            <asp:TextBox ID="txtRegistrarIn" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtRegistrarIn"></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">الإسم: </td>
                        <td>
                            <asp:TextBox ID="txtNameRegistrar" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNameRegistrar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <br />
                &nbsp;<asp:Button ID="btnPrevious2" runat="server" Text="السابق" CssClass="btn btn-primary btnPrevious" OnClick="btnPrevious2_Click" Width="75px" />
                &nbsp;<asp:Button ID="btnAdd" runat="server" Text="إدخال" CssClass="btn btn-success" OnClick="btnAdd_Click" Width="75px" />
            </asp:View>
        </asp:MultiView>
    </p>
</asp:Content>
