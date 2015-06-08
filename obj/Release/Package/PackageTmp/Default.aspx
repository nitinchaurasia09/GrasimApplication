<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GrasimApplication.Default" %>

<!doctype html>
<html lang="en" data-ng-app="meetingRoomApp" data-ng-controller="main-ctrl">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Grasim Control Panel</title>
    <link href="Content/Site.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/font-awesome.min.css" rel="stylesheet" />
    <link href="Content/simple-sidebar.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.min.js"></script>
</head>
<body>
    <form runat="server">
        <header>
            <div id="navbar-example" role="navigation" class="navbar navbar-default navbar-fixed-top">
                <div class="container">
                    <div class="navbar-header">
                        <a href="../" class="navbar-brand">Grasim Control Panel</a>
                    </div>
                    <div class="navbar-collapse navbar-responsive-collapse collapse" aria-expanded="false" style="height: 1px;">
                    </div>
                </div>
            </div>
        </header>
          <div id="page-content-wrapper">
            <div class="container-fluid">
                <div class="alert alert-danger" id="lblError" runat="server" visible="false">
                </div>
            </div>
        </div>
        <div id="wrapper">
            <div class="container">
                <div class="row">
                    <div class="col-md-offset-5 col-md-3">
                        <div class="form-login">
                            <h4>Welcome to Grasim.</h4>
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control input-sm chat-input"></asp:TextBox>
                            <br>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control input-sm chat-input"></asp:TextBox>
                            <br>
                            <div class="wrapper">
                                <span class="group-btn">
                                    <asp:LinkButton ID="lbtnLogin" runat="server" CssClass="btn btn-primary btn-md" OnClick="lbtnLogin_Click">login <i class="fa fa-sign-in"></i></asp:LinkButton>
                                </span>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <script src="../Scripts/bootstrap.min.js"></script>
        <script src="../Scripts/bootswatch.js"></script>
    </form>
</body>
</html>
