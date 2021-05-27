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
        [TestCase]
        public static void MappingWithNoVersionsShouldFail()
        {
            Assert.Throws<NotSupportedException>(() => Service.Map(new NoVersionsContainer.ServiceWithNoVersions()));
        }

        [TestCase]
        public static void MappingAResourceManagerService()
        {
            var action = Service.Map(new ResourceManagerContainer.FakeResourceManagerService());
            Assert.NotNull(action);
            Assert.AreEqual("FakeResourceManager", action.Name);
            Assert.AreEqual(true, action.ResourceManager);
            Assert.AreEqual("Microsoft.Foo", action.ResourceProvider);
        }

        [TestCase]
        public static void MappingANonResourceManagerService()
        {
            var action = Service.Map(new FakeDataPlaneContainer.FakeDataPlaneService());
            Assert.NotNull(action);
            Assert.AreEqual("FakeDataPlane", action.Name);
            Assert.AreEqual(false, action.ResourceManager);
            Assert.Null(action.ResourceProvider);
        }

        // since we look the versions up dynamically, putting these within their own class/namespace allows these to be discovered separately
        private class FakeDataPlaneContainer
        {
            internal class FakeDataPlaneService : ServiceDefinition
            {
                public string Name => "FakeDataPlane";
                public bool Generate => true;
                public string? ResourceProvider => null;
            }
            
            // found via discovery/reflection
            private class FakeApiVersion : ApiVersionDefinition
            {
                public string ApiVersion => "SomeVersion";
                public bool Generate => true;
                public bool Preview => true;
                public IEnumerable<ApiDefinition> Apis => new List<ApiDefinition> { new FakeApiDefinition() };
            }
        }

        private class NoVersionsContainer
        {
            internal class ServiceWithNoVersions : ServiceDefinition
            {
                public string Name => "Bob";
                public bool Generate => true;
                public string? ResourceProvider => "Hello";
            }
        }

        internal class ResourceManagerContainer
        {
            internal class FakeResourceManagerService : ServiceDefinition
            {
                public string Name => "FakeResourceManager";
                public bool Generate => false;
                public string? ResourceProvider => "Microsoft.Foo";
            }

            // looks like this isn't used, but it is since it's found via Discovery (which is why this has to be internal)
            internal class FakeApiVersion : ApiVersionDefinition
            {
                public string ApiVersion => "SomeVersion";
                public bool Generate => true;
                public bool Preview => true;
                public IEnumerable<ApiDefinition> Apis => new List<ApiDefinition> { new FakeApiDefinition() };
            }
        }
        
        private class FakeApiDefinition : ApiDefinition
        {
            public string ApiVersion => "2018-01-01";
            public string Name => "example";
            public IEnumerable<ApiOperation> Operations => new List<ApiOperation> { new FakeApiOperation() };
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
    }
}