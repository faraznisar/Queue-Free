<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Queue_Free.LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/Styles/Styles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container style">
        <div class="jumbotron text-center" style="height:100vh;">
            <div class="row">
                <div class="main col-md-12">
                    <div class="col-md-5 col-md-push-3">

                        <table class="table table-bordered " style="text-align: center; background-color: white">
                            <tr>
                                <td  colspan="2">
                                    <h2>Login</h2>
                                </td>
                            </tr>
                            <tr>
                                
                                <td  colspan="2">
                                    <asp:TextBox runat="server" placeholder="Username" ID="txtUserName" />
                                    <asp:RequiredFieldValidator ID="usernameValidator" runat="server" ControlToValidate="txtUserName" ErrorMessage="RequiredFieldValidator">Username Required.</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td  colspan="2">
                                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" placeholder="Password" />
                                    <asp:RequiredFieldValidator ID="PasswordValidator" runat="server" ControlToValidate="txtPassword" ErrorMessage="RequiredFieldValidator">Password Required</asp:RequiredFieldValidator>
                                    <%--    <asp:RequiredFieldValidator ErrorMessage="Please enter your password" ControlToValidate="txtpassword" runat="server" />
                                    --%> </td>
                            </tr>
                            <tr>
                                <td  colspan="2">
                                    <asp:Button CssClass="btn btn-info" ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td >Remember me
                               
                                    <asp:CheckBox Text="" ID="chkRemember" runat="server" /></td>
                            </tr>
                        </table>
                        <asp:Label Text="" ID="lblStatus" runat="server" />
                        <asp:Label Text="" Visible="false" ID="lblrole" runat="server" />
                        <asp:Label Text="" Visible="false" ID="lblp" runat="server" />
                    </div>





                </div>
            </div>
        </div>

    </div>
</asp:Content>
