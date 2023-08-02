// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class DirectoryModel
{
    [JsonPropertyName("administrativeUnits")]
    public List<AdministrativeUnitModel>? AdministrativeUnits { get; set; }

    [JsonPropertyName("attributeSets")]
    public List<AttributeSetModel>? AttributeSets { get; set; }

    [JsonPropertyName("customSecurityAttributeDefinitions")]
    public List<CustomSecurityAttributeDefinitionModel>? CustomSecurityAttributeDefinitions { get; set; }

    [JsonPropertyName("deletedItems")]
    public List<DirectoryObjectModel>? DeletedItems { get; set; }

    [JsonPropertyName("federationConfigurations")]
    public List<IdentityProviderBaseModel>? FederationConfigurations { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onPremisesSynchronization")]
    public List<OnPremisesDirectorySynchronizationModel>? OnPremisesSynchronization { get; set; }
}
