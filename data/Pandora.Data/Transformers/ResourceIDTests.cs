using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using NUnit.Framework;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;

namespace Pandora.Data.Transformers
{
    public static class ResourceIDTests
    {
        [TestCase]
        public static void MappingAResourceIDWithNoSegments()
        {
            var expected = new HelloWorldStaticResourceId();
            var actual = ResourceID.Map(expected);
            Assert.AreEqual("/hello/world", actual.IdString);
            Assert.AreEqual(0, actual.Constants.Count);
            Assert.AreEqual(2, actual.Segments.Count);

            var helloSegment = actual.Segments.First();
            Assert.AreEqual("hello", helloSegment.Name);
            Assert.AreEqual(ResourceIdSegmentType.Static, helloSegment.Type);
            Assert.Null(helloSegment.ConstantReference);
            Assert.AreEqual("hello", helloSegment.FixedValue);
            Assert.AreEqual("hello", helloSegment.ExampleValue);

            var worldSegment = actual.Segments.Skip(1).First();
            Assert.AreEqual("world", worldSegment.Name);
            Assert.AreEqual(ResourceIdSegmentType.Static, worldSegment.Type);
            Assert.Null(worldSegment.ConstantReference);
            Assert.AreEqual("world", worldSegment.FixedValue);
            Assert.AreEqual("world", worldSegment.ExampleValue);
        }

        [TestCase]
        public static void MappingAResourceIDWithASingleUserSpecifiedSegment()
        {
            var expected = new HelloWorldUserSpecifiableResourceId();
            var actual = ResourceID.Map(expected);
            Assert.AreEqual("/hello/{world}", actual.IdString);
            Assert.AreEqual(0, actual.Constants.Count);
            Assert.AreEqual(2, actual.Segments.Count);

            var helloSegment = actual.Segments.First();
            Assert.AreEqual("hello", helloSegment.Name);
            Assert.AreEqual(ResourceIdSegmentType.Static, helloSegment.Type);
            Assert.Null(helloSegment.ConstantReference);
            Assert.AreEqual("hello", helloSegment.FixedValue);
            Assert.AreEqual("hello", helloSegment.ExampleValue);

            var worldSegment = actual.Segments.Skip(1).First();
            Assert.AreEqual("world", worldSegment.Name);
            Assert.AreEqual(ResourceIdSegmentType.UserSpecified, worldSegment.Type);
            Assert.Null(worldSegment.ConstantReference);
            Assert.Null(worldSegment.FixedValue);
            Assert.AreEqual("worldValue", worldSegment.ExampleValue);
        }

        [TestCase]
        public static void MappingAResourceIDWithMultipleSegments()
        {
            var expected = new ResourceGroupResourceId();
            var actual = ResourceID.Map(expected);
            Assert.AreEqual("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}", actual.IdString);
            Assert.AreEqual(0, actual.Constants.Count);
            Assert.AreEqual(4, actual.Segments.Count);

            var subscriptionsSegment = actual.Segments.First();
            Assert.AreEqual("subscriptions", subscriptionsSegment.Name);
            Assert.AreEqual(ResourceIdSegmentType.Static, subscriptionsSegment.Type);
            Assert.Null(subscriptionsSegment.ConstantReference);
            Assert.AreEqual("subscriptions", subscriptionsSegment.FixedValue);
            Assert.AreEqual("subscriptions", subscriptionsSegment.ExampleValue);

            var subscriptionIdSegment = actual.Segments.Skip(1).First();
            Assert.AreEqual("subscriptionId", subscriptionIdSegment.Name);
            Assert.AreEqual(ResourceIdSegmentType.SubscriptionId, subscriptionIdSegment.Type);
            Assert.Null(subscriptionIdSegment.ConstantReference);
            Assert.Null(subscriptionIdSegment.FixedValue);
            Assert.AreEqual("12345678-1234-9876-4563-123456789012", subscriptionIdSegment.ExampleValue);

            var resourceGroupsSegment = actual.Segments.Skip(2).First();
            Assert.AreEqual("resourceGroups", resourceGroupsSegment.Name);
            Assert.AreEqual(ResourceIdSegmentType.Static, resourceGroupsSegment.Type);
            Assert.Null(resourceGroupsSegment.ConstantReference);
            Assert.AreEqual("resourceGroups", resourceGroupsSegment.FixedValue);
            Assert.AreEqual("resourceGroups", resourceGroupsSegment.ExampleValue);

            var resourceGroupSegment = actual.Segments.Skip(3).First();
            Assert.AreEqual("resourceGroup", resourceGroupSegment.Name);
            Assert.AreEqual(ResourceIdSegmentType.ResourceGroup, resourceGroupSegment.Type);
            Assert.Null(resourceGroupSegment.ConstantReference);
            Assert.Null(resourceGroupSegment.FixedValue);
            Assert.AreEqual("example-resource-group", resourceGroupSegment.ExampleValue);
        }

