using Microsoft.VisualStudio.TestTools.UnitTesting;
using SquareEquation;

namespace SquareEquationTest
{
    /// <summary>
    /// Test the SquareEquation class method.
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// When discriminant >0.
        /// </summary>
        [TestMethod]
        public void TwoRoots()
        {
            double expected_x1 = 0.828, expected_x2 = -4.828, x1, x2;
            string temp1,temp2;
            (x1, x2,temp1,temp2) = SQEquation.SearchRoots(1, 4, -4);
            Assert.AreEqual(expected_x1, x1);
            Assert.AreEqual(expected_x2, x2);
        }
        /// <summary>
        /// When discriminant = 0.
        /// </summary>
        [TestMethod]
        public void OneRoot()
        {
            double expected_x1 = -1, expected_x2 = -1, x1, x2;
            string temp1, temp2;
            (x1, x2, temp1, temp2) = SQEquation.SearchRoots(2, 4, 2);
            Assert.AreEqual(expected_x1, x1);
            Assert.AreEqual(expected_x2, x2);
        }
        /// <summary>
        /// When discriminant < 0.
        /// </summary>
        [TestMethod]
        public void ComplexRoots()
        {
            double exp_x1, exp_x2;
            string expected_x1 = "3 + i·2,236", expected_x2 = "3 - i·2,236", x1, x2;
            (exp_x1, exp_x2, x1, x2) = SQEquation.SearchRoots(1, -6, 14);
            Assert.AreEqual(expected_x1, x1);
            Assert.AreEqual(expected_x2, x2);
        }
    }
}
