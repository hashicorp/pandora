using NUnit.Framework;

namespace Pandora.Data.Transformers
{
    public static class ResourceIDTests
    {
        [TestCase]
        public static void MappingAResourceIDWithNoSegments()
        {
            var input = new TestingResourceId("/hello/world");
            var actual = ResourceID.Map(input);
            Assert.AreEqual("/hello/world", actual.Format);
        }

        [TestCase]
        public static void MappingAResourceIDWithASingleSegment()
        {
            var input = new TestingResourceId("/hello/{world}");
            var actual = ResourceID.Map(input);
            Assert.AreEqual("/hello/{world}", actual.Format);
        }

        [TestCase]
        public static void MappingAResourceIDWithMultipleSegments()
        {
            var input = new TestingResourceId("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}");
            var actual = ResourceID.Map(input);
            Assert.AreEqual("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}", actual.Format);
        }

        private class TestingResourceId : Definitions.Interfaces.ResourceID
        {
            private readonly string _format;

            public TestingResourceId(string format)
            {
                _format = format;
            }

            public string ID()
            {
                return _format;
            }
        }
    }
}