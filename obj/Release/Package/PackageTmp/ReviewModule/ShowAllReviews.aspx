<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ShowAllReviews.aspx.cs" Inherits="GrasimApplication.ReviewModule.ShowAllReviews" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Page Content -->
    <div id="page-content-wrapper">
        <div class="container-fluid">
            <h3>Publish Status Management</h3>
            <hr />
            <div class="alert alert-success" id="lblError" runat="server" visible="false">
            </div>

            <div class="modal-body">
                <form class="form-horizontal ">
                    <fieldset>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Manage Publishing Status</label>
                            <div class="col-lg-4">
                                <asp:DropDownList ID="ddlPublish" runat="server" Width="280px" CssClass="form-control">
                                    <asp:ListItem Value="0">Automatic</asp:ListItem>
                                    <asp:ListItem Value="1">Manual</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-3">
                                <asp:Button ID="btnPublish" runat="server" Text="Publish" CssClass="btn btn-primary" OnClick="btnPublish_Click" />
                            </div>
                        </div><br /><hr />
                        <h4>Review and Rating Management</h4>
                        <div class="row">
                            <div><a href="ManageReview.aspx" class="btn btn-primary btn-sm pull-right">Add Review</a></div>
                        </div>
                        <p></p>
                        <div class="form-group clearfix">
                            <div class="col-lg-12">
                                <div class="table-responsive">
                                    <asp:GridView ID="grdReview" runat="server" CssClass="table table-bordered table-hover table-striped" GridLines="None"
                                        AutoGenerateColumns="False" OnRowCommand="grdReview_RowCommand" OnRowDeleting="grdReview_RowDeleting" ShowHeaderWhenEmpty="True" EmptyDataText="No records Found" PageSize="20" AllowPaging="true" OnPageIndexChanging="grdReview_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID ="hdnGUID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "GUID") %>'/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="TailorName" HeaderText="Tailor Name" />
                                            <asp:BoundField DataField="ReviewTitle" HeaderText="Review Titile" />
                                            <asp:BoundField DataField="Description" HeaderText="Description" />
                                            <asp:BoundField DataField="Rating" HeaderText="Rating" />
                                            <asp:BoundField DataField="Publishing" HeaderText="Publishing" />
                                            <asp:BoundField DataField="ReviewStatus" HeaderText="Status" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton CssClass="btn btn-primary btn-xs" CommandName="Approve" Text="Approve" runat="server" CommandArgument="<%# Container.DataItemIndex %>"></asp:LinkButton>
                                                    <asp:LinkButton CssClass="btn btn-primary btn-xs" CommandName="Reject" Text="Reject" runat="server" CommandArgument="<%# Container.DataItemIndex %>"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle CssClass="cursor-pointer" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </fieldset>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
