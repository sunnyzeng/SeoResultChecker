using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEOResultChecker.DomainLogic;

namespace SEOResultChecker.UnitTest
{
    [TestClass]
    public class ParseEngineTests
    {
        private ParseEngine _parseEngine;
        private string _sampleHtml;
        private string _smokeballHtmlResult;

        [TestInitialize]
        public void ParseEngineTestsInitialize()
        {
            _parseEngine = new ParseEngine(new GoogleSEOResultParser());

            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
            var filePath = Path.Combine(outPutDirectory, "Data\\sample.html");
            using (var streamReader = new StreamReader(filePath, Encoding.UTF8))
            {
                _sampleHtml = streamReader.ReadToEnd();
            }

            filePath = Path.Combine(outPutDirectory, "Data\\singleResult.html");
            using (var streamReader = new StreamReader(filePath, Encoding.UTF8))
            {
                _smokeballHtmlResult = streamReader.ReadToEnd();
            }
        }

        [TestMethod]
        public void ParseEngineTests_TestSampleHtml_IsNotEmpty()
        {
            Assert.IsFalse(string.IsNullOrEmpty(_sampleHtml), "sample html has been loaded");
        }

        [TestMethod]
        public void ParseEngineTests_TestSampleHtml_Has_100_Records()
        {
            var results = _parseEngine.ParseResults(_sampleHtml, null);

            Assert.AreEqual(100, results.Count());
        }

        [TestMethod]
        public void ParseEngineTests_ParseSmokeBallResult()
        {
            var result = _parseEngine.ParseResult(_smokeballHtmlResult);

            Assert.AreEqual("Conveyancing Software - Smokeball", result.Name);
            Assert.AreEqual("https://www.smokeball.com.au/conveyancing.html", result.Url);
        }
    }
}
