using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteAutomation3_1
{
    enum PropertyType
    {
        Id,
        Name,
        LinkText,
        CssName,
        ClassName,
        CssSelector,
        XPath,
        TagName,
        Type,
        PartialLinkText
    }

    internal class PropertiesCollection
    {
        // Auto-implemented property
        public static IWebDriver driver { get; set; }
    }
}
