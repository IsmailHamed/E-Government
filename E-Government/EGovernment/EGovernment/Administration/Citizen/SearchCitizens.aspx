<%@ Page Title="بحث عن مواطن" EnableEventValidation="true" Language="C#" MasterPageFile="~/SiteAdministration.Master" AutoEventWireup="true" CodeBehind="SearchCitizens.aspx.cs" Inherits="EGovernment.Administration.Citizen.SearchCitizens" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="control-group" style="font-family: 'Traditional Arabic'; font-size: x-large">
        <br />
        <p>
            <div class="alert">
                <strong>
                    <h3 style="width: auto;">بيانات المواطنين</h3>
                </strong>
            </div>

        </p>

        <p>
            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearch">
                <input type="text" runat="server" id="search" class="searchcss" name="search" placeholder="بحث..">
                <asp:Button ID="btnSearch" runat="server" Visible="true" Width="0px" OnClick="btnSearch_Click" EnableTheming="False" BackColor="White" BorderWidth="0px" />
            </asp:Panel>
        </p>
        <p>
            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="table-condensed">
                <Columns>

                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" Visible="true" />
                    <asp:BoundField DataField="FirstName" HeaderText="الاسم" ReadOnly="True" SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="الكنية" ReadOnly="True" SortExpression="LastName" />
                    <asp:BoundField DataField="FatherNationalNumber" HeaderText="الرقم الوطني للأب" ReadOnly="True" SortExpression="FatherName" />
                    <asp:BoundField DataField="MotherNationalNumber" HeaderText="الرقم الوطني للأم" ReadOnly="True" SortExpression="MotherName" />
                    <asp:BoundField DataField="NationalNumber" HeaderText="الرقم الوطني" ReadOnly="True" SortExpression="NationalNumber" />
                    <asp:BoundField DataField="Birthday" HeaderText="تاريخ الولادة" ReadOnly="True" SortExpression="Birthday" />
                    <asp:BoundField DataField="BirthPlace" HeaderText="مكان الولادة" ReadOnly="True" SortExpression="BirthPlace" />
                    <asp:BoundField DataField="KiedPlace" HeaderText="مكان القيد" ReadOnly="True" SortExpression="KiedPlace" />
                    <asp:BoundField DataField="KiedNumber" HeaderText="رقم القيد" ReadOnly="True" SortExpression="KiedNumber" />
                    <asp:BoundField DataField="Gender" HeaderText="الجنس" ReadOnly="True" SortExpression="Gender" />
                    <asp:BoundField DataField="SocialStatus" HeaderText="الحالة الاجتماعية" ReadOnly="True" SortExpression="SocialStatus" />
                    <asp:BoundField DataField="Religion" HeaderText="الدين" ReadOnly="True" SortExpression="Religion" />
                    <asp:TemplateField  HeaderText="الأوامر">
                        <ItemTemplate>
                            <asp:Button ID="btnEditCitizen" runat="server" CssClass="btn-info" OnClick="btnEditCitizen_Click" Text="تعديل" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <asp:Button ID="btnEditCitizen" runat="server" CssClass="btn-info" OnClick="btnEditCitizen_Click" Text="تعديل" Width="60px" />
                </EmptyDataTemplate>
            </asp:GridView>

        </p>
        <p>
            <div class="alert warning" visible="false" id="lblNoData" runat="server" style="height: 60px; padding: 0px; text-align: center">
                <strong>
                    <h3>
                        <asp:Label ID="lblNoData1" runat="server" Text="لا يوجد بيانات حتى الآن"></asp:Label>
                    </h3>
                </strong>
            </div>
        </p>
    </div>


</asp:Content>
