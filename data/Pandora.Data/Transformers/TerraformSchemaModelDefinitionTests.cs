using System;
using System.Collections.Generic;
using NUnit.Framework;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Data.Transformers;

public static class TerraformSchemaModelDefinitionTests
{
    [TestCase]
    public static void ParsingAModelWhichContainsNoPropertiesShouldRaiseAnException()
    {
        Assert.Throws<NotSupportedException>(() => TerraformSchemaModelDefinition.Map(typeof(ModelWithNoProperties)));
    }

    [TestCase]
    public static void ParsingAModelWhichContainsBuiltInPropertiesShouldHaveASingleModel()
    {
        var actual = TerraformSchemaModelDefinition.Map(typeof(ModelWithOnlyBuiltInTypes));
        Assert.AreEqual(1, actual.Count);
        var model = actual["ModelWithOnlyBuiltInTypes"];
        Assert.NotNull(model);
        Assert.AreEqual(6, model.Fields.Count);
    }

    [TestCase]
    public static void ParsingAModelWhichContainsPandoraCustomTypesShouldHaveASingleModel()
    {
        var actual = TerraformSchemaModelDefinition.Map(typeof(ModelWithOnlyPandoraCustomTypes));
        Assert.AreEqual(1, actual.Count);
        var model = actual["ModelWithOnlyPandoraCustomTypes"];
        Assert.NotNull(model);
        Assert.AreEqual(14, model.Fields.Count);
    }

    [TestCase]
    public static void ParsingAModelWhichContainsANestedModel()
    {
        var actual = TerraformSchemaModelDefinition.Map(typeof(ModelContainingANestedModel));
        Assert.AreEqual(2, actual.Count);
        var model = actual["ModelContainingANestedModel"];
        Assert.NotNull(model);
        Assert.AreEqual(1, model.Fields.Count);
        var otherModel = actual["ModelWithOnlyBuiltInTypes"];
        Assert.AreEqual(6, otherModel.Fields.Count);
    }

    [TestCase]
    public static void ParsingAModelWhichContainsADictionaryOfANestedModel()
    {
        var actual = TerraformSchemaModelDefinition.Map(typeof(ModelContainingADictionaryOfANestedModel));
        Assert.AreEqual(2, actual.Count);
        var model = actual["ModelContainingADictionaryOfANestedModel"];
        Assert.NotNull(model);
        Assert.AreEqual(1, model.Fields.Count);
        var otherModel = actual["ModelWithOnlyBuiltInTypes"];
        Assert.AreEqual(6, otherModel.Fields.Count);
    }

    [TestCase]
    public static void ParsingAModelWhichContainsAListOfANestedModel()
    {
        var actual = TerraformSchemaModelDefinition.Map(typeof(ModelContainingAListOfANestedModel));
        Assert.AreEqual(2, actual.Count);
        var model = actual["ModelContainingAListOfANestedModel"];
        Assert.NotNull(model);
        Assert.AreEqual(1, model.Fields.Count);
        var otherModel = actual["ModelWithOnlyBuiltInTypes"];
        Assert.AreEqual(6, otherModel.Fields.Count);
    }

    [TestCase]
    public static void ParsingAModelWhichContainsTheSameNestedModelTwice()
    {
        var actual = TerraformSchemaModelDefinition.Map(typeof(ModelContainingTheSameNestedModelTwice));
        Assert.AreEqual(2, actual.Count);
        var model = actual["ModelContainingTheSameNestedModelTwice"];
        Assert.NotNull(model);
        Assert.AreEqual(2, model.Fields.Count);
        var otherModel = actual["ModelWithOnlyBuiltInTypes"];
        Assert.AreEqual(6, otherModel.Fields.Count);
    }

    [TestCase]
    public static void ParsingAModelWhichContainsADictionaryOfTheSameNestedModelTwice()
    {
        var actual = TerraformSchemaModelDefinition.Map(typeof(ModelContainingADictionaryOfTheSameNestedModelTwice));
        Assert.AreEqual(2, actual.Count);
        var model = actual["ModelContainingADictionaryOfTheSameNestedModelTwice"];
        Assert.NotNull(model);
        Assert.AreEqual(2, model.Fields.Count);
        var otherModel = actual["ModelWithOnlyBuiltInTypes"];
        Assert.AreEqual(6, otherModel.Fields.Count);
    }

