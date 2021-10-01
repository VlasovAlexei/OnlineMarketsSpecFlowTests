using System.Collections.Generic;

namespace OnlineMarketsSpecFlowTests.Hooks
{
    class ConfigElements
    {
        public string Url { get; set; }

        public Dictionary<string, Dictionary<string, string>> Pages { get; set; }
    }
}