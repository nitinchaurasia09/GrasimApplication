<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageQuery.aspx.cs" Inherits="GrasimApplication.QueryModule.ManageQuery" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Page Content -->
    <div id="page-content-wrapper">
        <div class="container-fluid">
            <h3>Query Management</h3>
            <hr />
            <div class="alert alert-success" id="lblError" visible="false" runat="server">
            </div>

            <div class="modal-body">
                <form class="form-horizontal ">
                    <fieldset>
                        <asp:HiddenField ID="hdnUserEmail" runat="server" />
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">User Name</label>
                            <div class="col-lg-9">
                                <asp:Label ID="lblUserName" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Query</label>
                            <div class="col-lg-9">
                                <asp:Label ID="lblQuery" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Reply</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtReply" runat="server" TextMode="MultiLine" Width="640" Height="330"></asp:TextBox>
                            </div>
                        </div>

                    </fieldset>
                </form>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnReply" runat="server" Text="Reply" CssClass="btn btn-primary" OnClick="btnReply_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Back" CssClass="btn btn-warning" PostBackUrl="ShowAllQueries.aspx" />
            </div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->
    <script>
        $(document).ready(function () {
            $('#MainContent_btnSave').click(function () {
                if ($('#MainContent_txtReply').val().trim() == '') {
                    alert('Please enter reply');
                    return false;
                }
            });
        });
    </script>

</asp:Content>
