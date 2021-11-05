using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json.Serialization;
using NUnit.Framework;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;

namespace Pandora.Data.Transformers
{
    public static class OperationTests
    {
        [TestCase]
        public static void MappingAnOperationWithNoStatusCodesShouldFail()
        {
            Assert.Throws<Exception>(() => Operation.Map(new OperationWithNoStatusCodes(), "2018-01-01", "MyApi"));
        }

        [TestCase]
        public static void MappingAnOperationWithNoRequestOrResponseObjects()
        {
            var actual = Operation.Map(new OperationWithNoRequestOrResponseObjects(), "2018-01-01", "MyApi");
            Assert.NotNull(actual);
            Assert.AreEqual("2018-01-01", actual.ApiVersion);
            Assert.AreEqual("MyApi", actual.ApiName);
            Assert.AreEqual("OperationWithNoRequestOrResponseObjects", actual.Name);
            Assert.AreEqual("application/json", actual.ContentType);
            Assert.AreEqual("DELETE", actual.Method);
            Assert.AreEqual(false, actual.LongRunning);
            Assert.Null(actual.RequestObject);
            Assert.Null(actual.ResponseObject);
            Assert.AreEqual(1, actual.ExpectedStatusCodes.Count);
            Assert.AreEqual(200, actual.ExpectedStatusCodes.First());
        }

        [TestCase]
        public static void MappingAnOperationWithMultipleStatusCodes()
        {
            var actual = Operation.Map(new OperationWithMultipleStatusCodes(), "2018-01-01", "MyApi");
            Assert.NotNull(actual);
            Assert.AreEqual("2018-01-01", actual.ApiVersion);
            Assert.AreEqual("MyApi", actual.ApiName);
            Assert.AreEqual("OperationWithMultipleStatusCodes", actual.Name);
            Assert.AreEqual("application/json", actual.ContentType);
            Assert.AreEqual("DELETE", actual.Method);
            Assert.AreEqual(false, actual.LongRunning);
            Assert.Null(actual.RequestObject);
            Assert.Null(actual.ResponseObject);
            Assert.AreEqual(2, actual.ExpectedStatusCodes.Count);
            Assert.AreEqual(200, actual.ExpectedStatusCodes.First());
            Assert.AreEqual(201, actual.ExpectedStatusCodes.Skip(1).First());
        }

        [TestCase]
        public static void LongRunningOperationsWithAResponseObjectGetsIgnored()
        {
            var actual = Operation.Map(new LongRunningOperationWithResponseObject(), "2018-01-01", "MyApi");
            Assert.NotNull(actual);
            Assert.AreEqual("2018-01-01", actual.ApiVersion);
            Assert.AreEqual("MyApi", actual.ApiName);
            Assert.AreEqual("LongRunningOperationWithResponseObject", actual.Name);
            Assert.AreEqual("DELETE", actual.Method);
            Assert.AreEqual(true, actual.LongRunning);
            Assert.Null(actual.ResponseObject);
        }

        [TestCase]
        public static void MappingAnOperationWithARequestObject()
        {
            var actual = Operation.Map(new OperationWithRequestObject(), "2018-01-01", "MyApi");
            Assert.NotNull(actual);
            Assert.AreEqual("2018-01-01", actual.ApiVersion);
            Assert.AreEqual("MyApi", actual.ApiName);
            Assert.AreEqual("OperationWithRequestObject", actual.Name);
            Assert.AreEqual("PUT", actual.Method);
            Assert.AreEqual(false, actual.LongRunning);
            Assert.NotNull(actual.RequestObject);
            Assert.Null(actual.ResponseObject);
            Assert.AreEqual("TestObject", actual.RequestObject!.ReferenceName);
            Assert.AreEqual(ObjectType.Reference, actual.RequestObject!.Type);
        }

        [TestCase]
        public static void MappingAnOperationWithASimpleTypeAsAResponseObject()
        {
            var actual = Operation.Map(new OperationWithASimpleTypeAsAResponseObject(), "2018-01-01", "MyApi");
            Assert.NotNull(actual);
            Assert.AreEqual("2018-01-01", actual.ApiVersion);
            Assert.AreEqual("MyApi", actual.ApiName);
            Assert.AreEqual("OperationWithASimpleTypeAsAResponseObject", actual.Name);
            Assert.AreEqual("GET", actual.Method);
            Assert.AreEqual(false, actual.LongRunning);
            Assert.Null(actual.RequestObject);
            Assert.NotNull(actual.ResponseObject);
            Assert.AreEqual(1, actual.ExpectedStatusCodes.Count);
            Assert.AreEqual(200, actual.ExpectedStatusCodes.First());
            Assert.AreEqual(ObjectType.String, actual.ResponseObject!.Type);
            Assert.Null(actual.ResponseObject!.ReferenceName);
        }

