using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Pandora.Data.Transformers;

public static class TerraformResourceTestDefinitionTests
{
    [TestCase]
    public static void EmptyBasicShouldThrowAnException()
    {
        Assert.Throws<NotSupportedException>(() => TerraformResourceTestDefinition.Map(new TestDefinitionWithEmptyBasic()));
    }

    [TestCase]
    public static void EmptyRequiresImportShouldThrowAnException()
    {
        Assert.Throws<NotSupportedException>(() => TerraformResourceTestDefinition.Map(new TestDefinitionWithEmptyRequiresImport()));
    }

    [TestCase]
    public static void BasicAndRequiredImportsOnly()
    {
        var actual = TerraformResourceTestDefinition.Map(new TestDefinitionWithBasicAndRequiresImportsOnly());
        Assert.AreEqual("basic", actual.BasicConfig);
        Assert.AreEqual("require imports", actual.RequiresImportConfig);
        Assert.Null(actual.CompleteConfig);
        Assert.Null(actual.TemplateConfig);
        Assert.AreEqual(0, actual.OtherTests.Count);
    }

    [TestCase]
    public static void WithComplete()
    {
        var actual = TerraformResourceTestDefinition.Map(new TestDefinitionWithComplete());
        Assert.AreEqual("basic", actual.BasicConfig);
        Assert.AreEqual("require imports", actual.RequiresImportConfig);
        Assert.AreEqual("complete", actual.CompleteConfig);
        Assert.Null(actual.TemplateConfig);
        Assert.AreEqual(0, actual.OtherTests.Count);
    }

    [TestCase]
    public static void WithTemplate()
    {
        var actual = TerraformResourceTestDefinition.Map(new TestDefinitionWithTemplate());
        Assert.AreEqual("basic", actual.BasicConfig);
        Assert.AreEqual("require imports", actual.RequiresImportConfig);
        Assert.Null(actual.CompleteConfig);
        Assert.AreEqual("template", actual.TemplateConfig);
        Assert.AreEqual(0, actual.OtherTests.Count);
    }

    [TestCase]
    public static void WithOtherTests()
    {
        var actual = TerraformResourceTestDefinition.Map(new TestDefinitionWithOtherTests());
        Assert.AreEqual("basic", actual.BasicConfig);
        Assert.AreEqual("require imports", actual.RequiresImportConfig);
        Assert.Null(actual.CompleteConfig);
        Assert.Null(actual.TemplateConfig);
        Assert.AreEqual(2, actual.OtherTests.Count);

        var firstTestConfigs = actual.OtherTests["First"];
        Assert.AreEqual(2, firstTestConfigs.Count);
        Assert.AreEqual("1-1", firstTestConfigs[0]);
        Assert.AreEqual("1-2", firstTestConfigs[1]);

        var secondTestConfigs = actual.OtherTests["Second"];
        Assert.AreEqual(2, secondTestConfigs.Count);
        Assert.AreEqual("2-1", secondTestConfigs[0]);
        Assert.AreEqual("2-2", secondTestConfigs[1]);
    }

    private class TestDefinitionWithEmptyBasic : Definitions.Interfaces.TerraformResourceTestDefinition
    {
        public string BasicTestConfig => null;
        public string RequiresImportConfig => "requires imports";
        public string? CompleteConfig => null;
        public string? TemplateConfig => null;
        public Dictionary<string, List<string>> OtherTests => new Dictionary<string, List<string>>();
    }

    private class TestDefinitionWithEmptyRequiresImport : Definitions.Interfaces.TerraformResourceTestDefinition
    {
        public string BasicTestConfig => "basic";
        public string RequiresImportConfig => null;
        public string? CompleteConfig => null;
        public string? TemplateConfig => null;
        public Dictionary<string, List<string>> OtherTests => new Dictionary<string, List<string>>();
    }

    private class TestDefinitionWithBasicAndRequiresImportsOnly : Definitions.Interfaces.TerraformResourceTestDefinition
    {
        public string BasicTestConfig => "basic";
        public string RequiresImportConfig => "require imports";
        public string? CompleteConfig => null;
        public string? TemplateConfig => null;
        public Dictionary<string, List<string>> OtherTests => new Dictionary<string, List<string>>();
    }

    private class TestDefinitionWithComplete : Definitions.Interfaces.TerraformResourceTestDefinition
    {
        public string BasicTestConfig => "basic";
        public string RequiresImportConfig => "require imports";
        public string? CompleteConfig => "complete";
        public string? TemplateConfig => null;
        public Dictionary<string, List<string>> OtherTests => new Dictionary<string, List<string>>();
    }

    private class TestDefinitionWithTemplate : Definitions.Interfaces.TerraformResourceTestDefinition
    {
        public string BasicTestConfig => "basic";
        public string RequiresImportConfig => "require imports";
        public string? CompleteConfig => null;
        public string? TemplateConfig => "template";
        public Dictionary<string, List<string>> OtherTests => new Dictionary<string, List<string>>();
    }

    private class TestDefinitionWithOtherTests : Definitions.Interfaces.TerraformResourceTestDefinition
    {
        public string BasicTestConfig => "basic";
        public string RequiresImportConfig => "require imports";
        public string? CompleteConfig => null;
        public string? TemplateConfig => null;
        public Dictionary<string, List<string>> OtherTests => new Dictionary<string, List<string>>
        {
            {"First", new List<string>{ "1-1", "1-2", }},
            {"Second", new List<string>{ "2-1", "2-2", }},
        };
    }
}