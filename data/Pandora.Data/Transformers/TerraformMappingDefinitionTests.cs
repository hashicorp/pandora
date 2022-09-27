using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using NUnit.Framework;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Mappings;

namespace Pandora.Data.Transformers;

public static class TerraformMappingDefinitionTests
{
    [TestCase]
    public static void MappingNothingReturnsNothing()
    {
        var actual = TerraformMappingDefinition.Map(new NoMappings());
        Assert.AreEqual(0, actual.ResourceIds.Count);
        Assert.AreEqual(0, actual.Create.Count);
        Assert.Null(actual.Update);
        Assert.AreEqual(0, actual.Read.Count);
    }

    [TestCase]
    public static void MappingAResourceIdSegment()
    {
        var actual = TerraformMappingDefinition.Map(new ResourceIdMappings());
        Assert.AreEqual(2, actual.ResourceIds.Count);
        Assert.NotNull(actual.ResourceIds.FirstOrDefault(r => r.SchemaFieldName == "Foo" && r.SegmentName == "segment1"));
        Assert.NotNull(actual.ResourceIds.FirstOrDefault(r => r.SchemaFieldName == "Bar" && r.SegmentName == "segment2"));
        Assert.AreEqual(0, actual.Create.Count);
        Assert.Null(actual.Update);
        Assert.AreEqual(0, actual.Read.Count);
    }

    [TestCase]
    public static void MappingADirectAssignmentMapping()
    {
        var actual = TerraformMappingDefinition.Map(new DirectAssignmentFieldMappings());
        Assert.AreEqual(0, actual.ResourceIds.Count);

        // at this point in time all mappings are shared across Create/Read/Update, they shouldn't be, but are today
        // so this test is based on that assumption
        Assert.AreEqual(2, actual.Create.Count);
        Assert.NotNull(actual.Create.FirstOrDefault(r => r.Type == TerraformFieldMappingType.DirectAssignment &&
                                                         r.DirectAssignment.SchemaModelName == "TestSchemaModel" &&
                                                         r.DirectAssignment.SchemaFieldName == "Foo" &&
                                                         r.DirectAssignment.SdkModelName == "TestSdkModel" &&
                                                         r.DirectAssignment.SdkFieldName == "SdkFoo"));
        Assert.NotNull(actual.Create.FirstOrDefault(r => r.Type == TerraformFieldMappingType.DirectAssignment &&
                                                         r.DirectAssignment.SchemaModelName == "TestSchemaModel" &&
                                                         r.DirectAssignment.SchemaFieldName == "Bar" &&
                                                         r.DirectAssignment.SdkModelName == "TestSdkModel" &&
                                                         r.DirectAssignment.SdkFieldName == "SdkBar"));

        Assert.NotNull(actual.Update);
        Assert.AreEqual(2, actual.Update!.Count);
        Assert.NotNull(actual.Update!.FirstOrDefault(r => r.Type == TerraformFieldMappingType.DirectAssignment &&
                                                         r.DirectAssignment.SchemaModelName == "TestSchemaModel" &&
                                                         r.DirectAssignment.SchemaFieldName == "Foo" &&
                                                         r.DirectAssignment.SdkModelName == "TestSdkModel" &&
                                                         r.DirectAssignment.SdkFieldName == "SdkFoo"));
        Assert.NotNull(actual.Update!.FirstOrDefault(r => r.Type == TerraformFieldMappingType.DirectAssignment &&
                                                         r.DirectAssignment.SchemaModelName == "TestSchemaModel" &&
                                                         r.DirectAssignment.SchemaFieldName == "Bar" &&
                                                         r.DirectAssignment.SdkModelName == "TestSdkModel" &&
                                                         r.DirectAssignment.SdkFieldName == "SdkBar"));

        Assert.AreEqual(2, actual.Read.Count);
        Assert.NotNull(actual.Read.FirstOrDefault(r => r.Type == TerraformFieldMappingType.DirectAssignment &&
                                                       r.DirectAssignment.SchemaModelName == "TestSchemaModel" &&
                                                       r.DirectAssignment.SchemaFieldName == "Foo" &&
                                                       r.DirectAssignment.SdkModelName == "TestSdkModel" &&
                                                       r.DirectAssignment.SdkFieldName == "SdkFoo"));
        Assert.NotNull(actual.Read.FirstOrDefault(r => r.Type == TerraformFieldMappingType.DirectAssignment &&
                                                       r.DirectAssignment.SchemaModelName == "TestSchemaModel" &&
                                                       r.DirectAssignment.SchemaFieldName == "Bar" &&
                                                       r.DirectAssignment.SdkModelName == "TestSdkModel" &&
                                                       r.DirectAssignment.SdkFieldName == "SdkBar"));
    }

    private class NoMappings : Definitions.Interfaces.TerraformMappingDefinition
    {
        public List<MappingType> Mappings => new List<MappingType>();
    }

    private class ResourceIdMappings : Definitions.Interfaces.TerraformMappingDefinition
    {
        public List<MappingType> Mappings => new List<MappingType>
        {
            Mapping.FromSchema<TestSchemaModel>(m => m.Foo).ToResourceIdSegmentNamed("segment1"),
            Mapping.FromSchema<TestSchemaModel>(m => m.Bar).ToResourceIdSegmentNamed("segment2"),
        };
    }

    private class DirectAssignmentFieldMappings : Definitions.Interfaces.TerraformMappingDefinition
    {
        public List<MappingType> Mappings => new List<MappingType>
        {
            Mapping.FromSchema<TestSchemaModel>(m => m.Foo).ToSdkField<TestSdkModel>(s => s.SdkFoo).Direct(),
            Mapping.FromSchema<TestSchemaModel>(m => m.Bar).ToSdkField<TestSdkModel>(s => s.SdkBar).Direct(),
        };
    }

    private class TestSchemaModel
    {
        [HclName("foo")]
        [Required]
        public string Foo { get; set; }

        [HclName("bar")]
        [Required]
        public string Bar { get; set; }
    }

    private class TestSdkModel
    {
        [JsonPropertyName("sdk_bar")]
        public string SdkBar { get; set; }

        [JsonPropertyName("sdk_foo")]
        public string SdkFoo { get; set; }
    }
}
