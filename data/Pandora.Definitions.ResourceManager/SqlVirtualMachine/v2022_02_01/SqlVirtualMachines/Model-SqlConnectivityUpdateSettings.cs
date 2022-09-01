using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.SqlVirtualMachines;


internal class SqlConnectivityUpdateSettingsModel
{
    [JsonPropertyName("connectivityType")]
    public ConnectivityTypeConstant? ConnectivityType { get; set; }

    [JsonPropertyName("port")]
    public int? Port { get; set; }

    [JsonPropertyName("sqlAuthUpdatePassword")]
    public string? SqlAuthUpdatePassword { get; set; }

    [JsonPropertyName("sqlAuthUpdateUserName")]
    public string? SqlAuthUpdateUserName { get; set; }
}
