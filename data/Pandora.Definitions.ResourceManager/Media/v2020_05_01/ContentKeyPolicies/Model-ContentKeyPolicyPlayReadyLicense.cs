using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.ContentKeyPolicies;


internal class ContentKeyPolicyPlayReadyLicenseModel
{
    [JsonPropertyName("allowTestDevices")]
    [Required]
    public bool AllowTestDevices { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("beginDate")]
    public DateTime? BeginDate { get; set; }

    [JsonPropertyName("contentKeyLocation")]
    [Required]
    public ContentKeyPolicyPlayReadyContentKeyLocationModel ContentKeyLocation { get; set; }

    [JsonPropertyName("contentType")]
    [Required]
    public ContentKeyPolicyPlayReadyContentTypeConstant ContentType { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expirationDate")]
    public DateTime? ExpirationDate { get; set; }

    [JsonPropertyName("gracePeriod")]
    public string? GracePeriod { get; set; }

    [JsonPropertyName("licenseType")]
    [Required]
    public ContentKeyPolicyPlayReadyLicenseTypeConstant LicenseType { get; set; }

    [JsonPropertyName("playRight")]
    public ContentKeyPolicyPlayReadyPlayRightModel? PlayRight { get; set; }

    [JsonPropertyName("relativeBeginDate")]
    public string? RelativeBeginDate { get; set; }

    [JsonPropertyName("relativeExpirationDate")]
    public string? RelativeExpirationDate { get; set; }
}
