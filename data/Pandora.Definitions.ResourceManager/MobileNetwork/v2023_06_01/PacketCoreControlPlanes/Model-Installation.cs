using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_06_01.PacketCoreControlPlanes;


internal class InstallationModel
{
    [JsonPropertyName("desiredState")]
    public DesiredInstallationStateConstant? DesiredState { get; set; }

    [JsonPropertyName("operation")]
    public AsyncOperationIdModel? Operation { get; set; }

    [JsonPropertyName("reasons")]
    public List<InstallationReasonConstant>? Reasons { get; set; }

    [JsonPropertyName("reinstallRequired")]
    public ReinstallRequiredConstant? ReinstallRequired { get; set; }

    [JsonPropertyName("state")]
    public InstallationStateConstant? State { get; set; }
}
