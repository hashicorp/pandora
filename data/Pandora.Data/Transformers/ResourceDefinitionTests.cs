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
    public static void MappingAnApiVersionContainingASingleModel()
    {
        var actual = ResourceDefinition.Map(new ResourceVersionWithASingleModel());
        Assert.NotNull(actual);
        Assert.AreEqual("ResourceVersionWithASingleModel", actual.Name);
        Assert.AreEqual(1, actual.Operations.Count);
        Assert.AreEqual("Fake", actual.Operations.First().Name);
        Assert.AreEqual(0, actual.Constants.Count);
        Assert.AreEqual(1, actual.Models.Count);
        Assert.AreEqual("First", actual.Models.First().Name);
    }

    [TestCase]
    public static void MappingAnApiVersionContainingMultipleModels()
    {
        var actual = ResourceDefinition.Map(new ResourceVersionWithMultipleModels());
        Assert.NotNull(actual);
        Assert.AreEqual("ResourceVersionWithMultipleModels", actual.Name);
        Assert.AreEqual(1, actual.Operations.Count);
        Assert.AreEqual("Fake", actual.Operations.First().Name);
        Assert.AreEqual(0, actual.Constants.Count);
        Assert.AreEqual(3, actual.Models.Count);
        Assert.AreEqual("First", actual.Models.First().Name);
        Assert.AreEqual("Other", actual.Models.Skip(1).First().Name);
        Assert.AreEqual("Third", actual.Models.Skip(2).First().Name);
    }

    [TestCase]
    public static void MappingAnApiVersionContainingASingleConstant()
    {
        var actual = ResourceDefinition.Map(new ResourceVersionWithASingleConstant());
        Assert.NotNull(actual);
        Assert.AreEqual("ResourceVersionWithASingleConstant", actual.Name);
        Assert.AreEqual(1, actual.Operations.Count);
        Assert.AreEqual("Fake", actual.Operations.First().Name);
        Assert.AreEqual(1, actual.Constants.Count);
        Assert.AreEqual("First", actual.Constants.First().Name);
        Assert.AreEqual(0, actual.Models.Count);
    }

    [TestCase]
    public static void MappingAnApiVersionContainingMultipleConstants()
    {
        var actual = ResourceDefinition.Map(new ResourceVersionWithMultipleConstants());
        Assert.NotNull(actual);
        Assert.AreEqual("ResourceVersionWithMultipleConstants", actual.Name);
        Assert.AreEqual(1, actual.Operations.Count);
        Assert.AreEqual("Fake", actual.Operations.First().Name);
        Assert.AreEqual(2, actual.Constants.Count);
        Assert.AreEqual("First", actual.Constants.First().Name);
        Assert.AreEqual("Second", actual.Constants.Skip(1).First().Name);
        Assert.AreEqual(0, actual.Models.Count);
    }

    [TestCase]
    public static void MappingAnApiVersionContainingAConstantInTheResourceID()
    {
        var actual = ResourceDefinition.Map(new ResourceVersionWithAConstantInTheResourceID());
        Assert.NotNull(actual);
        Assert.AreEqual("ResourceVersionWithAConstantInTheResourceID", actual.Name);
        Assert.AreEqual(1, actual.Operations.Count);
        Assert.AreEqual("FakeOperationWithAConstantInTheResourceID", actual.Operations.First().Name);
        Assert.AreEqual(1, actual.Constants.Count);
        Assert.AreEqual("PlanetName", actual.Constants.First().Name);
        Assert.AreEqual(0, actual.Models.Count);
    }

    [TestCase]
    public static void MappingAnApiVersionContainingAConstantInBothTheResourceIDAndResource()
    {
        var actual = ResourceDefinition.Map(new ResourceVersionWithAConstantInTheResourceIDAndResource());
        Assert.NotNull(actual);
        Assert.AreEqual("ResourceVersionWithAConstantInTheResourceIDAndResource", actual.Name);
        Assert.AreEqual(1, actual.Operations.Count);
        Assert.AreEqual("FakeOperationWithAConstantInTheResourceID", actual.Operations.First().Name);
        Assert.AreEqual(2, actual.Constants.Count);
        Assert.AreEqual("PlanetName", actual.Constants.First().Name);
        Assert.AreEqual("Second", actual.Constants.Skip(1).First().Name);
        Assert.AreEqual(0, actual.Models.Count);
    }

    [TestCase]
    public static void MappingAnApiVersionContainingAConstantInBothTheResourceIDAndResourceDuplicateType()
    {
        var actual = ResourceDefinition.Map(new ResourceVersionWithAConstantInTheResourceIDAndResourceDuplicateType());
        Assert.NotNull(actual);
        Assert.AreEqual("ResourceVersionWithAConstantInTheResourceIDAndResourceDuplicateType", actual.Name);
        Assert.AreEqual(1, actual.Operations.Count);
        Assert.AreEqual("FakeOperationWithAConstantInTheResourceID", actual.Operations.First().Name);
        Assert.AreEqual(1, actual.Constants.Count);
        Assert.AreEqual("PlanetName", actual.Constants.First().Name);
        Assert.AreEqual(0, actual.Models.Count);
    }

    private class ResourceVersionWithNoOperations : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ApiVersionWithNoOperations";
        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>();
        public IEnumerable<Type> Constants => new List<Type>();
        public IEnumerable<Type> Models => new List<Type>();
    }

    private class ResourceVersionWithASingleOperation : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ApiVersionWithASingleOperation";
        public IEnumerable<ApiOperation> Operations => new List<ApiOperation> { new FakeOperation() };
        public IEnumerable<Type> Constants => new List<Type>();
        public IEnumerable<Type> Models => new List<Type>();
    }

    private class ResourceVersionWithAMultipleOperations : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ApiVersionWithAMultipleOperations";

        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
            {new FakeOperation(), new FakeOtherOperation()};

        public IEnumerable<Type> Constants => new List<Type>();
        public IEnumerable<Type> Models => new List<Type>();
    }
    private class FakeOperation : PutOperation
    {
        public override Type? RequestObject() => null;
    }

    private class FakeOtherOperation : GetOperation
    {
        public override Type? ResponseObject() => null;
    }

    private class ResourceVersionWithASingleModel : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ResourceVersionWithASingleModel";

        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new FakeOperation(),
        };
        public IEnumerable<Type> Constants => new List<Type>();
        public IEnumerable<Type> Models => new List<Type>
        {
            typeof(FirstModel),
        };
    }

    private class ResourceVersionWithMultipleModels : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ResourceVersionWithMultipleModels";

        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new FakeOperation(),
        };

        public IEnumerable<Type> Constants => new List<Type>();
        public IEnumerable<Type> Models => new List<Type>
        {
            typeof(FirstModel),
            typeof(OtherModel),
            typeof(ThirdModel),
        };
    }

    private class ResourceVersionWithASingleConstant : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ResourceVersionWithASingleConstant";

        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new FakeOperation(),
        };

        public IEnumerable<Type> Constants => new List<Type>
        {
            typeof(FirstConstant),
        };

        public IEnumerable<Type> Models => new List<Type>();
    }

    private class ResourceVersionWithMultipleConstants : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ResourceVersionWithMultipleConstants";

        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new FakeOperation(),
        };

        public IEnumerable<Type> Constants => new List<Type>
        {
            typeof(FirstConstant),
            typeof(SecondConstant),
        };

        public IEnumerable<Type> Models => new List<Type>();
    }


    private class ResourceVersionWithAConstantInTheResourceIDAndResource : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ResourceVersionWithAConstantInTheResourceIDAndResource";

        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new FakeOperationWithAConstantInTheResourceID(),
        };

        public IEnumerable<Type> Constants => new List<Type>
        {
            typeof(SecondConstant),
        };

        public IEnumerable<Type> Models => new List<Type>();
    }

    private class ResourceVersionWithAConstantInTheResourceIDAndResourceDuplicateType : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ResourceVersionWithAConstantInTheResourceIDAndResourceDuplicateType";

        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new FakeOperationWithAConstantInTheResourceID(),
        };

        public IEnumerable<Type> Constants => new List<Type>
        {
            typeof(PlanetNameConstant),
        };

        public IEnumerable<Type> Models => new List<Type>();
    }

    private class ResourceVersionWithAConstantInTheResourceID : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "ResourceVersionWithAConstantInTheResourceID";

        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new FakeOperationWithAConstantInTheResourceID(),
        };

        public IEnumerable<Type> Constants => new List<Type>
        {
        };

        public IEnumerable<Type> Models => new List<Type>();
    }

    private class FakeOperationWithAConstantInTheResourceID : GetOperation
    {
        public override Definitions.Interfaces.ResourceID? ResourceId()
        {
            return new ResourceIDContainingAConstant();
        }
    }

    private class ResourceIDContainingAConstant : Definitions.Interfaces.ResourceID
    {
        public string? CommonAlias => null;
        public string ID => "/planets/{planetName}";
        public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
        {
            ResourceIDSegment.Static("planets", "planets"),
            ResourceIDSegment.Constant("planetName", typeof(PlanetNameConstant)),
        };
    }

    private class FirstModel
    {
        [JsonPropertyName("firstExample")]
        public string FirstExample { get; set; }
    }
    private class OtherModel
    {
        [JsonPropertyName("secondExample")]
        public string SecondExample { get; set; }
    }
    private class ThirdModel
    {
        [JsonPropertyName("thirdExample")]
        public string ThirdExample { get; set; }
    }

    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    private enum FirstConstant
    {
        [System.ComponentModel.Description("firstValue")]
        FirstValue,
    }
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    private enum SecondConstant
    {
        [System.ComponentModel.Description("secondValue")]
        SecondValue,
    }
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    private enum PlanetNameConstant
    {
        [System.ComponentModel.Description("earth")]
        Earth,
        [System.ComponentModel.Description("mars")]
        Mars,
    }
}