        [TestCase]
        public static void MappingAnOperationWithAListOfStringsAsAResponseObject()
        {
            var actual = Operation.Map(new OperationWithAListOfStringsAsAResponseObject(), "2018-01-01", "MyApi");
            Assert.NotNull(actual);
            Assert.AreEqual("2018-01-01", actual.ApiVersion);
            Assert.AreEqual("MyApi", actual.ApiName);
            Assert.AreEqual("OperationWithAListOfStringsAsAResponseObject", actual.Name);
            Assert.AreEqual("GET", actual.Method);
            Assert.AreEqual(false, actual.LongRunning);
            Assert.Null(actual.RequestObject);
            Assert.NotNull(actual.ResponseObject);
            Assert.AreEqual(1, actual.ExpectedStatusCodes.Count);
            Assert.AreEqual(200, actual.ExpectedStatusCodes.First());
            Assert.AreEqual(ObjectType.List, actual.ResponseObject!.Type);
            Assert.Null(actual.ResponseObject!.ReferenceName);
            Assert.NotNull(actual.ResponseObject!.NestedItem);
            Assert.AreEqual(ObjectType.String, actual.ResponseObject!.NestedItem!.Type);
            Assert.Null(actual.ResponseObject!.NestedItem!.ReferenceName);
            Assert.Null(actual.ResponseObject!.NestedItem!.NestedItem);
        }

        [TestCase]
        public static void MappingAnOperationWithAResourceID()
        {
            var actual = Operation.Map(new OperationWithAResourceId(), "2018-01-01", "MyApi");
            Assert.NotNull(actual);
            Assert.AreEqual("2018-01-01", actual.ApiVersion);
            Assert.AreEqual("MyApi", actual.ApiName);
            Assert.AreEqual("OperationWithAResourceId", actual.Name);
            Assert.AreEqual("GET", actual.Method);
            Assert.AreEqual(false, actual.LongRunning);
            Assert.Null(actual.RequestObject);
            Assert.NotNull(actual.ResponseObject);
            Assert.AreEqual("FakeResponseObject", actual.ResponseObject!.ReferenceName);
            Assert.AreEqual(ObjectType.Reference, actual.ResponseObject!.Type);
            Assert.AreEqual("FakeResourceId", actual.ResourceIdName);
        }

        [TestCase]
        public static void MappingAnOperationWithAResponseObject()
        {
            var actual = Operation.Map(new OperationWithResponseObject(), "2018-01-01", "MyApi");
            Assert.NotNull(actual);
            Assert.AreEqual("2018-01-01", actual.ApiVersion);
            Assert.AreEqual("MyApi", actual.ApiName);
            Assert.AreEqual("OperationWithResponseObject", actual.Name);
            Assert.AreEqual("GET", actual.Method);
            Assert.AreEqual(false, actual.LongRunning);
            Assert.Null(actual.RequestObject);
            Assert.NotNull(actual.ResponseObject);
            Assert.NotNull(actual.ResponseObject!.ReferenceName);
            Assert.AreEqual(1, actual.ExpectedStatusCodes.Count);
            Assert.AreEqual(200, actual.ExpectedStatusCodes.First());
            Assert.AreEqual("TestObject", actual.ResponseObject!.ReferenceName);
            Assert.AreEqual(ObjectType.Reference, actual.ResponseObject!.Type);
        }

