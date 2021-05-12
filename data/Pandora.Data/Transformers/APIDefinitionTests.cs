using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json.Serialization;
using NUnit.Framework;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;

namespace Pandora.Data.Transformers
{
    // TODO: tests covering options etc

    public static class APIDefinitionTests
    {
        [TestCase]
        public static void ApiVersionWithNoOperationsShouldFail()
        {
            Assert.Throws<NotSupportedException>(() => APIDefinition.Map(new ApiVersionWithNoOperations()));
        }

        [TestCase]
        public static void MappingAnApiVersionWithASingleOperation()
        {
            var actual = APIDefinition.Map(new ApiVersionWithASingleOperation());
            Assert.NotNull(actual);
            Assert.AreEqual("ApiVersionWithASingleOperation", actual.Name);
            Assert.AreEqual(1, actual.Operations.Count);
            Assert.AreEqual(0, actual.Constants.Count);
            Assert.AreEqual(0, actual.Models.Count);
        }

        [TestCase]
        public static void MappingAnApiVersionWithMultipleOperations()
        {
            var actual = APIDefinition.Map(new ApiVersionWithAMultipleOperations());
            Assert.NotNull(actual);
            Assert.AreEqual("ApiVersionWithAMultipleOperations", actual.Name);
            Assert.AreEqual(2, actual.Operations.Count);
            Assert.AreEqual("FakeOperation", actual.Operations.First().Name);
            Assert.AreEqual("FakeOtherOperation", actual.Operations.Skip(1).First().Name);
            Assert.AreEqual(0, actual.Constants.Count);
            Assert.AreEqual(0, actual.Models.Count);
        }

        [TestCase]
        public static void MappingAnApiVersionContainingARequestModel()
        {
            var actual = APIDefinition.Map(new ApiVersionWithARequestModel());
            Assert.NotNull(actual);
            Assert.AreEqual("ApiVersionWithARequestModel", actual.Name);
            Assert.AreEqual(1, actual.Operations.Count);
            Assert.AreEqual("FakeOperationWithRequestModel", actual.Operations.First().Name);
            Assert.AreEqual(0, actual.Constants.Count);
            Assert.AreEqual(1, actual.Models.Count);
            Assert.AreEqual("FakeModel", actual.Models.First().Name);
        }

        [TestCase]
        public static void MappingAnApiVersionContainingARequestAndResponseModel()
        {
            var actual = APIDefinition.Map(new ApiVersionWithARequestAndResponseModel());
            Assert.NotNull(actual);
            Assert.AreEqual("ApiVersionWithARequestAndResponseModel", actual.Name);
            Assert.AreEqual(1, actual.Operations.Count);
            Assert.AreEqual("FakeOperationWithRequestAndResponseModel", actual.Operations.First().Name);
            Assert.AreEqual(0, actual.Constants.Count);
            Assert.AreEqual(2, actual.Models.Count);
            Assert.AreEqual("FakeModel", actual.Models.First().Name);
            Assert.AreEqual("FakeSecondModel", actual.Models.Skip(1).First().Name);
        }

        [TestCase]
        public static void MappingAnApiVersionContainingAResponseModel()
        {
            var actual = APIDefinition.Map(new ApiVersionWithAResponseModel());
            Assert.NotNull(actual);
            Assert.AreEqual("ApiVersionWithAResponseModel", actual.Name);
            Assert.AreEqual(1, actual.Operations.Count);
            Assert.AreEqual("FakeOperationWithResponseModel", actual.Operations.First().Name);
            Assert.AreEqual(0, actual.Constants.Count);
            Assert.AreEqual(1, actual.Models.Count);
            Assert.AreEqual("FakeModel", actual.Models.First().Name);
        }

        [TestCase]
        public static void MappingAnApiVersionContainingNestedModels()
        {
            var actual = APIDefinition.Map(new ApiVersionWithANestedResponseModel());
            Assert.NotNull(actual);
            Assert.AreEqual("ApiVersionWithANestedResponseModel", actual.Name);
            Assert.AreEqual(1, actual.Operations.Count);
            Assert.AreEqual("FakeOperationWithANestedResponseModel", actual.Operations.First().Name);
            Assert.AreEqual(0, actual.Constants.Count);
            Assert.AreEqual(3, actual.Models.Count);
            Assert.AreEqual("FakeModel", actual.Models.First().Name);
            Assert.AreEqual("FakeSecondModel", actual.Models.Skip(1).First().Name);
            Assert.AreEqual("FakeWithNested", actual.Models.Skip(2).First().Name);
        }

