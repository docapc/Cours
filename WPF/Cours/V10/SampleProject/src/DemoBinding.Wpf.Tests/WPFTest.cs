using System;
using System.Threading;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;

namespace DemoBinding.Wpf.Tests
{
    [TestClass]
    public class WPFTest : TestSession
    {

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            Setup(context);
        }

        [TestMethod]
        public void TestApp()
        {
            //session.FindElementByName("Login").Click();
            session.FindElementByAccessibilityId("LoginButton").Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            var elements = session.FindElementsByClassName("ListBoxItem");
            var text= elements[0].FindElementsByClassName("TextBlock")[1].Text;
            text.Should().Be("test");
            session.FindElementByAccessibilityId("TbUserName").SendKeys("Le nom de test");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TearDown();
        }
    }
}