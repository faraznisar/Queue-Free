<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="Pay_Fee.aspx.cs" Inherits="Queue_Free.Student.Pay_Fee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="jumbotron text-center" style="height:100vh;">
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-8 col-md-push-2">


                        <div class="panel panel-primary">
                            <div class="panel-body">
                                <asp:RadioButton Text="Tution Fee." ID="rbTutionFee" runat="server" AutoPostBack="true" GroupName="FeeType" OnCheckedChanged="rbTutionFee_CheckedChanged" />



                                <asp:RadioButton Text="Examination fee." ID="rbExaminationFee" runat="server" AutoPostBack="true" GroupName="FeeType" OnCheckedChanged="rbExaminationFee_CheckedChanged" />

                            </div>
                        </div>


                        <div class="">
                            <div class="col-md-8 col-md-push-1">
                                <table class="table table-bordered" style="background-color: white">
                                    <tr>
                                        <td>Batch</td>
                                        <td>
                                            <asp:Label Text="" ID="lblBatch" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Semester
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSemester" runat="server">
                                                <asp:ListItem Text="1" />
                                                <asp:ListItem Text="2" />
                                                <asp:ListItem Text="3" />
                                                <asp:ListItem Text="4" />
                                                <asp:ListItem Text="5" />
                                                <asp:ListItem Text="6" />
                                                <asp:ListItem Text="7" />
                                                <asp:ListItem Text="8" />
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Department Name</td>
                                        <td>
                                            <asp:Label Text="" ID="lblDepttName" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <td>Session Name</td>
                                        <td>
                                            <asp:DropDownList ID="ddlSessionName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSessionName_SelectedIndexChanged">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td>Fee Amount</td>
                                        <td>
                                            <asp:Label Text="" ID="lblFeeAmount" runat="server" /></td>
                                    </tr>

                                    <tr>
                                        <td colspan="2">
                                            <asp:Button Text="Pay Fee" ID="btnPayFee" runat="server" OnClick="btnPayFee_Click" /></td>
                                    </tr>
                                </table>

                            </div>
                        </div>




                    </div>
                </div>
            </div>


            <div class="row">
                <div class="col-md-12">

                    <asp:GridView runat="server" ID="gvStudentFeeStatus" CellPadding="0" Height="60%" Width="80%" ForeColor="#333333" GridLines="None" BorderStyle="Solid" BorderWidth="1px" CellSpacing="8">
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


                    <asp:Label Text="pending" ID="lblTempStatus" Visible="false" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