        [TestCase]
        public static void MappingAnOperationWithARequestAndResponseObject()
        {
            var actual = Operation.Map(new OperationWithRequestAndResponseObject(), "2018-01-01", "MyApi");
            Assert.NotNull(actual);
            Assert.AreEqual("2018-01-01", actual.ApiVersion);
            Assert.AreEqual("MyApi", actual.ApiName);
            Assert.AreEqual("OperationWithRequestAndResponseObject", actual.Name);
            Assert.AreEqual("PUT", actual.Method);
            Assert.AreEqual(false, actual.LongRunning);
            Assert.NotNull(actual.RequestObject);
            Assert.NotNull(actual.RequestObject!.ReferenceName);
            Assert.NotNull(actual.ResponseObject);
            Assert.NotNull(actual.ResponseObject!.ReferenceName);
            Assert.AreEqual("TestObject", actual.RequestObject!.ReferenceName);
            Assert.AreEqual(ObjectType.Reference, actual.RequestObject!.Type);
            Assert.AreEqual("TestObject", actual.ResponseObject!.ReferenceName);
            Assert.AreEqual(ObjectType.Reference, actual.ResponseObject!.Type);
        }

        [TestCase]
        public static void MappingAnOperationWithASuffix()
        {
            var actual = Operation.Map(new OperationWithASuffix(), "2018-01-01", "MyApi");
            Assert.NotNull(actual);
            Assert.AreEqual("2018-01-01", actual.ApiVersion);
            Assert.AreEqual("MyApi", actual.ApiName);
            Assert.AreEqual("OperationWithASuffix", actual.Name);
            Assert.AreEqual("POST", actual.Method);
            Assert.AreEqual(false, actual.LongRunning);
            Assert.Null(actual.RequestObject);
            Assert.Null(actual.ResponseObject);
            Assert.AreEqual(1, actual.ExpectedStatusCodes.Count);
            Assert.AreEqual(200, actual.ExpectedStatusCodes.First());
            Assert.AreEqual(0, actual.Options.Count);
            Assert.AreEqual("/shutdown", actual.UriSuffix);
        }

        [TestCase]
        public static void MappingAnOperationWithOptions()
        {
            var actual = Operation.Map(new OperationWithOptions(), "2018-01-01", "MyApi");
            Assert.NotNull(actual);
            Assert.AreEqual("2018-01-01", actual.ApiVersion);
            Assert.AreEqual("MyApi", actual.ApiName);
            Assert.AreEqual("OperationWithOptions", actual.Name);
            Assert.AreEqual("POST", actual.Method);
            Assert.AreEqual(false, actual.LongRunning);
            Assert.Null(actual.ResponseObject);
            Assert.Null(actual.ResponseObject);

            Assert.AreEqual(3, actual.Options.Count);

            var firstOption = actual.Options.First(o => o.Name == "First");
            Assert.AreEqual(true, firstOption.Required);
            Assert.AreEqual(ObjectType.String, firstOption.ObjectDefinition.Type);
            Assert.AreEqual("first", firstOption.QueryStringName);

            var secondOption = actual.Options.First(o => o.Name == "SecondVal");
            Assert.AreEqual(false, secondOption.Required);
            Assert.AreEqual(ObjectType.Integer, secondOption.ObjectDefinition.Type);
            Assert.AreEqual("second", secondOption.QueryStringName);

            var constantOption = actual.Options.First(o => o.Name == "ConstantOption");
            Assert.AreEqual(true, constantOption.Required);
            Assert.AreEqual(ObjectType.Reference, constantOption.ObjectDefinition.Type);
            Assert.NotNull(constantOption.ObjectDefinition.ReferenceName);
            Assert.AreEqual("Some", constantOption.ObjectDefinition.ReferenceName);
            Assert.AreEqual("constantOption", constantOption.QueryStringName);
        }

        [TestCase]
        public static void MappingAnOperationWithPaginationDetails()
        {
            var actual = Operation.Map(new OperationWithPaginationDetails(), "2018-01-01", "MyApi");
            Assert.NotNull(actual);
            Assert.AreEqual("2018-01-01", actual.ApiVersion);
            Assert.AreEqual("MyApi", actual.ApiName);
            Assert.AreEqual("OperationWithPaginationDetails", actual.Name);
            Assert.AreEqual("application/json; charset=utf-8", actual.ContentType);
            Assert.AreEqual("GET", actual.Method);
            Assert.AreEqual(false, actual.LongRunning);
            Assert.Null(actual.RequestObject);
            Assert.NotNull(actual.ResponseObject);
            Assert.NotNull(actual.ResponseObject!.ReferenceName);
            Assert.AreEqual(1, actual.ExpectedStatusCodes.Count);
            Assert.AreEqual(200, actual.ExpectedStatusCodes.First());
            Assert.AreEqual(0, actual.Options.Count);
            Assert.AreEqual(ObjectType.Reference, actual.ResponseObject!.Type);
            Assert.AreEqual("FakeNestedType", actual.ResponseObject!.ReferenceName);
            Assert.AreEqual("@odata.foobar", actual.FieldContainingPaginationDetails);
        }

