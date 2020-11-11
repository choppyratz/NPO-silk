using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilkTest.Ntf;
using SilkTest.Ntf.XBrowser;
using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;

namespace Silk4NETProject3
{
    [SilkTestClass]
    public class UnitTest8
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
            Application xlApp = new Application();
            Workbook xlWorkBook = xlApp.Workbooks.Open("C:/Users/German/source/repos/Silk4NETProject3/test.xls", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0); ;
            Worksheet xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1); ;
            Microsoft.Office.Interop.Excel.Range range = xlWorkSheet.UsedRange;
            int rw = 2;
            for (int rCnt = 1; rCnt <= rw; rCnt++)
            {
                string val1 = (range.Cells[rCnt, 1] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                string operation = (range.Cells[rCnt, 2] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                string val2 = (range.Cells[rCnt, 3] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                string res = (range.Cells[rCnt, 4] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();

                BrowserWindow browserWindow = webBrowser.BrowserWindow("BrowserWindow");
                browserWindow.DomLink("btn_" + val1).Click();
                browserWindow.DomLink(operation).Click();
                browserWindow.DomLink("btn_" + val2).Click();
                browserWindow.DomLink("btn_enter").Click();
                Assert.AreEqual(res, browserWindow.DomTextField("calc_display_input").Text);
            }

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();
        }
    }
}