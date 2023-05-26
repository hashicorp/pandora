using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.DatabaseAutomaticTuning;

internal class Definition : ResourceDefinition
{
    public string Name => "DatabaseAutomaticTuning";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AutomaticTuningDisabledReasonConstant),
        typeof(AutomaticTuningModeConstant),
        typeof(AutomaticTuningOptionModeActualConstant),
        typeof(AutomaticTuningOptionModeDesiredConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AutomaticTuningOptionsModel),
        typeof(DatabaseAutomaticTuningModel),
        typeof(DatabaseAutomaticTuningPropertiesModel),
    };
}