        [TestCase]
        public static void MappingAVirtualMachineId()
        {
            var expected = new VirtualMachineResourceId();
            var actual = ResourceID.Map(expected);
            Assert.AreEqual("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Compute/virtualMachines/{virtualMachineName}", actual.IdString);
            Assert.AreEqual(0, actual.Constants.Count);
            Assert.AreEqual(8, actual.Segments.Count);

            var subscriptionsSegment = actual.Segments.First();
            Assert.AreEqual("subscriptions", subscriptionsSegment.Name);
            Assert.AreEqual(ResourceIdSegmentType.Static, subscriptionsSegment.Type);
            Assert.Null(subscriptionsSegment.ConstantReference);
            Assert.AreEqual("subscriptions", subscriptionsSegment.FixedValue);
            Assert.AreEqual("subscriptions", subscriptionsSegment.ExampleValue);

            var subscriptionIdSegment = actual.Segments.Skip(1).First();
            Assert.AreEqual("subscriptionId", subscriptionIdSegment.Name);
            Assert.AreEqual(ResourceIdSegmentType.SubscriptionId, subscriptionIdSegment.Type);
            Assert.Null(subscriptionIdSegment.ConstantReference);
            Assert.Null(subscriptionIdSegment.FixedValue);
            Assert.AreEqual("12345678-1234-9876-4563-123456789012", subscriptionIdSegment.ExampleValue);

            var resourceGroupsSegment = actual.Segments.Skip(2).First();
            Assert.AreEqual("resourceGroups", resourceGroupsSegment.Name);
            Assert.AreEqual(ResourceIdSegmentType.Static, resourceGroupsSegment.Type);
            Assert.Null(resourceGroupsSegment.ConstantReference);
            Assert.AreEqual("resourceGroups", resourceGroupsSegment.FixedValue);
            Assert.AreEqual("resourceGroups", resourceGroupsSegment.ExampleValue);

            var resourceGroupSegment = actual.Segments.Skip(3).First();
            Assert.AreEqual("resourceGroup", resourceGroupSegment.Name);
            Assert.AreEqual(ResourceIdSegmentType.ResourceGroup, resourceGroupSegment.Type);
            Assert.Null(resourceGroupSegment.ConstantReference);
            Assert.Null(resourceGroupSegment.FixedValue);
            Assert.AreEqual("example-resource-group", resourceGroupSegment.ExampleValue);

            var providersSegment = actual.Segments.Skip(4).First();
            Assert.AreEqual("providers", providersSegment.Name);
            Assert.AreEqual(ResourceIdSegmentType.Static, providersSegment.Type);
            Assert.Null(providersSegment.ConstantReference);
            Assert.AreEqual("providers", providersSegment.FixedValue);
            Assert.AreEqual("providers", providersSegment.ExampleValue);

            var microsoftComputeSegment = actual.Segments.Skip(5).First();
            Assert.AreEqual("microsoftCompute", microsoftComputeSegment.Name);
            Assert.AreEqual(ResourceIdSegmentType.ResourceProvider, microsoftComputeSegment.Type);
            Assert.Null(microsoftComputeSegment.ConstantReference);
            Assert.AreEqual("Microsoft.Compute", microsoftComputeSegment.FixedValue);
            Assert.AreEqual("Microsoft.Compute", microsoftComputeSegment.ExampleValue);

            var virtualMachinesSegment = actual.Segments.Skip(6).First();
            Assert.AreEqual("virtualMachines", virtualMachinesSegment.Name);
            Assert.AreEqual(ResourceIdSegmentType.Static, virtualMachinesSegment.Type);
            Assert.Null(virtualMachinesSegment.ConstantReference);
            Assert.AreEqual("virtualMachines", virtualMachinesSegment.FixedValue);
            Assert.AreEqual("virtualMachines", virtualMachinesSegment.ExampleValue);

            var virtualMachineSegment = actual.Segments.Skip(7).First();
            Assert.AreEqual("virtualMachineName", virtualMachineSegment.Name);
            Assert.AreEqual(ResourceIdSegmentType.UserSpecified, virtualMachineSegment.Type);
            Assert.Null(virtualMachineSegment.ConstantReference);
            Assert.Null(virtualMachineSegment.FixedValue);
            Assert.AreEqual("virtualMachineValue", virtualMachineSegment.ExampleValue);
        }

