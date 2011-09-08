using System;
using DataCash;
using System.Configuration;

namespace DataCash3DSecure
{
    public partial class ResponsePage : System.Web.UI.Page
    {
        private Config config;
        private Agent agent;

        protected void Page_Load(object sender, EventArgs e)
        {
            config = new Config(AppDomain.CurrentDomain.BaseDirectory + "datacash.conf"); // would probably need to come from web.config
            agent = new Agent(config);

            var MD = Request.Form["MD"].Split('|');
            var pares = Request.Form["pares"];

            //this is the datacash reference number...
            var datacash_reference = MD[0];

            //this holds our order id..
            var ourReference = MD[1];

            var result = authoriseTransaction(datacash_reference, pares);

            switch (result)
            {
                case 1:
                    /*this is where we need to call whatever functionality within our application that
                    marks the order as complete / paid for.*/
                    redirect("OrderComplete.aspx");
                    break;

                case 168:
                    //3DS transaction could not be authenticated....
                    break;

                case 188:
                    //unable to authenticate:
                    //http://datacash.custhelp.com/cgi-bin/datacash.cfg/php/enduser/std_adp.php?p_faqid=881
                    break;

                //basically, if any thing other than 1, the authentication failed - log and show error to user????
            }

            //else.....
            //some error:
            redirect("Error.aspx");
        }

        //had to create this method, as it is an iframe, need to redirect using Javascript....
        protected void redirect(string page)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "scriptid", "window.parent.location.href='" + page + "'", true);
        }

        private int authoriseTransaction(string datacash_ref)
        {
            return authoriseTransaction(datacash_ref, null);
        }
        private int authoriseTransaction(string datacash_ref, string pares)
        {
            var authRequest = new Document(config);

            authRequest.set("Request.Authentication.client", ConfigurationManager.AppSettings["DataCashVtid"]);
            authRequest.set("Request.Authentication.password", ConfigurationManager.AppSettings["DataCashPassword"]);

            authRequest.set("Request.Transaction.HistoricTxn.reference", datacash_ref);

            if (pares != null)
                authRequest.set("Request.Transaction.HistoricTxn.pares_message", pares);

            authRequest.set("Request.Transaction.HistoricTxn.method", "threedsecure_authorization_request");

            var authResponse = agent.send(authRequest);

            var resultStatus = Convert.ToInt32(authResponse.get("Result.status"));

            return resultStatus;
        }
    }
}