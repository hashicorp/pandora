using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_12_01.DeletedBackupInstances;


internal class DeletionInfoModel
{
    [JsonPropertyName("billingEndDate")]
    public string? BillingEndDate { get; set; }

    [JsonPropertyName("deleteActivityID")]
    public string? DeleteActivityID { get; set; }

    [JsonPropertyName("deletionTime")]
    public string? DeletionTime { get; set; }

    [JsonPropertyName("scheduledPurgeTime")]
    public string? ScheduledPurgeTime { get; set; }
}
