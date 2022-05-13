using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json.Serialization;
using NUnit.Framework;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using ResourceDefinition = Pandora.Definitions.Interfaces.ResourceDefinition;

namespace Pandora.Data.Transformers;

public static class ResourceDefinitionTests
{
    [TestCase]
    public static void ApiVersionWithNoOperationsShouldFail()
    {
        Assert.Throws<Exception>(() => ResourceDefinition.Map(new ResourceVersionWithNoOperations()));
    }

    [TestCase]
    public static void MappingAnApiVersionWithASingleOperation()
    {
        var actual = ResourceDefinition.Map(new ResourceVersionWithASingleOperation());
        Assert.NotNull(actual);
        Assert.AreEqual("ApiVersionWithASingleOperation", actual.Name);
        Assert.AreEqual(1, actual.Operations.Count);
        Assert.AreEqual(0, actual.Constants.Count);
        Assert.AreEqual(0, actual.Models.Count);
    }

    [TestCase]
    public static void MappingAnApiVersionWithMultipleOperations()
    {
        var actual = ResourceDefinition.Map(new ResourceVersionWithAMultipleOperations());
        Assert.NotNull(actual);
        Assert.AreEqual("ApiVersionWithAMultipleOperations", actual.Name);
        Assert.AreEqual(2, actual.Operations.Count);
        Assert.AreEqual("Fake", actual.Operations.First().Name);
        Assert.AreEqual("FakeOther", actual.Operations.Skip(1).First().Name);
        Assert.AreEqual(0, actual.Constants.Count);
        Assert.AreEqual(0, actual.Models.Count);
    }

    [TestCase]
    public static void MappingAnApiVersionContainingARequestModel()
    {
        var actual = ResourceDefinition.Map(new ResourceVersionWithARequestModel());
        Assert.NotNull(actual);
        Assert.AreEqual("ApiVersionWithARequestModel", actual.Name);
        Assert.AreEqual(1, actual.Operations.Count);
        Assert.AreEqual("FakeOperationWithRequestModel", actual.Operations.First().Name);
        Assert.AreEqual(0, actual.Constants.Count);
        Assert.AreEqual(1, actual.Models.Count);
        Assert.AreEqual("Fake", actual.Models.First().Name);
    }

    [TestCase]
    public static void MappingAnApiVersionContainingARequestAndResponseModel()
    {
        var actual = ResourceDefinition.Map(new ResourceVersionWithARequestAndResponseModel());
        Assert.NotNull(actual);
        Assert.AreEqual("ApiVersionWithARequestAndResponseModel", actual.Name);
        Assert.AreEqual(1, actual.Operations.Count);
        Assert.AreEqual("FakeOperationWithRequestAndResponseModel", actual.Operations.First().Name);
        Assert.AreEqual(0, actual.Constants.Count);
        Assert.AreEqual(2, actual.Models.Count);
        Assert.AreEqual("Fake", actual.Models.First().Name);
        Assert.AreEqual("FakeSecond", actual.Models.Skip(1).First().Name);
    }

    [TestCase]
    public static void MappingAnApiVersionContainingAResponseModel()
    {
        var actual = ResourceDefinition.Map(new ResourceVersionWithAResponseModel());
        Assert.NotNull(actual);
        Assert.AreEqual("ApiVersionWithAResponseModel", actual.Name);
        Assert.AreEqual(1, actual.Operations.Count);
        Assert.AreEqual("FakeOperationWithResponseModel", actual.Operations.First().Name);
        Assert.AreEqual(0, actual.Constants.Count);
        Assert.AreEqual(1, actual.Models.Count);
        Assert.AreEqual("Fake", actual.Models.First().Name);
    }

