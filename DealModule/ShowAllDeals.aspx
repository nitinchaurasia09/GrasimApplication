<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ShowAllDeals.aspx.cs" Inherits="GrasimApplication.DealModule.ShowAllDeals" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Page Content -->

    <div id="page-content-wrapper">
        <h3>Manage Deal</h3>
        <hr />
        <div class="container-fluid">
            <div class="row">
                <div><a href="ManageDeal.aspx" class="btn btn-primary btn-sm pull-right">Create new deal</a></div>
            </div>
            <p></p>
            <div class="row">
                <div class="col-lg-12">
                    <div class="table-responsive">
                        <asp:GridView ID="grdDeal" runat="server" CssClass="table table-bordered table-hover table-striped" GridLines="None"
                            AutoGenerateColumns="False" OnRowCommand="grdDeal_RowCommand" OnRowDeleting="grdDeal_RowDeleting" ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"  PageSize="20" AllowPaging="true" OnPageIndexChanging="grdDeal_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnGUID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "GUID") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Tailor" HeaderText="Tailor" />
                                <asp:BoundField DataField="DealPercentage" HeaderText="Deal Percentage" />
                                <asp:BoundField DataField="DealDescription" HeaderText="Message" />
                                <asp:BoundField DataField="DealStatus" HeaderText="Status" />
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
