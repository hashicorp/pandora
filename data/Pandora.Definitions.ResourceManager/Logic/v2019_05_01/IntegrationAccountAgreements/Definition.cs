using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;

internal class Definition : ResourceDefinition
{
    public string Name => "IntegrationAccountAgreements";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListContentCallbackUrlOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AgreementTypeConstant),
        typeof(EdifactCharacterSetConstant),
        typeof(EdifactDecimalIndicatorConstant),
        typeof(EncryptionAlgorithmConstant),
        typeof(HashingAlgorithmConstant),
        typeof(KeyTypeConstant),
        typeof(MessageFilterTypeConstant),
        typeof(SegmentTerminatorSuffixConstant),
        typeof(SigningAlgorithmConstant),
        typeof(TrailingSeparatorPolicyConstant),
        typeof(UsageIndicatorConstant),
        typeof(X12CharacterSetConstant),
        typeof(X12DateFormatConstant),
        typeof(X12TimeFormatConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AS2AcknowledgementConnectionSettingsModel),
        typeof(AS2AgreementContentModel),
        typeof(AS2EnvelopeSettingsModel),
        typeof(AS2ErrorSettingsModel),
        typeof(AS2MdnSettingsModel),
        typeof(AS2MessageConnectionSettingsModel),
        typeof(AS2OneWayAgreementModel),
        typeof(AS2ProtocolSettingsModel),
        typeof(AS2SecuritySettingsModel),
        typeof(AS2ValidationSettingsModel),
        typeof(AgreementContentModel),
        typeof(BusinessIdentityModel),
        typeof(EdifactAcknowledgementSettingsModel),
        typeof(EdifactAgreementContentModel),
        typeof(EdifactDelimiterOverrideModel),
        typeof(EdifactEnvelopeOverrideModel),
        typeof(EdifactEnvelopeSettingsModel),
        typeof(EdifactFramingSettingsModel),
        typeof(EdifactMessageFilterModel),
        typeof(EdifactMessageIdentifierModel),
        typeof(EdifactOneWayAgreementModel),
        typeof(EdifactProcessingSettingsModel),
        typeof(EdifactProtocolSettingsModel),
        typeof(EdifactSchemaReferenceModel),
        typeof(EdifactValidationOverrideModel),
        typeof(EdifactValidationSettingsModel),
        typeof(GetCallbackUrlParametersModel),
        typeof(IntegrationAccountAgreementModel),
        typeof(IntegrationAccountAgreementPropertiesModel),
        typeof(WorkflowTriggerCallbackUrlModel),
        typeof(WorkflowTriggerListCallbackUrlQueriesModel),
        typeof(X12AcknowledgementSettingsModel),
        typeof(X12AgreementContentModel),
        typeof(X12DelimiterOverridesModel),
        typeof(X12EnvelopeOverrideModel),
        typeof(X12EnvelopeSettingsModel),
        typeof(X12FramingSettingsModel),
        typeof(X12MessageFilterModel),
        typeof(X12MessageIdentifierModel),
        typeof(X12OneWayAgreementModel),
        typeof(X12ProcessingSettingsModel),
        typeof(X12ProtocolSettingsModel),
        typeof(X12SchemaReferenceModel),
        typeof(X12SecuritySettingsModel),
        typeof(X12ValidationOverrideModel),
        typeof(X12ValidationSettingsModel),
    };
}
