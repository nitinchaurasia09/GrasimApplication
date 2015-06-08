<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageTailor.aspx.cs" Inherits="GrasimApplication.TailorModule.ManageTailor" EnableViewState="true" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Page Content -->
    <div id="page-content-wrapper">
        <div class="container-fluid">
            <h3>Add/Edit Tailor</h3>
            <hr />
            <div class="alert alert-success" id="lblError" runat="server" visible="false">
            </div>
            <div class="modal-body">
                <form class="form-horizontal ">
                    <fieldset>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Tailor Name *</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtTailorName" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Email *</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" MaxLength="150"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Phone</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" MaxLength="12"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Address</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" MaxLength="25"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">City</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Pincode</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtPin" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Price range</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtPriceRange" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Country *</label>
                            <div class="col-lg-9">
                                <asp:DropDownList ID="ddlCountry" runat="server" Width="280px" AppendDataBoundItems="true" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                    <asp:ListItem Value="0">Select Country</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">State *</label>
                            <div class="col-lg-9">
                                <asp:DropDownList ID="ddlState" runat="server" Width="280px" AppendDataBoundItems="true" CssClass="form-control">
                                    <asp:ListItem Value="0">Select State</asp:ListItem>
                                </asp:DropDownList>
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
                            <label for="inputName" class="col-lg-3 control-label">Expertise</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtExpertise" runat="server" CssClass="form-control" MaxLength="250"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Description</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="280px" Columns="2" Rows="3" CssClass="form-control" MaxLength="250"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Feature *</label>
                            <div class="col-lg-9">
                                <asp:CheckBoxList ID="chkFeature" runat="server" RepeatDirection="Horizontal" CssClass="listSpace" AutoPostBack="true" OnSelectedIndexChanged="chkFeature_SelectedIndexChanged"></asp:CheckBoxList>
                            </div>
                        </div>
                        <div class="form-group clearfix" id="dvCategory" runat="server" visible="false">
                            <label for="inputName" class="col-lg-3 control-label">Category *</label>
                            <div class="col-lg-9">
                                <asp:CheckBoxList ID="chkCategory" runat="server" RepeatDirection="Horizontal" CssClass="listSpace"></asp:CheckBoxList>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Style *</label>
                            <div class="col-lg-9">
                                <asp:CheckBoxList ID="chkStyle" runat="server" RepeatDirection="Horizontal" CssClass="listSpace"></asp:CheckBoxList>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Image</label>
                            <div class="col-lg-9">
                                <asp:FileUpload ID="flTailorImage" runat="server" ViewStateMode="Disabled" />
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label"></label>
                            <div class="col-lg-9">
                                <asp:Image ID="imgTailor" runat="server" Width="100" Height="100" Visible="false" />
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Latitude *</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtLatitude" runat="server" CssClass="form-control" MaxLength="5"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Longitude *</label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="txtLongitude" runat="server" CssClass="form-control" MaxLength="5"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputName" class="col-lg-3 control-label">Search Latitude /Longitude</label>
                            <div class="col-lg-9">
                                <div id="map" style="width: 500px; height: 350px; border: 1px solid #999;"></div>
                                <input id="address" name="address" size="69" value=""><br />
                                <input type="submit" value="Submit" id="btnSearchGoogle" />
                            </div>
                        </div>
                    </fieldset>
                </form>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Back" CssClass="btn btn-warning" PostBackUrl="ShowAllTailors.aspx" />
            </div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->
    <script src="http://maps.google.com/maps/api/js?sensor=false" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#MainContent_btnSave').click(function () {
                var reg = new RegExp("^-?([1-8]?[1-9]|[1-9]0)\.{1}\d{1,6}");
                if ($('#MainContent_txtTailorName').val().trim() == '') {
                    alert('Please enter Tailor Name');
                    return false;
                }
                if ($('#MainContent_txtEmail').val().trim() == '') {
                    alert('Please enter Email');
                    return false;
                } else {
                    if (IsEmail($('#MainContent_txtEmail').val()) == false) {
                        alert('Please enter correct Email');
                        return false;
                    }
                }
                if ($('#MainContent_txtPhone').val().trim() != '') {
                    //return false;
                }

                if ($('#MainContent_ddlCountry').val().trim() == '0') {
                    alert('Please select country');
                    return false;
                }

                if ($('#MainContent_ddlState').val().trim() == '0') {
                    alert('Please select state');
                    return false;
                }


                if ($('#MainContent_flTailorImage').val().trim() != '') {
                    if (($('#MainContent_flTailorImage')[0].files[0].size / (1024 * 1024)) > 2) {
                        alert('File size should not be more than 2 MB');
                        return false;
                    }
                }
                if ($('#MainContent_txtLatitude').val().trim() == '') {
                    alert('Please enter Latitude');
                    return false;
                } else {
                    if (reg.exec($('#MainContent_txtLatitude').val()) == false) {
                        alert('Invalid Latitude');
                    }
                }
                if ($('#MainContent_txtLongitude').val().trim() == '') {
                    alert('Please enter Longitude');
                    return false;
                } else {
                    if (reg.exec($('#MainContent_txtLongitude').val()) == false) {
                        alert('Invalid Longitude');
                    }
                }

                var checkBoxListCategory = document.getElementById("<%=chkCategory.ClientID %>");
                var checkboxesCategory = checkBoxListCategory.getElementsByTagName("input");
                var isValid = false;
                for (var i = 0; i < checkboxesCategory.length; i++) {
                    if (checkboxesCategory[i].checked) {
                        isValid = true;
                        break;
                    }
                }
                if (isValid == false) {
                    alert('Please select atleast one Category');
                    return false;
                }

                var checkBoxListStyle = document.getElementById("<%=chkStyle.ClientID %>");
                var checkboxesStyle = checkBoxListStyle.getElementsByTagName("input");
                var isValid = false;
                for (var i = 0; i < checkboxesStyle.length; i++) {
                    if (checkboxesStyle[i].checked) {
                        isValid = true;
                        break;
                    }
                }
                if (isValid == false) {
                    alert('Please select atleast one Style');
                    return false;
                }

                var checkBoxListFeature = document.getElementById("<%=chkFeature.ClientID %>");
                var checkboxesFeature = checkBoxListFeature.getElementsByTagName("input");
                var isValid = false;
                for (var i = 0; i < checkboxesFeature.length; i++) {
                    if (checkboxesFeature[i].checked) {
                        isValid = true;
                        break;
                    }
                }
                if (isValid == false) {
                    alert('Please select atleast one Feature');
                    return false;
                }
            });
        });

        function IsEmail(email) {
            var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            return regex.test(email);
        }

        window.onload = function () {
            // find DOM elements

            var latField = $('#MainContent_txtLatitude');
            var lngField = $('#MainContent_txtLongitude');
            var canvas = document.getElementById('map');
            var options = {
                zoom: 10,
                center: new google.maps.LatLng(37.09, -95.71),
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var map = new google.maps.Map(canvas, options);
            var marker = new google.maps.Marker({
                draggable: true,
                map: map
            });
            // After dragging, updates both Lat and Lng.
            google.maps.event.addListener(marker, 'dragend', function () {
                var curLatLng = marker.getPosition();
                latField.val(curLatLng.lat());
                lngField.val(curLatLng.lng());
            });

            google.maps.event.trigger(marker, "click");

            var infowindow = new google.maps.InfoWindow();
            var geocoder = new google.maps.Geocoder();
            // set handler for form.onsubmit event
            $("#btnSearchGoogle").click(function () {
                return showAddressOnMap($('#address').val());
            })

            // worker function to display marker on map at address
            function showAddressOnMap(address) {
                try {
                    var geocoderRequest = {
                        address: address
                    }
                    geocoder.geocode(geocoderRequest, function (results, status) {
                        if (status == google.maps.GeocoderStatus.OK) {
                            var location = results[0].geometry.location;
                            map.setCenter(location);
                            marker.setPosition(location);
                            var content = [];
                            content.push('<strong>' + results[0].formatted_address + '</strong>');
                            content.push('Lat: ' + location.lat());
                            content.push('Lng: ' + location.lng());
                            infowindow.setContent(content.join('<br/>'));
                            infowindow.open(map, marker);
                            latField.value = location.lat();
                            lngField.value = location.lng();
                        }
                    });
                    return false;
                }
                catch (e) {
                    return false;//ensure form does not submit, even if there's an error
                }
            }
        };
    </script>
</asp:Content>