        [TestCase]
        public static void MappingAnApiVersionContainingDuplicateModelsAreDeDuped()
        {
            var actual = APIDefinition.Map(new ApiVersionWithADuplicateNestedResponseModel());
            Assert.NotNull(actual);
            Assert.AreEqual("ApiVersionWithADuplicateNestedResponseModel", actual.Name);
            Assert.AreEqual(1, actual.Operations.Count);
            Assert.AreEqual("FakeOperationWithADuplicateNestedResponseModel", actual.Operations.First().Name);
            Assert.AreEqual(0, actual.Constants.Count);
            Assert.AreEqual(2, actual.Models.Count);
            Assert.AreEqual("FakeModel", actual.Models.First().Name);
            Assert.AreEqual("FakeWithDuplicateNestedTypes", actual.Models.Skip(1).First().Name);
        }

        [TestCase]
        public static void MappingAnApiVersionContainingConstants()
        {
            var actual = APIDefinition.Map(new ApiVersionWithARequestModelAndConstant());
            Assert.NotNull(actual);
            Assert.AreEqual("ApiVersionWithARequestModelAndConstant", actual.Name);
            Assert.AreEqual(1, actual.Operations.Count);
            Assert.AreEqual("FakeOperationWithRequestModelAndConstant", actual.Operations.First().Name);
            Assert.AreEqual(1, actual.Constants.Count);
            Assert.AreEqual("FakeConstant", actual.Constants.First().Name);
            Assert.AreEqual(1, actual.Models.Count);
            Assert.AreEqual("FakeWithConstant", actual.Models.First().Name);
        }

        [TestCase]
        public static void MappingAnApiVersionContainingDuplicateConstants()
        {
            var actual = APIDefinition.Map(new ApiVersionWithARequestModelAndDuplicateConstants());
            Assert.NotNull(actual);
            Assert.AreEqual("ApiVersionWithARequestModelAndDuplicateConstants", actual.Name);
            Assert.AreEqual(1, actual.Operations.Count);
            Assert.AreEqual("FakeOperationWithRequestModelAndDuplicateConstants", actual.Operations.First().Name);
            Assert.AreEqual(1, actual.Constants.Count);
            Assert.AreEqual("FakeConstant", actual.Constants.First().Name);
            Assert.AreEqual(1, actual.Models.Count);
            Assert.AreEqual("FakeWithDuplicateConstants", actual.Models.First().Name);
        }

        [TestCase]
        public static void MappingAnApiVersionContainingNestedConstants()
        {
            var actual = APIDefinition.Map(new ApiVersionWithARequestModelWithNestedConstants());
            Assert.NotNull(actual);
            Assert.AreEqual("ApiVersionWithARequestModelWithNestedConstants", actual.Name);
            Assert.AreEqual(1, actual.Operations.Count);
            Assert.AreEqual("FakeOperationWithRequestModelAndNestedConstants", actual.Operations.First().Name);
            Assert.AreEqual(2, actual.Constants.Count);
            Assert.AreEqual("FakeConstant", actual.Constants.First().Name);
            Assert.AreEqual("FakeSecondConstant", actual.Constants.Skip(1).First().Name);
            Assert.AreEqual(2, actual.Models.Count);
            Assert.AreEqual("FakeWithConstant", actual.Models.First().Name);
            Assert.AreEqual("FakeWithNestedConstants", actual.Models.Skip(1).First().Name);
        }

        [TestCase]
        public static void MappingAnApiVersionContainingDuplicateNestedConstants()
        {
            var actual = APIDefinition.Map(new ApiVersionWithARequestModelWithDuplicateNestedConstants());
            Assert.NotNull(actual);
            Assert.AreEqual("ApiVersionWithARequestModelWithDuplicateNestedConstants", actual.Name);
            Assert.AreEqual(1, actual.Operations.Count);
            Assert.AreEqual("FakeOperationWithRequestModelAndDuplicateNestedConstants", actual.Operations.First().Name);
            Assert.AreEqual(1, actual.Constants.Count);
            Assert.AreEqual("FakeConstant", actual.Constants.First().Name);
            Assert.AreEqual(2, actual.Models.Count);
            Assert.AreEqual("FakeWithConstant", actual.Models.First().Name);
            Assert.AreEqual("FakeWithDuplicateNestedConstants", actual.Models.Skip(1).First().Name);
        }

