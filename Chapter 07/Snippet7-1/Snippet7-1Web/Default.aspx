<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="silverlightControlHost">
        <object data="data:application/x-silverlight," type="application/x-silverlight-2" width="100%" height="100%">
			<param name="source" value="ClientBin/Snippet7-1.xap"/>
			<param name="onerror" value="onSilverlightError" />
			<param name="background" value="white" />
			
			<a href="http://go.microsoft.com/fwlink/?LinkID=115261" style="text-decoration: none;">
     			<img src="http://go.microsoft.com/fwlink/?LinkId=108181" alt="Get Microsoft Silverlight" style="border-style: none"/>
			</a>
		</object>
    </div>
    </form>
</body>
</html>
