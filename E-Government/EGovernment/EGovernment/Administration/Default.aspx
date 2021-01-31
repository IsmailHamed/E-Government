<%@ Page Title="الرئيسية" Language="C#" MasterPageFile="~/SiteAdministration.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EGovernment.Administration.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .col-md-4 {
            float: right;
        }
    </style>

    <br />
    <div id="myCarousel" class="carousel slide " style="width: 100%; height: 400px; margin: 0 auto" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
            <li data-target="#myCarousel" data-slide-to="3"></li>
            <li data-target="#myCarousel" data-slide-to="4"></li>

        </ol>

        <!-- Wrapper for slides -->
        <div class="carousel-inner">
            <div class="item active">
                <asp:LinkButton runat="server" OnClick="IndividualCivilRegistration_Click">
                <img src="../Images/IndividualCivilRegistration.jpg" style="width: 100%; height: 400px; margin: 0 auto" alt="قيد مدني فردي">
                </asp:LinkButton>
            </div>
            <div class="item">
                <asp:LinkButton runat="server" OnClick="birth_Click">

                <img src="../Images/birth.jpg" style="width: 100%; height: 400px; margin: 0 auto" alt="بيان ولادة">
                </asp:LinkButton>

            </div>

            <div class="item">
                <asp:LinkButton runat="server" OnClick="death_Click">

                <img src="../Images/death.jpg" style="width: 100%; height: 400px; margin: 0 auto" alt="بيان وفاة">
                </asp:LinkButton>
            </div>

            <div class="item">
                <asp:LinkButton runat="server" OnClick="divorce_Click">
                <img src="../Images/divorce.jpg" style="width: 100%; height: 400px; margin: 0 auto" alt="بيان طلاق">
                </asp:LinkButton>
            </div>
            <div class="item">
                <asp:LinkButton runat="server" OnClick="marrage_Click">
                <img src="../Images/marrage.jpg" style="width: 100%;  height: 400px; margin: 0 auto" alt="بيان زواج">
                </asp:LinkButton>
            </div>
        </div>

        <!-- Left and right controls -->
        <a class="left carousel-control" href="#myCarousel" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="right carousel-control" href="#myCarousel" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>


    <div class="row">
        <div class="col-md-4">
            <h2>قيد مدني فردي</h2>
            <p>
                تتضمن بيانات قيد المواطن 
            </p>
            <p>
                <asp:Button ID="IndividualCivilRegistration" class="btn btn-default" Text="متابعة>>" runat="server" OnClick="IndividualCivilRegistration_Click" />
            </p>
        </div>
        <div class="col-md-4">
            <h2>بيان ولادة</h2>
            <p>
                تتضمن بيانات المواطن الرئيسيةو رقم الواقعة وتاريخ الواقعة إضافة الى تاريخ التسجيل
            </p>
            <p>
                <asp:Button ID="birth" class="btn btn-default" Text="متابعة >>" runat="server" OnClick="birth_Click" />
            </p>
        </div>
        <div class="col-md-4">
            <h2>بيان وفاة</h2>
            <p>
                تتضمن بيانات المتوفي ورقمه الوطني ومكان حدوث الوفاة ورقم الواقعة وتاريخ الواقعة وتاريخ التسجيل
            </p>
            <p>
                <asp:Button ID="death" class="btn btn-default" Text="متابعة >>" runat="server" OnClick="death_Click" />
            </p>
        </div>
        <div class="col-md-4">
            <h2>بيان طلاق</h2>
            <p>
                تتضمن بيانات الزوج والزوجة وأرقامهما الوطنية ورقم الواقعة زتاريخ الواقعة وتاريخ التسجيل 
            </p>
            <p>
                <asp:Button ID="divorce" class="btn btn-default" Text="متابعة >>" runat="server" OnClick="divorce_Click" />
            </p>
        </div>
        <div class="col-md-4">
            <h2>بيان زواج</h2>
            <p>
                تتضمن بيانات الزوج ورقمه الوطني وبيانات الزوجة ورقمها الوطني ورقم الواقعة وتاريخ الواقعة وتاريخ تسجيل الواقعة
            <p>
                <asp:Button ID="marrage" class="btn btn-default" Text="متابعة >>" runat="server" OnClick="marrage_Click" />
            </p>
        </div>

    </div>
</asp:Content>
