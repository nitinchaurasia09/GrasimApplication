<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageDeal.aspx.cs" Inherits="GrasimApplication.DealModule.ManageDeal" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Page Content -->
    <div id="page-content-wrapper">
        <div class="container-fluid">
            <h3>Add/Edit Deal</h3><hr />
            <div class="alert alert-success" id="lblError" runat="server" visible="false" >
                
            </div>

            <div class="modal-body">
                <form class="form-horizontal ">
                    <fieldset>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Tailor *</label>
                            <div class="col-lg-9">
                               <asp:DropDownList ID="ddlTailor" runat="server" Width="280px" AppendDataBoundItems="true" CssClass="form-control">
                                    <asp:ListItem Value="0">Select Tailor</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Deal Percentage *</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtDealPercentage" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Deal Description</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtDealDescription" runat="server" TextMode="MultiLine" Width="300px" Columns="2" Rows="2" CssClass="form-control" MaxLength="250"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Deal Status</label>
                            <div class="col-lg-9">
                                <asp:RadioButtonList ID="rdoStatus" runat="server" RepeatDirection="Horizontal" CssClass="listSpace">
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
                <asp:Button ID="btnCancel" runat="server" Text="Back" CssClass="btn btn-warning" PostBackUrl="ShowAllDeals.aspx" />
            </div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->
    <script>
        $(document).ready(function () {
            $('#MainContent_btnSave').click(function () {
                if ($('#MainContent_ddlTailor').val().trim() == '0') {
                    alert('Please select Tailor Name');
                    return false;
                }
                if ($('#MainContent_txtDealPercentage').val().trim() == '') {
                    alert('Please select Deal Percentage');
                    return false;
                }
                else {
                    if (IsNumeric($('#MainContent_txtDealPercentage').val()) == false) {
                        alert('Please enter numeric value');
                        return false;
                    }
                }
                if ($('#MainContent_txtDealDescription').val().trim() == '') {
                    alert('Please enter Deal Description');
                    return false;
                }
            });
        });
        function IsNumeric(number) {
            var regex = /^[0-9]*$/;
            return regex.test(number);
        }
    </script>

</asp:Content>