        [TestCase]
        public static void MappingAnOperationShouldTrimTheSuffixOfOperation()
        {
            var actual = Operation.Map(new OperationSimpleOperation(), "2018-01-01", "MyApi");
            Assert.NotNull(actual);
            Assert.AreEqual("2018-01-01", actual.ApiVersion);
            Assert.AreEqual("MyApi", actual.ApiName);
            Assert.AreEqual("OperationSimple", actual.Name);
        }

        private class OperationWithNoStatusCodes : DeleteOperation
        {
            public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
            {
                return new List<HttpStatusCode>();
            }
        }

        private class OperationWithNoRequestOrResponseObjects : DeleteOperation
        {
            public override string? ContentType()
            {
                return "application/json";
            }
        }

        private class OperationWithMultipleStatusCodes : DeleteOperation
        {
            public override string? ContentType()
            {
                return "application/json";
            }

            public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
            {
                return new List<HttpStatusCode>
                {
                    HttpStatusCode.OK,
                    HttpStatusCode.Created
                };
            }
        }

        private class LongRunningOperationWithResponseObject : LongRunningDeleteOperation
        {
            public override Type? ResponseObject() => typeof(TestObject);
        }

        private class OperationWithRequestObject : PutOperation
        {
            public override Type? RequestObject() => typeof(TestObject);
        }

        private class OperationWithResponseObject : GetOperation
        {
            public override Type? ResponseObject() => typeof(TestObject);
        }

        private class OperationWithRequestAndResponseObject : PutOperation
        {
            public override Type? RequestObject() => typeof(TestObject);

            public override Type? ResponseObject() => typeof(TestObject);
        }
    }

    public class OperationWithAListOfStringsAsAResponseObject : GetOperation
    {
        public override Type? ResponseObject()
        {
            return typeof(List<string>);
        }
    }

    public class OperationWithASimpleTypeAsAResponseObject : GetOperation
    {
        public override Type? ResponseObject()
        {
            return typeof(string);
        }
    }

    public class OperationSimpleOperation : PutOperation
    {
        public override Type? RequestObject() => typeof(TestObject);

        public override Type? ResponseObject() => typeof(TestObject);

        public override string? UriSuffix() => "/hello";
    }

    public class OperationWithAResourceId : GetOperation
    {
        public override Type? ResponseObject() => typeof(FakeResponseObject);

        public override Definitions.Interfaces.ResourceID? ResourceId() => new FakeResourceId();

        public class FakeResponseObject
        {
            [JsonPropertyName("foo")]
            public string Foo { get; set; }
        }

        public class FakeResourceId : Definitions.Interfaces.ResourceID
        {
            public string? CommonAlias => null;
            
            public string ID => "/hello";
            
            public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
            {
                new()
                {
                    Name = "hello",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "hello",
                }
            };
        }
    }

    public class OperationWithASuffix : PostOperation
    {
        public override Type? RequestObject() => null;

        public override string? UriSuffix() => "/shutdown";
    }

    public class OperationWithOptions : PostOperation
    {
        public override Type? OptionsObject() => typeof(NestedOptionsObject);
        public override Type? RequestObject() => null;

        public class NestedOptionsObject
        {
            [QueryStringName("first")]
            public string First { get; set; }

            [QueryStringName("second")]
            [Optional]
            public int SecondVal { get; set; }

            [QueryStringName("constantOption")]
            public SomeConstant ConstantOption { get; set; }
        }

        [ConstantType(ConstantTypeAttribute.ConstantType.String)]
        public enum SomeConstant
        {
            [System.ComponentModel.Description("first")]
            FirstVal,

            [System.ComponentModel.Description("second")]
            SecondVal
        }
    }

    public class OperationWithPaginationDetails : ListOperation
    {
        public override string? FieldContainingPaginationDetails() => "@odata.foobar";
        public override Type NestedItemType() => typeof(FakeNestedType);

        public class FakeNestedType
        {
            [JsonPropertyName("@odata.foobar")]
            public string FooBar { get; set; }
        }
    }

    internal class TestObject
    {
        public bool Whatever { get; set; }
    }
}