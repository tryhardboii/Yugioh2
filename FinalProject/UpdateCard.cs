using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace FinalProject
{
    class UpdateCard
    {
        public static string Database = "https://db.ygoprodeck.com/api/v4/cardinfo.php";
        public static string Start()
        {
            var request = (HttpWebRequest)WebRequest.Create(Database);

            var res = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(res.GetResponseStream()).ReadToEnd();

            return responseString;
        }
    }
}
