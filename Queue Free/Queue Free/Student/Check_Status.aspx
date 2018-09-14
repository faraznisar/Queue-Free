<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="Check_Status.aspx.cs" Inherits="Queue_Free.Student.Check_Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="jumbotron text-center" style="height:100vh;">
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-8 col-md-push-2">
                        <div class="panel panel-info">
                            <div class="panel-body">
                                <asp:RadioButton Text="Pass" ID="rbPass" GroupName="rbfee" AutoPostBack="true" runat="server"/>
                                <asp:RadioButton Text="Fail" ID="rbFail" GroupName="rbfee" AutoPostBack="true" runat="server" />

                            </div>
                            <asp:TextBox runat="server" ID="txttempId" />
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-6 col-md-push-3">
                                    <div>
                                        <asp:Button Text="Submit" ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
