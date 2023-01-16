using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Formulas;


internal class FormulaPropertiesModel
{
    [JsonPropertyName("author")]
    public string? Author { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationDate")]
    public DateTime? CreationDate { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("formulaContent")]
    public LabVirtualMachineCreationParameterModel? FormulaContent { get; set; }

    [JsonPropertyName("osType")]
    public string? OsType { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("uniqueIdentifier")]
    public string? UniqueIdentifier { get; set; }

    [JsonPropertyName("vm")]
    public FormulaPropertiesFromVMModel? VM { get; set; }
}
