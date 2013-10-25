<%@ Page Language="C#" AutoEventWireup="true" %>

<%@ Register Assembly="System.Web.Silverlight" Namespace="System.Web.UI.SilverlightControls"
    TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" style="height:100%;">
<head runat="server">
    <title>Bonus</title>
    <script type="text/javascript">
        function sendMessage(message) {
            var mySilverlightControl2 = document.getElementById("Xaml2");
            mySilverlightControl2.content.bridge.SetMessage(message);
        }
    </script>
</head>
<body style="height:100%;margin:0;">
    <form id="form1" runat="server" style="height:100%;">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                
        <div style="height:100px; padding:20px;">
            <asp:Silverlight ID="Xaml1" runat="server" Source="~/ClientBin/App1.xap" MinimumVersion="2.0.30917.0" Width="100%" Height="100%" />
        </div>
        
        <br />
        
        <div style="height:100px; padding:20px;">
            <asp:Silverlight ID="Xaml2" runat="server" Source="~/ClientBin/App2.xap" MinimumVersion="2.0.30917.0" Width="100%" Height="100%" />
        </div>
    </form>
</body>
</html>