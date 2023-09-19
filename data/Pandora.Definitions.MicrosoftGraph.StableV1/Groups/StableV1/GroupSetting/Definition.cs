// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSetting;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSetting";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSettingOperation(),
        new DeleteGroupByIdSettingByIdOperation(),
        new GetGroupByIdSettingByIdOperation(),
        new GetGroupByIdSettingCountOperation(),
        new ListGroupByIdSettingsOperation(),
        new UpdateGroupByIdSettingByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
