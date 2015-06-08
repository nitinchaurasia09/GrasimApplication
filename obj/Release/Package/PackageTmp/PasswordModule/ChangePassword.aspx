<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="GrasimApplication.PasswordModule.ChangePassword" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Page Content -->
    <div id="page-content-wrapper">
        <div class="container-fluid">
            <h3>Change Password</h3><hr />
            <div class="alert alert-success" id="lblError" runat="server" visible="false">
            </div>
            <div class="modal-body">
                <form class="form-horizontal ">
                    <fieldset>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Old Password *</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtOldPassword" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">New Password *</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Confirm Password *</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                            </div>
                        </div>
                    </fieldset>
                </form>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->
    <script>
        $(document).ready(function () {
            $('#MainContent_btnSave').click(function () {
                if ($('#MainContent_txtOldPassword').val().trim() == '') {
                    alert('Please enter Old Password');
                    return false;
                }
                if ($('#MainContent_txtNewPassword').val().trim() == '') {
                    alert('Please enter New Password');
                    return false;
                }
                if ($('#MainContent_txtNewPassword').val().trim() != $('#MainContent_txtConfirmPassword').val().trim()) {
                    alert('New password and confirm password should be same');
                    return false;
                }
            });
        });
    </script>
</asp:Content>
