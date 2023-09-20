// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeDeviceManagementTroubleshootingEvent;

internal class ListMeDeviceManagementTroubleshootingEventsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => null;
    public override Type NestedItemType() => typeof(DeviceManagementTroubleshootingEventCollectionResponseModel);
    public override string? UriSuffix() => "/me/deviceManagementTroubleshootingEvents";
}
