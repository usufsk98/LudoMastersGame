/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System;
using System.Collections.Generic;
using System.Reflection;

namespace PlayFab.UUnit
{
    [AttributeUsage(AttributeTargets.Method)]
    public class UUnitTestAttribute : Attribute
    {
    }

    public class UUnitTestSuite
    {
        private List<UUnitTestCase> tests = new List<UUnitTestCase>();
        private int lastTestIndex = -1;
        private UUnitTestResult testResult = new UUnitTestResult();

        public void Add(UUnitTestCase testCase)
        {
            tests.Add(testCase);
        }

        public void RunAllTests()
        {
            bool eachResult = false;
            while (eachResult == false)
                eachResult = RunOneTest();
        }

        /// <summary>
        /// Run a single test, and return whether the test suite is finished
        /// </summary>
        /// <returns>True when all tests are finished</returns>
        public bool RunOneTest()
        {
            // Abort if we've already finished testing
            bool doneTesting = lastTestIndex >= tests.Count;
            if (doneTesting) return true;

            lastTestIndex++;
            doneTesting = lastTestIndex >= tests.Count;
            if (!doneTesting)
            {
                tests[lastTestIndex].Run(testResult);
            }
            return doneTesting;
        }

        public UUnitTestResult GetResults()
        {
            bool doneTesting = lastTestIndex >= tests.Count;
            return doneTesting ? testResult : null; // Only return the results when finished
        }

        public void FindAndAddAllTestCases(Type parent)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var a in assemblies)
            {
                var types = a.GetTypes();
                foreach (var t in types)
                {
                    if (!t.IsAbstract && t.IsSubclassOf(parent))
                        AddAll(t);
                }
            }
        }

        private void AddAll(Type testCaseType)
        {
            var methods = testCaseType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (MethodInfo m in methods)
            {
                var attributes = m.GetCustomAttributes(typeof(UUnitTestAttribute), false);
                if (attributes.Length > 0)
                {
                    ConstructorInfo constructor = testCaseType.GetConstructors()[0];
                    UUnitTestCase newTestCase = (UUnitTestCase)constructor.Invoke(null);
                    newTestCase.SetTest(m.Name);
                    Add(newTestCase);
                }
            }
        }

        /// <summary>
        /// Return that tests were run, and all of them reported success
        /// </summary>
        public bool AllTestsPassed()
        {
            return testResult.AllTestsPassed();
        }
    }
}
