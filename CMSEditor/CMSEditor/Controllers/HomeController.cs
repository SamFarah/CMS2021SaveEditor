using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSEditor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Translate()
        {
            string path = @"C:\Users\osama\Source\Repos\SamFarah\CMS2021SaveEditor\CMSEditor\CMSEditor\TempSaves\Translate.txt";
            StreamReader sr = new StreamReader(path, true);

            Dictionary<string, string> TempPolishToEnglish = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            List<string> Redo = new List<string>() ;

            // Process Uploaded File            
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                if (line.StartsWith("!"))
                {
                    var parts = line.Split('=');
                    var Key = parts[0].TrimStart('!');
                    var value = parts[1];

                    if (value.StartsWith("^!"))
                    {
                        Redo.Add(Key);                        
                    }


                    if (!TempPolishToEnglish.ContainsKey (Key))
                        TempPolishToEnglish.Add(Key, value);

                    
                }
            }

            foreach (var item in Redo)
            {
                
                var LastPart = TempPolishToEnglish[item].Split(' ').Skip(1).ToArray();
                try
                {
                    TempPolishToEnglish[item] = TempPolishToEnglish[TempPolishToEnglish[item].Split(' ')[0].TrimStart('^').TrimStart('!')] + ' ' + string.Join(" ", LastPart);
                }
                catch (Exception)
                {

                    
                }
                
            }

            sr.Close();

            Response.Write(string.Join(",",TempPolishToEnglish.Select(x=> $"{{\"{x.Key}\",\"{x.Value}\"}}" ).ToList()));

            return View("Index");
        }
    }
}