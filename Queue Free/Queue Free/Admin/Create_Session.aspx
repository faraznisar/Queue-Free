<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Create_Session.aspx.cs" Inherits="Queue_Free.Admin.Create_Session" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <div class="jumbotron text-center " style="height:100vh;">
            <div class="row">
                <div class="col-md-12">
                    <div class="row">
                        <div class="container-fluid">
                            <div class="col-md-6 col-md-push-2">

                                <table class="table table-bordered" style="background-color:white">
                                    <tr>
                                        <td>Session Name</td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtSessionName" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button Text="Create" ID="btnCreateSession" runat="server" OnClick="btnCreateSession_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>

                        </div>
                    </div>

                    <asp:Label Text="" ID="lblStatus" runat="server" />
                    <br /><br /><br /> <br />

                    <div class="row">
                        <div class="container-fluid">
                            <div class="col-md-6 col-md-push-3">
                                <div class="panel panel-success">
                                    <div class="panel-body">
                                        <asp:Button Text="View Session" ID="btnViewSession" runat="server" OnClick="btnViewSession_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <br /> <br /><br /> <br />
                    <div class="row">
                        <div class="container-fluid">
                            <div class="col-md-10 col-md-push-1">
                                <div class="panel panel-success">
                                    <div class="panel-body">
                                        <asp:GridView runat="server" ID="gvViewSession" CellPadding="4" ForeColor="#333333" GridLines="None" Height="30%" Width="70%">
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

                </div>
            </div>
        </div>




    </div>

</asp:Content>
