using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_12_01.BackupInstances;


internal class ProtectionStatusDetailsModel
{
    [JsonPropertyName("errorDetails")]
    public UserFacingErrorModel? ErrorDetails { get; set; }

    [JsonPropertyName("status")]
    public StatusConstant? Status { get; set; }
}
