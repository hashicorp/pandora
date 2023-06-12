using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using NUnit.Framework;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Mappings;
using Pandora.Definitions.Operations;
using ServiceDefinition = Pandora.Definitions.Interfaces.ServiceDefinition;

namespace Pandora.Data.Transformers;

public static class ServiceTests
{
    [TestCase]
    public static void MappingWithNoVersionsShouldFail()
    {
        Assert.Throws<Exception>(() => Service.Map(new NoVersionsContainer.ServiceWithNoVersions(), ServiceDefinitionType.ResourceManager));
    }

    [TestCase]
    public static void MappingAResourceManagerService()
    {
        var actual = Service.Map(new ResourceManagerContainer.FakeResourceManagerService(), ServiceDefinitionType.ResourceManager);
        Assert.NotNull(actual);
        Assert.AreEqual("FakeResourceManager", actual.Name);
        Assert.AreEqual(ServiceDefinitionType.ResourceManager, actual.DefinitionType);
        Assert.AreEqual("Microsoft.Foo", actual.ResourceProvider);
        Assert.AreEqual("foo", actual.TerraformPackageName);
        Assert.AreEqual(0, actual.TerraformResources.Count());
    }

    [TestCase]
    public static void MappingAResourceManagerServiceContainingResources()
    {
        var actual = Service.Map(new ResourceManagerContainer.FakeResourceManagerServiceWithTerraformResource(), ServiceDefinitionType.ResourceManager);
        Assert.NotNull(actual);
        Assert.AreEqual("FakeResourceManagerServiceWithTerraformResource", actual.Name);
        Assert.AreEqual(ServiceDefinitionType.ResourceManager, actual.DefinitionType);
        Assert.AreEqual("Microsoft.Foo", actual.ResourceProvider);
        Assert.AreEqual("foo", actual.TerraformPackageName);
        Assert.AreEqual(1, actual.TerraformResources.Count());
    }

    [TestCase]
    public static void MappingAResourceManagerServiceContainingDuplicateResources()
    {
        Assert.Throws<Exception>(() => Service.Map(new ResourceManagerContainer.FakeResourceManagerServiceWithDuplicateTerraformResources(), ServiceDefinitionType.ResourceManager));
    }

    [TestCase]
    public static void MappingANonResourceManagerService()
    {
        var actual = Service.Map(new FakeDataPlaneContainer.FakeDataPlaneService(), ServiceDefinitionType.DataPlane);
        Assert.NotNull(actual);
        Assert.AreEqual("FakeDataPlane", actual.Name);
        Assert.AreEqual(ServiceDefinitionType.DataPlane, actual.DefinitionType);
        Assert.Null(actual.ResourceProvider);
        Assert.Null(actual.TerraformPackageName);
        Assert.AreEqual(0, actual.TerraformResources.Count());
    }

    // since we look the versions up dynamically, putting these within their own class/namespace allows these to be discovered separately
    private class FakeDataPlaneContainer
    {
        internal class FakeDataPlaneService : ServiceDefinition
        {
            public string Name => "FakeDataPlane";
            public bool Generate => true;
            public string? ResourceProvider => null;

            public string? TerraformPackageName => null;
            public IEnumerable<Definitions.Interfaces.TerraformResourceDefinition> TerraformResources => new List<Definitions.Interfaces.TerraformResourceDefinition>();
        }

        // found via discovery/reflection
        private class FakeApiVersion : ApiVersionDefinition
        {
            public string ApiVersion => "SomeVersion";
            public bool Generate => true;
            public bool Preview => true;
            public IEnumerable<Definitions.Interfaces.ResourceDefinition> Resources => new List<Definitions.Interfaces.ResourceDefinition> { new FakeResourceDefinition() };
            public IEnumerable<Definitions.Interfaces.TerraformResourceDefinition> TerraformResources => new List<Definitions.Interfaces.TerraformResourceDefinition>();
            public Source Source => Source.HandWritten;
        }
    }

    private class NoVersionsContainer
    {
        internal class ServiceWithNoVersions : ServiceDefinition
        {
            public string Name => "Bob";
            public bool Generate => true;
            public string? ResourceProvider => "Hello";

            public string? TerraformPackageName => "bob";
            public IEnumerable<Definitions.Interfaces.TerraformResourceDefinition> TerraformResources => new List<Definitions.Interfaces.TerraformResourceDefinition>();
        }
    }

    internal class ResourceManagerContainer
    {
        internal class FakeResourceManagerServiceWithDuplicateTerraformResources : ServiceDefinition
        {
            public string Name => "FakeResourceManagerServiceWithDuplicateTerraformResources";
            public bool Generate => false;
            public string? ResourceProvider => "Microsoft.Foo";
            public string? TerraformPackageName => "foo";
            public IEnumerable<Definitions.Interfaces.TerraformResourceDefinition> TerraformResources => new List<Definitions.Interfaces.TerraformResourceDefinition>
            {
                new FakeTerraformResourceDefinition(),
                new FakeTerraformResourceDefinition(),
            };
        }

