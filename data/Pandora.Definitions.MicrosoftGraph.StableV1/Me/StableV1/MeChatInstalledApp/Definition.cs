// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeChatInstalledApp;

internal class Definition : ResourceDefinition
{
    public string Name => "MeChatInstalledApp";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeChatByIdInstalledAppByIdUpgradeOperation(),
        new CreateMeChatByIdInstalledAppOperation(),
        new DeleteMeChatByIdInstalledAppByIdOperation(),
        new GetMeChatByIdInstalledAppByIdOperation(),
        new GetMeChatByIdInstalledAppCountOperation(),
        new ListMeChatByIdInstalledAppsOperation(),
        new UpdateMeChatByIdInstalledAppByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeChatByIdInstalledAppByIdUpgradeRequestModel)
    };
}
