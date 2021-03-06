﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageCategory.aspx.cs" Inherits="GrasimApplication.CategoryModule.ManageCategory" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Page Content -->
    <div id="page-content-wrapper">
        <div class="container-fluid">
            <h3>Add/Edit Category</h3>
            <hr />
            <div class="alert alert-success" id="lblError" runat="server">
            </div>

            <div class="modal-body">
                <form class="form-horizontal ">
                    <fieldset>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Feature *</label>
                            <div class="col-lg-9">
                                <asp:DropDownList ID="ddlFeature" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Category Name *</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtCatName" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Category Description</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="300px" Columns="2" Rows="2" CssClass="form-control" MaxLength="250"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Status</label>
                            <div class="col-lg-9">
                                <asp:RadioButtonList ID="rdoStatus" runat="server" RepeatDirection="Horizontal" CssClass="listSpace">
                                    <asp:ListItem Text="Yes" Value="0" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Image</label>
                            <div class="col-lg-9">
                                <asp:FileUpload ID="imgUpload" runat="server" />
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label"></label>
                            <div class="col-lg-9">
                                <asp:Image ID="catImage" runat="server" Width="100" Height="100" Visible="false" />
                            </div>
                        </div>
                    </fieldset>
                </form>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Back" CssClass="btn btn-warning" PostBackUrl="ShowAllCategories.aspx" />
            </div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->
    <script>
        $(document).ready(function () {
            $('#MainContent_btnSave').click(function () {
                if ($('#MainContent_txtCatName').val().trim() == '') {
                    alert('Please select Category Name');
                    return false;
                }
                if (($('#MainContent_imgUpload')[0].files[0].size / (1024 * 1024)) > 1) {
                    alert('File size should not be more than 1 MB');
                    return false;
                }
            });
        });
    </script>

</asp:Content>
