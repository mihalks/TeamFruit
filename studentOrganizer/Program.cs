using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Collections.Specialized;

namespace studentOrganizer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            // Parser.Pars();

            // Ниже - те запросы, которые могу получать расписание для любой группы
            // чтобы они работали правильно, нужно адекватно связать их с методом Parser.Pars()
            // так чтобы, Parser.Pars() принимал просто группу например "3/42", 
            // в нем вызывались методы GetGroupID и GetSchedule. они уже сделают всё что надо
            // а потом результат всего этого отобразить на странице сайта
            // P.S. переправить второй метод для того чтобы он писал всё БД 
            // или переправить метод Parser.Pars чтобы он просто дозаписывал TimeTabel.json
            //
            // string idgr;
            // string idgrid;
            // Parser.GetGroupID("3/42", out idgr, out idgrid);
            // Parser.GetSchedule(idgr,idgrid);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
