using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_04_01.ProtectionContainers;


internal class GenericContainerExtendedInfoModel
{
    [JsonPropertyName("containerIdentityInfo")]
    public ContainerIdentityInfoModel? ContainerIdentityInfo { get; set; }

    [JsonPropertyName("rawCertData")]
    public string? RawCertData { get; set; }

    [JsonPropertyName("serviceEndpoints")]
    public Dictionary<string, string>? ServiceEndpoints { get; set; }
}
