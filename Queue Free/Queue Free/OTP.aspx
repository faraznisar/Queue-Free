<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="OTP.aspx.cs" Inherits="Queue_Free.OTP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
         <div class="jumbotron text-center" style="height:100vh;">
             <div class="row">
                  <div class="col-md-12">
            <div class="col-md-5 col-md-push-2">
                
                    
                        <table class="table table-bordered table-hover" style="text-align:center; background-color:white">
                            <tr>
                                <td>Enter OTP</td>
                                <td>
                                    <asp:TextBox runat="server" ID="TxtOTP" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TxtOTP" runat="server" ErrorMessage="RequiredFieldValidator">Enter OTP</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button Text="Submit" CssClass="btn btn-info" ID="BtnSubmitOTP" runat="server" OnClick="BtnSubmitOTP_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:Label Text="" ID="lblstatus"  runat="server" /></td>
                            </tr>
                        </table>
                        <asp:Label Text="" ID="lbltemp" Visible="false" runat="server" />
                        
                  
            </div>
        </div>
             </div>
         </div>
       
    </div>
</asp:Content>
