using System;
using NUnit.Framework;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

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
    public static void PandoraTypesGetMapped()
    {
        var actual = TerraformSchemaModelDefinition.Map(typeof(ModelContainingAllPandoraCustomTypes));
        var mappedModel = actual["ModelContainingAllPandoraCustomTypes"];
        Assert.NotNull(mappedModel);
        Assert.AreEqual(12, mappedModel.Fields.Count);
        
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
        
        var systemAndUserAssignedIdentityListProp = mappedModel.Fields["SystemAndUserAssignedIdentityList"];
        Assert.NotNull(systemAndUserAssignedIdentityListProp);
        Assert.AreEqual(TerraformSchemaFieldType.IdentitySystemAndUserAssigned, systemAndUserAssignedIdentityListProp.ObjectDefinition.Type);
        Assert.AreEqual("system_and_user_assigned_identity_list", systemAndUserAssignedIdentityListProp.HclName);
        
        var systemAndUserAssignedIdentityMapProp = mappedModel.Fields["SystemAndUserAssignedIdentityMap"];
        Assert.NotNull(systemAndUserAssignedIdentityMapProp);
        Assert.AreEqual(TerraformSchemaFieldType.IdentitySystemAndUserAssigned, systemAndUserAssignedIdentityMapProp.ObjectDefinition.Type);
        Assert.AreEqual("system_and_user_assigned_identity_map", systemAndUserAssignedIdentityMapProp.HclName);
        
        var legacySystemAndUserAssignedIdentityListProp = mappedModel.Fields["LegacySystemAndUserAssignedIdentityList"];
        Assert.NotNull(legacySystemAndUserAssignedIdentityListProp);
        Assert.AreEqual(TerraformSchemaFieldType.IdentitySystemAndUserAssigned, legacySystemAndUserAssignedIdentityListProp.ObjectDefinition.Type);
        Assert.AreEqual("legacy_system_and_user_assigned_identity_list", legacySystemAndUserAssignedIdentityListProp.HclName);
        
        var legacySystemAndUserAssignedIdentityMapProp = mappedModel.Fields["LegacySystemAndUserAssignedIdentityMap"];
        Assert.NotNull(legacySystemAndUserAssignedIdentityMapProp);
        Assert.AreEqual(TerraformSchemaFieldType.IdentitySystemAndUserAssigned, legacySystemAndUserAssignedIdentityMapProp.ObjectDefinition.Type);
        Assert.AreEqual("legacy_system_and_user_assigned_identity_map", legacySystemAndUserAssignedIdentityMapProp.HclName);
        
        var systemOrUserAssignedIdentityListProp = mappedModel.Fields["SystemOrUserAssignedIdentityList"];
        Assert.NotNull(systemOrUserAssignedIdentityListProp);
        Assert.AreEqual(TerraformSchemaFieldType.IdentitySystemOrUserAssigned, systemOrUserAssignedIdentityListProp.ObjectDefinition.Type);
        Assert.AreEqual("system_or_user_assigned_identity_list", systemOrUserAssignedIdentityListProp.HclName);
        
        var systemOrUserAssignedIdentityMapProp = mappedModel.Fields["SystemOrUserAssignedIdentityMap"];
        Assert.NotNull(systemOrUserAssignedIdentityMapProp);
        Assert.AreEqual(TerraformSchemaFieldType.IdentitySystemOrUserAssigned, systemOrUserAssignedIdentityMapProp.ObjectDefinition.Type);
        Assert.AreEqual("system_or_user_assigned_identity_map", systemOrUserAssignedIdentityMapProp.HclName);
        
        var userAssignedIdentityListProp = mappedModel.Fields["UserAssignedIdentityList"];
        Assert.NotNull(userAssignedIdentityListProp);
        Assert.AreEqual(TerraformSchemaFieldType.IdentityUserAssigned, userAssignedIdentityListProp.ObjectDefinition.Type);
        Assert.AreEqual("user_assigned_identity_list", userAssignedIdentityListProp.HclName);
        
        var userAssignedIdentityMapProp = mappedModel.Fields["UserAssignedIdentityMap"];
        Assert.NotNull(userAssignedIdentityMapProp);
        Assert.AreEqual(TerraformSchemaFieldType.IdentityUserAssigned, userAssignedIdentityMapProp.ObjectDefinition.Type);
        Assert.AreEqual("user_assigned_identity_map", userAssignedIdentityMapProp.HclName);
    }

    [TestCase()]
    public static void PandoraTypesNotValidInTheSchemaRaiseAnException()
    {
        Assert.Throws<NotSupportedException>(() =>  TerraformSchemaModelDefinition.Map(typeof(ModelContainingPandoraCustomTypesNotValidInSchema)));
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

    private class ModelContainingAllPandoraCustomTypes
    {
        [HclName("edge_zone")]
        [Required]
        public EdgeZone EdgeZone { get; set; }

        [HclName("location")]
        [Required]
        public Location Location { get; set; }

        [HclName("tags")]
        [Required]
        public Tags Tags { get; set; }

        [HclName("system_assigned_identity")]
        [Required]
        public SystemAssignedIdentity SystemAssignedIdentity { get; set; }

        [HclName("system_and_user_assigned_identity_list")]
        [Required]
        public SystemAndUserAssignedIdentityList SystemAndUserAssignedIdentityList { get; set; }

        [HclName("system_and_user_assigned_identity_map")]
        [Required]
        public SystemAndUserAssignedIdentityMap SystemAndUserAssignedIdentityMap { get; set; }

        [HclName("legacy_system_and_user_assigned_identity_list")]
        [Required]
        public LegacySystemAndUserAssignedIdentityList LegacySystemAndUserAssignedIdentityList { get; set; }

        [HclName("legacy_system_and_user_assigned_identity_map")]
        [Required]
        public LegacySystemAndUserAssignedIdentityMap LegacySystemAndUserAssignedIdentityMap { get; set; }

        [HclName("system_or_user_assigned_identity_list")]
        [Required]
        public SystemOrUserAssignedIdentityList SystemOrUserAssignedIdentityList { get; set; }

        [HclName("system_or_user_assigned_identity_map")]
        [Required]
        public SystemOrUserAssignedIdentityMap SystemOrUserAssignedIdentityMap { get; set; }

        [HclName("user_assigned_identity_list")]
        [Required]
        public UserAssignedIdentityList UserAssignedIdentityList { get; set; }

        [HclName("user_assigned_identity_map")]
        [Required]
        public UserAssignedIdentityMap UserAssignedIdentityMap { get; set; }

        // NOTE: SystemData and RawFile shouldn't be output (since we don't at this time)
    }

    private class ModelContainingPandoraCustomTypesNotValidInSchema
    {
        [HclName("raw_file")]
        [Required]
        public RawFile RawFile { get; set; }
        
        [HclName("system_data")]
        [Required]
        public SystemData SystemData { get; set; }
    }
}