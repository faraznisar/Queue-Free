<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="Fee_History.aspx.cs" Inherits="Queue_Free.Student.Fee_Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="jumbotron text-center" style="height:100vh;">
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-8 col-md-push-2">
                        <table class="table table-bordered" style="background-color:white">
                            <tr>
                                <td>
                                    <asp:Label Text="Session " runat="server" /></td>
                                <td>
                                    <asp:DropDownList ID="ddlSessionName" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Semester
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSemester" runat="server">
                                        
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label Text="Fee Type"  runat="server" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlFeeType" runat="server">
                                        <asp:ListItem Text="Fee Type" />
                                        <asp:ListItem Text="Examination Fee" />
                                        <asp:ListItem Text="Tution Fee" />
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button Text="Submit" ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" />
                                </td>
                            </tr>
                        </table>

                        <%--<div class="panel panel-primary">
                            <div class="panel-body">
                                <asp:RadioButton Text="Tution Fee." ID="rbTutionFee" runat="server" AutoPostBack="true" GroupName="FeeType" OnCheckedChanged="rbTutionFee_CheckedChanged"/>



                                <asp:RadioButton Text="Hostel fee." ID="rbHostelFee" runat="server" AutoPostBack="true" GroupName="FeeType" OnCheckedChanged="rbHostelFee_CheckedChanged" />

                            </div>
                        </div>--%>


                        <br />

                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-8 col-md-push-2">
                                    <table class="table table-bordered" style="background-color:white">
                                        <tr>
                                            <td>Student Name</td>
                                            <td>
                                                <asp:Label Text="" ID="lblSttudentName" runat="server" /></td>
                                        </tr>
                                        <tr>
                                            <td>Roll No</td>
                                            <td>
                                                <asp:Label Text="" ID="lblRollno" runat="server" /></td>
                                        </tr>
                                        <tr>
                                            <td>Department</td>
                                            <td>
                                                <asp:Label Text="" ID="lblDepartmentName" runat="server" /></td>

                                        </tr>
                                        <tr>
                                            <td>Batch</td>
                                            <td>
                                                <asp:Label Text="" ID="lblBatch" runat="server" /></td>
                                        </tr>
                                        <tr>
                                            <td>Fee Amount</td>
                                            <td>
                                                <asp:Label Text="" ID="lblAmount" runat="server" />
                                           </td>
                                        </tr>
                                        <tr>
                                            <td>Status</td>
                                            <td>
                                                <asp:Label Text="" ID="lblStatus" runat="server" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Date Paid
                                            </td>
                                            <td>
                                                <asp:Label Text="" ID="lblDatePaid" runat="server" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2"> <asp:Button Text="Get pdf" ID="btnGetPdf" runat="server" OnClick="btnGetPdf_Click" /></td>
                                        <%--<td> <asp:Button Text="Get Department copy" ID="btnDepttpdf" runat="server" OnClick="btnDepttpdf_Click" /></td>--%>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                
               
            </div>            
            <asp:Label Text="" Visible="false" ID="lbltemp1" runat="server" />
            <asp:Label Text="" Visible="false" ID="lbltemp2" runat="server" />
            <asp:Label Text="" Visible="false" ID="lbltemp3" runat="server" />
            <asp:Label Text="" Visible="false" ID="lbltempfee" runat="server" />
        </div>
        </div>
</asp:Content>
