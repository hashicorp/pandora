using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using NUnit.Framework;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;

namespace Pandora.Data.Transformers;

public static class ServiceTests
{
    [TestCase]
    public static void MappingWithNoVersionsShouldFail()
    {
        Assert.Throws<Exception>(() => Service.Map(new NoVersionsContainer.ServiceWithNoVersions()));
    }

    [TestCase]
    public static void MappingAResourceManagerService()
    {
        var actual = Service.Map(new ResourceManagerContainer.FakeResourceManagerService());
        Assert.NotNull(actual);
        Assert.AreEqual("FakeResourceManager", actual.Name);
        Assert.AreEqual(true, actual.ResourceManager);
        Assert.AreEqual("Microsoft.Foo", actual.ResourceProvider);
        Assert.AreEqual("foo", actual.TerraformPackageName);
        Assert.AreEqual(0, actual.TerraformResources.Count());
    }

    [TestCase]
    public static void MappingAResourceManagerServiceContainingResources()
    {
        var actual = Service.Map(new ResourceManagerContainer.FakeResourceManagerServiceWithTerraformResource());
        Assert.NotNull(actual);
        Assert.AreEqual("FakeResourceManagerServiceWithTerraformResource", actual.Name);
        Assert.AreEqual(true, actual.ResourceManager);
        Assert.AreEqual("Microsoft.Foo", actual.ResourceProvider);
        Assert.AreEqual("foo", actual.TerraformPackageName);
        Assert.AreEqual(1, actual.TerraformResources.Count());
    }

    [TestCase]
    public static void MappingAResourceManagerServiceContainingDuplicateResources()
    {
        Assert.Throws<Exception>(() => Service.Map(new ResourceManagerContainer.FakeResourceManagerServiceWithDuplicateTerraformResources()));
    }

    [TestCase]
    public static void MappingANonResourceManagerService()
    {
        var actual = Service.Map(new FakeDataPlaneContainer.FakeDataPlaneService());
        Assert.NotNull(actual);
        Assert.AreEqual("FakeDataPlane", actual.Name);
        Assert.AreEqual(false, actual.ResourceManager);
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
            public bool GenerateSchema => true;
            public MethodDefinition ReadMethod => new MethodDefinition
            {
                Generate = true,
                Method = typeof(FakeTerraformOperation),
                TimeoutInMinutes = 30,
            };

            public Definitions.Interfaces.ResourceID ResourceId => new FakeTerraformOperationResourceId();
            public string ResourceLabel => "fake_resource";
            public MethodDefinition? UpdateMethod => new MethodDefinition
            {
                Generate = true,
                Method = typeof(FakeTerraformOperation),
                TimeoutInMinutes = 30,
            };
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
