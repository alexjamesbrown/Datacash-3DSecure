using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;

namespace CreditCardProcessing
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var pareq = (string)Session["pareq"];
                var acsUrl = (string)Session["acsUrl"];
                var termUrl = (string)Session["termUrl"];
                var md = (string)Session["md"];

                string data = String.Format("PaReq={0}&TermUrl={1}&MD={2}", Server.UrlEncode(pareq), termUrl, md);

                var req = (HttpWebRequest)WebRequest.Create(acsUrl);

                byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(pareq);

                byte[] buffer = Encoding.UTF8.GetBytes(data);

                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = buffer.Length;

                using (var reqst = req.GetRequestStream())
                {
                    reqst.Write(buffer, 0, buffer.Length);
                    reqst.Flush();
                    reqst.Close();

                    using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
                    {
                        Stream resst = res.GetResponseStream();
                        StreamReader sr = new StreamReader(resst);
                        string response = sr.ReadToEnd();

                        Response.Write(response);
                    }
                }
            }
        }
    }
}
