using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using NUnit.Framework;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Mappings;
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
        Assert.AreEqual("2020-01-01", actual.ApiVersion);
        Assert.NotNull(actual.CreateMethod);
        Assert.True(actual.CreateMethod.Generate);
        Assert.AreEqual("SomeCreate", actual.CreateMethod.MethodName);
        Assert.AreEqual(9, actual.CreateMethod.TimeoutInMinutes);
        Assert.NotNull(actual.DeleteMethod);
        Assert.True(actual.DeleteMethod.Generate);
        Assert.AreEqual("SomeDelete", actual.DeleteMethod.MethodName);
        Assert.AreEqual(10, actual.DeleteMethod.TimeoutInMinutes);
        Assert.AreEqual("Fake Planet", actual.DisplayName);
        Assert.True(actual.GenerateIDValidationFunction);
        Assert.True(actual.GenerateModel);
        Assert.True(actual.GenerateSchema);
        Assert.NotNull(actual.ReadMethod);
        Assert.True(actual.ReadMethod.Generate);
        Assert.AreEqual("SomeRead", actual.ReadMethod.MethodName);
        Assert.AreEqual(11, actual.ReadMethod.TimeoutInMinutes);
        Assert.AreEqual("fake_planet", actual.ResourceLabel);
        Assert.AreEqual("FakeResourceId", actual.ResourceIdName);
        Assert.AreEqual("Basic", actual.ResourceName);
        Assert.AreEqual("Example", actual.Resource);
        Assert.NotNull(actual.UpdateMethod);
        Assert.True(actual.UpdateMethod.Generate);
        Assert.AreEqual("SomeUpdate", actual.UpdateMethod.MethodName);
        Assert.AreEqual(12, actual.UpdateMethod.TimeoutInMinutes);

        Assert.AreEqual("BasicResourceSchema", actual.SchemaModelName);
        Assert.AreEqual(1, actual.SchemaModels.Count);
        var resourceSchema = actual.SchemaModels["BasicResourceSchema"];
        Assert.NotNull(resourceSchema);
        Assert.AreEqual(1, resourceSchema.Fields.Count);
        var nameField = resourceSchema.Fields["Name"];
        Assert.NotNull(nameField);

        // @tombuildsstuff: disabling Mappings temporarily since the priority is threading through Schema/Docs/Tests
        // we'll come back and enable this but for now this is an easy way to ensure we don't add this early 
        var fieldsWithMappings = resourceSchema.Fields.Select(f => f.Value.Mappings).Where(m => m.Create != null || m.Read != null || m.Update != null || !string.IsNullOrWhiteSpace(m.ResourceIDSegment)).ToList();
        Assert.AreEqual(0, fieldsWithMappings.Count);
        // TODO: Terraform Mappings

        Assert.AreEqual("basic config", actual.Tests!.BasicConfig);
        Assert.AreEqual("requires import config", actual.Tests!.RequiresImportConfig);
        Assert.AreEqual("complete config", actual.Tests!.CompleteConfig);
        Assert.AreEqual("template config", actual.Tests!.TemplateConfig);
        Assert.AreEqual(1, actual.Tests!.OtherTests.Count);
        var someTestConfigs = actual.Tests!.OtherTests["SomeTest"];
        Assert.NotNull(someTestConfigs);
        Assert.AreEqual(2, someTestConfigs.Count);
        Assert.AreEqual("first", someTestConfigs[0]);
        Assert.AreEqual("second", someTestConfigs[1]);

        // TODO: validation
    }

    [TestCase]
    public void MappingAResourceUsingDifferentAPIVersionsShouldFail()
    {
        Assert.Throws<NotSupportedException>(() => TerraformResourceDefinition.Map(new ResourceUsingDifferentAPIVersions()));
    }

    internal class BasicResource : Definitions.Interfaces.TerraformResourceDefinition
    {
        public MethodDefinition CreateMethod => new MethodDefinition
        {
            Generate = true,
            Method = typeof(v2020_01_01.Example.SomeCreateOperation),
            TimeoutInMinutes = 9,
        };
        public MethodDefinition DeleteMethod => new MethodDefinition
        {
            Generate = true,
            Method = typeof(v2020_01_01.Example.SomeDeleteOperation),
            TimeoutInMinutes = 10,
        };
        public string DisplayName => "Fake Planet";
        public bool GenerateIDValidationFunction => true;
        public bool GenerateModel => true;
        public bool GenerateSchema => true;
        public MethodDefinition ReadMethod => new MethodDefinition
        {
            Generate = true,
            Method = typeof(v2020_01_01.Example.SomeReadOperation),
            TimeoutInMinutes = 11,
        };
        public string ResourceLabel => "fake_planet";
        public Type? SchemaModel => typeof(BasicResourceSchema);

        public TerraformMappingDefinition SchemaMappings => new BasicResourceMappings();
        public Definitions.Interfaces.TerraformResourceTestDefinition Tests => new BasicResourceTests();

        public MethodDefinition? UpdateMethod => new MethodDefinition
        {
            Generate = true,
            Method = typeof(v2020_01_01.Example.SomeUpdateOperation),
            TimeoutInMinutes = 12,
        };
        public Definitions.Interfaces.ResourceID ResourceId => new v2020_01_01.Example.FakeResourceId();
    }

    internal class BasicResourceSchema
    {
        [HclName("name")]
        [ForceNew]
        [Required]
        public string Name { get; set; }
    }

    internal class BasicResourceMappings : TerraformMappingDefinition
    {
        public List<Mapping> Mappings => new List<Mapping>
        {
            Mapping.FromSchema<BasicResourceSchema>(s => s.Name).ToSdkModelField<v2020_01_01.Example.SomeModel>(m => m.Example),
        };
    }

    internal class BasicResourceTests : Definitions.Interfaces.TerraformResourceTestDefinition
    {
        public string BasicTestConfig => @"basic config";
        public string RequiresImportConfig => @"requires import config";
        public string? CompleteConfig => @"complete config";
        public string? TemplateConfig => @"template config";

        public Dictionary<string, List<string>> OtherTests => new Dictionary<string, List<string>>
        {
            {"SomeTest", new List<string> {"first", "second"}},
        };
    }

    internal class ResourceUsingDifferentAPIVersions : Definitions.Interfaces.TerraformResourceDefinition
    {
        public MethodDefinition CreateMethod => new MethodDefinition
        {
            Generate = true,
            Method = typeof(v2020_01_01.Example.SomeCreateOperation),
            TimeoutInMinutes = 9,
        };
        public MethodDefinition DeleteMethod => new MethodDefinition
        {
            Generate = true,
            Method = typeof(v2020_01_01.Example.SomeDeleteOperation),
            TimeoutInMinutes = 10,
        };
        public string DisplayName => "Fake Planet";
        public bool GenerateIDValidationFunction => true;
        public bool GenerateModel => true;
        public bool GenerateSchema => true;

        public MethodDefinition ReadMethod => new MethodDefinition
        {
            Generate = true,
            Method = typeof(v2020_01_01.Example.SomeReadOperation),
            TimeoutInMinutes = 11,
        };
        public string ResourceLabel => "fake_planet";
        public Type? SchemaModel => null;
        public TerraformMappingDefinition SchemaMappings => null;
        public Definitions.Interfaces.TerraformResourceTestDefinition Tests => null;

        public MethodDefinition? UpdateMethod => new MethodDefinition
        {
            Generate = true,
            Method = typeof(v2020_01_01.Example.SomeUpdateOperation),
            TimeoutInMinutes = 12,
        };
        public Definitions.Interfaces.ResourceID ResourceId => new v2015_01_01.Example.FakeResourceId();
    }

    private class v2020_01_01
    {
        internal class Example
        {
            internal class SomeCreateOperation : PutOperation
            {
                public override Type? RequestObject() => typeof(SomeModel);

                public override Definitions.Interfaces.ResourceID? ResourceId() => new FakeResourceId();
            }
            internal class SomeDeleteOperation : DeleteOperation
            {
                public override Definitions.Interfaces.ResourceID? ResourceId() => new FakeResourceId();
            }

            internal class SomeReadOperation : GetOperation
            {
                public override Definitions.Interfaces.ResourceID? ResourceId() => new FakeResourceId();

                public override Type? ResponseObject() => typeof(SomeModel);
            }
            internal class SomeUpdateOperation : PutOperation
            {
                public override Type? RequestObject() => typeof(SomeModel);

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

            internal class SomeModel
            {
                [JsonPropertyName("example")]
                public string Example { get; set; }
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
