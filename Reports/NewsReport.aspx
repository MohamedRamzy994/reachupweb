<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsReport.aspx.cs" Inherits="AppletSoftware.Views.Reports.NewsReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>APPLET Software</title>
    <link rel="icon" href="../Images/images/logo.png" />
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ToolPanelView="ParameterPanel" ToolPanelWidth="200px" />

        </div>
    </form>
   
</body>
</html>
