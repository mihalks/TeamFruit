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
                string[] TimeTable = File.ReadAllLines("./TimeTable.json");
                // добавлено по просьбе Кости, кидается исключениями. Опечатка в названии "TimeTabel"?
            }
            else
            {
                Console.WriteLine("False");

                //Здесь надо прописать запросы
                Parser.GetSchedule(Parser.GetGroupID("3/42")); // поменять эту строчку, когда переделаю запросы

                using (FileStream fstream = new FileStream("./TimeTabel.json", FileMode.OpenOrCreate))
                {
                    // преобразуем строку в байты
                    byte[] array = System.Text.Encoding.Default.GetBytes("РАСПИСАНИЕ");// передать переменую полученую из запроса
                                                                                       // запись массива байтов в файл
                    fstream.Write(array, 0, array.Length);
                    string[] TimeTable = File.ReadAllLines("./TimeTable.json");
                    // добавлено по просьбе Кости, кидается исключениями. Опечатка в названии "TimeTabel"?
                    fstream.Close(); // оказывается потоки нужно закрывать, иначе рискуем получить исключение, что файл уже используется
                    Console.WriteLine("Текст записан в файл");
                }
            }
            return ""; //подумать что должно возвращаться
        }

        public static string GetGroupID(string group) // запрос для получения idgroup и idgrid(просто надо) 
        {
            string url = "https://www.isuct.ru/index.php?q=student/schedule/currentstudentsgroups";
            using (var webClient = new WebClient())
            {
                var pars = new NameValueCollection();
                pars.Add("search", group);
                var response = webClient.UploadValues(url, pars);
                string str = System.Text.Encoding.UTF8.GetString(response);
                return str;
                // распарсить ответ и передавать результаты дальше в метод Parse.GetSchedule() для получения расписания (сделаю, наверное)
            }
        }

        public static string GetSchedule(string groupID) // дописать, чтобы получать расписание любой группы, пока что для 3/42 (сделаю, наверное)
        {
            string url = "https://www.isuct.ru/system/ajax"; // туда запрос
            using (var webClient = new WebClient())
            {
                //не раскрывать - много текста
                #region 
                var pars = new NameValueCollection();
                pars.Add("type", "currentstudentsgroups");
                pars.Add("idgr", groupID);
                pars.Add("idaud", "");
                pars.Add("idprep", "");
                pars.Add("idprepid", "");
                pars.Add("idaudid", "");
                pars.Add("idgrid", "9687");
                pars.Add("form_build_id", "form-WnOwNmk3-tviflUmbW_vrncjxwu82eR14Ky0bydSNa0");
                pars.Add("form_id", "studschedule_form");
                pars.Add("_triggering_element_name", "op");
                pars.Add("_triggering_element_value", "Показать расписание");
                pars.Add("ajax_html_ids[]", "visually-impaired-controls");
                pars.Add("ajax_html_ids[]", "id_vi_panel");
                pars.Add("ajax_html_ids[]", "xvi-images");
                pars.Add("ajax_html_ids[]", "vi_widget_link-offs");
                pars.Add("ajax_html_ids[]", "vi-sans-serif");
                pars.Add("ajax_html_ids[]", "vi-serif");
                pars.Add("ajax_html_ids[]", "vi-spacing-small");
                pars.Add("ajax_html_ids[]", "vi-spacing-normal");
                pars.Add("ajax_html_ids[]", "vi-spacing-big");
                pars.Add("ajax_html_ids[]", "vi-height-small");
                pars.Add("ajax_html_ids[]", "vi-height-normal");
                pars.Add("ajax_html_ids[]", "vi-height-big");
                pars.Add("ajax_html_ids[]", "vi-color1");
                pars.Add("ajax_html_ids[]", "vi-color2");
                pars.Add("ajax_html_ids[]", "vi-color3");
                pars.Add("ajax_html_ids[]", "vi-color4");
                pars.Add("ajax_html_ids[]", "vi-color5");
                pars.Add("ajax_html_ids[]", "header_wrapper");
                pars.Add("ajax_html_ids[]", "top");
                pars.Add("ajax_html_ids[]", "topinfo");
                pars.Add("ajax_html_ids[]", "topinfo-left");
                pars.Add("ajax_html_ids[]", "topinfo-center");
                pars.Add("ajax_html_ids[]", "bt_widget-vi-on");
                pars.Add("ajax_html_ids[]", "vi_widget_link-on");
                pars.Add("ajax_html_ids[]", "Copy");
                pars.Add("ajax_html_ids[]", "bt_widget-vi-off");
                pars.Add("ajax_html_ids[]", "vi_widget_link-off");
                pars.Add("ajax_html_ids[]", "topinfo-right");
                pars.Add("ajax_html_ids[]", "block-locale-language");
                pars.Add("ajax_html_ids[]", "block-search-form");
                pars.Add("ajax_html_ids[]", "search-block-form");
                pars.Add("ajax_html_ids[]", "edit-search-block-form--2");
                pars.Add("ajax_html_ids[]", "ui-id-1");
                pars.Add("ajax_html_ids[]", "edit-actions");
                pars.Add("ajax_html_ids[]", "edit-submit--2");
                pars.Add("ajax_html_ids[]", "header");
                pars.Add("ajax_html_ids[]", "logo");
                pars.Add("ajax_html_ids[]", "site-title");
                pars.Add("ajax_html_ids[]", "site-description");
                pars.Add("ajax_html_ids[]", "cbp-hrmenu");
                pars.Add("ajax_html_ids[]", "block-multiblock-2");
                pars.Add("ajax_html_ids[]", "block-multiblock-3");
                pars.Add("ajax_html_ids[]", "block-multiblock-4");
                pars.Add("ajax_html_ids[]", "block-block-39");
                pars.Add("ajax_html_ids[]", "block-multiblock-5");
                pars.Add("ajax_html_ids[]", "block-multiblock-9");
                pars.Add("ajax_html_ids[]", "block-block-37");
                pars.Add("ajax_html_ids[]", "block-multiblock-7");
                pars.Add("ajax_html_ids[]", "block-block-38");
                pars.Add("ajax_html_ids[]", "block-multiblock-8");
                pars.Add("ajax_html_ids[]", "block-block-16");
                pars.Add("ajax_html_ids[]", "main-menu");
                pars.Add("ajax_html_ids[]", "top-area");
                pars.Add("ajax_html_ids[]", "page-wrap");
                pars.Add("ajax_html_ids[]", "container");
                pars.Add("ajax_html_ids[]", "content");
                pars.Add("ajax_html_ids[]", "breadcrumbs");
                pars.Add("ajax_html_ids[]", "post-content");
                pars.Add("ajax_html_ids[]", "block-system-main");
                pars.Add("ajax_html_ids[]", "studschedule-form");
                pars.Add("ajax_html_ids[]", "edit-type");
                pars.Add("ajax_html_ids[]", "edit-type-auditorium");
                pars.Add("ajax_html_ids[]", "edit-type-prepod");
                pars.Add("ajax_html_ids[]", "edit-type-currentstudentsgroups");
                pars.Add("ajax_html_ids[]", "edit-idgr");
                pars.Add("ajax_html_ids[]", "edit-idgr-autocomplete");
                pars.Add("ajax_html_ids[]", "edit-idgr-autocomplete-aria-live");
                pars.Add("ajax_html_ids[]", "edit-idaud");
                pars.Add("ajax_html_ids[]", "edit-idaud-autocomplete");
                pars.Add("ajax_html_ids[]", "edit-idaud-autocomplete-aria-live");
                pars.Add("ajax_html_ids[]", "edit-idprep");
                pars.Add("ajax_html_ids[]", "edit-idprep-autocomplete");
                pars.Add("ajax_html_ids[]", "edit-idprep-autocomplete-aria-live");
                pars.Add("ajax_html_ids[]", "idprepid");
                pars.Add("ajax_html_ids[]", "idaudid");
                pars.Add("ajax_html_ids[]", "idgrid");
                pars.Add("ajax_html_ids[]", "edit-submit");
                pars.Add("ajax_html_ids[]", "form-ajax-node-content");
                pars.Add("ajax_html_ids[]", "undercontent");
                pars.Add("ajax_html_ids[]", "undercontentinfo");
                pars.Add("ajax_html_ids[]", "block-block-79");
                pars.Add("ajax_html_ids[]", "footer");
                pars.Add("ajax_html_ids[]", "footer-area");
                pars.Add("ajax_html_ids[]", "block-block-21");
                pars.Add("ajax_html_ids[]", "block-block-22");
                pars.Add("ajax_html_ids[]", "block-block-27");
                pars.Add("ajax_html_ids[]", "block-block-26");
                pars.Add("ajax_html_ids[]", "copyright");
                pars.Add("ajax_html_ids[]", "backtotop");
                pars.Add("ajax_html_ids[]", "popup-active-overlay");
                pars.Add("ajax_html_ids[]", "cboxOverlay");
                pars.Add("ajax_html_ids[]", "colorbox");
                pars.Add("ajax_html_ids[]", "cboxWrapper");
                pars.Add("ajax_html_ids[]", "cboxTopLeft");
                pars.Add("ajax_html_ids[]", "cboxTopCenter");
                pars.Add("ajax_html_ids[]", "cboxTopRight");
                pars.Add("ajax_html_ids[]", "cboxMiddleLeft");
                pars.Add("ajax_html_ids[]", "cboxContent");
                pars.Add("ajax_html_ids[]", "cboxTitle");
                pars.Add("ajax_html_ids[]", "cboxCurrent");
                pars.Add("ajax_html_ids[]", "cboxPrevious");
                pars.Add("ajax_html_ids[]", "cboxNext");
                pars.Add("ajax_html_ids[]", "cboxSlideshow");
                pars.Add("ajax_html_ids[]", "cboxLoadingOverlay");
                pars.Add("ajax_html_ids[]", "cboxLoadingGraphic");
                pars.Add("ajax_html_ids[]", "cboxMiddleRight");
                pars.Add("ajax_html_ids[]", "cboxBottomLeft");
                pars.Add("ajax_html_ids[]", "cboxBottomCenter");
                pars.Add("ajax_html_ids[]", "cboxBottomRight");
                pars.Add("ajax_page_state[theme]", "isuct");
                pars.Add("ajax_page_state[theme_token]", "mEeQE8PBT5VXCwbL0Nk2K0dN5tE1EVxT8_n_C9P9OFc");
                pars.Add("ajax_page_state[css][0]", "1");
                pars.Add("ajax_page_state[css][1]", "1");
                pars.Add("ajax_page_state[css][2]", "1");
                pars.Add("ajax_page_state[css][modules/system/system.base.css]", "1");
                pars.Add("ajax_page_state[css][modules/system/system.menus.css]", "1");
                pars.Add("ajax_page_state[css][modules/system/system.messages.css]", "1");
                pars.Add("ajax_page_state[css][modules/system/system.theme.css]", "1");
                pars.Add("ajax_page_state[css][misc/ui/jquery.ui.core.css]", "1");
                pars.Add("ajax_page_state[css][misc/ui/jquery.ui.theme.css]", "1");
                pars.Add("ajax_page_state[css][misc/ui/jquery.ui.menu.css]", "1");
                pars.Add("ajax_page_state[css][misc/ui/jquery.ui.autocomplete.css]", "1");
                pars.Add("ajax_page_state[css][misc/ui/jquery.ui.accordion.css]", "1");
                pars.Add("ajax_page_state[css][misc/ui/jquery.ui.button.css]", "1");
                pars.Add("ajax_page_state[css][misc/ui/jquery.ui.resizable.css]", "1");
                pars.Add("ajax_page_state[css][misc/ui/jquery.ui.dialog.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/modules/audtodayschedule/css/schedule.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/modules/calendar/css/calendar_multiday.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/modules/date/date_api/date.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/modules/date/date_popup/themes/datepicker.1.7.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/modules/date/date_repeat_field/date_repeat_field.css]", "1");
                pars.Add("jax_page_state[css][modules/field/theme/field.css]", "1");
                pars.Add("ajax_page_state[css][modules/node/node.css]", "1");
                pars.Add("ajax_page_state[css][modules/node/node.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/modules/ppslist/css/ppslist.css]", "1");
                pars.Add("ajax_page_state[css][modules/search/search.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/modules/studrating/css/styles.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/modules/studrating/css/jquery.dataTables.min.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/modules/studschedule/css/schedule.css]", "1");
                pars.Add("ajax_page_state[css][modules/user/user.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/modules/visuallyimpaired/css/styles.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/modules/views/css/views.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/modules/back_to_top/css/back_to_top.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/modules/ckeditor/css/ckeditor.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/modules/cctags/cctags.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/libraries/colorbox/example2/colorbox.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/modules/ctools/css/ctools.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/modules/panels/css/panels.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/modules/popup/popup.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/modules/textsize/textsize.css]", "1");
                pars.Add("ajax_page_state[css][modules/locale/locale.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/modules/custom_search/custom_search.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/modules/flexslider/assets/css/flexslider_img.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/libraries/flexslider/flexslider.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/modules/search_autocomplete/css/themes/basic-green.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/modules/search_autocomplete/css/themes/minimal.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/modules/search_autocomplete/css/themes/user-blue.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/modules/eu_cookie_compliance/css/eu_cookie_compliance.css]", "1");
                pars.Add("ajax_page_state[css][https://www.isuct.ru/sites/all/modules/storefront_cps/style.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/themes/isuct/css/font-awesome.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/themes/isuct/css/style.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/themes/isuct/css/media.css]", "1");
                pars.Add("ajax_page_state[css][sites/all/themes/isuct/css/component.css]", "1");
                pars.Add("ajax_page_state[js][0]", "1");
                pars.Add("ajax_page_state[js][1]", "1");
                pars.Add("ajax_page_state[js][2]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/flexslider/assets/js/flexslider.load.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/eu_cookie_compliance/js/eu_cookie_compliance.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/jquery_update/replace/jquery/1.8/jquery.min.js]", "1");
                pars.Add("ajax_page_state[js][misc/jquery-extend-3.4.0.js]", "1");
                pars.Add("ajax_page_state[js][misc/jquery.once.js]", "1");
                pars.Add("ajax_page_state[js][misc/drupal.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/jquery_update/replace/ui/ui/minified/jquery.ui.core.min.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/jquery_update/replace/ui/ui/minified/jquery.ui.widget.min.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/jquery_update/replace/ui/ui/minified/jquery.ui.effect.min.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/eu_cookie_compliance/js/jquery.cookie-1.4.1.min.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/jquery_update/replace/misc/jquery.form.min.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/jquery_update/replace/ui/ui/minified/jquery.ui.position.min.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/jquery_update/replace/ui/ui/minified/jquery.ui.menu.min.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/jquery_update/replace/ui/ui/minified/jquery.ui.autocomplete.min.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/jquery_update/replace/ui/ui/minified/jquery.ui.accordion.min.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/jquery_update/replace/ui/ui/minified/jquery.ui.button.min.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/jquery_update/replace/ui/ui/minified/jquery.ui.mouse.min.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/jquery_update/replace/ui/ui/minified/jquery.ui.draggable.min.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/jquery_update/replace/ui/ui/minified/jquery.ui.resizable.min.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/jquery_update/replace/ui/ui/minified/jquery.ui.dialog.min.js]", "1");
                pars.Add("ajax_page_state[js][misc/ajax.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/jquery_update/js/jquery_update.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/admin_menu/admin_devel/admin_devel.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/audtodayschedule/js/my.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/ppslist/js/my.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/studrating/js/my.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/studrating/js/jquery.dataTables.min.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/studschedule/js/my.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/visuallyimpaired/js/js.for.the.visually.impaired.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/visuallyimpaired/js/js.cookie.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/webform_steps/webform_steps.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/back_to_top/js/back_to_top.js]", "1");
                pars.Add("ajax_page_state[js][public://languages/ru_rJV0hRSXXwygvsLzqDEmn6qNlLb9lZOMo7QpRnIbSyU.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/autocomplete_post/autocomplete_post.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/libraries/colorbox/jquery.colorbox-min.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/colorbox/js/colorbox.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/colorbox/js/colorbox_load.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/colorbox/js/colorbox_inline.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/iframe/iframe.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/jcaption/jcaption.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/popup/popup.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/libraries/jstorage/jstorage.min.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/textsize/jquery.textsize.js]", "1");
                pars.Add("ajax_page_state[js][misc/jquery.cookie.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/custom_search/js/custom_search.js]", "1");
                pars.Add("ajax_page_state[js][misc/autocomplete.js]", "1");
                pars.Add("ajax_page_state[js][misc/progress.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/themes/fix/js/colorbox-fix.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/libraries/easing/jquery.easing.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/libraries/flexslider/jquery.flexslider-min.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/modules/search_autocomplete/js/jquery.autocomplete.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/themes/isuct/js/custom.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/themes/isuct/js/cbpHorizontalMenu.js]", "1");
                pars.Add("ajax_page_state[js][sites/all/themes/isuct/js/modernizr.custom.js]", "1");
                pars.Add("ajax_page_state[jquery_version]", "1.8");

                #endregion
                var response = webClient.UploadValues(url, pars);
                string schedule = System.Text.Encoding.UTF8.GetString(response);

                FileStream fileWithSchedule = new FileStream("./TimeTabel.json", FileMode.OpenOrCreate); // запишем в файл
                StreamWriter w = new StreamWriter(fileWithSchedule);
                fileWithSchedule.Write(response);
                fileWithSchedule.Close(); // оказывается потоки нужно закрывать, иначе рискуем получить исключение, что файл уже используется
                return schedule;
            }
        }
    }
}