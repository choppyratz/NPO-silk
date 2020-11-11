using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilkTest.Ntf;
using SilkTest.Ntf.XBrowser;
using System;
using System.Collections.Generic;

namespace Silk4NETProject3
{
    [SilkTestClass]
    public class UnitTest7
    {
        private readonly Desktop _desktop = Agent.Desktop;

        [TestInitialize]
        public void Initialize()
        {
            // Go to web page 'https://calc.by/math-calculators/scientific-calculator.html'
            BrowserBaseState baseState = new BrowserBaseState();
            baseState.Execute();
        }

        [TestMethod]
        public void TestMethod1()
        {
            BrowserApplication webBrowser = _desktop.BrowserApplication("calc_by");

            BrowserWindow browserWindow = webBrowser.BrowserWindow("BrowserWindow");
            browserWindow.DomTextField("calc_display_input").SetText("5+5*5-10/2");
            browserWindow.DomLink("btn_enter").Click();
            Assert.AreEqual("25", browserWindow.DomTextField("calc_display_input").Text);
        }
    }
}