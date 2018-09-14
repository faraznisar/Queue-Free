<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Update_Student_Details.aspx.cs" Inherits="Queue_Free.Admin.Update_Student_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="jumbotron text-center" style="height:100vh;">
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-4 col-md-push-4">

                        <table class="table table-bordered tablestyle" style="text-align:center ">
                            <tr>
                                <td>Enter Rollno
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="TxtRollno" />
                                </td>
                            </tr>
                            <tr>

                                <td colspan="2">
                                    <asp:Button CssClass="btn btn-info" Text="Search" ID="BtnSearch" runat="server" OnClick="BtnSearch_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>Email
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button Text="Update Email Id" CssClass="btn btn-info" ID="BtnEmail" runat="server" OnClick="BtnEmail_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>Mobile_No
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMobileNo" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button Text="Update Mobile_No" CssClass="btn btn-info" ID="BtnUpdateMobile" runat="server" OnClick="BtnUpdateMobile_Click" />
                                </td>
                            </tr>
                        </table>
                        <asp:Label Text="" ID="LblStatus" runat="server" />
                    </div>

                    <div>
                        <table>
                        </table>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
