using System;
using NUnit.Framework;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Data.Transformers;

public static class TerraformSchemaFieldDefinitionTests
{
    // TODO: Mappings & Validation

    [TestCase]
    public static void ComputedAttributeGetsMapped()
    {
        var actual = TerraformSchemaModelDefinition.Map(typeof(ModelContainingAComputedAttribute));
        var mappedModel = actual["ModelContainingAComputedAttribute"];
        Assert.NotNull(mappedModel);
        var prop = mappedModel.Fields["Example"];
        Assert.NotNull(prop);
        Assert.AreEqual(TerraformSchemaFieldType.String, prop.ObjectDefinition.Type);
        Assert.AreEqual("example", prop.HclName);
        Assert.True(prop.Computed);
        Assert.False(prop.ForceNew);
        Assert.False(prop.Optional);
        Assert.False(prop.Required);
        Assert.Null(prop.Documentation.Markdown);
    }

    [TestCase]
    public static void DocumentationAttributeGetsMapped()
    {
        var actual = TerraformSchemaModelDefinition.Map(typeof(ModelContainingADocumentationAttribute));
        var mappedModel = actual["ModelContainingADocumentationAttribute"];
        Assert.NotNull(mappedModel);
        var prop = mappedModel.Fields["Example"];
        Assert.NotNull(prop);
        Assert.AreEqual(TerraformSchemaFieldType.String, prop.ObjectDefinition.Type);
        Assert.AreEqual("example", prop.HclName);
        Assert.False(prop.Computed);
        Assert.False(prop.ForceNew);
        Assert.False(prop.Optional);
        Assert.True(prop.Required);
        Assert.AreEqual("This property does something.", prop.Documentation.Markdown);
    }

    [TestCase]
    public static void ForceNewAttributeGetsMapped()
    {
        var actual = TerraformSchemaModelDefinition.Map(typeof(ModelContainingAForceNewAttribute));
        var mappedModel = actual["ModelContainingAForceNewAttribute"];
        Assert.NotNull(mappedModel);
        var prop = mappedModel.Fields["Example"];
        Assert.NotNull(prop);
        Assert.AreEqual(TerraformSchemaFieldType.String, prop.ObjectDefinition.Type);
        Assert.AreEqual("example", prop.HclName);
        Assert.False(prop.Computed);
        Assert.True(prop.ForceNew);
        Assert.True(prop.Optional); // has to be one of optional/computed/required
        Assert.False(prop.Required);
        Assert.Null(prop.Documentation.Markdown);
    }

    [TestCase]
    public static void OptionalAttributeGetsMapped()
    {
        var actual = TerraformSchemaModelDefinition.Map(typeof(ModelContainingAOptionalAttribute));
        var mappedModel = actual["ModelContainingAOptionalAttribute"];
        Assert.NotNull(mappedModel);
        var prop = mappedModel.Fields["Example"];
        Assert.NotNull(prop);
        Assert.AreEqual(TerraformSchemaFieldType.String, prop.ObjectDefinition.Type);
        Assert.AreEqual("example", prop.HclName);
        Assert.False(prop.Computed);
        Assert.False(prop.ForceNew);
        Assert.True(prop.Optional);
        Assert.False(prop.Required);
        Assert.Null(prop.Documentation.Markdown);
    }

    [TestCase]
    public static void RequiredAttributeGetsMapped()
    {
        var actual = TerraformSchemaModelDefinition.Map(typeof(ModelContainingARequiredAttribute));
        var mappedModel = actual["ModelContainingARequiredAttribute"];
        Assert.NotNull(mappedModel);
        var prop = mappedModel.Fields["Example"];
        Assert.NotNull(prop);
        Assert.AreEqual(TerraformSchemaFieldType.String, prop.ObjectDefinition.Type);
        Assert.AreEqual("example", prop.HclName);
        Assert.False(prop.Computed);
        Assert.False(prop.ForceNew);
        Assert.False(prop.Optional);
        Assert.True(prop.Required);
        Assert.Null(prop.Documentation.Markdown);
    }


    [TestCase]
    public static void BuiltInTypesGetMapped()
    {
        var actual = TerraformSchemaModelDefinition.Map(typeof(ModelContainingAllBuiltInTypes));
        var mappedModel = actual["ModelContainingAllBuiltInTypes"];
        Assert.NotNull(mappedModel);
        Assert.AreEqual(5, mappedModel.Fields.Count);

        var boolProp = mappedModel.Fields["BooleanProp"];
        Assert.NotNull(boolProp);
        Assert.AreEqual(TerraformSchemaFieldType.Boolean, boolProp.ObjectDefinition.Type);
        Assert.AreEqual("boolean_prop", boolProp.HclName);

        var dateTimeProp = mappedModel.Fields["DateTimeProp"];
        Assert.NotNull(dateTimeProp);
        Assert.AreEqual(TerraformSchemaFieldType.DateTime, dateTimeProp.ObjectDefinition.Type);
        Assert.AreEqual("date_time_prop", dateTimeProp.HclName);

        var intProp = mappedModel.Fields["IntegerProp"];
        Assert.NotNull(intProp);
        Assert.AreEqual(TerraformSchemaFieldType.Integer, intProp.ObjectDefinition.Type);
        Assert.AreEqual("integer_prop", intProp.HclName);

        var stringProp = mappedModel.Fields["StringProp"];
        Assert.NotNull(stringProp);
        Assert.AreEqual(TerraformSchemaFieldType.String, stringProp.ObjectDefinition.Type);
        Assert.AreEqual("string_prop", stringProp.HclName);
    }

