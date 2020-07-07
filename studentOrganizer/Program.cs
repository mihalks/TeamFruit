using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text;
using System.Collections.Specialized;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace studentOrganizer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            //Parser.Pars();

            // Ниже - те запросы, которые могу получать расписание для любой группы
            // чтобы они работали правильно, нужно адекватно связать их с методом Parser.Pars()
            // так чтобы, Parser.Pars() принимал просто группу например "3/42", 
            // в нем вызывались методы GetGroupID и GetSchedule. они уже сделают всё что надо
            // а потом результат всего этого отобразить на странице сайта
            // P.S. переправить второй метод для того чтобы он писал всё БД 

            /*string idgr;
            string idgrid;
            // рандомно меняются, приходится из запроса в браузере доставать, работают до закрытия текущей сессии, из которой взяты
            string form_id = "form-BizhEQw09_e7Rez3d4zBZ0STRH-tHa2QW-herrutjEs";

            string theme_token = "j_35vXGHVLg-BZ5L06_X0qhsnX2aD2fXvOPGdPsp6cs";

            Parser.GetGroupID("3/42", out idgr, out idgrid);
            Console.WriteLine(idgrid);
            var str = Parser.GetSchedule(idgr, idgrid, form_id, theme_token);*/
            
            //Console.WriteLine(str);
            //Utf8JsonReader
            //var a = JsonSerializer.Deserialize(str, );
            //string str = a.ToString();
            //Console.WriteLine(Encoding.UTF8.GetBytes(a));

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
