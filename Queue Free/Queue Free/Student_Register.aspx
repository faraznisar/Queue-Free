<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Student_Register.aspx.cs" Inherits="Queue_Free.Student_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="jumbotron text-center " style="height:100vh;">
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-4 col-md-push-2">

                        <table class=" table table-bordered " style="text-align:center; background-color:white" runat="server">
                            <tr>
                                <td  >Roll Number
                                </td>
                                <td >
                                    <asp:TextBox runat="server" ID="TxtRollNo" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtRollNo" runat="server" ErrorMessage="RequiredFieldValidator">Roll No required.</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <%--  <tr>
                            <td>Enter Mobile-No</td>
                            <td>
                                <asp:TextBox ID="TxtMobileNo" runat="server" /></td>
                        </tr>--%>
                            <tr>
                                <td   colspan="2">
                                    <asp:Button  Text="Search" CssClass="btn btn-info " ID="BtnSearch" runat="server" OnClick="BtnSearch_Click" /></td>
                            </tr>
                            <tr>
                                <td  colspan="2">
                                    <asp:Label Text="" ID="LblStatus" runat="server" /></td>
                            </tr>
                        </table>

                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