    [TestCase]
    public static void MappingAnApiVersionContainingNestedModels()
    {
        var actual = ResourceDefinition.Map(new ResourceVersionWithANestedResponseModel());
        Assert.NotNull(actual);
        Assert.AreEqual("ApiVersionWithANestedResponseModel", actual.Name);
        Assert.AreEqual(1, actual.Operations.Count);
        Assert.AreEqual("FakeOperationWithANestedResponseModel", actual.Operations.First().Name);
        Assert.AreEqual(0, actual.Constants.Count);
        Assert.AreEqual(3, actual.Models.Count);
        Assert.AreEqual("Fake", actual.Models.First().Name);
        Assert.AreEqual("FakeSecond", actual.Models.Skip(1).First().Name);
        Assert.AreEqual("FakeWithNested", actual.Models.Skip(2).First().Name);
    }

    [TestCase]
    public static void MappingAnApiVersionContainingDuplicateModelsAreDeDuped()
    {
        var actual = ResourceDefinition.Map(new ResourceVersionWithADuplicateNestedResponseModel());
        Assert.NotNull(actual);
        Assert.AreEqual("ApiVersionWithADuplicateNestedResponseModel", actual.Name);
        Assert.AreEqual(1, actual.Operations.Count);
        Assert.AreEqual("FakeOperationWithADuplicateNestedResponseModel", actual.Operations.First().Name);
        Assert.AreEqual(0, actual.Constants.Count);
        Assert.AreEqual(2, actual.Models.Count);
        Assert.AreEqual("Fake", actual.Models.First().Name);
        Assert.AreEqual("FakeWithDuplicateNestedTypes", actual.Models.Skip(1).First().Name);
    }

    [TestCase]
    public static void MappingAnApiVersionContainingConstants()
    {
        var actual = ResourceDefinition.Map(new ResourceVersionWithARequestModelAndConstant());
        Assert.NotNull(actual);
        Assert.AreEqual("ApiVersionWithARequestModelAndConstant", actual.Name);
        Assert.AreEqual(1, actual.Operations.Count);
        Assert.AreEqual("FakeOperationWithRequestModelAndConstant", actual.Operations.First().Name);
        Assert.AreEqual(1, actual.Constants.Count);
        Assert.AreEqual("Fake", actual.Constants.First().Name);
        Assert.AreEqual(1, actual.Models.Count);
        Assert.AreEqual("FakeWithConstant", actual.Models.First().Name);
    }

    [TestCase]
    public static void MappingAnApiVersionContainingDuplicateConstants()
    {
        var actual = ResourceDefinition.Map(new ResourceVersionWithARequestModelAndDuplicateConstants());
        Assert.NotNull(actual);
        Assert.AreEqual("ApiVersionWithARequestModelAndDuplicateConstants", actual.Name);
        Assert.AreEqual(1, actual.Operations.Count);
        Assert.AreEqual("FakeOperationWithRequestModelAndDuplicateConstants", actual.Operations.First().Name);
        Assert.AreEqual(1, actual.Constants.Count);
        Assert.AreEqual("Fake", actual.Constants.First().Name);
        Assert.AreEqual(1, actual.Models.Count);
        Assert.AreEqual("FakeWithDuplicateConstants", actual.Models.First().Name);
    }

    [TestCase]
    public static void MappingAnApiVersionContainingNestedConstants()
    {
        var actual = ResourceDefinition.Map(new ResourceVersionWithARequestModelWithNestedConstants());
        Assert.NotNull(actual);
        Assert.AreEqual("ApiVersionWithARequestModelWithNestedConstants", actual.Name);
        Assert.AreEqual(1, actual.Operations.Count);
        Assert.AreEqual("FakeOperationWithRequestModelAndNestedConstants", actual.Operations.First().Name);
        Assert.AreEqual(2, actual.Constants.Count);
        Assert.AreEqual("Fake", actual.Constants.First().Name);
        Assert.AreEqual("FakeSecond", actual.Constants.Skip(1).First().Name);
        Assert.AreEqual(2, actual.Models.Count);
        Assert.AreEqual("FakeWithConstant", actual.Models.First().Name);
        Assert.AreEqual("FakeWithNestedConstants", actual.Models.Skip(1).First().Name);
    }

