<%@ Page Title="إضافة مواطن" Language="C#" MasterPageFile="~/SiteAdministration.Master" AutoEventWireup="true" CodeBehind="AddCitizen.aspx.cs" Inherits="EGovernment.Administration.Citizen.AddCitizen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="control-group" style="font-family: 'Traditional Arabic'; font-size: x-large">
        <br />
        <p>
            <div class="alert">
                <strong>
                    <h3 style="width: auto;">البيانات الشخصية للمواطن</h3>
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
            الاسم:<br />
            <input runat="server" type="text" id="FirstName" name="FirstName" placeholder="أدخل اسم المواطن هنا">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="FirstName"></asp:RequiredFieldValidator>
            <span style="float: left; direction: rtl;">
                <asp:Image ID="Image1" runat="server" Height="171px" Width="196px" /></span>
        </p>

        <p>
            الكنية:<br />
            <input runat="server" type="text" id="LastName" name="LastName" placeholder="أدخل الكنية">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="LastName"></asp:RequiredFieldValidator>
        </p>

        
        <p hidden="hidden">
            الرقم الوطني للأب:<br />
            <input runat="server" type="text" id="FatherNationalNumber" name="FatherName" placeholder="أدخل الرقم الوطني للأب">
            </p>

        <p hidden="hidden">
            الرقم الوطني للأم:<br />
            <input runat="server" type="text" id="MotherNationalNumber" name="MotherName" placeholder="أدخل الرقم الوطني للأم">
        </p>

        <p>
             محل الولادة:<br />
             <input runat="server" type="text" id="BirthPlace" name="BirthPlace" placeholder="أدخل مكان الولادة">
              <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="BirthPlace"></asp:RequiredFieldValidator>
        </p>

        <p>
            تاريخ الولادة:<br />
            <input runat="server" type="date" id="Birthday" name="Birthday">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="Birthday"></asp:RequiredFieldValidator>
        </p>

        <p>
            الرقم الوطني:<br />
            <input runat="server" type="text" id="NationalNumber" name="NationalNumber" placeholder="أدخل الرقم الوطني">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="NationalNumber"></asp:RequiredFieldValidator>
        </p>

        <p>
            مكان القيد:<br />
            <input runat="server" type="text" id="KiedPlace" name="KiedPlace" placeholder="أدخل مكان القيد">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="KiedPlace"></asp:RequiredFieldValidator>
        </p>

        <p>
            رقم القيد:<br />
            <input runat="server" type="text" id="KiedNumber" name="KiedNumber" placeholder="أدخل رقم القيد">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="KiedNumber"></asp:RequiredFieldValidator>
        </p>


        <p>
            الدين:<br />
            <input runat="server" type="text" id="Religion" name="Religion" placeholder="أدخل الدين">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="Religion"></asp:RequiredFieldValidator>
        </p>

        <p>
            الجنس:<br />
            <input runat="server" id="male" type="radio" name="gender" value="male" checked>
            ذكر<br>
            <input runat="server" type="radio" name="gender" value="female" id="female">
            أنثى<br>
        </p>

        <p hidden="hidden">
            الحالة الاجتماعية:<br />
            <input runat="server" id="ss1" type="radio" name="SocialStatus" value="عازب" checked>
            عازب<br>
            <input runat="server" id="ss2" type="radio" name="SocialStatus" value="متأهل">
            متأهل<br>
            <input runat="server" id="ss3" type="radio" name="SocialStatus" value="أرمل">
            أرمل<br>
            <input runat="server" id="ss4" type="radio" name="SocialStatus" value="مطلق">
            مطلق<br>
        </p>

        <p>
            الصورة الشخصية:<br />
            <asp:FileUpload ID="FileUploadControl" runat="server" Style="font-family: 'Traditional Arabic'; font-size: large; " CssClass="btn-default" />

        </p>
        <br />
        <br />
        <p>
            &nbsp;<asp:Button ID="btnAdd" runat="server" Text="إدخال" CssClass="btn-success" OnClick="btnAdd_Click"/>
        </p>
    </div>
</asp:Content>
