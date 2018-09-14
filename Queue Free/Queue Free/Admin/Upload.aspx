<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="Queue_Free.Admin.Upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="jumbotron text-center" style="height:100vh;">
            <div class="row">
                <div class="col-md-12">
                          <div class="col-md-6 col-md-push-3">
                    <div>
                        <table class="table table-bordered " style="background-color:white; text-align:center">
                            <tr>
                                <td colspan="2">
                                    <asp:FileUpload ID="FileUpload1" runat="server" /></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnImport" runat="server" Text="Display" OnClick="btnImport_Click" /></td>
                                <td>
                                        <asp:Button Text="Add" ID="btnDBAdd" runat="server" OnClick="btnDBAdd_Click" /></td>
                            </tr>
                        </table>


                        <br />
                        <br />
                        <asp:Literal ID="limsg" runat="server"></asp:Literal>
                        <br />
                        <hr />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panel-success" style="background-color:#eeeeee;">
                            <div class="panel-body">
                                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="40%" Width="80%">
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
</asp:Content>