        [TestCase]
        public static void MappingAnApiVersionWithMultipleOperationsAndASharedConstant()
        {
            // TODO: implement this....?
        }

        [TestCase]
        public static void MappingAnApiVersionWithMultipleOperationsAndASharedModel()
        {
            var actual = APIDefinition.Map(new ApiVersionWithAMultipleOperationsAndASharedModel());
            Assert.NotNull(actual);
            Assert.AreEqual("ApiVersionWithAMultipleOperationsAndASharedModel", actual.Name);
            Assert.AreEqual(2, actual.Operations.Count);
            Assert.AreEqual("FirstOperation", actual.Operations.First().Name);
            Assert.AreEqual("SecondOperation", actual.Operations.Skip(1).First().Name);
            Assert.AreEqual(0, actual.Constants.Count);
            Assert.AreEqual(3, actual.Models.Count);
        }

        private class ApiVersionWithNoOperations : ApiDefinition
        {
            public string ApiVersion => "2018-01-01";
            public string Name => "ApiVersionWithNoOperations";
            public IEnumerable<ApiOperation> Operations => new List<ApiOperation>();
        }

        private class ApiVersionWithASingleOperation : ApiDefinition
        {
            public string ApiVersion => "2018-01-01";
            public string Name => "ApiVersionWithASingleOperation";
            public IEnumerable<ApiOperation> Operations => new List<ApiOperation> {new FakeOperation()};
        }

        private class ApiVersionWithAMultipleOperations : ApiDefinition
        {
            public string ApiVersion => "2018-01-01";
            public string Name => "ApiVersionWithAMultipleOperations";

            public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
                {new FakeOperation(), new FakeOtherOperation()};
        }

        private class ApiVersionWithARequestModel : ApiDefinition
        {
            public string ApiVersion => "2018-01-01";
            public string Name => "ApiVersionWithARequestModel";
            public IEnumerable<ApiOperation> Operations => new List<ApiOperation> {new FakeOperationWithRequestModel()};
        }

        private class ApiVersionWithARequestAndResponseModel : ApiDefinition
        {
            public string ApiVersion => "2018-01-01";
            public string Name => "ApiVersionWithARequestAndResponseModel";

            public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
                {new FakeOperationWithRequestAndResponseModel()};
        }

        private class ApiVersionWithAResponseModel : ApiDefinition
        {
            public string ApiVersion => "2018-01-01";
            public string Name => "ApiVersionWithAResponseModel";

            public IEnumerable<ApiOperation> Operations =>
                new List<ApiOperation> {new FakeOperationWithResponseModel()};
        }

        private class ApiVersionWithANestedResponseModel : ApiDefinition
        {
            public string ApiVersion => "2018-01-01";
            public string Name => "ApiVersionWithANestedResponseModel";

            public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
                {new FakeOperationWithANestedResponseModel()};
        }

        private class ApiVersionWithADuplicateNestedResponseModel : ApiDefinition
        {
            public string ApiVersion => "2018-01-01";
            public string Name => "ApiVersionWithADuplicateNestedResponseModel";

            public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
                {new FakeOperationWithADuplicateNestedResponseModel()};
        }

        private class ApiVersionWithARequestModelAndConstant : ApiDefinition
        {
            public string ApiVersion => "2018-01-01";
            public string Name => "ApiVersionWithARequestModelAndConstant";

            public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
                {new FakeOperationWithRequestModelAndConstant()};
        }

        private class ApiVersionWithARequestModelAndDuplicateConstants : ApiDefinition
        {
            public string ApiVersion => "2018-01-01";
            public string Name => "ApiVersionWithARequestModelAndDuplicateConstants";

            public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
                {new FakeOperationWithRequestModelAndDuplicateConstants()};
        }

        private class ApiVersionWithARequestModelWithNestedConstants : ApiDefinition
        {
            public string ApiVersion => "2018-01-01";
            public string Name => "ApiVersionWithARequestModelWithNestedConstants";

            public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
                {new FakeOperationWithRequestModelAndNestedConstants()};
        }

        private class ApiVersionWithARequestModelWithDuplicateNestedConstants : ApiDefinition
        {
            public string ApiVersion => "2018-01-01";
            public string Name => "ApiVersionWithARequestModelWithDuplicateNestedConstants";

