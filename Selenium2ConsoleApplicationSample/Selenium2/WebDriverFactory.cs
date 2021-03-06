﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using System;

namespace Selenium2ConsoleApplicationSample.Selenium2
{
    internal class WebDriverFactory
    {
        /// <summary>
        /// 対象のWebDriverのインスタンスを作成します。
        /// </summary>
        /// <param name="browserName"></param>
        /// <returns>WebDriver</returns>
        public static IWebDriver CreateInstance(AppSettings.BrowserName browserName)
        {
            switch (browserName)
            {
                case AppSettings.BrowserName.None:
                    throw new ArgumentException(string.Format("Not Definition. BrowserName:{0}", browserName));

                case AppSettings.BrowserName.Chrome:
                    return new ChromeDriver();

                case AppSettings.BrowserName.Firefox:
                    FirefoxDriverService driverService = FirefoxDriverService.CreateDefaultService();
                    driverService.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    driverService.HideCommandPromptWindow = true;
                    driverService.SuppressInitialDiagnosticInformation = true;
                    return new FirefoxDriver(driverService);

                case AppSettings.BrowserName.InternetExplorer:
                    return new InternetExplorerDriver();

                case AppSettings.BrowserName.Edge:
                    return new EdgeDriver();

                case AppSettings.BrowserName.Safari:
                    return new SafariDriver();

                default:
                    throw new ArgumentException(string.Format("Not Definition. BrowserName:{0}", browserName));
            }
        }
    }
}
