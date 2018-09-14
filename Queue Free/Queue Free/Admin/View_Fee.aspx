<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="View_Fee.aspx.cs" Inherits="Queue_Free.Admin.View_Fee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="jumbotron text-center" style="height:100vh;">
            <div class="row">
                <div class="col-md-12">
                     <div class="col-md-6">
           <%-- <table class="table table-bordered " style="text-align:center">
                  <tr>
                      <th>Batch</th>
                      <th>Session Name</th>
                      <th>Department Name</th>
                      <th>Tution Fee</th>
                      <th>Hostel Fee</th>
                  </tr>
                <tr>
                    
                    <td>
                        <asp:Label Text="" ID="lblBatch" runat="server" /></td>                    
                    <td>
                        <asp:Label Text="" ID="lblSessionName" runat="server" /></td>                    
                    <td>
                        <asp:Label Text="" ID="DeptName" runat="server" /></td>                    
                    <td>
                        <asp:TextBox ID="txtTutionFee" runat="server" /></td>
                    <td>
                        <asp:TextBox ID="txtHostelFee" runat="server" /> 
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:Button CssClass="btn btn-info" Text="Update" ID="btnUpdate" runat="server" />
                    </td>
                </tr>
            </table>--%>
            <%--<table class="table table-bordered tablestyle" style="text-align:center">
                <tr>
                    <td>Batch</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlBatch" AutoPostBack="true" OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged" >
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td> Session Name</td>
                    <td>
                        <asp:DropDownList runat="server" id ="ddlSessionName" AutoPostBack="true" OnSelectedIndexChanged="ddlSessionName_SelectedIndexChanged">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Department Name </td>
                    <td>
                        <asp:DropDownList ID="ddlDepttName" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlDepttName_SelectedIndexChanged" >
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td> Tution Fee</td>
                    <td>
                        <asp:TextBox ID="txtTutionFee" runat="server" /></td>
                </tr>
                <tr>
                    <td>Hostel Fee</td>
                    <td> <asp:TextBox ID="txtHostelFee" runat="server" /></td>
                </tr>
                    <tr>
                        <td>
                            <asp:Button Text="View Fee" ID="btnViewFee" OnClick="btnViewFee_Click" CssClass="btn btn-info" runat="server" /></td>
                    <td>
                        <asp:Button CssClass="btn btn-info" Text="Update" ID="BtnUpdate" runat="server" />
                    </td>
                </tr>
            </table>--%>
            <br />

            <asp:GridView runat="server" ID="gvViewFee" CellPadding="4" ForeColor="#333333" GridLines="None" Height="166px" Width="881px">
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