    [TestCase]
    public static void MappingAnApiVersionContainingDuplicateNestedConstants()
    {
        var actual = ResourceDefinition.Map(new ResourceVersionWithARequestModelWithDuplicateNestedConstants());
        Assert.NotNull(actual);
        Assert.AreEqual("ApiVersionWithARequestModelWithDuplicateNestedConstants", actual.Name);
        Assert.AreEqual(1, actual.Operations.Count);
        Assert.AreEqual("FakeOperationWithRequestModelAndDuplicateNestedConstants", actual.Operations.First().Name);
        Assert.AreEqual(1, actual.Constants.Count);
        Assert.AreEqual("Fake", actual.Constants.First().Name);
        Assert.AreEqual(2, actual.Models.Count);
        Assert.AreEqual("FakeWithConstant", actual.Models.First().Name);
        Assert.AreEqual("FakeWithDuplicateNestedConstants", actual.Models.Skip(1).First().Name);
    }

    [TestCase]
    public static void MappingAnApiVersionWithMultipleOperationsAndASharedConstant()
    {
        var actual = ResourceDefinition.Map(new ResourceVersionWithAMultipleOperationsAndASharedConstant());
        Assert.NotNull(actual);
        Assert.AreEqual("ApiVersionWithAMultipleOperationsAndASharedConstant", actual.Name);
        Assert.AreEqual(2, actual.Operations.Count);
        Assert.AreEqual("First", actual.Operations.First().Name);
        Assert.AreEqual("Second", actual.Operations.Skip(1).First().Name);
        Assert.AreEqual(1, actual.Constants.Count);
        Assert.AreEqual(2, actual.Models.Count);
    }

    [TestCase]
    public static void MappingAnApiVersionWithMultipleOperationsAndASharedModel()
    {
        var actual = ResourceDefinition.Map(new ResourceVersionWithAMultipleOperationsAndASharedModel());
        Assert.NotNull(actual);
        Assert.AreEqual("ApiVersionWithAMultipleOperationsAndASharedModel", actual.Name);
        Assert.AreEqual(2, actual.Operations.Count);
        Assert.AreEqual("First", actual.Operations.First().Name);
        Assert.AreEqual("Second", actual.Operations.Skip(1).First().Name);
        Assert.AreEqual(0, actual.Constants.Count);
        Assert.AreEqual(3, actual.Models.Count);
    }

    [TestCase]
    public static void MappingAnApiWhichContainsAConstantWithinOptions()
    {
        var actual = ResourceDefinition.Map(new ResourceVersionWithAConstantWithinOptions());
        Assert.NotNull(actual);
        Assert.AreEqual("ApiVersionWithAConstantWithinOptions", actual.Name);
        Assert.AreEqual(1, actual.Operations.Count);
        Assert.AreEqual("Example", actual.Operations.First().Name);
        Assert.AreEqual(1, actual.Constants.Count);
        Assert.AreEqual(0, actual.Models.Count);

        var constant = actual.Constants.First(c => c.Name == "ConstantHiddenInOptions");
        Assert.NotNull(constant);
    }

    [TestCase]
    public static void MappingAnApiWhichContainsAConstantWithinResourceId()
    {
        var actual = ResourceDefinition.Map(new ResourceVersionWithConstantWithinResourceId());
        Assert.NotNull(actual);
        Assert.AreEqual("ApiVersionWithConstantWithinResourceId", actual.Name);
        Assert.AreEqual(1, actual.Operations.Count);
        Assert.AreEqual("Example", actual.Operations.First().Name);
        Assert.AreEqual(1, actual.Constants.Count);
        Assert.AreEqual(0, actual.Models.Count);

        var constant = actual.Constants.First(c => c.Name == "ConstantHiddenInResourceId");
        Assert.NotNull(constant);
    }