        [TestCase]
        public static void MappingAResourceIDContainingAConstant()
        {
            var expected = new ResourceIdContainingAConstant();
            var actual = ResourceID.Map(expected);
            Assert.AreEqual("/planets/{planetName}", actual.IdString);
            Assert.AreEqual(1, actual.Constants.Count);
            Assert.AreEqual("PlanetName", actual.Constants.First().Name);
            Assert.AreEqual(2, actual.Segments.Count);

            var planetsSegment = actual.Segments.First();
            Assert.AreEqual("planets", planetsSegment.Name);
            Assert.AreEqual(ResourceIdSegmentType.Static, planetsSegment.Type);
            Assert.Null(planetsSegment.ConstantReference);
            Assert.AreEqual("planets", planetsSegment.FixedValue);
            Assert.AreEqual("planets", planetsSegment.ExampleValue);

            var planetNameSegment = actual.Segments.Skip(1).First();
            Assert.AreEqual("planetName", planetNameSegment.Name);
            Assert.AreEqual(ResourceIdSegmentType.Constant, planetNameSegment.Type);
            Assert.AreEqual("PlanetName", planetNameSegment.ConstantReference);
            Assert.Null(planetNameSegment.FixedValue);
            Assert.AreEqual("jupiter", planetNameSegment.ExampleValue);
        }

        [TestCase]
        public static void MappingAResourceIDContainingAScope()
        {
            var expected = new ResourceIdContainingAScope();
            var actual = ResourceID.Map(expected);
            Assert.AreEqual("/{scope}/someOperation", actual.IdString);
            Assert.AreEqual(0, actual.Constants.Count);
            Assert.AreEqual(2, actual.Segments.Count);

            var scopeSegment = actual.Segments.First();
            Assert.AreEqual("scope", scopeSegment.Name);
            Assert.AreEqual(ResourceIdSegmentType.Scope, scopeSegment.Type);
            Assert.Null(scopeSegment.ConstantReference);
            Assert.Null(scopeSegment.FixedValue);
            Assert.AreEqual("/subscriptions/12345678-1234-9876-4563-123456789012/resourceGroups/some-resource-group", scopeSegment.ExampleValue);

            var planetsSegment = actual.Segments.Skip(1).First();
            Assert.AreEqual("someOperation", planetsSegment.Name);
            Assert.AreEqual(ResourceIdSegmentType.Static, planetsSegment.Type);
            Assert.Null(planetsSegment.ConstantReference);
            Assert.AreEqual("someOperation", planetsSegment.FixedValue);
            Assert.AreEqual("someOperation", planetsSegment.ExampleValue);
        }