    [TestCase]
    public static void ParsingAModelWhichContainsAListOfTheSameNestedModelTwice()
    {
        var actual = TerraformSchemaModelDefinition.Map(typeof(ModelContainingAListOfTheSameNestedModelTwice));
        Assert.AreEqual(2, actual.Count);
        var model = actual["ModelContainingAListOfTheSameNestedModelTwice"];
        Assert.NotNull(model);
        Assert.AreEqual(2, model.Fields.Count);
        var otherModel = actual["ModelWithOnlyBuiltInTypes"];
        Assert.AreEqual(6, otherModel.Fields.Count);
    }

    private class ModelWithNoProperties
    {
    }
    
    private class ModelWithOnlyBuiltInTypes {
        [HclName("example_boolean")]
        public bool ExampleBoolean { get; set; }
        
        [HclName("example_datetime")]
        public DateTime ExampleDateTime { get; set; }
        
        [HclName("example_integer")]
        public int ExampleInteger { get; set; }
        
        [HclName("example_float")]
        public float ExampleFloat { get; set; }
        
        [HclName("example_object")]
        public object ExampleObject { get; set; }
        
        [HclName("example_string")]
        public string ExampleString { get; set; }
    }

    private class ModelWithOnlyPandoraCustomTypes
    {
        [HclName("edge_zone")]
        public EdgeZone EdgeZone { get; set; }

        [HclName("location")]
        public Location Location { get; set; }

        [HclName("raw_file")]
        public RawFile RawFile { get; set; }

        [HclName("tags")]
        public Tags Tags { get; set; }

        [HclName("system_assigned_identity")]
        public SystemAssignedIdentity SystemAssignedIdentity { get; set; }

        [HclName("system_and_user_assigned_identity_list")]
        public SystemAndUserAssignedIdentityList SystemAndUserAssignedIdentityList { get; set; }

        [HclName("system_and_user_assigned_identity_map")]
        public SystemAndUserAssignedIdentityMap SystemAndUserAssignedIdentityMap { get; set; }

        [HclName("legacy_system_and_user_assigned_identity_list")]
        public LegacySystemAndUserAssignedIdentityList LegacySystemAndUserAssignedIdentityList { get; set; }

        [HclName("legacy_system_and_user_assigned_identity_map")]
        public LegacySystemAndUserAssignedIdentityMap LegacySystemAndUserAssignedIdentityMap { get; set; }

        [HclName("system_or_user_assigned_identity_list")]
        public SystemOrUserAssignedIdentityList SystemOrUserAssignedIdentityList { get; set; }

        [HclName("system_or_user_assigned_identity_map")]
        public SystemOrUserAssignedIdentityMap SystemOrUserAssignedIdentityMap { get; set; }

        [HclName("user_assigned_identity_list")]
        public UserAssignedIdentityList UserAssignedIdentityList { get; set; }

        [HclName("user_assigned_identity_map")]
        public UserAssignedIdentityMap UserAssignedIdentityMap { get; set; }

        [HclName("system_data")]
        public SystemData SystemData { get; set; }
    }

    private class ModelContainingANestedModel 
    {
        [HclName("nested_model")]
        public ModelWithOnlyBuiltInTypes NestedModel { get; set; }
    }

    private class ModelContainingTheSameNestedModelTwice
    {
        [HclName("first_nested_model")]
        public ModelWithOnlyBuiltInTypes FirstNestedModel { get; set; }
        
        [HclName("second_nested_model")]
        public ModelWithOnlyBuiltInTypes SecondNestedModel { get; set; }
    }

    private class ModelContainingAListOfANestedModel
    {
        [HclName("nested_model")]
        public List<ModelWithOnlyBuiltInTypes> NestedModel { get; set; }
    }

    private class ModelContainingADictionaryOfANestedModel
    {
        [HclName("nested_model")]
        public Dictionary<string, ModelWithOnlyBuiltInTypes> NestedModel { get; set; }
    }
    
    private class ModelContainingAListOfTheSameNestedModelTwice
    {
        [HclName("first_nested_model")]
        public List<ModelWithOnlyBuiltInTypes> FirstNestedModel { get; set; }
        
        [HclName("second_nested_model")]
        public List<ModelWithOnlyBuiltInTypes> SecondNestedModel { get; set; }
    }

    private class ModelContainingADictionaryOfTheSameNestedModelTwice
    {
        [HclName("first_nested_model")]
        public Dictionary<string, ModelWithOnlyBuiltInTypes> FirstNestedModel { get; set; }
        
        [HclName("second_nested_model")]
        public Dictionary<string, ModelWithOnlyBuiltInTypes> SecondNestedModel { get; set; }
    }
}