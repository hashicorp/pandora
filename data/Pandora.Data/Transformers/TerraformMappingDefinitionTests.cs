using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
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
    }

    [TestCase]
    public static void MappingAResourceIdSegment()
    {
        var actual = TerraformMappingDefinition.Map(new ResourceIdMappings());
        Assert.AreEqual(2, actual.ResourceIds.Count);
        Assert.NotNull(actual.ResourceIds.FirstOrDefault(r => r.SchemaFieldName == "Foo" && r.SegmentName == "segment1"));
        Assert.NotNull(actual.ResourceIds.FirstOrDefault(r => r.SchemaFieldName == "Bar" && r.SegmentName == "segment2"));
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

    private class TestSchemaModel
    {
        [HclName("foo")]
        [Required]
        public string Foo { get; set; }
        
        [HclName("bar")]
        [Required]
        public string Bar { get; set; }
    }
}
