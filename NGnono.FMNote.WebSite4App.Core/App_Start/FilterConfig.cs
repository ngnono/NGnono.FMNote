﻿using System.Web.Mvc;

namespace NGnono.FMNote.WebSite4App.Core.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}