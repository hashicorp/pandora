using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.IntegrationRuntime;


internal class IntegrationRuntimeSsisPropertiesModel
{
    [JsonPropertyName("catalogInfo")]
    public IntegrationRuntimeSsisCatalogInfoModel? CatalogInfo { get; set; }

    [JsonPropertyName("customSetupScriptProperties")]
    public IntegrationRuntimeCustomSetupScriptPropertiesModel? CustomSetupScriptProperties { get; set; }

    [JsonPropertyName("dataProxyProperties")]
    public IntegrationRuntimeDataProxyPropertiesModel? DataProxyProperties { get; set; }

    [JsonPropertyName("edition")]
    public IntegrationRuntimeEditionConstant? Edition { get; set; }

    [JsonPropertyName("expressCustomSetupProperties")]
    public List<CustomSetupBaseModel>? ExpressCustomSetupProperties { get; set; }

    [JsonPropertyName("licenseType")]
    public IntegrationRuntimeLicenseTypeConstant? LicenseType { get; set; }
}
