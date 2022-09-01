using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_03_01.ContainerApps;


internal class CustomDomainModel
{
    [JsonPropertyName("bindingType")]
    public BindingTypeConstant? BindingType { get; set; }

    [JsonPropertyName("certificateId")]
    [Required]
    public string CertificateId { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }
}
