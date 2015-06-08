<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageReview.aspx.cs" Inherits="GrasimApplication.ReviewModule.ManageReview" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Page Content -->
    <div id="page-content-wrapper">
        <div class="container-fluid">
            <h3>Add Tailors Review</h3>
            <hr />
            <div class="alert alert-success" id="lblError" runat="server" visible="false">
            </div>
            <div class="modal-body">
                <form class="form-horizontal ">
                    <fieldset>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Tailor *</label>
                            <div class="col-lg-9">
                                <asp:DropDownList ID="ddlTaior" runat="server" Width="280px" AppendDataBoundItems="true" CssClass="form-control">
                                    <asp:ListItem Value="0">Select Tailor</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Review Title *</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtReviewTitle" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Description *</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="300px" Columns="2" Rows="2" CssClass="form-control" MaxLength="250"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Rating *</label>
                            <div class="col-lg-9">
                                <asp:DropDownList ID="ddlRating" runat="server" Width="280px" CssClass="form-control">
                                    <asp:ListItem Value="1">1</asp:ListItem>
                                    <asp:ListItem Value="2">2</asp:ListItem>
                                    <asp:ListItem Value="3">3</asp:ListItem>
                                    <asp:ListItem Value="4">4</asp:ListItem>
                                    <asp:ListItem Value="5">5</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </fieldset>
                </form>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Back" CssClass="btn btn-warning" PostBackUrl="ShowAllReviews.aspx" />
            </div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->
    <script type="text/javascript">
        $(document).ready(function () {
            $('#MainContent_btnSave').click(function () {

                if ($('#MainContent_ddlTaior').val().trim() == '0') {
                    alert('Please select Tailor Name');
                    return false;
                }
                if ($('#MainContent_txtReviewTitle').val().trim() == '') {
                    alert('Please enter review title');
                    return false;
                }
                if ($('#MainContent_txtDescription').val().trim() == '') {
                    alert('Please enter description');
                    return false;
                }
            });
        });
    </script>
</asp:Content>
