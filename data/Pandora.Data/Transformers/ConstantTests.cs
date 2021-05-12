using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Pandora.Definitions.Attributes;

namespace Pandora.Data.Transformers
{
    public class ConstantTests
    {
        [TestCase]
        public void MappingFromTypeWithNoEnumsReturnsNoEnums()
        {
            var actual = Constant.FromObject(typeof(ClassWithoutEnum));
            Assert.AreEqual(0, actual.Count);
        }
        
        [TestCase]
        public void MappingFromTypeWithAnEnumsReturnsThatEnum()
        {
            var actual = Constant.FromObject(typeof(ClassWithSingleEnum));
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("Example", actual.First().Name);
            Assert.AreEqual(2, actual.First().Values.Count);
            Assert.AreEqual("first", actual.First().Values["First"]);
            Assert.AreEqual("second", actual.First().Values["Second"]);
            Assert.AreEqual(false, actual.First().CaseInsensitive);
        }

        [TestCase]
        public void MappingFromTypeWithANestedEnumReturnsThatEnum()
        {
            var actual = Constant.FromObject(typeof(ClassWithNestedClassContainingAnEnum));
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("Example", actual.First().Name);
            Assert.AreEqual(2, actual.First().Values.Count);
            Assert.AreEqual("first", actual.First().Values["First"]);
            Assert.AreEqual("second", actual.First().Values["Second"]);
            Assert.AreEqual(false, actual.First().CaseInsensitive);
        }

        [TestCase]
        public void MappingFromTypeContainingTheSameEnumNestedTwiceExistsOnce()
        {
            var actual = Constant.FromObject(typeof(ClassWithNestedClasses));
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("Example", actual.First().Name);
            Assert.AreEqual(2, actual.First().Values.Count);
            Assert.AreEqual("first", actual.First().Values["First"]);
            Assert.AreEqual("second", actual.First().Values["Second"]);
            Assert.AreEqual(false, actual.First().CaseInsensitive);
        }
        
        [TestCase]
        public void MappingFromTypeWhichIsNotAClassShouldFail()
        {
            Assert.Throws<NotSupportedException>(() => Constant.FromObject(typeof(Example)));
        }
        
        [TestCase]
        public void MappingABasicEnum()
        {
            var actual = Constant.FromEnum(new Example().GetType());
            Assert.NotNull(actual);
            Assert.AreEqual(false, actual.CaseInsensitive);
            Assert.AreEqual("Example", actual.Name);
            Assert.AreEqual(2, actual.Values.Count);
            Assert.AreEqual("first", actual.Values["First"]);
            Assert.AreEqual("second", actual.Values["Second"]);
        }
        
        [TestCase]
        public void MappingWithACaseSensitiveAttribute()
        {
            var actual = Constant.FromEnum(new CaseInsensitiveExample().GetType());
            Assert.NotNull(actual);
            Assert.AreEqual(true, actual.CaseInsensitive);
            Assert.AreEqual("CaseInsensitiveExample", actual.Name);
            Assert.AreEqual(2, actual.Values.Count);
            Assert.AreEqual("first", actual.Values["First"]);
            Assert.AreEqual("second", actual.Values["Second"]);
        }
        
        [TestCase]
        public void MappingWithoutDescriptionsShouldFail()
        {
            Assert.Throws<NotSupportedException>(() => Constant.FromEnum(new EnumMissingAttribute().GetType()));
        }
        
        [TestCase]
        public void MappingAClassShouldFail()
        {
            Assert.Throws<NotSupportedException>(() => Constant.FromEnum(new ClassWithoutEnum().GetType()));
        }

        private class ClassWithoutEnum
        {
            public bool Hello { get; set; }
        }

        private class ClassWithSingleEnum
        {
            public Example Prop { get; set; }
        }

        private class ClassWithNestedClassContainingAnEnum
        {
            public ClassWithSingleEnum Inner { get; set; }
        }

        private class ClassWithNestedClasses
        {
            public ClassWithNestedClassContainingAnEnum First { get; set; }
            
            public ClassWithNestedClassContainingAnEnum Second { get; set; }
        }

        private enum Example
        {
            [System.ComponentModel.Description("first")]
            First,
            
            [System.ComponentModel.Description("second")]
            Second
        }

        [CaseInsensitiveDueToApiBug("example-for-acctest")]
        private enum CaseInsensitiveExample
        {
            [System.ComponentModel.Description("first")]
            First,
            
            [System.ComponentModel.Description("second")]
            Second
        }

        private enum EnumMissingAttribute
        {
            [System.ComponentModel.Description("first")]
            First,
            
            // intentionally missing the description
            Second
        }
    }
}