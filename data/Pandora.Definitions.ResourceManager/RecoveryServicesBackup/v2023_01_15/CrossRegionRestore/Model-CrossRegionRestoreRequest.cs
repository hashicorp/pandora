using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_01_15.CrossRegionRestore;


internal class CrossRegionRestoreRequestModel
{
    [JsonPropertyName("crossRegionRestoreAccessDetails")]
    public CrrAccessTokenModel? CrossRegionRestoreAccessDetails { get; set; }

    [JsonPropertyName("restoreRequest")]
    public RestoreRequestModel? RestoreRequest { get; set; }
}
