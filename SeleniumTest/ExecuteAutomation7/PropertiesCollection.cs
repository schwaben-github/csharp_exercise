using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteAutomation7
{
    enum PropertyType
    {
        Id,
        Name,
        LinkText,
        CssName,
        CssSelector,
        ClassName,
        Type
    }

    internal class PropertiesCollection
    {
        // Auto-implemented property
        public static IWebDriver driver { get; set; }
    }
}