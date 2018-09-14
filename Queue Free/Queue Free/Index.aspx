<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Queue_Free.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12 contentposition">
                <div>
                    <asp:Image ImageUrl="~/Images/Queue-Free-Index.jpg" CssClass="img-responsive img-rounded Index-Image" runat="server" />
                </div>
               

                <%--paragraph--%>




                <%--beginning of my tale--%>


                <div class="col-md-12">
                    <div>
                        <h2 style="text-align:center; color:white; ">Designed and developed by</h2>
                        <div class="col-md-3" >
                            <div class="Division-Border Index-Division" >
                               <img src="Images/Faraz.jpg" class="Developer-Image" />
                               <p style="text-align:center; color:white;">
                                   Faraz Nisar Shah.<br />
                                   Faraz.nisar1@gmail.com.<br />
                                   <a style="text-decoration:none;" href="https://github.com/Faraznisar">GitHub</a>

                               </p>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="Division-Border">
                                <img src="Images/DSC_0143.JPG" class="Developer-Image" />
                                <p  style="text-align:center; color:white;">
                                    Gazala Mushtaq.<br />
                                    gazalamushtaq188@gmail.com.<br />

                                </p>
                            </div>
                           
                        </div>
                        <div class="col-md-3">
                            <div class="Division-Border">
                                <img src="Images/Soliheen.jpg" class="Developer-Image"/>
                                <p  style="text-align:center; color:white;">
                                    Soliheen Farooq Khan.<br />
                                    Soliheen.369@gmail.com.<br />

                                </p>
                            </div>
                           
                        </div>
                        <div class="col-md-3">
                            <div class="Division-Border">
                                <img src="Images/Instagram%20post%20by%20Malik%20Ijtiba_BMuDsKnF4r3.jpg"  class="Developer-Image"/>
                                <p  style="text-align:center; color:white;">
                                    Malik Ijtiba.<br />
                                    malikijtiba@outlook.com.<br />

                                </p>
                            </div>
                            
                        </div>
                    </div>
                </div>


            </div>
        </div>
    </div>
</asp:Content>
