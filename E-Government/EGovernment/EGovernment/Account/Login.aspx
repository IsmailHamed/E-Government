<%@ Page Title="تسجيل دخول" Language="C#" MasterPageFile="~/SiteAdministration.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EGovernment.Account.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .control-label {
            float: right;
        }

        #ex {
            padding-top: 100px;
        }
    </style>

    <div id="ex" class="container">
        <div class="row vertical-offset-100">
            <div class="col-md-4 col-md-offset-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title"><strong>تسجيل دخول</strong></h3>
                    </div>
                    <div class="panel-body">
                        <form accept-charset="UTF-8" role="form">
                            <fieldset>
                                <div class="form-group">
                                    <input class="form-control" placeholder="اسم المستخدم" name="txtUserName" type="text" runat="server"
                                        id="txtUserName">
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtuserName" ID="rfvUserName"
                                        CssClass="text-danger" ErrorMessage="الرجاء إدخال اسم المستخدم" />
                                    <br />
                                </div>
                                <div class="form-group">
                                    <input class="form-control" placeholder="كلمة المرور" name="txtpassword" type="password" value=""
                                        runat="server" id="txtPassword">
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" CssClass="text-danger"
                                        ID="rfvPassWord"
                                        ErrorMessage="الرجاء إدخال كلمة المرور" /><br />

                                </div>
                                <asp:Button Text="تسجيل دخول" CssClass="btn btn-success" runat="server" OnClick="btnLogIn_Click" Width="280px" />
                            </fieldset>

                            <p>
                                <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">إنشاء حساب جديد</asp:HyperLink>
                            </p>
                            <hr />
                            <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                                <p class="text-danger">
                                    <asp:Literal runat="server" ID="FailureText" />
                                </p>
                            </asp:PlaceHolder>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
