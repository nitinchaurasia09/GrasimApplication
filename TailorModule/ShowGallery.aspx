<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowGallery.aspx.cs" Inherits="GrasimApplication.TailorModule.ShowGallery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div id="page-content-wrapper"><h3>Manage Tailor Gallery</h3><hr />
        <div class="container-fluid">
            <div class="row">
                <div><a href="ManageGallery.aspx?tailorId=<%= Request.QueryString["tailorid"] %>" class="btn btn-primary btn-sm pull-right">Add new photo</a></div>
            </div><p></p>
            <div class="row">
                <div class="col-lg-12">
                    <div class="table-responsive">
                        <asp:GridView ID="grdGallery" runat="server" CssClass="table table-bordered table-hover table-striped" GridLines="None"
                            AutoGenerateColumns="False" OnRowCommand="grdGallery_RowCommand" OnRowDeleting="grdGallery_RowDeleting" ShowHeaderWhenEmpty="True" EmptyDataText="No records Found" PageSize="20" AllowPaging="true" OnPageIndexChanging="grdGallery_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID ="hdnGUID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "GUID") %>'/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                <asp:ImageField DataImageUrlField="GalleryImage" HeaderText="Gallery Image" ControlStyle-Width="50" ControlStyle-Height="50" />
                                <asp:BoundField DataField="TailorName" HeaderText="Tailor Name" />
                                <asp:BoundField DataField="TailorEmail" HeaderText="Tailor Email" />
                                <asp:BoundField DataField="GalleryStatus" HeaderText="Gallery Status" />
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
</asp:Content>