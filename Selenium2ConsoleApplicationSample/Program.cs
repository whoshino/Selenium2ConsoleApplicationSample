﻿using OpenQA.Selenium;
using Selenium2ConsoleApplicationSample.Selenium2;
using System;
using System.Threading;

namespace Selenium2ConsoleApplicationSample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // AppSettings.BrowserName.Firefoxを変更することによって対象のブラウザを変更できます
            using (IWebDriver webDriver = WebDriverFactory.CreateInstance(AppSettings.BrowserName.Chrome))
            {
                // https://www.google.co.jp に遷移させる
                webDriver.Url = @"https://www.google.co.jp";

                // #lst-ibの要素を取得する
                IWebElement element = webDriver.FindElement(By.CssSelector("#lst-ib"));

                // 上記取得した要素に対してテキストを入力してサブミット
                element.SendKeys("Selenium2");
                element.Submit();

                // 一瞬で完了するため3秒スリープ
                Thread.Sleep(TimeSpan.FromSeconds(3));

                // ブラウザを閉じる
                webDriver.Quit();
            }
        }
    }
}