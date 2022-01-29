using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net.Http;
using System.Net;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ShiloApi.Controllers
{ 
    [EnableCors("shilo")]
    [ApiController]
    [Route("[controller]")]
    public class KolWedController : ControllerBase
    {
        //a static List of bands
        public static List<ewdingBand> BandData = new List<ewdingBand>();
        // An instance of data communication to the database
        
        public KolWedController()
        {
            
        }
        
        [HttpGet("weding")]
        // Creates a croler that searches YouTube for wedding bands and returns a list of 
        //wedding bands with a URL for a video and a description of the band
        public async Task<List<ewdingBand>> StartWedingCrawlerasync()
        {
            // Clear the list not to create duplicates
            BandData.Clear();
            List<string> urls = new List<string>();
            string url1 = "https://www.youtube.com/results?search_query=להקת+חתונות";
            var httpClient = new HttpClient();
            var httpClient2 = new HttpClient();
            var html1 = await httpClient.GetStringAsync(url1);
            var htmlDok = new HtmlDocument();
            htmlDok.LoadHtml(html1);
            var abcHtml = htmlDok.DocumentNode.Descendants("script").ToList();
            int index = 0;
            // Look for the location of the URL within the JS / HTML document
            //And crop the URL
            foreach (var i in abcHtml)
            {
                index += 1;
                if (i.InnerText.Contains("webCommandMetadata") && i.InnerText.Contains("navigationEndpoint"))
                {
                    Console.WriteLine(index);
                    string[] objects = i.InnerText.Split('"');
                    foreach (string item in objects)
                    {
                        if (item.Contains("/watch?v="))
                        {
                            urls.Add(item);

                        }
                    }

                }


            }
            // Look up the description on each band page and cut it into a list
            foreach (string web in urls)
            {

                string[] objects1 = (await httpClient2.GetStringAsync("https://www.youtube.com" + web)).Split(',');
                foreach (string str in objects1)
                {
                    if (str.Contains("shortDescription") && !str.Contains("playerVars"))
                    {
                        ewdingBand newBand = new ewdingBand() { url = web, bendData = str };
                        BandData.Add(newBand);
                    }
                }
            }
            return BandData;
        }
        
    }
}
