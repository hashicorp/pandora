using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.AlertsManagements;

internal class AlertsMetaDataOperation : Pandora.Definitions.Operations.GetOperation
{
    public override Type? ResponseObject() => typeof(AlertsMetaDataModel);

    public override Type? OptionsObject() => typeof(AlertsMetaDataOperation.AlertsMetaDataOptions);

    public override string? UriSuffix() => "/providers/Microsoft.AlertsManagement/alertsMetaData";

    internal class AlertsMetaDataOptions
    {
        [QueryStringName("identifier")]
        public IdentifierConstant Identifier { get; set; }
    }
}
