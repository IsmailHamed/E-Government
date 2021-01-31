<%@ Page Title="MarriedListByAge" Language="C#" MasterPageFile="~/SiteAdministration.Master" AutoEventWireup="true" CodeBehind="MarriedListByAge.aspx.cs" Inherits="EGovernment.StatisticsReports.MarriedNumByAge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="control-group" style="font-family: 'Traditional Arabic'; font-size: x-large; ">
        <br />
        <p>
            <div class="alert">
                <strong>
                    <h3 style="width: auto;">قائمة بالمتزوجين في عمر معين</h3>
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
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <p>
                    العمر:<br />
                    <input runat="server" type="text" id="txtAge" name="FirstName" placeholder="أدخل العمر هنا">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtAge"></asp:RequiredFieldValidator>

                </p>

                <br />
                <asp:Button ID="btnContinue" runat="server" Text="متابعة" CssClass="btn btn-success" OnClick="btnContinue_Click" Width="75px" />
            </asp:View>
            <asp:View ID="View2" runat="server">

                <p>
                    <div class="alert info">
                        النتائج:
                    </div>
                    الاسم|الكنية|الرقم الوطني<br />
                    <div class="form-horizontal">
                        <asp:ListBox ID="lstValues" CssClass="form-control fontlarge" runat="server" Width="426px"></asp:ListBox>
                    </div>
                    <p>
                    </p>
                    <br />
                    <asp:Button ID="btnPrevious" runat="server" CssClass="btn btn-success" OnClick="btnPrevious_Click" Text="السابق" Width="75px" />
                    <asp:Button ID="btnExport" runat="server" CssClass="btn btn-success" OnClick="btnExport_Click" Text="تصدير" Width="75px" />
                </p>

            </asp:View>
        </asp:MultiView>
    </div>

</asp:Content>
