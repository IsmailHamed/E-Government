<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdministration.Master" AutoEventWireup="true" CodeBehind="MDChildSelection.aspx.cs" Inherits="EGovernment.Output.MDChildSelection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="control-group" style="font-family: 'Traditional Arabic'; font-size: x-large">
        <br />
        <p>
            <div class="alert">
                <strong>
                    <h3 style="width: auto;">يرجى اختيار أحد الأولاد لاستخراج بيان الولادة المناسب</h3>
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
            الأولاد:<br />
            <asp:ListBox ID="lstChildren" runat="server"></asp:ListBox>
        </p>
        <asp:TextBox ID="txtFatherId" runat="server" Visible="False"></asp:TextBox>
        <br />
        <asp:Button ID="btnSelect" runat="server" Text="اختيار" CssClass="btn btn-success" OnClick="btnSelect_Click" Width="75px" />
    </div>
</asp:Content>
