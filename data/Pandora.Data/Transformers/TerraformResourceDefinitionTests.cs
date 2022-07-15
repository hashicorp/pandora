using System;
using System.Collections.Generic;
using NUnit.Framework;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;

namespace Pandora.Data.Transformers;

public class TerraformResourceDefinitionTests
{
    [TestCase]
    public void MappingABasicResourceDefinition()
    {
        var input = new BasicResource();
        var actual = TerraformResourceDefinition.Map(input);
        Assert.NotNull(actual);
        Assert.NotNull(actual.DeleteMethod);
        Assert.True(actual.DeleteMethod.Generate);
        Assert.AreEqual("SomeDelete", actual.DeleteMethod.MethodName);
        Assert.AreEqual(10, actual.DeleteMethod.TimeoutInMinutes);
        Assert.AreEqual("Fake Planet", actual.DisplayName);
        Assert.True(actual.GenerateIDValidationFunction);
        Assert.True(actual.GenerateSchema);
        Assert.AreEqual("fake_planet", actual.ResourceLabel);
        Assert.AreEqual("FakeResourceId", actual.ResourceIdName);
        Assert.AreEqual("Basic", actual.ResourceName);
        Assert.AreEqual("Example", actual.Resource);
    }

    [TestCase]
    public void MappingAResourceUsingDifferentAPIVersionsShouldFail()
    {
        Assert.Throws<NotSupportedException>(() => TerraformResourceDefinition.Map(new ResourceUsingDifferentAPIVersions()));
    }

    internal class BasicResource : Definitions.Interfaces.TerraformResourceDefinition
    {
        public MethodDefinition DeleteMethod => new MethodDefinition
        {
            Generate = true,
            Method = typeof(v2020_01_01.Example.SomeDeleteOperation),
            TimeoutInMinutes = 10,
        };
        public string DisplayName => "Fake Planet";
        public bool GenerateIDValidationFunction => true;
        public bool GenerateSchema => true;
        public string ResourceLabel => "fake_planet";
        public Definitions.Interfaces.ResourceID ResourceId => new v2020_01_01.Example.FakeResourceId();
    }

    internal class ResourceUsingDifferentAPIVersions : Definitions.Interfaces.TerraformResourceDefinition
    {
        public MethodDefinition DeleteMethod => new MethodDefinition
        {
            Generate = true,
            Method = typeof(v2020_01_01.Example.SomeDeleteOperation),
            TimeoutInMinutes = 10,
        };
        public string DisplayName => "Fake Planet";
        public bool GenerateIDValidationFunction => true;
        public bool GenerateSchema => true;
        public string ResourceLabel => "fake_planet";
        public Definitions.Interfaces.ResourceID ResourceId => new v2015_01_01.Example.FakeResourceId();
    }

    private class v2020_01_01
    {
        internal class Example
        {
            internal class SomeDeleteOperation : DeleteOperation
            {
                public override Definitions.Interfaces.ResourceID? ResourceId() => new FakeResourceId();
            }

            internal class FakeResourceId : Definitions.Interfaces.ResourceID
            {
                public string? CommonAlias => null;
                public string ID => "/planets/{planetName}";
                public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
                {
                    ResourceIDSegment.Static("planets", "planets"),
                    ResourceIDSegment.UserSpecified("planetName")
                };
            }
        }
    }

    private class v2015_01_01
    {
        internal class Example
        {
            internal class SomeDeleteOperation : DeleteOperation
            {
                public override Definitions.Interfaces.ResourceID? ResourceId() => new FakeResourceId();
            }

            internal class FakeResourceId : Definitions.Interfaces.ResourceID
            {
                public string? CommonAlias => null;
                public string ID => "/planets/{planetName}";
                public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
                {
                    ResourceIDSegment.Static("planets", "planets"),
                    ResourceIDSegment.UserSpecified("planetName")
                };
            }
        }
    }
}