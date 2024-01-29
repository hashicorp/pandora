// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;

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
    /// GenerateModel defines whether the Typed Model(s) should be output for this Resource.
    /// </summary>
    public bool GenerateModel { get; }

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
    /// ResourceCategory is the Category under which this Resource should appear in the documentation.
    /// </summary>
    public string ResourceCategory { get; }

    /// <summary>
    /// ResourceDescription is the description which should be used for this Resource.
    /// </summary>
    public string ResourceDescription { get; }

    /// <summary>
    /// ResourceExampleUsage is the Example Usage snippet for this Resource which can be used in the documentation.
    /// </summary>
    public string ResourceExampleUsage { get; }

    /// <summary>
    /// ResourceId specifies the Resource ID associated with this Terraform Resource.
    /// </summary>
    public ResourceID ResourceId { get; }

    /// <summary>
    /// ResourceLabel is the Terraform Resource Label which should be used for this Resource
    /// **without** the Provider Prefix (e.g. `resource_group` rather than `azurerm_resource_group`).
    /// </summary>
    public string ResourceLabel { get; }

    /// <summary>
    /// SchemaModel is a reference to a Type defining the Terraform Schema for this Resource. 
    /// </summary>
    public Type? SchemaModel { get; }

    /// <summary>
    /// SchemaMappings is a reference to the TerraformMappingDefinition which defines how the TerraformSchema
    /// defined in SchemaModel should be mapped to/from the SDK Models and Terraform Resource ID. 
    /// </summary>
    public TerraformMappingDefinition SchemaMappings { get; }

    /// <summary>
    /// Tests is a reference to the TerraformResourceTestDefinition which defines how the Terraform Acceptance
    /// Tests should look for this resource.
    /// </summary>
    public TerraformResourceTestDefinition Tests { get; }

    /// <summary>
    /// UpdateMethod optionally defines the Update Method associated with this Resource, both for whether this
    /// should be generated and determining which SDK methods which should be called.
    /// </summary>
    public MethodDefinition? UpdateMethod { get; }
}