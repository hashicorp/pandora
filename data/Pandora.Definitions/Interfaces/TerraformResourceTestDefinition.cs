using System.Collections.Generic;

namespace Pandora.Definitions.Interfaces;

public interface TerraformResourceTestDefinition
{
    /// <summary>
    /// BasicTestConfig defines the Terraform Configuration for the Basic Test.
    /// This should provision the Resource using the bare minimum configuration,
    /// namely just Required fields.
    /// </summary>
    public string BasicTestConfig { get; }

    /// <summary>
    /// RequiresImportConfig defines the Terraform Configuration for the RequiresImport
    /// Test.
    /// This first provisions the Basic config and then the RequiresImport config
    /// which validates that when a user tries to provision a resource with the same
    /// unique identifiers, that we flag this as requiring import rather than unintentionally
    /// adopting it (as almost all Azure APIs are Upserts)
    /// </summary>
    public string RequiresImportConfig { get; }

    /// <summary>
    /// CompleteConfig is an optional field which defines the Terraform Configuration
    /// used for the Complete test - which should contain both the Required and all
    /// Optional fields.
    /// This is also used to output the Update test - which provisions the Basic test
    /// configuration, then the Complete configuration and finally the Basic configuration
    /// to ensure that optional fields can be removed.
    /// </summary>
    public string? CompleteConfig { get; }

    /// <summary>
    /// TemplateConfig is an optional field which defines the Terraform Configuration
    /// output as the Template, which is used by each of the other tests to provision
    /// any dependent resources.
    /// </summary>
    public string? TemplateConfig { get; }

    /// <summary>
    /// OtherTests is a dictionary of key (Test Name) to a list of Terraform
    /// Configurations which should be run together as a test.
    /// </summary>
    public Dictionary<string, List<string>> OtherTests { get; }
}