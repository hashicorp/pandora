using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;


internal class AS2AcknowledgementConnectionSettingsModel
{
    [JsonPropertyName("ignoreCertificateNameMismatch")]
    [Required]
    public bool IgnoreCertificateNameMismatch { get; set; }

    [JsonPropertyName("keepHttpConnectionAlive")]
    [Required]
    public bool KeepHTTPConnectionAlive { get; set; }

    [JsonPropertyName("supportHttpStatusCodeContinue")]
    [Required]
    public bool SupportHTTPStatusCodeContinue { get; set; }

    [JsonPropertyName("unfoldHttpHeaders")]
    [Required]
    public bool UnfoldHTTPHeaders { get; set; }
}
