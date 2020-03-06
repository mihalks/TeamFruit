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
using System.IO;


namespace studentOrganizer
{
    
    public static class Parser
    {
        public static string Pars()
        {
            
         if (System.IO.File.Exists("./TimeTabel.json"))
            {
                Console.WriteLine("true");

            }
            else 
            {
                 Console.WriteLine("False");
                 
                 //Здесь надо прописать запросы
                 
                using (FileStream fstream = new FileStream("./TimeTabel.json", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes("РАСПИСАНИЕ");//передать переменую полученую из запроса
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");
            }
            }
            return "";// подумать что должно возвращаться
        }


    }
}