    [TestCase]
    public static void PandoraCommonSchemaTypesGetMapped()
    {
        var actual = TerraformSchemaModelDefinition.Map(typeof(ModelContainingAllPandoraCommonSchemaTypes));
        var mappedModel = actual["ModelContainingAllPandoraCommonSchemaTypes"];
        Assert.NotNull(mappedModel);
        Assert.AreEqual(9, mappedModel.Fields.Count);

        var edgeZoneProp = mappedModel.Fields["EdgeZone"];
        Assert.NotNull(edgeZoneProp);
        Assert.AreEqual(TerraformSchemaFieldType.EdgeZone, edgeZoneProp.ObjectDefinition.Type);
        Assert.AreEqual("edge_zone", edgeZoneProp.HclName);

        var locationProp = mappedModel.Fields["Location"];
        Assert.NotNull(locationProp);
        Assert.AreEqual(TerraformSchemaFieldType.Location, locationProp.ObjectDefinition.Type);
        Assert.AreEqual("location", locationProp.HclName);

        var tagsProp = mappedModel.Fields["Tags"];
        Assert.NotNull(tagsProp);
        Assert.AreEqual(TerraformSchemaFieldType.Tags, tagsProp.ObjectDefinition.Type);
        Assert.AreEqual("tags", tagsProp.HclName);

        var systemAssignedIdentityProp = mappedModel.Fields["SystemAssignedIdentity"];
        Assert.NotNull(systemAssignedIdentityProp);
        Assert.AreEqual(TerraformSchemaFieldType.IdentitySystemAssigned, systemAssignedIdentityProp.ObjectDefinition.Type);
        Assert.AreEqual("system_assigned_identity", systemAssignedIdentityProp.HclName);

        var systemAndUserAssignedIdentityProp = mappedModel.Fields["SystemAndUserAssignedIdentity"];
        Assert.NotNull(systemAndUserAssignedIdentityProp);
        Assert.AreEqual(TerraformSchemaFieldType.IdentitySystemAndUserAssigned, systemAndUserAssignedIdentityProp.ObjectDefinition.Type);
        Assert.AreEqual("system_and_user_assigned_identity", systemAndUserAssignedIdentityProp.HclName);

        var systemOrUserAssignedIdentityProp = mappedModel.Fields["SystemOrUserAssignedIdentity"];
        Assert.NotNull(systemOrUserAssignedIdentityProp);
        Assert.AreEqual(TerraformSchemaFieldType.IdentitySystemOrUserAssigned, systemOrUserAssignedIdentityProp.ObjectDefinition.Type);
        Assert.AreEqual("system_or_user_assigned_identity", systemOrUserAssignedIdentityProp.HclName);

        var userAssignedIdentityProp = mappedModel.Fields["UserAssignedIdentity"];
        Assert.NotNull(userAssignedIdentityProp);
        Assert.AreEqual(TerraformSchemaFieldType.IdentityUserAssigned, userAssignedIdentityProp.ObjectDefinition.Type);
        Assert.AreEqual("user_assigned_identity", userAssignedIdentityProp.HclName);
    }

    private class ModelContainingAComputedAttribute
    {
        [Computed]
        [HclName("example")]
        public string Example { get; set; }
    }
    private class ModelContainingADocumentationAttribute
    {
        [Documentation("This property does something.")]
        [HclName("example")]
        [Required]
        public string Example { get; set; }
    }
    private class ModelContainingAForceNewAttribute
    {
        [HclName("example")]
        [ForceNew]
        [Optional]
        public string Example { get; set; }
    }
    private class ModelContainingAOptionalAttribute
    {
        [HclName("example")]
        [Optional]
        public string Example { get; set; }
    }
    private class ModelContainingARequiredAttribute
    {
        [HclName("example")]
        [Required]
        public string Example { get; set; }
    }

    private class ModelContainingAllBuiltInTypes
    {
        [HclName("boolean_prop")]
        [Required]
        public bool BooleanProp { get; set; }

        [HclName("date_time_prop")]
        [Required]
        public DateTime DateTimeProp { get; set; }

        [HclName("float_prop")]
        [Required]
        public float FloatProp { get; set; }

        [HclName("integer_prop")]
        [Required]
        public int IntegerProp { get; set; }

        // NOTE: we intentionally don't support Object at this time

        [HclName("string_prop")]
        [Required]
        public string StringProp { get; set; }
    }

    private class ModelContainingAllPandoraCommonSchemaTypes
    {
        [HclName("edge_zone")]
        [Required]
        public EdgeZoneSingle EdgeZone { get; set; }

        [HclName("location")]
        [Required]
        public Location Location { get; set; }

        [HclName("tags")]
        [Required]
        public Tags Tags { get; set; }

        [HclName("system_assigned_identity")]
        [Required]
        public SystemAssignedIdentity SystemAssignedIdentity { get; set; }

        [HclName("system_and_user_assigned_identity")]
        [Required]
        public SystemAndUserAssignedIdentity SystemAndUserAssignedIdentity { get; set; }

        [HclName("system_or_user_assigned_identity")]
        [Required]
        public SystemOrUserAssignedIdentity SystemOrUserAssignedIdentity { get; set; }

        [HclName("user_assigned_identity")]
        [Required]
        public UserAssignedIdentity UserAssignedIdentity { get; set; }

        [HclName("zone")]
        [Required]
        public ZoneSingle Zone { get; set; }

        [HclName("zones")]
        [Required]
        public ZonesMultiple Zones { get; set; }
    }
}