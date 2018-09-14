<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Student_Fee_Status.aspx.cs" Inherits="Queue_Free.Admin.Student_Fee_Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="jumbotron text-center" style="height:100vh;">
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-8 col-md-push-1">
                                <table class="table table-bordered" style="background-color:#ffffff">
                                    
                                    <tr>
                                        <td>Department Name</td>
                                        <td>
                                            <asp:DropDownList ID="ddlDepttName" AutoPostBack="true"  runat="server">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td>Batch</td>
                                        <td>
                                            <asp:DropDownList ID="ddlBatch" AutoPostBack="true"  runat="server">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td>Session Name</td>
                                        <td>
                                            <asp:DropDownList ID="ddlSessionName" AutoPostBack="true" OnSelectedIndexChanged="ddlSessionName_SelectedIndexChanged"  runat="server">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button Text="Get Details" ID="btnGetStatus" OnClick="btnGetStatus_Click" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Button Text="Get Summary" ID="btnGetSummary" OnClick="btnGetSummary_Click" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button Text="Get Pdf" ID="btnGetPdf" OnClick="btnGetPdf_Click" runat="server" />
                                        </td>
                                    </tr>
                                </table>

                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                    <asp:GridView runat="server" ID="gvStudentFeeStatusAdmin" Height="60%" Width="80%"  CellPadding="0" ForeColor="#333333" GridLines="Both" >
                                        


                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                        
                                    </asp:GridView>
                            </div>
                    </div>
            </div>
        </div>
    </div>
</asp:Content>
