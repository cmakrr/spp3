using AssemblyAnalyzer;

namespace UnitTests
{
    public class Tests
    {
        public string currentPath;
        [SetUp]
        public void Setup()
        {
            currentPath = "...";
        }

        [Test]
        public void TestResult_FromIncorrectAssemblyFile()
        {
            AnalyzerResult res = null;
            try
            {
                res = Analyzer.Analyze("");
            }
            catch (Exception ex)
            {
                Assert.Pass(ex.Message);
            }
        }

        [Test]
        public void TestResult_FromCurrentAssembly()
        {
            AnalyzerResult res = null;
            try
            {
                res = Analyzer.Analyze(currentPath);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.IsTrue(res.namespacesDictionary.ContainsKey(typeof(Tests).Namespace));
            Assert.IsTrue(res.namespacesDictionary[typeof(Tests).Namespace].typeInfos
                .First().methods
                .Find(p => p.Name == "TestResult_FromCurrentAssembly") != null);
        }

        [Test]
        public void TestResult_CheckContainingBasicMethods()
        {
            string[] basicMethods = {"GetHashCode", "Equals", "ToString", "GetType"};
            AnalyzerResult res = null;
            try
            {
                res = Analyzer.Analyze(currentPath);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.AreEqual(res.namespacesDictionary[typeof(Tests).Namespace].typeInfos
                .First().methods.FindAll(p => basicMethods.Contains(p.Name)).Count(), 4);
        }
    }
}