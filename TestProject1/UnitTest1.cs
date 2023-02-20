using Microsoft.VisualStudio.TestTools.UnitTesting;
using REG_MARK_LIB;
using System;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckMark_IsTrueRegion02()
        {
            Assert.IsTrue(Class1.CheckMark("a123aa02".ToUpper()));
        }
        [TestMethod]
        public void CheckMark_IsTrueRegion152()
        {
            Assert.IsTrue(Class1.CheckMark("a123aa152".ToUpper()));
        }
        [TestMethod]
        public void CheckMark_IsFalseRegio222()
        {
            Assert.IsFalse(Class1.CheckMark("a123aa222".ToUpper()));
        }
        [TestMethod]
        public void CheckMark_IsFalseOrderNumers()
        {
            Assert.IsFalse(Class1.CheckMark("a123za01".ToUpper()));
        }
        [TestMethod]
        public void CheckMark_AreEqualNext()
        {
            Assert.AreEqual("a123aa152".ToUpper(), Class1.GetNextMarkAfter("a124aa152".ToUpper()));
        }
        [TestMethod]
        public void CheckMark_AreEqualNextElement()
        {

            Assert.AreEqual(Class1.GetNextMarkAfter("a999aa152".ToUpper()), "a001ab152".ToUpper());
        }
        [TestMethod]
        public void CheckMark_AreNotEqualNext()
        {
            Assert.AreNotEqual("a128aa152".ToUpper(), Class1.GetNextMarkAfter("a123aa150".ToUpper()));
        }
        [TestMethod]
        public void CheckMark_AreNotEqualNextElement()
        {

            Assert.AreNotEqual(Class1.GetNextMarkAfter("a999aa152".ToUpper()), "a001ab150".ToUpper());
        }
    }
}