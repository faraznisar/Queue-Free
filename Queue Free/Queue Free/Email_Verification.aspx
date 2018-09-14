<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Email_Verification.aspx.cs" Inherits="Queue_Free.Email_Verification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
         <div class="jumbotron text-center" style="height:100vh;">
             <div class="row">
                 <div class="col-md-12">
            <div class="col-md-5 col-md-push-3">                
                        <table class="table table-bordered table-hover" style="text-align:center;background-color:white">
                            <tr>
                                <td >Enter Email</td>
                                <td >
                                    <asp:TextBox ID="txtemail" runat="server" />
                                    <asp:RequiredFieldValidator ErrorMessage="Email required." ControlToValidate="txtemail" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td  colspan="2">
                                    <asp:Button Text="Submit" CssClass="btn btn-info" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:Label Text="" runat="server" ID="lblStatus" /></td>
                            </tr>
                        </table>
                            <h4>try another way to register <a href="Mobile_No.aspx">here</a></h4>
                        
                        <asp:Label ID="lbltemp" Text="" runat="server" Visible="false" />
                        <asp:Label Text="" ID="lblOTP" Visible="true" runat="server" />
                    </div>
            
        </div>
             </div>
         </div>
        
    </div>
</asp:Content>
