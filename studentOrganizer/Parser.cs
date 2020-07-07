using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace studentOrganizer
{
    public static class Parser
    {
        public static string Pars(string group) 
        // еше не готов, проблемы с обработкой полученных данных и стабильностью отправленных вызовов. 
        //нужно искать, как самому генерировать form_buid_id и theme_token, либо брать как-то из другого запроса
        {
            if (System.IO.File.Exists("./TimeTable.json"))
            {
                Console.WriteLine("true");
                string[] TimeTable = File.ReadAllLines("./TimeTable.json");//html agility pack
            }
            else
            {
                Console.WriteLine("False");

                // //Здесь надо прописать запросы
                // //попробовал - что-то пошло не так
                string idgr;
                string idgrid;
                Parser.GetGroupID(group, out idgr, out idgrid);
                var a = Parser.GetSchedule(idgr, idgrid, "form-NuSVQj4_dVc7nTZ6wtgFvoWrZnQbZyFOGIpFGBhXo7k", "dESk-vzGrzFaEo7EC6r-rBN7NwuA1neQikPP2EHkzjc");

                // using (FileStream fstream = new FileStream("./TimeTabel.json", FileMode.OpenOrCreate))
                // {
                //     // преобразуем строку в байты
                //     byte[] array = System.Text.Encoding.Default.GetBytes("РАСПИСАНИЕ");// передать переменую полученую из запроса
                //                                                                        // запись массива байтов в файл
                //     fstream.Write(array, 0, array.Length);
                //     string[] TimeTable = File.ReadAllLines("./TimeTabel.json");
                //     Console.WriteLine("Текст записан в файл");
                // }
                return a;
            }
            return ""; //подумать что должно возвращаться
        }

        public static void GetGroupID(string group, out string idgr, out string idgrid) // запрос для получения idgroup и idgrid(просто надо) 
        {
            string url = "https://www.isuct.ru/index.php?q=student/schedule/currentstudentsgroups";

            var pars = new List<KeyValuePair<string, string>>();

            pars.Add(new KeyValuePair<string, string>("search", group));

            var str = Post2(url, pars).Result;
            /*var pars = new NameValueCollection();
            pars.Add("search", group);
            string str = Encoding.UTF8.GetString(Post(url, pars));*/
            System.Console.WriteLine("\nResponse received was :\n{0}", str);

            idgr = group;
            Regex regex = new Regex(@"\d{5}|\d{4}");
            Match match2 = regex.Match(str);
            idgrid = match2.ToString();
            // распарсить ответ и передавать результаты дальше в метод Parse.GetSchedule() для получения расписания (сделал, наверное)
        }

        public static string GetSchedule(string idgr, string idgrid, string form_build_id, string ajax_page_state_theme_token) // дописать, чтобы получать расписание любой группы, пока что для 3/42 (сделаю, наверное)
        {
            string url = "https://www.isuct.ru/system/ajax"; // туда запрос

            var queryData = new List<KeyValuePair<string, string>>();

            queryData.Add(new KeyValuePair<string, string>("type", "currentstudentsgroups"));
            queryData.Add(new KeyValuePair<string, string>("idgr", idgr));
            queryData.Add(new KeyValuePair<string, string>("idaud", ""));
            queryData.Add(new KeyValuePair<string, string>("idprep", ""));
            queryData.Add(new KeyValuePair<string, string>("idprepid", ""));
            queryData.Add(new KeyValuePair<string, string>("idaudid", ""));
            queryData.Add(new KeyValuePair<string, string>("idgrid", idgrid));
            queryData.Add(new KeyValuePair<string, string>("form_build_id", form_build_id)); // здесь меняется
            queryData.Add(new KeyValuePair<string, string>("form_id", "studschedule_form"));
            queryData.Add(new KeyValuePair<string, string>("_triggering_element_name", "op"));
            queryData.Add(new KeyValuePair<string, string>("_triggering_element_value", "Показать расписание"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "visually-impaired-controls"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "id_vi_panel"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "xvi-images"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "vi_widget_link-offs"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "vi-sans-serif"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "vi-serif"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "vi-spacing-small"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "vi-spacing-normal"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "vi-spacing-big"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "vi-height-small"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "vi-height-normal"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "vi-height-big"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "vi-color1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "vi-color2"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "vi-color3"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "vi-color4"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "vi-color5"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "header_wrapper"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "top"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "topinfo"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "topinfo-left"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "topinfo-center"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "bt_widget-vi-on"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "vi_widget_link-on"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "Copy"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "bt_widget-vi-off"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "vi_widget_link-off"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "topinfo-right"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "block-locale-language"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "block-search-form"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "search-block-form"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "edit-search-block-form--2"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "ui-id-1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "edit-actions"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "edit-submit--2"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "header"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "logo"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "site-title"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "site-description"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "cbp-hrmenu"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "block-multiblock-2"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "block-multiblock-3"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "block-multiblock-4"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "block-block-39"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "block-multiblock-5"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "block-multiblock-9"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "block-block-37"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "block-multiblock-7"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "block-block-38"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "block-multiblock-8"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "block-block-16"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "main-menu"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "top-area"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "page-wrap"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "container"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "content"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "breadcrumbs"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "post-content"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "block-system-main"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "studschedule-form"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "edit-type"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "edit-type-auditorium"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "edit-type-prepod"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "edit-type-currentstudentsgroups"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "edit-idgr"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "edit-idgr-autocomplete"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "edit-idgr-autocomplete-aria-live"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "edit-idaud"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "edit-idaud-autocomplete"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "edit-idaud-autocomplete-aria-live"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "edit-idprep"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "edit-idprep-autocomplete"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "edit-idprep-autocomplete-aria-live"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "idprepid"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "idaudid"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "idgrid"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "edit-submit"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "form-ajax-node-content"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "undercontent"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "undercontentinfo"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "block-block-79"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "footer"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "footer-area"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "block-block-21"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "block-block-22"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "block-block-27"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "block-block-26"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "copyright"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "backtotop"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "popup-active-overlay"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "cboxOverlay"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "colorbox"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "cboxWrapper"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "cboxTopLeft"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "cboxTopCenter"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "cboxTopRight"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "cboxMiddleLeft"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "cboxContent"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "cboxTitle"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "cboxCurrent"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "cboxPrevious"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "cboxNext"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "cboxSlideshow"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "cboxLoadingOverlay"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "cboxLoadingGraphic"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "cboxMiddleRight"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "cboxBottomLeft"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "cboxBottomCenter"));
            queryData.Add(new KeyValuePair<string, string>("ajax_html_ids[]", "cboxBottomRight"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[theme]", "isuct"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[theme_token]", ajax_page_state_theme_token)); // здесь меняется
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][0]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][1]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][2]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][modules/system/system.base.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][modules/system/system.menus.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][modules/system/system.messages.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][modules/system/system.theme.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][misc/ui/jquery.ui.core.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][misc/ui/jquery.ui.theme.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][misc/ui/jquery.ui.menu.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][misc/ui/jquery.ui.autocomplete.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][misc/ui/jquery.ui.accordion.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][misc/ui/jquery.ui.button.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][misc/ui/jquery.ui.resizable.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][misc/ui/jquery.ui.dialog.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/modules/audtodayschedule/css/schedule.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/modules/calendar/css/calendar_multiday.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/modules/date/date_api/date.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/modules/date/date_popup/themes/datepicker.1.7.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/modules/date/date_repeat_field/date_repeat_field.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("jax_page_state[css][modules/field/theme/field.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][modules/node/node.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][modules/node/node.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/modules/ppslist/css/ppslist.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][modules/search/search.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/modules/studrating/css/styles.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/modules/studrating/css/jquery.dataTables.min.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/modules/studschedule/css/schedule.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][modules/user/user.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/modules/visuallyimpaired/css/styles.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/modules/views/css/views.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/modules/back_to_top/css/back_to_top.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/modules/ckeditor/css/ckeditor.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/modules/cctags/cctags.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/libraries/colorbox/example2/colorbox.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/modules/ctools/css/ctools.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/modules/panels/css/panels.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/modules/popup/popup.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/modules/textsize/textsize.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][modules/locale/locale.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/modules/custom_search/custom_search.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/modules/flexslider/assets/css/flexslider_img.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/libraries/flexslider/flexslider.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/modules/search_autocomplete/css/themes/basic-green.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/modules/search_autocomplete/css/themes/minimal.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/modules/search_autocomplete/css/themes/user-blue.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/modules/eu_cookie_compliance/css/eu_cookie_compliance.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][https://www.isuct.ru/sites/all/modules/storefront_cps/style.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/themes/isuct/css/font-awesome.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/themes/isuct/css/style.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/themes/isuct/css/media.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[css][sites/all/themes/isuct/css/component.css]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][0]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][1]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][2]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/flexslider/assets/js/flexslider.load.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/eu_cookie_compliance/js/eu_cookie_compliance.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/jquery_update/replace/jquery/1.8/jquery.min.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][misc/jquery-extend-3.4.0.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][misc/jquery.once.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][misc/drupal.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/jquery_update/replace/ui/ui/minified/jquery.ui.core.min.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/jquery_update/replace/ui/ui/minified/jquery.ui.widget.min.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/jquery_update/replace/ui/ui/minified/jquery.ui.effect.min.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/eu_cookie_compliance/js/jquery.cookie-1.4.1.min.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/jquery_update/replace/misc/jquery.form.min.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/jquery_update/replace/ui/ui/minified/jquery.ui.position.min.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/jquery_update/replace/ui/ui/minified/jquery.ui.menu.min.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/jquery_update/replace/ui/ui/minified/jquery.ui.autocomplete.min.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/jquery_update/replace/ui/ui/minified/jquery.ui.accordion.min.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/jquery_update/replace/ui/ui/minified/jquery.ui.button.min.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/jquery_update/replace/ui/ui/minified/jquery.ui.mouse.min.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/jquery_update/replace/ui/ui/minified/jquery.ui.draggable.min.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/jquery_update/replace/ui/ui/minified/jquery.ui.resizable.min.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/jquery_update/replace/ui/ui/minified/jquery.ui.dialog.min.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][misc/ajax.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/jquery_update/js/jquery_update.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/admin_menu/admin_devel/admin_devel.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/audtodayschedule/js/my.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/ppslist/js/my.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/studrating/js/my.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/studrating/js/jquery.dataTables.min.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/studschedule/js/my.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/visuallyimpaired/js/js.for.the.visually.impaired.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/visuallyimpaired/js/js.cookie.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/webform_steps/webform_steps.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/back_to_top/js/back_to_top.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][public://languages/ru_rJV0hRSXXwygvsLzqDEmn6qNlLb9lZOMo7QpRnIbSyU.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/autocomplete_post/autocomplete_post.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/libraries/colorbox/jquery.colorbox-min.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/colorbox/js/colorbox.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/colorbox/js/colorbox_load.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/colorbox/js/colorbox_inline.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/iframe/iframe.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/jcaption/jcaption.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/popup/popup.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/libraries/jstorage/jstorage.min.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/textsize/jquery.textsize.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][misc/jquery.cookie.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/custom_search/js/custom_search.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][misc/autocomplete.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][misc/progress.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/themes/fix/js/colorbox-fix.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/libraries/easing/jquery.easing.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/libraries/flexslider/jquery.flexslider-min.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/modules/search_autocomplete/js/jquery.autocomplete.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/themes/isuct/js/custom.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/themes/isuct/js/cbpHorizontalMenu.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[js][sites/all/themes/isuct/js/modernizr.custom.js]", "1"));
            queryData.Add(new KeyValuePair<string, string>("ajax_page_state[jquery_version]", "1.8"));

            Encoding utf8 = new UTF8Encoding(true);

            //string rawSchedule = System.Text.Encoding.UTF8.GetString(Post(url, queryData));
            string rawSchedule = Post2(url, queryData).Result;
            rawSchedule = Regex.Unescape(rawSchedule);

            //var htmlCleaner = new Regex("^<td> </td>$", RegexOptions.Singleline);
            //var b = htmlCleaner.Matches(rawSchedule);

            //var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            //htmlDoc.LoadHtml(rawSchedule);
            //JObject o = JObject.Parse(rawSchedule);

            //var jObject = JsonConvert.DeserializeObject(rawSchedule);


            //var result = htmlDoc.GetElementbyId("form-ajax-node-content").ChildNodes.Where(x => x.Name == "tr");

            Byte[] encodedBytes = utf8.GetBytes(rawSchedule);

            using (FileStream fileWithSchedule = new FileStream("./TimeTable.html", FileMode.OpenOrCreate))
            {
                fileWithSchedule.WriteAsync(encodedBytes, 0, encodedBytes.Length);
                Console.WriteLine("Wrote {0} bytes to the file.", fileWithSchedule.Length);
            }

            using (var sr = new StreamReader("TimeTable.html", Encoding.UTF8))
            {
                string line = string.Empty;
                line = sr.ReadToEnd();
                Console.WriteLine(line);
            }
            return rawSchedule;
        }
        private static byte[] Post(string url, NameValueCollection queryData) // старый Post метод, через WebClient
        {
            using (var webClient = new WebClient())
            {
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                byte[] responseArr = webClient.UploadValues(url, "POST", queryData);
                return responseArr;
            }
        }
        private static async Task<string> Post2(string url, List<KeyValuePair<string, string>> queryData) // новый, через HttpClient
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var content = new FormUrlEncodedContent(queryData);
                var result = await httpClient.PostAsync(url, content);
                string rawSchedule = result.Content.ReadAsStringAsync().Result;
                return rawSchedule;
            }
        }
    }
}
