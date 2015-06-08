<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ShowAllCategories.aspx.cs" Inherits="GrasimApplication.CategoryModule.ShowAllCategories" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Page Content -->

    <div id="page-content-wrapper">
        <h3>Manage Category</h3>
        <hr />
        <div class="container-fluid">
            <div class="row">
                <div><a href="ManageCategory.aspx" class="btn btn-primary btn-sm pull-right">Create new category</a></div>
            </div>
            <p></p>
            <div class="row">
                <div class="col-lg-12">
                    <div class="table-responsive">
                        <asp:GridView ID="grdCategory" runat="server" CssClass="table table-bordered table-hover table-striped" GridLines="None"
                            AutoGenerateColumns="False" OnRowCommand="grdCategory_RowCommand" OnRowDeleting="grdCategory_RowDeleting" ShowHeaderWhenEmpty="True" EmptyDataText="No records Found" PageSize="20" AllowPaging="true" OnPageIndexChanging="grdCategory_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnGUID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "GUID") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="FeatureName" HeaderText="Feature Name" />
                                <asp:BoundField DataField="CategoryName" HeaderText="Category Name" />
                                <asp:BoundField DataField="CategoryStatus" HeaderText="Category Status" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton CssClass="btn btn-primary btn-xs" CommandName="Edit" Text="Edit" runat="server" CommandArgument="<%# Container.DataItemIndex %>"></asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-primary btn-xs" CommandName="Delete" Text="Delete" runat="server" CommandArgument="<%# Container.DataItemIndex %>"></asp:LinkButton>
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
