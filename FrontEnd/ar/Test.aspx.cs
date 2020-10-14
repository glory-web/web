using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ar_Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string s = "1#2#3#";
        string[] array = new string[3];
        string sas = s.Substring(1,5);
        for (int i = 0; i < 3; i++)
        {
            int end = s.LastIndexOf('#');
            string temp = s.Substring(0, s.LastIndexOf('#'));
            int strat = temp.LastIndexOf("#");
            array[i] = s.Substring(strat+1 , end - strat - 1);
            
            s = s.Substring(0, s.LastIndexOf('#') - array[i].Length );


        }
        /*for (int i = 0; i < 3; i++)
        {
            int start = s.IndexOf('#');
            string temp = s.Substring(0, start);
        }*/

    }
    protected void Search1_Load(object sender, EventArgs e)
    {

    }
}
