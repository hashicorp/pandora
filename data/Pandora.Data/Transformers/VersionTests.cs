using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Pandora.Data.Models;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;

namespace Pandora.Data.Transformers;

public static class VersionTests
{
    [TestCase]
    public static void MappingAVersionWithoutAnyOperationsShouldFail()
    {
        Assert.Throws<Exception>(() => Version.Map(new VersionDefinitionWithNoOperations()));
    }

    [TestCase]
    public static void MappingAVersionWithASingleApiDefinition()
    {
        var actual = Version.Map(new VersionDefinitionWithASingleOperation());
        Assert.NotNull(actual);
        Assert.AreEqual("SomeVersion", actual.Version);
        Assert.AreEqual(true, actual.Generate);
        Assert.AreEqual(false, actual.Preview);
        Assert.AreEqual(1, actual.Resources.Count());
        Assert.AreEqual(0, actual.TerraformResources.Count());
        Assert.AreEqual(ApiDefinitionsSource.HandWritten, actual.Source);
    }

    [TestCase]
    public static void MappingAVersionWithASingleApiDefinitionAndATerraformResource()
    {
        var actual = Version.Map(new VersionDefinitionWithASingleOperationAndATerraformResource());
        Assert.NotNull(actual);
        Assert.AreEqual("SomeVersion", actual.Version);
        Assert.AreEqual(true, actual.Generate);
        Assert.AreEqual(false, actual.Preview);
        Assert.AreEqual(1, actual.Resources.Count());
        Assert.AreEqual(1, actual.TerraformResources.Count());
        Assert.AreEqual(ApiDefinitionsSource.HandWritten, actual.Source);
    }

    [TestCase]
    public static void MappingAVersionWithDuplicateTerraformResourcesShouldRaiseAnError()
    {
        Assert.Throws<Exception>(() => Version.Map(new VersionDefinitionWithDuplicateOperations()));
    }

    [TestCase]
    public static void MappingAVersionContainingADuplicateOperationTwiceShouldRaiseAnError()
    {
        Assert.Throws<Exception>(() => Version.Map(new VersionDefinitionWithDuplicateTerraformResources()));
    }

    private class VersionDefinitionWithNoOperations : ApiVersionDefinition
    {
        public string ApiVersion => "SomeVersion";
        public bool Generate => false;
        public bool Preview => false;
        public IEnumerable<Definitions.Interfaces.ResourceDefinition> Resources => new List<Definitions.Interfaces.ResourceDefinition>();
        public IEnumerable<Definitions.Interfaces.TerraformResourceDefinition> TerraformResources => new List<Definitions.Interfaces.TerraformResourceDefinition>();
        public Source Source => Source.HandWritten;
    }

    private class VersionDefinitionWithASingleOperation : ApiVersionDefinition
    {
        public string ApiVersion => "SomeVersion";
        public bool Generate => true;
        public bool Preview => false;
        public IEnumerable<Definitions.Interfaces.ResourceDefinition> Resources => new List<Definitions.Interfaces.ResourceDefinition> { new SomeResourceDefinition() };
        public IEnumerable<Definitions.Interfaces.TerraformResourceDefinition> TerraformResources => new List<Definitions.Interfaces.TerraformResourceDefinition>();
        public Source Source => Source.HandWritten;
    }

    public class VersionDefinitionWithASingleOperationAndATerraformResource : ApiVersionDefinition
    {
        public string ApiVersion => "SomeVersion";
        public bool Generate => true;
        public bool Preview => false;
        public IEnumerable<Definitions.Interfaces.ResourceDefinition> Resources => new List<Definitions.Interfaces.ResourceDefinition>
        {
            new SomeResourceDefinition(),
        };
        
        public IEnumerable<Definitions.Interfaces.TerraformResourceDefinition> TerraformResources => new List<Definitions.Interfaces.TerraformResourceDefinition>
        {
            new ExampleTerraformDefinition(),
        };
        public Source Source => Source.HandWritten;
    }

    private class VersionDefinitionWithDuplicateOperations : ApiVersionDefinition
    {
        public string ApiVersion => "SomeVersion";
        public bool Generate => true;
        public bool Preview => false;
        public IEnumerable<Definitions.Interfaces.ResourceDefinition> Resources => new List<Definitions.Interfaces.ResourceDefinition> { new SomeResourceDefinition(), new SomeResourceDefinition() };
        
        public IEnumerable<Definitions.Interfaces.TerraformResourceDefinition> TerraformResources => new List<Definitions.Interfaces.TerraformResourceDefinition>();
        public Source Source => Source.HandWritten;
    }
    
    public class VersionDefinitionWithDuplicateTerraformResources : ApiVersionDefinition
    {
        public string ApiVersion => "SomeVersion";
        public bool Generate => true;
        public bool Preview => false;
        public IEnumerable<Definitions.Interfaces.ResourceDefinition> Resources => new List<Definitions.Interfaces.ResourceDefinition> {};
        
        public IEnumerable<Definitions.Interfaces.TerraformResourceDefinition> TerraformResources => new List<Definitions.Interfaces.TerraformResourceDefinition>
        {
            new ExampleTerraformDefinition(),
            new ExampleTerraformDefinition(),
        };
        public Source Source => Source.HandWritten;
    }

    private class SomeResourceDefinition : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "example";
        public IEnumerable<ApiOperation> Operations => new List<ApiOperation> { new v2020_01_01.Example.FakeApiOperation() };
    }

    private class ExampleTerraformDefinition : Definitions.Interfaces.TerraformResourceDefinition
    {
        public MethodDefinition DeleteMethod => new MethodDefinition
        {
            Generate = false,
            Method = typeof(v2020_01_01.Example.FakeApiOperation),
            TimeoutInMinutes = 10,
        };

        public string DisplayName => "Example Resource";
        public bool GenerateIDValidationFunction => true;
        public bool GenerateSchema => true;
        public Definitions.Interfaces.ResourceID ResourceId => new v2020_01_01.Example.FakeResourceId();
        public string ResourceLabel => "example_resource";
        public string ResourceName => "ExampleResource";
    }


    private class v2020_01_01
    {
        internal class Example
        {
            internal class FakeApiOperation : GetOperation
            {
                public override Type? ResponseObject()
                {
                    return typeof(SomeObject);
                }

                private class SomeObject
                {
                }
            }

            internal class FakeResourceId : Definitions.Interfaces.ResourceID
            {
                public string? CommonAlias => null;

                public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}";

                public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
                {
                    ResourceIDSegment.Static("subscriptions", "subscriptions"),
                    ResourceIDSegment.SubscriptionId("subscriptionId"),
                    ResourceIDSegment.Static("resourceGroups", "resourceGroups"),
                    ResourceIDSegment.ResourceGroup("resourceGroup"),
                };
            }
        }
    }
}