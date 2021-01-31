<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdministration.Master" AutoEventWireup="true" CodeBehind="MDWifeSelection.aspx.cs" Inherits="EGovernment.Output.MDWifeSelection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="control-group" style="font-family: 'Traditional Arabic'; font-size: x-large">
        <br />
        <p>
            <div class="alert">
                <strong>
                    <h3 style="width: auto;">يرجى اختيار أحد الزوجات لاستخراج بيان الزواج المناسب</h3>
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
            الزوجات:<br />
            <asp:ListBox ID="lstWifes" runat="server"></asp:ListBox>
        </p>
        <br />
        <asp:Button ID="btnSelect" runat="server" Text="اختيار" CssClass="btn btn-success" OnClick="btnSelect_Click" Width="75px" />
    </div>

</asp:Content>
