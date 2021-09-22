using System;
using System.Collections.Generic;
using NUnit.Framework;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;

namespace Pandora.Data.Transformers
{
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
            Assert.AreEqual(1, actual.Apis.Count);
        }

        [TestCase]
        public static void MappingAVersionContainingADuplicateOperationTwiceShouldRaiseAnError()
        {
            Assert.Throws<Exception>(() => Version.Map(new VersionDefinitionWithDuplicateOperations()));
        }

        private class VersionDefinitionWithNoOperations : ApiVersionDefinition
        {
            public string ApiVersion => "SomeVersion";
            public bool Generate => false;
            public bool Preview => false;
            public IEnumerable<ApiDefinition> Apis => new List<ApiDefinition>();
        }

        private class VersionDefinitionWithASingleOperation : ApiVersionDefinition
        {
            public string ApiVersion => "SomeVersion";
            public bool Generate => true;
            public bool Preview => false;
            public IEnumerable<ApiDefinition> Apis => new List<ApiDefinition> { new SomeApiDefinition() };
        }

        private class VersionDefinitionWithDuplicateOperations : ApiVersionDefinition
        {
            public string ApiVersion => "SomeVersion";
            public bool Generate => true;
            public bool Preview => false;
            public IEnumerable<ApiDefinition> Apis => new List<ApiDefinition> { new SomeApiDefinition(), new SomeApiDefinition() };
        }

        private class SomeApiDefinition : ApiDefinition
        {
            public string ApiVersion => "2018-01-01";
            public string Name => "example";
            public IEnumerable<ApiOperation> Operations => new List<ApiOperation> { new FakeApiOperation() };
            public Definitions.Interfaces.ResourceID ResourceId => new FakeResourceId();
        }

        private class FakeApiOperation : GetOperation
        {
            public override Type? ResponseObject()
            {
                return typeof(SomeObject);
            }

            private class SomeObject
            {
            }
        }

        private class FakeResourceId : Definitions.Interfaces.ResourceID
        {
            public string ID() => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}";

            public List<ResourceIDSegment> Segments()
            {
                return new List<ResourceIDSegment>
                {
                    new()
                    {
                        Type = ResourceIDSegmentType.Static,
                        FixedValue = "subscriptions",
                        Name = "subscriptions",
                    },
                    new()
                    {
                        Type = ResourceIDSegmentType.SubscriptionId,
                        Name = "subscriptionId",
                    },
                    new()
                    {
                        Type = ResourceIDSegmentType.Static,
                        FixedValue = "resourceGroups",
                        Name = "resourceGroups",
                    },
                    new()
                    {
                        Type = ResourceIDSegmentType.ResourceGroup,
                        Name = "resourceGroups",
                    },
                };
            }
        }
    }
}