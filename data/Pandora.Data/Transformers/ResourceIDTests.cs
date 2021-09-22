using System.Collections.Generic;
using NUnit.Framework;
using Pandora.Definitions.Interfaces;

namespace Pandora.Data.Transformers
{
    public static class ResourceIDTests
    {
        // TODO: add an Operation test in time for "With Constants" (when threading through the Mappings in the next PR)
        // to ensure constants get picked out
        
        // TODO: more tests
        
        [TestCase]
        public static void MappingAResourceIDWithNoSegments()
        {
            var expected = new HelloWorldStaticResourceId();
            var actual = ResourceID.Map(expected);
            Assert.AreEqual("/hello/world", actual.Format);
        }

        [TestCase]
        public static void MappingAResourceIDWithASingleSegment()
        {
            var expected = new HelloWorldUserSpecifiableResourceId();
            var actual = ResourceID.Map(expected);
            Assert.AreEqual("/hello/{world}", actual.Format);
        }

        [TestCase]
        public static void MappingAResourceIDWithMultipleSegments()
        {
            var expected = new ResourceGroupResourceId();
            var actual = ResourceID.Map(expected);
            Assert.AreEqual("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}", actual.Format);
        }
        
        private class HelloWorldStaticResourceId : Definitions.Interfaces.ResourceID
        {
            public string ID() => "/hello/world";

            public List<ResourceIDSegment> Segments() => new List<ResourceIDSegment>
            {
                new()
                {
                    Name = "hello",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "hello"
                },
                new()
                {
                    Name = "world",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "world"
                }
            };
        }
        
        private class HelloWorldUserSpecifiableResourceId : Definitions.Interfaces.ResourceID
        {
            public string ID() => "/hello/{world}";

            public List<ResourceIDSegment> Segments() => new List<ResourceIDSegment>
            {
                new()
                {
                    Name = "hello",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "hello"
                },
                new()
                {
                    Name = "world",
                    Type = ResourceIDSegmentType.UserSpecified,
                }
            };
        }
        
        private class ResourceGroupResourceId : Definitions.Interfaces.ResourceID
        {
            public string ID() => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}";

            public List<ResourceIDSegment> Segments() => new List<ResourceIDSegment>
            {
                new()
                {
                    Name = "subscriptions",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "subscriptions"
                },
                new()
                {
                    Name = "subscriptionId",
                    Type = ResourceIDSegmentType.SubscriptionId,
                },
                new()
                {
                    Name = "resourceGroups",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "resourceGroups"
                },
                new()
                {
                    Name = "resourceGroup",
                    Type = ResourceIDSegmentType.ResourceGroup,
                }
            };
        }
    }
}