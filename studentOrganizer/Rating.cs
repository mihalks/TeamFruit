using System;
using System.Net;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;

namespace studentOrganizer
{
    public static class Rating
    {
        public static List<RatingSubject> GetRating(string studnumber, string paspnumber)
        {
            //string url = "https://api.allorigins.win/get?url=https://www.isuct.ru/student/rating/view?paspnumber=732022&studnumber=3180435";
            string url = $"https://www.isuct.ru/student/rating/view?paspnumber={paspnumber}&studnumber={studnumber}";
            using (var httpClient = new HttpClient())
            {
                var content = new List<RatingSubject>();
                var response = httpClient.GetStringAsync(url).Result;
                var html = new HtmlAgilityPack.HtmlDocument();
                html.LoadHtml(response);
                var nodeCollection = html.DocumentNode.SelectNodes("//tr");

                foreach (var node in nodeCollection)
                {
                    //var childNodes = node.ChildNodes;
                    var childNodeArr = node.ChildNodes.ToArray();
                    var subject = new RatingSubject();

                    subject.Semester = childNodeArr[0].InnerText;
                    subject.SubjectName = childNodeArr[1].InnerText;
                    subject.Type = childNodeArr[2].InnerText;
                    subject.FinalScore = childNodeArr[3].InnerText;
                    subject.Term = childNodeArr[4].InnerText;
                    subject.FirstCheckPointScore = childNodeArr[5].InnerText;
                    subject.NumberOfAbsenteeismAtTheFirstCheckpoint = childNodeArr[6].InnerText;
                    subject.SecondCheckPointScore = childNodeArr[7].InnerText;
                    subject.NumberOfAbsenteeismAtTheSecondCheckpoint = childNodeArr[8].InnerText;
                    subject.ThirdCheckPointScore = childNodeArr[9].InnerText;
                    subject.NumberOfAbsenteeismAtTheThirdCheckpoint = childNodeArr[10].InnerText;

                    content.Add(subject);
                }
                content.RemoveAt(0); // это список предметов 
                return content;
            }
        }
    }
}