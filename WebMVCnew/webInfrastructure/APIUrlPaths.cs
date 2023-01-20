namespace WebMVCnew.webInfrastructure
{
    public class APIUrlPaths
    {
        public static class Paginatedclass
        {
            public static string Geteventscategories(string baseUrl)
            {
                return $"{baseUrl}/geteventscategories";
            }
            public static string Getpopularevents(string baseUrl)
            {
                return $"{baseUrl}/getpopularevents";
            }
            public static string Getcatalog(string baseUrl, int pagenumber, int pagesize, int? popularevents, int? categories)
            {
                var PreUri = string.Empty;
                var filterQs = string.Empty;
                if (popularevents.HasValue)
                {
                    filterQs = $"populareventsid={popularevents.Value}";
                }
                if (categories.HasValue)
                {
                    filterQs = (filterQs == string.Empty) ? $"eventcategoryid={categories.Value}" :
                         $"{filterQs}&eventcategoryid={categories.Value}";
                }
                if (string.IsNullOrEmpty(filterQs))
                {
                    PreUri = $"{baseUrl}/getcatalog?pageIndex={pagenumber}&pageSize={pagesize}";
                }
                else
                {
                    PreUri = $"{baseUrl}/getcatalog/filter?pageIndex={pagenumber}&pageSize={pagesize}&{filterQs}";
                }

                return PreUri;

            }
        }
    }
}   

