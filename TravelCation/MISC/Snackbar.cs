using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace TravelCation.MISC
{
    public static class showToastr
    {
        public static void Success(this Page page, string message, string title)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
            string.Format("toastr.success('{0}', '{1}');", message, title), addScriptTags: true);
        }

        public static void Info(this Page page, string message, string title)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
            string.Format("toastr.info('{0}', '{1}');", message, title), addScriptTags: true);
        }

        public static void Warning(this Page page, string message, string title)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
            string.Format("toastr.warning('{0}', '{1}');", message, title), addScriptTags: true);
        }

        public static void Error(this Page page, string message, string title)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
            string.Format("toastr.error('{0}', '{1}');", message, title), addScriptTags: true);
        }
    }
}