<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageUser.aspx.cs" Inherits="GrasimApplication.UserModule.ManageUser" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Page Content -->
    <div id="page-content-wrapper">
        <div class="container-fluid">
            <h3>Add/Edit User</h3>
            <hr />
            <div class="alert alert-success" id="lblError" runat="server">
            </div>

            <div class="modal-body">
                <form class="form-horizontal ">
                    <fieldset>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">User Name *</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">User Email *</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtUserEmail" runat="server" Width="300px" Columns="2" Rows="2" CssClass="form-control" MaxLength="300"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">User Phone *</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtUserPhone" runat="server" Width="300px" Columns="2" Rows="2" CssClass="form-control" MaxLength="24"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">User Location *</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtUserLocation" runat="server" Width="300px" Columns="2" Rows="2" CssClass="form-control" MaxLength="500"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">First Name *</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtFirstName" runat="server" Width="300px" Columns="2" Rows="2" CssClass="form-control" MaxLength="40"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Last Name *</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtLastName" runat="server" Width="300px" Columns="2" Rows="2" CssClass="form-control" MaxLength="40"></asp:TextBox>
                            </div>
                        </div>
                        <div id="divPassword" class="form-group clearfix" runat="server" visible="false">
                            <label for="inputName" class="col-lg-3 control-label">Password *</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="300px" Columns="2" Rows="2" CssClass="form-control" MaxLength="40"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">IsAdmin</label>
                            <div class="col-lg-9">
                                <asp:RadioButtonList ID="rdoIsAdmin" runat="server" RepeatDirection="Horizontal" CssClass="listSpace">
                                    <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="1" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Is Active</label>
                            <div class="col-lg-9">
                                <asp:RadioButtonList ID="rdoUserStatus" runat="server" RepeatDirection="Horizontal" CssClass="listSpace">
                                    <asp:ListItem Text="Yes" Value="0" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Image</label>
                            <div class="col-lg-9">
                                <asp:FileUpload ID="flUserImage" runat="server" ViewStateMode="Disabled" />
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label"></label>
                            <div class="col-lg-9">
                                <asp:Image ID="imgUser" runat="server" Width="100" Height="100" Visible="false" />
                            </div>
                        </div>
                    </fieldset>
                </form>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Back" CssClass="btn btn-warning" PostBackUrl="ShowAllUsers.aspx" />
            </div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->
    <script>
        $(document).ready(function () {
            $('#MainContent_btnSave').click(function () {
                if ($('#MainContent_txtUserName').val().trim() == '') {
                    alert('Please select User Name');
                    return false;
                }
                if ($('#MainContent_txtUserEmail').val().trim() == '') {
                    alert('Please enter Email');
                    return false;
                } else {
                    if (IsEmail($('#MainContent_txtUserEmail').val()) == false) {
                        alert('Please enter correct Email');
                        return false;
                    }
                }
                if ($('#MainContent_txtUserPhone').val().trim() == '') {
                    alert('Please enter User Phone');
                    return false;
                }
                if ($('#MainContent_txtUserLocation').val().trim() == '') {
                    alert('Please enter User Location');
                    return false;
                }
                if ($('#MainContent_txtFirstName').val().trim() == '') {
                    alert('Please enter First Name');
                    return false;
                }
                if ($('#MainContent_txtLastName').val().trim() == '') {
                    alert('Please enter Last Name');
                    return false;
                }
                if ($('#MainContent_divPassword').is(':visible')) {
                    if ($('#MainContent_txtPassword').val().trim() == '') {
                        alert('Please enter Password');
                        return false;
                    }
                }
                if ($('#MainContent_flUserImage').val().trim() != '') {
                    if (($('#MainContent_flUserImage')[0].files[0].size / (1024 * 1024)) > 2) {
                        alert('File size should not be more than 2 MB');
                        return false;
                    }
                }

            });
        });
        function IsEmail(email) {
            var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            return regex.test(email);
        }
    </script>

</asp:Content>
