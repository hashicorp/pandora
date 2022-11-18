using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationsManagement.v2015_11_01_preview.ManagementAssociation;

internal class ListBySubscriptionOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new SubscriptionId();

\t\tpublic override Type? ResponseObject() => typeof(ManagementAssociationPropertiesListModel);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.OperationsManagement/managementAssociations";


}