    [Test]
    public static void MappingAnApiWhichReturnsADiscriminatedType()
    {
        var actual = ResourceDefinition.Map(new ResourceVersionReturningADiscriminatedType());
        Assert.NotNull(actual);
        Assert.AreEqual("ApiVersionReturningADiscriminatedType", actual.Name);
        Assert.AreEqual(1, actual.Operations.Count);
        Assert.AreEqual("GetDog", actual.Operations.First().Name);
        Assert.AreEqual(0, actual.Constants.Count);
        Assert.AreEqual(2, actual.Models.Count);

        var dog = actual.Models.FirstOrDefault(m => m.Name == "Doggy");
        Assert.NotNull(dog);
        Assert.AreEqual(1, dog.Properties.Count);
        Assert.AreEqual("Barkasaurous", dog.ParentTypeName);
        Assert.AreEqual("Dog", dog.TypeHintValue);
        Assert.AreEqual("Type", dog.TypeHintIn);

        var barkasaurous = actual.Models.FirstOrDefault(m => m.Name == "Barkasaurous");
        Assert.NotNull(dog);
        Assert.AreEqual(1, barkasaurous.Properties.Count);
        Assert.Null(barkasaurous.ParentTypeName);
        Assert.Null(barkasaurous.TypeHintValue);
        Assert.AreEqual("Type", barkasaurous.TypeHintIn);
    }

    [Test]
    public static void MappingAnApiWhichReturnsAModelContainingAListOfADiscriminatedType()
    {
        var actual = ResourceDefinition.Map(new ResourceVersionReturningAModelContainingAListOfADiscriminatedType());
        Assert.NotNull(actual);
        Assert.AreEqual("ApiVersionReturningAModelContainingAListOfADiscriminatedType", actual.Name);
        Assert.AreEqual(1, actual.Operations.Count);
        Assert.AreEqual("GetListOfDogs", actual.Operations.First().Name);
        Assert.AreEqual(0, actual.Constants.Count);
        Assert.AreEqual(3, actual.Models.Count);

        var dogWrapper = actual.Models.FirstOrDefault(m => m.Name == "DogWrapper");
        Assert.NotNull(dogWrapper);
        Assert.AreEqual(1, dogWrapper.Properties.Count);
        Assert.Null(dogWrapper.ParentTypeName);
        Assert.Null(dogWrapper.TypeHintIn);
        Assert.Null(dogWrapper.TypeHintValue);

        var dog = actual.Models.FirstOrDefault(m => m.Name == "Doggy");
        Assert.NotNull(dog);
        Assert.AreEqual(1, dog.Properties.Count);
        Assert.AreEqual("Barkasaurous", dog.ParentTypeName);
        Assert.AreEqual("Dog", dog.TypeHintValue);
        Assert.AreEqual("Type", dog.TypeHintIn);

        var barkasaurous = actual.Models.FirstOrDefault(m => m.Name == "Barkasaurous");
        Assert.NotNull(dog);
        Assert.AreEqual(1, barkasaurous.Properties.Count);
        Assert.Null(barkasaurous.ParentTypeName);
        Assert.Null(barkasaurous.TypeHintValue);
        Assert.AreEqual("Type", barkasaurous.TypeHintIn);
    }

    [Test]
    public static void MappingAnApiWhichReturnsAModelContainingAListOfADiscriminatedTypeWithNoBaseTypeShouldReturnError()
    {
        // this handles the case of invalid data as seem in https://github.com/hashicorp/pandora/issues/73#issuecomment-935943146 
        Assert.Throws<Exception>(() => ResourceDefinition.Map(new ResourceVersionReturningAModelContainingAListOfADiscriminatedTypeWithNoBaseType()));
    }

