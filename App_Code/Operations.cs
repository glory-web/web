using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Operations
/// </summary>
public class Operations
{
	public Operations()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public static  string Key_Search_Color(string text,string key)
    {
        if (String.IsNullOrEmpty(key) || key == "")
            return text;
        string StartTag = "<span style='background-color: #ffff66'>", EndTag = "</span>";
        if (string.IsNullOrEmpty(key))
            key = "";
        Regex reg = new Regex(key);
        return reg.Replace(text, StartTag + key + EndTag);

    }
    public static string FirstWords(string input, int numberWords)
    {
        try
        {
            // Number of words we still want to display.
            int words = numberWords;
            // Loop through entire summary.
            for (int i = 0; i < input.Length; i++)
            {
                // Increment words on a space.
                if (input[i] == ' ')
                {
                    words--;
                }
                // If we have no more words to display, return the substring.
                if (words == 0)
                {
                    return input.Substring(0, i);
                }
            }
        }
        catch (Exception)
        {
            // Log the error.
        }
        return string.Empty;
    }
    public static string FirstDot(string input)
    {
        try
        {
            return input.Substring (0,input.IndexOf ('.'));
        }
        catch (Exception)
        {
            return string.Empty;
            // Log the error.
        }
        
    }
}
