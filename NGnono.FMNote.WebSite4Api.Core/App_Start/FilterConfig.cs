﻿using System.Web.Mvc;

namespace NGnono.FMNote.WebSite4Api.Core.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}