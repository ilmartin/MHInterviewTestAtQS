using System.Collections.Generic;
using System.Globalization;

namespace MartinHuiLoanApplicationApi.Const
{
    public static class Constants
    {
        // Private setter to ensure the list can only be set once
        public static IReadOnlyList<RegionInfo> Countries { get; private set; }

        // Constructor to initialize the list
        static Constants()
        {
            //ISO 3166-1 List all country existing in the world
            var countries = new List<RegionInfo>();
            var cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo culture in cultures)
            {
                var region = new RegionInfo(culture.LCID);
                if (!(countries.Contains(region)))
                {
                    countries.Add(region);
                }
            }
            Countries = countries;
        }
    }
}
