<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Mobile_No.aspx.cs" Inherits="Queue_Free.Mobile_No" %>

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
                                <td >Mobile No</td>
                                <td >
                                    <asp:TextBox ID="txtMobileNo" runat="server" TextMode="Number" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtMobileNo" runat="server" ErrorMessage="RequiredFieldValidator">Mobile No is required</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button Text="Submit" CssClass="btn btn-info" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label Text="" runat="server" ID="lblStatus" /></td>
                            </tr>
                            
                        </table>
                        
                        
                        <asp:Label ID="lbltemp" Text="" runat="server" Visible="False" />
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
