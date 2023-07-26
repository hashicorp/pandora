using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2023_07_01.DiagnosticSettings;

internal class Definition : ResourceDefinition
{
    public string Name => "DiagnosticSettings";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetDiagnosticProactiveLogCollectionSettingsOperation(),
        new GetDiagnosticRemoteSupportSettingsOperation(),
        new UpdateDiagnosticProactiveLogCollectionSettingsOperation(),
        new UpdateDiagnosticRemoteSupportSettingsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessLevelConstant),
        typeof(ProactiveDiagnosticsConsentConstant),
        typeof(RemoteApplicationTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DiagnosticProactiveLogCollectionSettingsModel),
        typeof(DiagnosticRemoteSupportSettingsModel),
        typeof(DiagnosticRemoteSupportSettingsPropertiesModel),
        typeof(ProactiveLogCollectionSettingsPropertiesModel),
        typeof(RemoteSupportSettingsModel),
    };
}