        internal class FakeResourceManagerServiceWithTerraformResource : ServiceDefinition
        {
            public string Name => "FakeResourceManagerServiceWithTerraformResource";
            public bool Generate => false;
            public string? ResourceProvider => "Microsoft.Foo";
            public string? TerraformPackageName => "foo";
            public IEnumerable<Definitions.Interfaces.TerraformResourceDefinition> TerraformResources => new List<Definitions.Interfaces.TerraformResourceDefinition>
            {
                new FakeTerraformResourceDefinition(),
            };
        }

        internal class FakeResourceManagerService : ServiceDefinition
        {
            public string Name => "FakeResourceManager";
            public bool Generate => false;
            public string? ResourceProvider => "Microsoft.Foo";
            public string? TerraformPackageName => "foo";
            public IEnumerable<Definitions.Interfaces.TerraformResourceDefinition> TerraformResources => new List<Definitions.Interfaces.TerraformResourceDefinition>();
        }

        // looks like this isn't used, but it is since it's found via Discovery (which is why this has to be internal)
        internal class FakeApiVersion : ApiVersionDefinition
        {
            public string ApiVersion => "SomeVersion";
            public bool Generate => true;
            public bool Preview => true;
            public IEnumerable<Definitions.Interfaces.ResourceDefinition> Resources => new List<Definitions.Interfaces.ResourceDefinition> { new FakeResourceDefinition() };
            public Source Source => Source.HandWritten;
        }

        internal class FakeTerraformResourceDefinition : Definitions.Interfaces.TerraformResourceDefinition
        {
            public MethodDefinition CreateMethod => new MethodDefinition
            {
                Generate = true,
                Method = typeof(FakeTerraformOperation),
                TimeoutInMinutes = 30,
            };
            public MethodDefinition DeleteMethod => new MethodDefinition
            {
                Generate = true,
                Method = typeof(FakeTerraformOperation),
                TimeoutInMinutes = 30,
            };
            public string DisplayName => "Fake Resource";
            public bool GenerateIDValidationFunction => true;
            public bool GenerateModel => true;
            public bool GenerateSchema => true;
            public MethodDefinition ReadMethod => new MethodDefinition
            {
                Generate = true,
                Method = typeof(FakeTerraformOperation),
                TimeoutInMinutes = 30,
            };
            public Definitions.Interfaces.ResourceID ResourceId => new FakeTerraformOperationResourceId();
            public string ResourceLabel => "fake_resource";
            public string ResourceCategory => "fake resource category";
            public string ResourceDescription => "fake resource description";
            public string ResourceExampleUsage => "fake example usage";
            public Type? SchemaModel => typeof(FakeTerraformSchemaModel);
            public Definitions.Interfaces.TerraformMappingDefinition SchemaMappings => new FakeTerraformResourceMappings();
            public Definitions.Interfaces.TerraformResourceTestDefinition Tests => new FakeTestDefinition();

            public MethodDefinition? UpdateMethod => new MethodDefinition
            {
                Generate = true,
                Method = typeof(FakeTerraformOperation),
                TimeoutInMinutes = 30,
            };
        }

        private class FakeTerraformResourceMappings : Definitions.Interfaces.TerraformMappingDefinition
        {
            public List<MappingType> Mappings => new List<MappingType>();
        }

        private class FakeTerraformSchemaModel
        {
            [Required]
            [HclName("some_field")]
            public string SomeField { get; set; }
        }

        private class FakeTerraformOperation : GetOperation
        {
            public override Type? RequestObject()
            {
                return typeof(FakeTerraformModel);
            }

            public override Definitions.Interfaces.ResourceID? ResourceId()
            {
                return new FakeTerraformOperationResourceId();
            }
        }

        internal class FakeTerraformOperationResourceId : Definitions.Interfaces.ResourceID
        {
            public string? CommonAlias => null;
            public string ID => "/planets/{planetName}";
            public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
            {
                ResourceIDSegment.Static("planets", "planets"),
                ResourceIDSegment.UserSpecified("planetName"),
            };
        }

        private class FakeTerraformModel
        {
            [JsonPropertyName("example")]
            public string Example { get; set; }
        }
    }

    private class FakeResourceDefinition : Definitions.Interfaces.ResourceDefinition
    {
        public string Name => "example";
        public IEnumerable<ApiOperation> Operations => new List<ApiOperation> { new FakeApiOperation() };
        public IEnumerable<Type> Constants => new List<Type>();

        public IEnumerable<Type> Models => new List<Type>
        {
            typeof(FakeObject),
        };
    }

    private class FakeApiOperation : GetOperation
    {
        public override Type? ResponseObject()
        {
            return typeof(FakeObject);
        }
    }

    private class FakeObject
    {
        [JsonPropertyName("hello")]
        public bool Hello { get; set; }
    }
}


internal class FakeTestDefinition : Definitions.Interfaces.TerraformResourceTestDefinition
{
    public string BasicTestConfig => "basic";
    public string RequiresImportConfig => "requires import";
    public string? CompleteConfig => null;
    public string? TemplateConfig => null;
    public Dictionary<string, List<string>> OtherTests => new Dictionary<string, List<string>>();
}
