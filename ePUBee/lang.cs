using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace ePUBee
{
    class getLang { 
        public static String getString(String str){
            lang langlist = new lang();
            return langlist.getString(str);

        }
    }
    class lang
    {   
        private Hashtable langstr = new Hashtable();
        public String getString(String str){
            return langstr[str].ToString();
        }
        public lang()
        {
            if (langstr.Count == 0) { 
            langstr.Add("quickpublish", "Quick Publish");
            langstr.Add("publish", "Publish");
            langstr.Add("saveaspdf", "SaveAs PDF");
            langstr.Add("aboutus", "About us");
            langstr.Add("donate", "Donate");
            langstr.Add("publishing", "Publishing");
            langstr.Add("processing", "Processing");
            langstr.Add("others", "Others");
            langstr.Add("ok", "OK");
            //langstr.Add("", "");
            //langstr.Add("", "");
            //langstr.Add("", "");
            //langstr.Add("", "");
            //langstr.Add("", "");
            //langstr.Add("", "");
            //langstr.Add("", "");
            //langstr.Add("", "");
            //langstr.Add("", "");
            //langstr.Add("", "");
            //langstr.Add("", "");
            //langstr.Add("", "");
            //langstr.Add("", "");
            }
        }
    }
}
