using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Nginx.v2022_08_01.NginxDeployment;


internal class NginxFrontendIPConfigurationModel
{
    [JsonPropertyName("privateIPAddresses")]
    public List<NginxPrivateIPAddressModel>? PrivateIPAddresses { get; set; }

    [JsonPropertyName("publicIPAddresses")]
    public List<NginxPublicIPAddressModel>? PublicIPAddresses { get; set; }
}