        private class HelloWorldStaticResourceId : Definitions.Interfaces.ResourceID
        {
            public string? CommonAlias => null;

            public string ID => "/hello/world";

            public List<ResourceIDSegment> Segments => new()
            {
                new ResourceIDSegment
                {
                    Name = "hello",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "hello"
                },
                new ResourceIDSegment
                {
                    Name = "world",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "world"
                }
            };
        }

        private class HelloWorldUserSpecifiableResourceId : Definitions.Interfaces.ResourceID
        {
            public string? CommonAlias => null;

            public string ID => "/hello/{world}";

            public List<ResourceIDSegment> Segments => new()
            {
                new ResourceIDSegment
                {
                    Name = "hello",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "hello"
                },
                new ResourceIDSegment
                {
                    Name = "world",
                    Type = ResourceIDSegmentType.UserSpecified,
                }
            };
        }

        private class VirtualMachineResourceId : Definitions.Interfaces.ResourceID
        {
            public string? CommonAlias => null;

            public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Compute/virtualMachines/{virtualMachineName}";

            public List<ResourceIDSegment> Segments => new()
            {
                new ResourceIDSegment
                {
                    Name = "subscriptions",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "subscriptions"
                },
                new ResourceIDSegment
                {
                    Name = "subscriptionId",
                    Type = ResourceIDSegmentType.SubscriptionId,
                },
                new ResourceIDSegment
                {
                    Name = "resourceGroups",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "resourceGroups"
                },
                new ResourceIDSegment
                {
                    Name = "resourceGroup",
                    Type = ResourceIDSegmentType.ResourceGroup,
                },
                new ResourceIDSegment
                {
                    Name = "providers",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "providers"
                },
                new ResourceIDSegment
                {
                    Name = "microsoftCompute",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.Compute"
                },
                new ResourceIDSegment
                {
                    Name = "virtualMachines",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "virtualMachines"
                },
                new ResourceIDSegment
                {
                    Name = "virtualMachineName",
                    Type = ResourceIDSegmentType.UserSpecified,
                },
            };
        }

        private class ResourceGroupResourceId : Definitions.Interfaces.ResourceID
        {
            public string? CommonAlias => null;

            public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}";

            public List<ResourceIDSegment> Segments => new()
            {
                new ResourceIDSegment
                {
                    Name = "subscriptions",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "subscriptions"
                },
                new ResourceIDSegment
                {
                    Name = "subscriptionId",
                    Type = ResourceIDSegmentType.SubscriptionId,
                },
                new ResourceIDSegment
                {
                    Name = "resourceGroups",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "resourceGroups"
                },
                new ResourceIDSegment
                {
                    Name = "resourceGroup",
                    Type = ResourceIDSegmentType.ResourceGroup,
                }
            };
        }

        private class ResourceIdContainingAConstant : Definitions.Interfaces.ResourceID
        {
            public string? CommonAlias => null;

            public string ID => "/planets/{planetName}";

            public List<ResourceIDSegment> Segments => new()
            {
                new ResourceIDSegment
                {
                    Name = "planets",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "planets"
                },
                new ResourceIDSegment
                {
                    Name = "planetName",
                    Type = ResourceIDSegmentType.Constant,
                    ConstantReference = typeof(PlanetName)
                }
            };

            [ConstantType(ConstantTypeAttribute.ConstantType.String)]
            private enum PlanetName
            {
                [System.ComponentModel.Description("mars")]
                Mars,

                [System.ComponentModel.Description("jupiter")]
                Jupiter
            }
        }

        private class ResourceIdContainingAScope : Definitions.Interfaces.ResourceID
        {
            public string? CommonAlias => null;

            public string ID => "/{scope}/someOperation";

            public List<ResourceIDSegment> Segments => new()
            {
                new ResourceIDSegment
                {
                    Name = "scope",
                    Type = ResourceIDSegmentType.Scope,
                },
                new ResourceIDSegment
                {
                    Name = "someOperation",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "someOperation"
                },
            };
        }
    }
}