            public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
                {new FakeOperationWithRequestModelAndDuplicateNestedConstants()};
        }

        private class ApiVersionWithAMultipleOperationsAndASharedModel : ApiDefinition
        {
            public string ApiVersion => "2018-01-01";
            public string Name => "ApiVersionWithAMultipleOperationsAndASharedModel";

            public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
            {
                new FirstOperation(),
                new SecondOperation(),
            };

            private class FirstOperation : PutOperation
            {
                public override object? RequestObject()
                {
                    return new FirstObject();
                }
            }

            private class SecondOperation : GetOperation
            {
                public override object? ResponseObject()
                {
                    return new SecondObject();
                }
            }

            private class FirstObject
            {
                [JsonPropertyName("someObject")] public SomeObject SomeObject { get; set; }
            }

            private class SecondObject
            {
                [JsonPropertyName("someObject")] public SomeObject SomeObject { get; set; }
            }

            private class SomeObject
            {
                [JsonPropertyName("someValue")] public bool SomeValue { get; set; }
            }
        }

        private class FakeOperation : ApiOperation
        {
            public string? ContentType() => "application/json";

            public IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
            };

            public bool LongRunning() => false;
            public HttpMethod Method() => HttpMethod.Put;
            public object? RequestObject() => null;

            public Definitions.Interfaces.ResourceID? ResourceId() => null;
            public object? ResponseObject() => null;
            public string? FieldContainingPaginationDetails() => null;
            public object? OptionsObject() => null;
            public string? UriSuffix() => null;
        }

        private class FakeOtherOperation : ApiOperation
        {
            public string? ContentType() => "application/json";

            public IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
            };

            public bool LongRunning() => false;
            public HttpMethod Method() => HttpMethod.Put;
            public object? RequestObject() => null;

