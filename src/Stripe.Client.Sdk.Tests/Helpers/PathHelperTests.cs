using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Sdk.Helpers;

namespace Stripe.Client.Sdk.Tests.Helpers
{
    [TestClass]
    public class PathHelperTests
    {
        [TestMethod]
        public void GetPathTest_ShouldConcatenate()
        {
            var path = PathHelper.GetPath("a", "b", "c");
            Assert.AreEqual("a/b/c", path);
        }

        [TestMethod]
        public void GetPathTest_ShouldTrimLeadingSlash()
        {
            var path = PathHelper.GetPath("/a", "b", "c");
            Assert.AreEqual("a/b/c", path);
        }

        [TestMethod]
        public void GetPathTest_ShouldTrimTrailingSlash()
        {
            var path = PathHelper.GetPath("a/", "b", "c/");
            Assert.AreEqual("a/b/c", path);
        }

        [TestMethod]
        public void GetPathTest_ShouldTrimLeadingAndTrailingWhitespace()
        {
            var path = PathHelper.GetPath("a ", "b", " c");
            Assert.AreEqual("a/b/c", path);
        }
    }
}