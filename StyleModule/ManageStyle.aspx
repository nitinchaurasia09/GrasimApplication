<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageStyle.aspx.cs" Inherits="GrasimApplication.StyleModule.ManageStyle" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Page Content -->
    <div id="page-content-wrapper">
        <div class="container-fluid">
            <h3>Add/Edit Style</h3><hr />
            <div class="alert alert-success" id="lblError" runat="server" visible="false">
            </div>
            <div class="modal-body">
                <form class="form-horizontal ">
                    <fieldset>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Style Name *</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtStyleName" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Style Description</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="300px" Columns="2" Rows="2" CssClass="form-control" MaxLength="250"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Status</label>
                            <div class="col-lg-9">
                                <asp:RadioButtonList ID="rdoStatus" runat="server" RepeatDirection="Horizontal"  CssClass="listSpace">
                                    <asp:ListItem Text="Yes" Value="0" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                    </fieldset>
                </form>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Back" CssClass="btn btn-warning" PostBackUrl="ShowAllStyles.aspx" />
            </div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->
    <script>
        $(document).ready(function () {
            $('#MainContent_btnSave').click(function () {
                if ($('#MainContent_txtStyleName').val().trim() == '') {
                    alert('Please select Style Name');
                    return false;
                }
            });
        });
    </script>
</asp:Content>
