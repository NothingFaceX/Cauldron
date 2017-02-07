﻿using Cauldron.Interception.External.Test;
using Cauldron.Interception.Test.Interceptors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Cauldron.Interception.Test
{
    [TestClass]
    public class Property_Interceptor_Code_Validation_Tests
    {
        [ExternalLockablePropertyInterceptor]
        public static string StaticLockableProperty { get; set; }

        [TestPropertyInterceptor]
        public static double StaticProperty { get; set; }

        [TestPropertyInterceptor]
        public ITestInterface InterfaceProperty { get; set; }

        [ExternalLockablePropertyInterceptor]
        public string LockableProperty { get; set; }

        [EnumPropertyInterceptor]
        public TestEnum PropertyWithEnumValue { get; private set; }

        [TestPropertyInterceptor]
        public long ValueTypeProperty { get; set; }

        [TestPropertyInterceptor]
        public long ValueTypePropertyPrivateSetter { get; private set; }

        [TestMethod]
        public void EnumProperty_Property_Getter()
        {
            this.PropertyWithEnumValue = (TestEnum)20;
            Assert.AreEqual((TestEnum)45, this.PropertyWithEnumValue);

            this.PropertyWithEnumValue = (TestEnum)5;
            Assert.AreEqual(TestEnum.Two, this.PropertyWithEnumValue);

            this.PropertyWithEnumValue = (TestEnum)12;
            Assert.AreEqual((TestEnum)232, this.PropertyWithEnumValue);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void EnumProperty_Property_Setter()
        {
            this.PropertyWithEnumValue = TestEnum.Three;
            this.PropertyWithEnumValue = TestEnum.Three;
        }

        [TestMethod]
        public void LockableProperties()
        {
            this.LockableProperty = "Hello";
            StaticLockableProperty = "Computer";
            Assert.AreEqual("Hello", this.LockableProperty);
            Assert.AreEqual("Computer", StaticLockableProperty);
        }

        [TestMethod]
        public void Static_Property()
        {
            StaticProperty = 4.6;
            Assert.AreEqual(4.6, StaticProperty);

            StaticProperty = 66;
            Assert.AreEqual(78344.796875, StaticProperty);
        }

        [TestMethod]
        public void ValueType_Property()
        {
            this.ValueTypeProperty = 50;
            Assert.AreEqual(50, this.ValueTypeProperty);

            this.ValueTypeProperty = 30;
            Assert.AreEqual(9999, this.ValueTypeProperty);
        }
    }
}