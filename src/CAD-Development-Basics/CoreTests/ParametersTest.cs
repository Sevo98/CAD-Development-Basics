using System;
using NUnit.Framework;
using Core;

namespace CoreTests
{
    [TestFixture]
    public class ParametersTest
    {

        private Parameters ParametersEmpty { get; set; } = new Parameters();

        private Parameters Parameters { get; set; } = new Parameters()
        {
            CylinderEdge = true,
            DepthBoltHeadHoles = 1,
            DepthBoltThreadHoles = 1,
            DiameterArea = 1000,
            DiameterBody = 1,
            DiameterBoltHeadHoles = 1,
            DiameterBoltThreadHoles = 1,
            HeightBody = 600,
            HeightEdge = 150,
            HeightVisor = 1
        };

        [TestCase(TestName = "diameter area test get")]
        public void DiameterAreaTest_GetValue()
        {
            //setup
            int expected = 1000;

            //act
            int actual = Parameters.DiameterArea;

            //assert
            Assert.AreEqual(expected, actual, "fail");
        }

        [TestCase(TestName = "height body test get")]
        public void HeightBodyTest_Get()
        {
            //setup
            int expected = 600;

            //act
            int actual = Parameters.HeightBody;

            //assert
            Assert.AreEqual(expected, actual, "fail");
        }

        [TestCase(TestName = "diameter area test correct set")]
        public void DiameterAreaTest_Set_CorrectValue()
        {
            //setup
            int expected = 1000;
            Parameters parameters = ParametersEmpty;
            parameters.DiameterArea = expected;

            //act
            int actual = parameters.DiameterArea;

            //assert
            Assert.AreEqual(expected, actual, "fail");
        }

        [TestCase(2000,TestName = "diameter area test incorrect more value")]
        [TestCase(100, TestName = "diameter area test incorrect less value")]
        public void DiameterAreaTest_Set_IncorrectValue(int value)
        {
            Assert.Throws<ArgumentException>(() => ParametersEmpty.DiameterArea = value, "fail");
        }
    }
}