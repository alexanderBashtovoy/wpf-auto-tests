using System;
using System.Moles;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestUI;
using UIAutoTest;	  

namespace TestProject1
{
	/// <summary>
	/// Summary description for UnitTest1
	/// </summary>
	[TestClass]
	public class UnitTest1
	{
		private static Application _application;
		private static Window _mainWindow;

		#region Additional test attributes
		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		[ClassInitialize]
		public static void MyClassInitialize(TestContext testContext)
		{
			_application = _application ?? UI.Run(() => new App { MainWindow = new MainWindow() });

			_mainWindow = _mainWindow ?? _application.Get(x => x.MainWindow);
		}
		//
		// Use ClassCleanup to run code after all tests in a class have run
		[ClassCleanup]
		public static void MyClassCleanup()
		{
			_application.Invoke(x => x.Shutdown());
		}
		//
		// Use TestInitialize to run code before running each test 
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion

		[TestMethod]
		public void TestStartup()
		{
			var textBox = _mainWindow.FindChild((TextBox el) => el.Name == "SomeTexBox");

			Assert.IsNotNull(textBox);

			Assert.AreEqual("123123123", textBox.Get(x => x.Text));
		}

		[TestMethod]
		public void TestFirstButtonClick()
		{
			var textBox = _mainWindow.FindChild((TextBox el) => el.Name == "SomeTexBox");
			var button = _mainWindow.FindChild((Button el) => el.Content.Equals("Click for test"));
			button.Raise(ButtonBase.ClickEvent);

			Assert.AreEqual("Habrahabr", textBox.Get(x => x.Text));
		}

		[TestMethod]
		[HostType("Moles")]
		public void TestSecondButton()
		{
			var dateTimeExpect = new DateTime(2011, 12, 08, 12, 30, 25);
			MDateTime.NowGet = () => dateTimeExpect;

			var button = _mainWindow.FindChild((Button el) => el.Content.Equals("Click for test 2"));
			button.Raise(ButtonBase.ClickEvent);

			var textBox = _mainWindow.FindChilds<TextBox>().First();
			Assert.AreEqual(dateTimeExpect.ToString(), textBox.Get(x => x.Text));
		}

	}
}
