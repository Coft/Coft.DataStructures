using Coft.DataStructures.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Coft.DataStructures.TreesUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Tree<int> tree = new Tree<int>();
            tree.Evaluator = new IntEvaluator();

            tree.Insert(1);
            tree.Insert(10);
            tree.Insert(2);
            tree.Insert(5);
            tree.Insert(20);

            Node<int> e = tree.Find(2);
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Tree<int> tree = new Tree<int>();
            tree.Evaluator = new IntEvaluator();

            tree.Insert(1);
            tree.Insert(10);
            tree.Insert(2);
            tree.Insert(5);
            tree.Insert(20);
            tree.Insert(21);
            tree.Insert(19);
            tree.Insert(-1);
            tree.Insert(15);

            tree.Remove(1);
            tree.Remove(10);

            Node<int> e = tree.Find(2);
            Assert.IsNotNull(e);
        }

        [TestMethod]
        [ExpectedException(typeof(EvaluatorNullException))]
        public void TestMethod3()
        {
            Tree<int> tree = new Tree<int>();
            tree.Insert(3);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Tree<int> tree = new Tree<int>();
            tree.Evaluator = new IntEvaluator();

            tree.Remove(3);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Tree<int> tree = new Tree<int>();
            tree.Evaluator = new IntEvaluator();

            tree.Find(3);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Tree<int> tree = new Tree<int>();
            tree.Evaluator = new IntEvaluator();

            tree.FindNext(3);
        }

        [TestMethod]
        public void TestMethod7()
        {
            Tree<int> tree = new Tree<int>();
            tree.Evaluator = new IntEvaluator();

            tree.FindNext(3);
        }

        [TestMethod]
        public void TestMethod8()
        {
            Tree<int> tree = new Tree<int>();
            tree.Evaluator = new IntEvaluator();

            tree.Insert(1);
            tree.Insert(1);
            tree.Insert(1);

            tree.Remove(1);
        }
    }
}