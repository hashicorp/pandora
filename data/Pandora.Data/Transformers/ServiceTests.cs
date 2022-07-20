using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using NUnit.Framework;
using Pandora.Definitions;
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
        var action = Service.Map(new ResourceManagerContainer.FakeResourceManagerService());
        Assert.NotNull(action);
        Assert.AreEqual("FakeResourceManager", action.Name);
        Assert.AreEqual(true, action.ResourceManager);
        Assert.AreEqual("Microsoft.Foo", action.ResourceProvider);
        Assert.AreEqual("foo", action.TerraformPackageName);
    }

    [TestCase]
    public static void MappingANonResourceManagerService()
    {
        var action = Service.Map(new FakeDataPlaneContainer.FakeDataPlaneService());
        Assert.NotNull(action);
        Assert.AreEqual("FakeDataPlane", action.Name);
        Assert.AreEqual(false, action.ResourceManager);
        Assert.Null(action.ResourceProvider);
        Assert.Null(action.TerraformPackageName);
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
            public IEnumerable<Definitions.Interfaces.TerraformResourceDefinition> TerraformResources => new List<Definitions.Interfaces.TerraformResourceDefinition>();
            public Source Source => Source.HandWritten;
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