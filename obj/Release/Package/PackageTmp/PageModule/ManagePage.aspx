<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="ManagePage.aspx.cs" Inherits="GrasimApplication.PageModule.ManagePage" EnableEventValidation="false" validateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <!-- Page Content -->
    <div id="page-content-wrapper">
        <div class="container-fluid">
            <h3>Add/Edit Page</h3><hr />
            <div class="alert alert-success" id="lblError" runat="server" visible="false" >
                
            </div>

            <div class="modal-body">
                <form class="form-horizontal ">
                    <fieldset>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Page Name *</label>
                            <div class="col-lg-9">
                                 <asp:DropDownList ID="ddlPageName" runat="server" Width="280px" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPageName_SelectedIndexChanged">
                                    <asp:ListItem Value="0">Select Page</asp:ListItem>
                                     <asp:ListItem Value="1">Home Page</asp:ListItem>
                                     <asp:ListItem Value="2">About Us</asp:ListItem>
                                     <asp:ListItem Value="3">Help</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Category Description</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="640" Height="330"></asp:TextBox>
                            </div>
                        </div>
                    </fieldset>
                </form>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" /></div>
        </div>
    </div>
    <script type="text/javascript" src="tiny_mce/tiny_mce.js"></script>
    <script type="text/javascript" language="javascript">
        tinyMCE.init({
            mode: "textareas",
            theme: "advanced",
            plugins: "pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups",

        });
    </script>
</asp:Content>
