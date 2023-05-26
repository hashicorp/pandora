using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureActiveDirectory.v2017_04_01.DiagnosticSettings;

internal class ListOperation : Pandora.Definitions.Operations.GetOperation
{
    public override Type? ResponseObject() => typeof(DiagnosticSettingsResourceCollectionModel);

    public override string? UriSuffix() => "/providers/Microsoft.AADIAM/diagnosticSettings";


}