            public Definitions.Interfaces.ResourceID? ResourceId() => null;
            public object? ResponseObject() => null;
            public string? FieldContainingPaginationDetails() => null;
            public object? OptionsObject() => null;
            public string? UriSuffix() => null;
        }

        private class FakeOperationWithRequestModel : ApiOperation
        {
            public string? ContentType() => "application/json";

            public IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
            };

            public bool LongRunning() => false;
            public HttpMethod Method() => HttpMethod.Put;
            public object? RequestObject() => new FakeModel();

            public Definitions.Interfaces.ResourceID? ResourceId() => null;
            public object? ResponseObject() => null;
            public string? FieldContainingPaginationDetails() => null;
            public object? OptionsObject() => null;
            public string? UriSuffix() => null;
        }

        private class FakeOperationWithRequestAndResponseModel : ApiOperation
        {
            public string? ContentType() => "application/json";

            public IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
            };

            public bool LongRunning() => false;
            public HttpMethod Method() => HttpMethod.Put;
            public object? RequestObject() => new FakeModel();

            public Definitions.Interfaces.ResourceID? ResourceId() => null;
            public object? ResponseObject() => new FakeSecondModel();
            public string? FieldContainingPaginationDetails() => null;
            public object? OptionsObject() => null;
            public string? UriSuffix() => null;
        }

        private class FakeOperationWithResponseModel : ApiOperation
        {
            public string? ContentType() => "application/json";

            public IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
            };

            public bool LongRunning() => false;
            public HttpMethod Method() => HttpMethod.Put;
            public object? RequestObject() => null;

            public Definitions.Interfaces.ResourceID? ResourceId() => null;
            public object? ResponseObject() => new FakeModel();
            public string? FieldContainingPaginationDetails() => null;
            public object? OptionsObject() => null;
            public string? UriSuffix() => null;
        }

        private class FakeOperationWithANestedResponseModel : ApiOperation
        {
            public string? ContentType() => "application/json";

            public IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
            };

            public bool LongRunning() => false;
            public HttpMethod Method() => HttpMethod.Put;
            public object? RequestObject() => null;

            public Definitions.Interfaces.ResourceID? ResourceId() => null;
            public object? ResponseObject() => new FakeWithNested();
            public string? FieldContainingPaginationDetails() => null;
            public object? OptionsObject() => null;
            public string? UriSuffix() => null;
        }

        private class FakeOperationWithADuplicateNestedResponseModel : ApiOperation
        {
            public string? ContentType() => "application/json";

            public IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
            };

            public bool LongRunning() => false;
            public HttpMethod Method() => HttpMethod.Put;
            public object? RequestObject() => null;

            public Definitions.Interfaces.ResourceID? ResourceId() => null;
            public object? ResponseObject() => new FakeWithDuplicateNestedTypes();
            public string? FieldContainingPaginationDetails() => null;
            public object? OptionsObject() => null;
            public string? UriSuffix() => null;
        }

        private class FakeOperationWithRequestModelAndConstant : ApiOperation
        {
            public string? ContentType() => "application/json";

            public IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
            };

            public bool LongRunning() => false;
            public HttpMethod Method() => HttpMethod.Put;
            public object? RequestObject() => null;

            public Definitions.Interfaces.ResourceID? ResourceId() => null;
            public object? ResponseObject() => new FakeWithConstant();
            public string? FieldContainingPaginationDetails() => null;
            public object? OptionsObject() => null;
            public string? UriSuffix() => null;
        }

        private class FakeOperationWithRequestModelAndDuplicateConstants : ApiOperation
        {
            public string? ContentType() => "application/json";

            public IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
            };

            public bool LongRunning() => false;
            public HttpMethod Method() => HttpMethod.Put;
            public object? RequestObject() => null;

            public Definitions.Interfaces.ResourceID? ResourceId() => null;
            public object? ResponseObject() => new FakeWithDuplicateConstants();
            public string? FieldContainingPaginationDetails() => null;
            public object? OptionsObject() => null;
            public string? UriSuffix() => null;
        }

        private class FakeOperationWithRequestModelAndNestedConstants : ApiOperation
        {
            public string? ContentType() => "application/json";

            public IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
            };

            public bool LongRunning() => false;
            public HttpMethod Method() => HttpMethod.Put;
            public object? RequestObject() => null;

            public Definitions.Interfaces.ResourceID? ResourceId() => null;
            public object? ResponseObject() => new FakeWithNestedConstants();
            public string? FieldContainingPaginationDetails() => null;
            public object? OptionsObject() => null;
            public string? UriSuffix() => null;
        }

        private class FakeOperationWithRequestModelAndDuplicateNestedConstants : ApiOperation
        {
            public string? ContentType() => "application/json";

            public IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
            };

            public bool LongRunning() => false;
            public HttpMethod Method() => HttpMethod.Put;
            public object? RequestObject() => null;

            public Definitions.Interfaces.ResourceID? ResourceId() => null;
            public object? ResponseObject() => new FakeWithDuplicateNestedConstants();
            public string? FieldContainingPaginationDetails() => null;
            public object? OptionsObject() => null;
            public string? UriSuffix() => null;
        }

        private class FakeWithDuplicateNestedConstants
        {
            [JsonPropertyName("first")] public FakeWithConstant First { get; set; }

            [JsonPropertyName("second")] public FakeWithConstant Second { get; set; }
        }

        private class FakeWithNestedConstants
        {
            [JsonPropertyName("first")] public FakeWithConstant First { get; set; }

            [JsonPropertyName("second")] public FakeSecondConstant Second { get; set; }
        }

        private class FakeWithConstant
        {
            [JsonPropertyName("constant")] public FakeConstant Constant { get; set; }
        }

        private class FakeWithDuplicateConstants
        {
            [JsonPropertyName("first")] public FakeConstant First { get; set; }

            [JsonPropertyName("second")] public FakeConstant Second { get; set; }
        }

        private enum FakeConstant
        {
            [System.ComponentModel.Description("first")]
            First,

            [System.ComponentModel.Description("second")]
            Second
        }

        private enum FakeSecondConstant
        {
            [System.ComponentModel.Description("third")]
            Third,

            [System.ComponentModel.Description("fourth")]
            Fourth
        }

        private class FakeWithNested
        {
            [JsonPropertyName("first")] public FakeModel First { get; }

            [JsonPropertyName("second")] public FakeSecondModel Second { get; }
        }

        private class FakeWithDuplicateNestedTypes
        {
            [JsonPropertyName("first")] public FakeModel First { get; }

            [JsonPropertyName("second")] public FakeModel Second { get; }
        }

        private class FakeModel
        {
            [JsonPropertyName("example")] public bool Example { get; set; }
        }

        private class FakeSecondModel
        {
            [JsonPropertyName("second")] public string Second { get; set; }
        }

        private class FakeResourceId : Definitions.Interfaces.ResourceID
        {
            public string ID()
            {
                return "/hello/{worldName}";
            }
        }
    }
}