<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowAllTailors.aspx.cs" Inherits="GrasimApplication.TailorModule.ShowAllTailors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <!-- Page Content -->
    <div id="page-content-wrapper">
        <div class="container-fluid">
            <h3>Manage Tailor</h3><hr />
            <div class="row">
                <div><a href="ManageTailor.aspx" class="btn btn-primary btn-sm pull-right">Create new Tailor</a></div>
            </div><p></p>
            <div class="row">
                <div class="col-lg-12">
                    <div class="table-responsive">
                        <asp:GridView ID="grdTailor" runat="server" CssClass="table table-bordered table-hover table-striped" GridLines="None"
                            AutoGenerateColumns="False" OnRowCommand="grdTailor_RowCommand" OnRowDeleting="grdTailor_RowDeleting" ShowHeaderWhenEmpty="True" EmptyDataText="No records Found" PageSize="20" AllowPaging="true" OnPageIndexChanging="grdTailor_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID ="hdnGUID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "GUID") %>'/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                <asp:BoundField DataField="TailorName" HeaderText="Tailor Name" />
                                <asp:BoundField DataField="TailorEmail" HeaderText="Tailor Email" />
                                <asp:BoundField DataField="TailorStatus" HeaderText="Tailor Status" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton CssClass="btn btn-primary btn-xs" CommandName="Edit" Text="Edit" runat="server" CommandArgument="<%# Container.DataItemIndex %>"></asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-primary btn-xs" CommandName="Delete" Text="Delete" runat="server" CommandArgument="<%# Container.DataItemIndex %>"></asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-primary btn-xs" CommandName="ManageGallery" Text="Manage Gallery" runat="server" CommandArgument="<%# Container.DataItemIndex %>"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="cursor-pointer" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->

</asp:Content>
