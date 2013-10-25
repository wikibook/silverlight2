using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Collections.Generic;

namespace SilverlightInAction.Web
{
  /// <summary>
  /// Summary description for SampleAsmx
  /// </summary>
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [ToolboxItem(false)]
  // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
  // [System.Web.Script.Services.ScriptService]
  public class SampleAsmx : System.Web.Services.WebService
  {

    [WebMethod]
    public DateTime GetTime()
    {
      return DateTime.Now;
    }
  }
}
