using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileToolLibrary.Tests
{
    [TestClass]
    public class ExistenceTests
    {
        [TestMethod]
        public void PathValidator_ShouldExist()
        {
            MethodInfo methodInfo = typeof(FileTool).GetMethod("PathValidator", BindingFlags.NonPublic |
                                                                                BindingFlags.Static |
                                                                                BindingFlags.Instance)!;
            Assert.AreNotEqual(null, methodInfo);
        }
    }
}
