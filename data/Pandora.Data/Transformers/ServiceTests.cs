using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using NUnit.Framework;
using Pandora.Definitions;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;

namespace Pandora.Data.Transformers
{
    public static class ServiceTests
    {
        // TODO: tests with data sources/resources and duplicates etc
        
        [TestCase]
        public static void MappingWithNoVersionsShouldFail()
        {
            Assert.Throws<NotSupportedException>(() => Service.Map(new ServiceWithNoVersions()));
        }

        [TestCase]
        public static void MappingAResourceManagerService()
        {
            var action = Service.Map(new FakeResourceManagerService());
            Assert.NotNull(action);
            Assert.AreEqual("FakeResourceManager", action.Name);
            Assert.AreEqual(true, action.ResourceManager);
            Assert.AreEqual("Microsoft.Foo", action.ResourceProvider);
        }

        [TestCase]
        public static void MappingANonResourceManagerService()
        {
            var action = Service.Map(new FakeDataPlaneService());
            Assert.NotNull(action);
            Assert.AreEqual("FakeDataPlane", action.Name);
            Assert.AreEqual(false, action.ResourceManager);
            Assert.Null(action.ResourceProvider);
        }

        [TestCase]
        public static void MappingAServiceContainingDuplicateVersionsShouldFail()
        {
            Assert.Throws<NotSupportedException>(() => Service.Map(new FakeResourceManagerWithDuplicateVersionsService()));
        }

        private class ServiceWithNoVersions : ServiceDefinition
        {
            public string Name => "Bob";
            public bool Generate => true;
            public string? ResourceProvider => "Hello";
            public IEnumerable<TerraformResourceDefinition> Resources => new List<TerraformResourceDefinition>();
            public IEnumerable<ApiVersionDefinition> Versions => new List<ApiVersionDefinition>();
        }

        private class FakeDataPlaneService : ServiceDefinition
        {
            public string Name => "FakeDataPlane";
            public bool Generate => true;
            public string? ResourceProvider => null;
            public IEnumerable<TerraformResourceDefinition> Resources => new List<TerraformResourceDefinition>();
            public IEnumerable<ApiVersionDefinition> Versions => new List<ApiVersionDefinition> { new FakeApiVersion() };
        }

        private class FakeResourceManagerService : ServiceDefinition
        {
            public string Name => "FakeResourceManager";
            public bool Generate => false;
            public string? ResourceProvider => "Microsoft.Foo";
            public IEnumerable<TerraformResourceDefinition> Resources => new List<TerraformResourceDefinition>();
            public IEnumerable<ApiVersionDefinition> Versions => new List<ApiVersionDefinition> { new FakeApiVersion() };
        }

        private class FakeResourceManagerWithDuplicateVersionsService : ServiceDefinition
        {
            public string Name => "FakeResourceManager";
            public bool Generate => false;
            public string? ResourceProvider => "Microsoft.Foo";
            public IEnumerable<TerraformResourceDefinition> Resources => new List<TerraformResourceDefinition>();
            public IEnumerable<ApiVersionDefinition> Versions => new List<ApiVersionDefinition>
            {
                new FakeApiVersion(),
                new FakeApiVersion()
            };
        }

        private class FakeApiVersion : ApiVersionDefinition
        {
            public string ApiVersion => "SomeVersion";
            public bool Generate => true;
            public bool Preview => true;
            public IEnumerable<ApiDefinition> Apis => new List<ApiDefinition> { new FakeApiDefinition() };
        }
        
        private class FakeApiDefinition : ApiDefinition
        {
            public string ApiVersion => "2018-01-01";
            public string Name => "example";
            public IEnumerable<ApiOperation> Operations => new List<ApiOperation> { new FakeApiOperation() };
            public Definitions.Interfaces.ResourceID ResourceId => new FakeResourceId();
        }

        private class FakeApiOperation : GetOperation
        {
            public override object? ResponseObject()
            {
                return new FakeObject();
            }
        }

        private class FakeObject
        {
            [JsonPropertyName("hello")]
            public bool Hello { get; set; }
        }

        private class FakeResourceId : Definitions.Interfaces.ResourceID
        {
            public string ID() => "/hello/{planet}";
        }
    }
}