    private class ResourceVersionWithNoOperations : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ApiVersionWithNoOperations";
        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>();
    }

    private class ResourceVersionWithASingleOperation : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ApiVersionWithASingleOperation";
        public IEnumerable<ApiOperation> Operations => new List<ApiOperation> { new FakeOperation() };
    }

    private class ResourceVersionWithAMultipleOperations : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ApiVersionWithAMultipleOperations";

        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
            {new FakeOperation(), new FakeOtherOperation()};
    }

    private class ResourceVersionWithARequestModel : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ApiVersionWithARequestModel";
        public IEnumerable<ApiOperation> Operations => new List<ApiOperation> { new FakeOperationWithRequestModel() };
    }

    private class ResourceVersionWithARequestAndResponseModel : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ApiVersionWithARequestAndResponseModel";

        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
            {new FakeOperationWithRequestAndResponseModel()};
    }

    private class ResourceVersionWithAResponseModel : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ApiVersionWithAResponseModel";

        public IEnumerable<ApiOperation> Operations =>
            new List<ApiOperation> { new FakeOperationWithResponseModel() };
    }

    private class ResourceVersionWithANestedResponseModel : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ApiVersionWithANestedResponseModel";

        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
            {new FakeOperationWithANestedResponseModel()};
    }

    private class ResourceVersionWithADuplicateNestedResponseModel : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ApiVersionWithADuplicateNestedResponseModel";

        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
            {new FakeOperationWithADuplicateNestedResponseModel()};
    }

    private class ResourceVersionWithARequestModelAndConstant : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ApiVersionWithARequestModelAndConstant";

        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
            {new FakeOperationWithRequestModelAndConstant()};
    }

    private class ResourceVersionWithARequestModelAndDuplicateConstants : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ApiVersionWithARequestModelAndDuplicateConstants";

        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
            {new FakeOperationWithRequestModelAndDuplicateConstants()};
    }

    private class ResourceVersionWithARequestModelWithNestedConstants : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ApiVersionWithARequestModelWithNestedConstants";

        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
            {new FakeOperationWithRequestModelAndNestedConstants()};
    }

    private class ResourceVersionWithARequestModelWithDuplicateNestedConstants : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ApiVersionWithARequestModelWithDuplicateNestedConstants";

        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
            {new FakeOperationWithRequestModelAndDuplicateNestedConstants()};
    }

    private class ResourceVersionWithAMultipleOperationsAndASharedConstant : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ApiVersionWithAMultipleOperationsAndASharedConstant";

        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new FirstOperation(),
            new SecondOperation(),
        };

        private class FirstOperation : PutOperation
        {
            public override Type? RequestObject()
            {
                return typeof(FirstObject);
            }
        }

        private class SecondOperation : GetOperation
        {
            public override Type? ResponseObject()
            {
                return typeof(SecondObject);
            }
        }

        private class FirstObject
        {
            [JsonPropertyName("someConst")]
            public SomeConstant SomeObject { get; set; }
        }

        private class SecondObject
        {
            [JsonPropertyName("someConst")]
            public SomeConstant SomeConst { get; set; }
        }

        [ConstantType(ConstantTypeAttribute.ConstantType.String)]
        private enum SomeConstant
        {
            [System.ComponentModel.Description("hello")]
            Hello,

            [System.ComponentModel.Description("world")]
            World
        }
    }

    private class ResourceVersionWithAMultipleOperationsAndASharedModel : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ApiVersionWithAMultipleOperationsAndASharedModel";

        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new FirstOperation(),
            new SecondOperation(),
        };

        private class FirstOperation : PutOperation
        {
            public override Type? RequestObject()
            {
                return typeof(FirstObject);
            }
        }

        private class SecondOperation : GetOperation
        {
            public override Type? ResponseObject()
            {
                return typeof(SecondObject);
            }
        }

        private class FirstObject
        {
            [JsonPropertyName("someObject")]
            public SomeObject SomeObject { get; set; }
        }

        private class SecondObject
        {
            [JsonPropertyName("someObject")]
            public SomeObject SomeObject { get; set; }
        }

        private class SomeObject
        {
            [JsonPropertyName("someValue")]
            public bool SomeValue { get; set; }
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
        public Type? RequestObject() => null;

        public Definitions.Interfaces.ResourceID? ResourceId() => null;
        public Type? ResponseObject() => null;
        public string? FieldContainingPaginationDetails() => null;
        public Type? OptionsObject() => null;
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
        public Type? RequestObject() => null;

        public Definitions.Interfaces.ResourceID? ResourceId() => null;
        public Type? ResponseObject() => null;
        public string? FieldContainingPaginationDetails() => null;
        public Type? OptionsObject() => null;
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
        public Type? RequestObject() => typeof(FakeModel);

        public Definitions.Interfaces.ResourceID? ResourceId() => null;
        public Type? ResponseObject() => null;
        public string? FieldContainingPaginationDetails() => null;
        public Type? OptionsObject() => null;
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
        public Type? RequestObject() => typeof(FakeModel);

        public Definitions.Interfaces.ResourceID? ResourceId() => null;
        public Type? ResponseObject() => typeof(FakeSecondModel);
        public string? FieldContainingPaginationDetails() => null;
        public Type? OptionsObject() => null;
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
        public Type? RequestObject() => null;

        public Definitions.Interfaces.ResourceID? ResourceId() => null;
        public Type? ResponseObject() => typeof(FakeModel);
        public string? FieldContainingPaginationDetails() => null;
        public Type? OptionsObject() => null;
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
        public Type? RequestObject() => null;

        public Definitions.Interfaces.ResourceID? ResourceId() => null;
        public Type? ResponseObject() => typeof(FakeWithNested);
        public string? FieldContainingPaginationDetails() => null;
        public Type? OptionsObject() => null;
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
        public Type? RequestObject() => null;

        public Definitions.Interfaces.ResourceID? ResourceId() => null;
        public Type? ResponseObject() => typeof(FakeWithDuplicateNestedTypes);
        public string? FieldContainingPaginationDetails() => null;
        public Type? OptionsObject() => null;
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
        public Type? RequestObject() => null;

        public Definitions.Interfaces.ResourceID? ResourceId() => null;
        public Type? ResponseObject() => typeof(FakeWithConstant);
        public string? FieldContainingPaginationDetails() => null;
        public Type? OptionsObject() => null;
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
        public Type? RequestObject() => null;

        public Definitions.Interfaces.ResourceID? ResourceId() => null;
        public Type? ResponseObject() => typeof(FakeWithDuplicateConstants);
        public string? FieldContainingPaginationDetails() => null;
        public Type? OptionsObject() => null;
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
        public Type? RequestObject() => null;

        public Definitions.Interfaces.ResourceID? ResourceId() => null;
        public Type? ResponseObject() => typeof(FakeWithNestedConstants);
        public string? FieldContainingPaginationDetails() => null;
        public Type? OptionsObject() => null;
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
        public Type? RequestObject() => null;

        public Definitions.Interfaces.ResourceID? ResourceId() => null;
        public Type? ResponseObject() => typeof(FakeWithDuplicateNestedConstants);
        public string? FieldContainingPaginationDetails() => null;
        public Type? OptionsObject() => null;
        public string? UriSuffix() => null;
    }

    private class FakeWithDuplicateNestedConstants
    {
        [JsonPropertyName("first")]
        public FakeWithConstant First { get; set; }

        [JsonPropertyName("second")]
        public FakeWithConstant Second { get; set; }
    }

    private class FakeWithNestedConstants
    {
        [JsonPropertyName("first")]
        public FakeWithConstant First { get; set; }

        [JsonPropertyName("second")]
        public FakeSecondConstant Second { get; set; }
    }

    private class FakeWithConstant
    {
        [JsonPropertyName("constant")]
        public FakeConstant Constant { get; set; }
    }

    private class FakeWithDuplicateConstants
    {
        [JsonPropertyName("first")]
        public FakeConstant First { get; set; }

        [JsonPropertyName("second")]
        public FakeConstant Second { get; set; }
    }

    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    private enum FakeConstant
    {
        [System.ComponentModel.Description("first")]
        First,

        [System.ComponentModel.Description("second")]
        Second
    }

    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    private enum FakeSecondConstant
    {
        [System.ComponentModel.Description("third")]
        Third,

        [System.ComponentModel.Description("fourth")]
        Fourth
    }

    private class FakeWithNested
    {
        [JsonPropertyName("first")]
        public FakeModel First { get; }

        [JsonPropertyName("second")]
        public FakeSecondModel Second { get; }
    }

    private class FakeWithDuplicateNestedTypes
    {
        [JsonPropertyName("first")]
        public FakeModel First { get; }

        [JsonPropertyName("second")]
        public FakeModel Second { get; }
    }

    private class FakeModel
    {
        [JsonPropertyName("example")]
        public bool Example { get; set; }
    }

    private class FakeSecondModel
    {
        [JsonPropertyName("second")]
        public string Second { get; set; }
    }

    private class ResourceVersionReturningADiscriminatedType : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ApiVersionReturningADiscriminatedType";
        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new GetDogOperation(),
        };
    }

    internal class GetDogOperation : GetOperation
    {
        public override Type? ResponseObject()
        {
            return typeof(Doggy);
        }
    }

    internal abstract class Barkasaurous
    {
        [ProvidesTypeHint]
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    [ValueForType("Dog")]
    internal class Doggy : Barkasaurous
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    private class ResourceVersionReturningAModelContainingAListOfADiscriminatedType : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ApiVersionReturningAModelContainingAListOfADiscriminatedType";
        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new GetListOfDogs(),
        };
    }

    private class GetListOfDogs : GetOperation
    {
        public override Type? ResponseObject()
        {
            return typeof(DogWrapper);
        }
    }

    private class DogWrapper
    {
        [JsonPropertyName("doggies")]
        public List<Doggy> Doggies { get; set; }
    }

    private class ResourceVersionReturningAModelContainingAListOfADiscriminatedTypeWithNoBaseType : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ApiVersionReturningAModelContainingAListOfADiscriminatedTypeWithNoBaseType";
        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new GetListOfUnicorns(),
        };
    }

    private class GetListOfUnicorns : GetOperation
    {
        public override Type? ResponseObject()
        {
            return typeof(Unicorn);
        }
    }

    [ValueForType("unicorn")]
    private class Unicorn
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class ResourceVersionWithConstantWithinResourceId : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ApiVersionWithConstantWithinResourceId";

        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new ExampleOperation()
        };

        public class ExampleOperation : HeadOperation
        {
            public override Definitions.Interfaces.ResourceID? ResourceId()
            {
                return new ExampleResourceId();
            }
        }

        public class ExampleResourceId : Definitions.Interfaces.ResourceID
        {
            public string? CommonAlias => null;

            public string ID => "/planets/{planetName}";

            public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
            {
                ResourceIDSegment.Static("planets", "planets"),
                ResourceIDSegment.Constant("planetName", typeof(ConstantHiddenInResourceId)),
            };
        }

        [ConstantType(ConstantTypeAttribute.ConstantType.String)]
        public enum ConstantHiddenInResourceId
        {
            [System.ComponentModel.Description("First")]
            First,

            [System.ComponentModel.Description("Second")]
            Second,
        }
    }

    public class ResourceVersionWithAConstantWithinOptions : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ApiVersionWithAConstantWithinOptions";

        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new ExampleOperation()
        };

        public class ExampleOperation : HeadOperation
        {
            public override Type? OptionsObject()
            {
                return typeof(ExampleOptionsObject);
            }

            public class ExampleOptionsObject
            {
                [QueryStringName("someVal")]
                public ConstantHiddenInOptions SomeVal { get; set; }
            }
        }

        [ConstantType(ConstantTypeAttribute.ConstantType.String)]
        public enum ConstantHiddenInOptions
        {
            [System.ComponentModel.Description("First")]
            First,

            [System.ComponentModel.Description("Second")]
            Second,
        }
    }
}