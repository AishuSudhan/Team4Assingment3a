namespace WebMVCnew.webInfrastructure
{
    public static class APIUrlPaths
    {
        public static class catalogevents
        {
            public static string geteventscategories(string baseUrl)
            {
                return $"{baseUrl}/getcategories";
            }
            public static string getpopularevents(string baseUrl)
            {
                return $"{baseUrl}/getpopularevents";
            }
            public static string getcatalog(string baseUrl,int pagenumber,int pagesize)
            {
                return $"{baseUrl}/getcatalog?Pagenumber={pagenumber}&Pagesize={pagesize}";
            }
        }
    }
}
