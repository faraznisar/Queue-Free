<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Create_or_Change_Password.aspx.cs" Inherits="Queue_Free.Create_or_Change_Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
         <div class="jumbotron text-center" style="height:100vh;">
             <div class="row">
                  <div class="col-md-12">
            <div class="col-md-5 col-md-push-3">
                
                        <table class="table table-bordered table-hover Table_Style" style="text-align:center">
                            <tr>
                                <td>Enter Password</td>
                                <td>
                                    <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" /><br />
                                    <asp:RequiredFieldValidator ID="requiredPassword" ControlToValidate="txtpassword" runat="server" ErrorMessage="Password is required."></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:Label Text="" ID="lblnopassword" runat="server" />

                                </td>
                            </tr>
                            <tr>
                                <td>Re-enter password</td>
                                <td>
                                    <asp:TextBox ID="txtretypepassword" runat="server" TextMode="Password" /><br />
                                    
                                    <asp:CompareValidator ID="comparePasswords"  ControlToCompare="txtpassword" ControlToValidate="txtretypepassword" Operator="Equal" Type="String" runat="server" ErrorMessage="Passwords don't match."></asp:CompareValidator>
                                    <%--<asp:CompareValidator ID="ComparePasswords"  ControlToCompare="txtpassword" ControlToValidate="txtretypepassword" Operator="Equal" Type="String" ErrorMessage="Passwords don't match."  runat="server" />--%>
                                </td>

                            </tr>
                            
                            <tr>
                                <td colspan="2">
                                    <asp:Button Text="Save" CssClass="btn btn-info" ID="BtnSavePassword" runat="server" OnClick="BtnSavePassword_Click"  /></td>
                            </tr>
                        </table>
                        <asp:Label ID="lbltemp" Text="" runat="server" Visible="False" />
                    </div>

              
        </div>
             </div>
         </div>
       
    </div>
</asp:Content>
