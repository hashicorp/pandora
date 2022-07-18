namespace Pandora.Definitions.Interfaces;

public interface TerraformResourceDefinition
{
    /// <summary>
    /// CreateMethod defines the Create Method associated with this Resource, both for whether this
    /// should be generated and determining which SDK methods which should be called.
    /// </summary>
    public MethodDefinition CreateMethod { get; }

    /// <summary>
    /// DeleteMethod defines the Delete Method associated with this Resource, both for whether this
    /// should be generated and determining which SDK methods which should be called.
    /// </summary>
    public MethodDefinition DeleteMethod { get; }

    /// <summary>
    /// DisplayName is the human readable name for this Resource, used in the Documentation.
    /// </summary>
    public string DisplayName { get; }

    /// <summary>
    /// GenerateIDValidationFunction specifies whether an ID Validation Function should be generated
    /// for this Resource.
    /// </summary>
    public bool GenerateIDValidationFunction { get; }

    /// <summary>
    /// GenerateSchema specifies whether the Schema should be generated for this Resource.
    /// </summary>
    public bool GenerateSchema { get; }

    /// <summary>
    /// ReadMethod defines the Read Method associated with this Resource, both for whether this
    /// should be generated and determining which SDK methods which should be called.
    /// </summary>
    public MethodDefinition ReadMethod { get; }

    /// <summary>
    /// ResourceId specifies the Resource ID associated with this Terraform Resource.
    /// </summary>
    public ResourceID ResourceId { get; }

    /// <summary>
    /// ResourceLabel is the Terraform Resource Label which should be used for this Resource
    /// **without** the Provider Prefix (e.g. `resource_group` rather than `azurerm_resource_group`).
    /// </summary>
    public string ResourceLabel { get; }
}