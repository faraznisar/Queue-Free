<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Populate_Fee_Structure.aspx.cs" Inherits="Queue_Free.Admin.Populate_Fee_Structure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        
            <div class="row">
            <div class="col-md-12">
                <div class="col-md-6 col-md-push-3">

                    <asp:Table ID="tblresult" CssClass="table table-bordered Table_Style  "  runat="server">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell>Batch</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Session Name</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Department Name</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Tution Fee</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Examination Fee</asp:TableHeaderCell>

                        </asp:TableHeaderRow>


                    </asp:Table>
                    <asp:Button Text="Add" ID="btnAdd" runat="server" OnClick="btnAdd_Click" />

                </div>
            </div>
        </div>
        </div>
        

</asp:Content>
