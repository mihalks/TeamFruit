using System;
using System.Net;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace studentOrganizer
{
    public static class Timetable
    {
        public static object GetTimetable(string group)
        {
            var correctGr = Regex.Replace(group, "/", "-"); // желательно, чтобы сразу нормально отправлялось
            /*using (var sr = new StreamReader("TimetableApi.json", Encoding.UTF8)) // старый код для работы через файл
            {
                var jsonStr = sr.ReadToEnd();
                var fullTimetable = JsonConvert.DeserializeObject<FullTimeTable>(jsonStr);
                var gr = fullTimetable.Faculties.First(x => x.Groups.Any(x => x.Name == correctGr)).Groups.First(x => x.Name == correctGr);
                return gr;
            }*/
            using (var http = new HttpClient())
            {
                var jsonStr = http.GetStringAsync("https://forms.isuct.ru/timetable/rvuzov").Result;
                var fullTimetable = JsonConvert.DeserializeObject<FullTimeTable>(jsonStr);
                var gr = fullTimetable.Faculties.First(x => x.Groups.Any(x => x.Name == correctGr)).Groups.First(x => x.Name == correctGr);
                return gr;
            }
        }
    }
}