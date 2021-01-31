<%@ Page Title="الرقم الوطني" Language="C#" MasterPageFile="~/SiteAdministration.Master" AutoEventWireup="true" CodeBehind="NationalNumber.aspx.cs" Inherits="EGovernment.Output.NationalNumber" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="control-group" style="font-family: 'Traditional Arabic'; font-size: x-large">
        <br />
        <p>
            <div class="alert">
                <strong>
                    <h3 style="width: auto;">للاستفادة من هذه الخدمة يرجى إدخال الرقم الوطني</h3>
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
            الرقم الوطني:<br />
            <input runat="server" type="text" id="txtNationalNumber" name="FirstName" placeholder="أدخل الرقم الوطني هنا">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNationalNumber"></asp:RequiredFieldValidator>
            <br />
            <asp:CheckBox ID="chkForWhome" runat="server" Checked="true" Text="هذا الرقم يعود لوالد المتوفى" OnCheckedChanged="chkForWhome_CheckedChanged" Visible="False"/>
        </p>

        <br />
        <asp:Button ID="btnContinue" runat="server" Text="متابعة" CssClass="btn btn-success" OnClick="btnContinue_Click" Width="75px" />
    </div>
</asp:Content>
