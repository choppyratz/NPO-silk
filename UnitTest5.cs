﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilkTest.Ntf;
using SilkTest.Ntf.XBrowser;
using System;
using System.Collections.Generic;

namespace Silk4NETProject3
{
    [SilkTestClass]
    public class UnitTest5
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
            browserWindow.DomLink("log").Click();
            browserWindow.DomLink("btn_1").Click();
            browserWindow.DomLink("btn_0").Click();
            browserWindow.DomLink("btn_0").Click();
            browserWindow.DomLink(")").Click();
            browserWindow.DomLink("btn_enter").Click();
            Assert.AreEqual("2", browserWindow.DomTextField("calc_display_input").Text);
        }
    }
}