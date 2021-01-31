<%@ Page Title="بحث عن موظف" EnableEventValidation="true" Language="C#" MasterPageFile="~/SiteAdministration.Master" AutoEventWireup="true" CodeBehind="SearchEmployee.aspx.cs" Inherits="EGovernment.Administration.Employee.SearchEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="control-group" style="font-family: 'Traditional Arabic'; font-size: x-large">
        <br />
        <p>
            <div class="alert">
                <strong>
                    <h3 style="width: auto;">بيانات الموظفين</h3>
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
                   <asp:BoundField DataField="FirstName" HeaderText="الاسم" ReadOnly="True" SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="الكنية" ReadOnly="True" SortExpression="LastName" />
                    <asp:BoundField DataField="NationalNumber" HeaderText="الرقم الوطني" ReadOnly="True" SortExpression="NationalNumber" />
                    <asp:BoundField DataField="Phone" HeaderText="رقم الهاتف" ReadOnly="True" SortExpression="Phone" />
                    <asp:BoundField DataField="Address" HeaderText="العنوان" ReadOnly="True" SortExpression="Address" />
                    <asp:BoundField DataField="Specialization" HeaderText="الاختصاص" ReadOnly="True" SortExpression="Specialization" />
                    <asp:BoundField DataField="S_Date" HeaderText="تاريخ البدء" ReadOnly="True" SortExpression="S_Date" />
                    <asp:BoundField DataField="E_Date" HeaderText="تاريخ الانتهاء" ReadOnly="True" SortExpression="E_Date" />
                    <asp:BoundField DataField="Rank" HeaderText="الرتبة" ReadOnly="True" SortExpression="Rank" />
                    <asp:BoundField DataField="CivilAffairs" HeaderText="الشؤون المدنية" ReadOnly="True" SortExpression="CivilAffairs" />
                    <asp:BoundField DataField="CivilRegistry" HeaderText="السجل المدني" ReadOnly="True" SortExpression="CivilRegistry" />
                    <asp:BoundField DataField="Role" HeaderText="عنوان الصلاحيات" ReadOnly="True" SortExpression="Role" />
                    <asp:BoundField DataField="IsWorking" HeaderText="الحالة" ReadOnly="True" SortExpression="IsWorking" />
                    <asp:TemplateField HeaderText="الأوامر">
                        <ItemTemplate>
                            <asp:Button ID="btnEditEmployee" runat="server" CssClass="btn-info" OnClick="btnEditEmployee_Click" Text="تعديل" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <asp:Button ID="btnEditEmployee" runat="server" CssClass="btn-info" OnClick="btnEditEmployee_Click" Text="تعديل" Width="60px" />
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
