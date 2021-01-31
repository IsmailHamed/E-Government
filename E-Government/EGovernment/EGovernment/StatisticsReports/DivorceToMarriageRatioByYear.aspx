<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdministration.Master" AutoEventWireup="true" CodeBehind="DivorceToMarriageRatioByYear.aspx.cs" Inherits="EGovernment.StatisticsReports.DivorceToMarriageRatioByYear" %>
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
                    السنة:<br />
                    <input runat="server" type="text" id="txtYear" name="FirstName" placeholder="أدخل السنة هنا">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtYear"></asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtYear" ErrorMessage="السنة غير صحيحة" ForeColor="Red" ValidationExpression="^\d{4}$"></asp:RegularExpressionValidator>

                </p>

                <br />
                <asp:Button ID="btnContinue" runat="server" Text="متابعة" CssClass="btn btn-success" OnClick="btnContinue_Click" Width="75px" />
            </asp:View>
            <asp:View ID="View2" runat="server">

                <p>
                    <div class="alert info">
                        النتائج:
                    </div>
                    النسبة:
                    <asp:Label ID="lblResult" runat="server" Text="0.0%"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnPrevious" runat="server" CssClass="btn btn-success" OnClick="btnPrevious_Click" Text="السابق" Width="75px" />
                    <p>
                    </p>
                </p>

            </asp:View>
        </asp:MultiView>
    </div>

</asp:Content>
