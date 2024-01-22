// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_09_15.CosmosDB;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CustomerManagedKeyStatusConstant
{
    [Description("Access to the configured customer managed key confirmed.")]
    AccessToTheConfiguredCustomerManagedKeyConfirmedPoint,

    [Description("Access to your account is currently revoked because the access rules are blocking outbound requests to the Azure Key Vault service; for more details about this error and how to restore access to your account please visit https://learn.microsoft.com/en-us/azure/cosmos-db/cmk-troubleshooting-guide (4016).")]
    AccessToYourAccountIsCurrentlyRevokedBecauseTheAccessRulesAreBlockingOutboundRequestsToTheAzureKeyVaultServiceForMoreDetailsAboutThisErrorAndHowToRestoreAccessToYourAccountPleaseVisitHttpsLearnPointmicrosoftPointcomEnNegativeusAzureCosmosNegativedbCmkNegativetroubleshootingNegativeguideFourZeroOneSixPoint,

    [Description("Access to your account is currently revoked because the Azure Cosmos DB account has an undefined default identity; for more details about this error and how to restore access to your account please visit https://learn.microsoft.com/en-us/azure/cosmos-db/cmk-troubleshooting-guide#invalid-azure-cosmos-db-default-identity (4015).")]
    AccessToYourAccountIsCurrentlyRevokedBecauseTheAzureCosmosDBAccountHasAnUndefinedDefaultIdentityForMoreDetailsAboutThisErrorAndHowToRestoreAccessToYourAccountPleaseVisitHttpsLearnPointmicrosoftPointcomEnNegativeusAzureCosmosNegativedbCmkNegativetroubleshootingNegativeguideInvalidNegativeazureNegativecosmosNegativedbNegativedefaultNegativeidentityFourZeroOneFivePoint,

    [Description("Access to your account is currently revoked because the Azure Cosmos DB account's key vault key URI does not follow the expected format; for more details about this error and how to restore access to your account please visit https://learn.microsoft.com/en-us/azure/cosmos-db/cmk-troubleshooting-guide#improper-syntax-detected-on-the-key-vault-uri-property (4006).")]
    AccessToYourAccountIsCurrentlyRevokedBecauseTheAzureCosmosDBAccountSKeyVaultKeyURIDoesNotFollowTheExpectedFormatForMoreDetailsAboutThisErrorAndHowToRestoreAccessToYourAccountPleaseVisitHttpsLearnPointmicrosoftPointcomEnNegativeusAzureCosmosNegativedbCmkNegativetroubleshootingNegativeguideImproperNegativesyntaxNegativedetectedNegativeonNegativetheNegativekeyNegativevaultNegativeuriNegativepropertyFourZeroZeroSixPoint,

    [Description("Access to your account is currently revoked because the Azure Cosmos DB service is unable to obtain the AAD authentication token for the account's default identity; for more details about this error and how to restore access to your account please visit https://learn.microsoft.com/en-us/azure/cosmos-db/cmk-troubleshooting-guide#azure-active-directory-token-acquisition-error (4000).")]
    AccessToYourAccountIsCurrentlyRevokedBecauseTheAzureCosmosDBServiceIsUnableToObtainTheAADAuthenticationTokenForTheAccountSDefaultIdentityForMoreDetailsAboutThisErrorAndHowToRestoreAccessToYourAccountPleaseVisitHttpsLearnPointmicrosoftPointcomEnNegativeusAzureCosmosNegativedbCmkNegativetroubleshootingNegativeguideAzureNegativeactiveNegativedirectoryNegativetokenNegativeacquisitionNegativeerrorFourZeroZeroZeroPoint,

    [Description("Access to your account is currently revoked because the Azure Cosmos DB service is unable to wrap or unwrap the key; for more details about this error and how to restore access to your account please visit https://learn.microsoft.com/en-us/azure/cosmos-db/cmk-troubleshooting-guide#internal-unwrapping-procedure-error (4005).")]
    AccessToYourAccountIsCurrentlyRevokedBecauseTheAzureCosmosDBServiceIsUnableToWrapOrUnwrapTheKeyForMoreDetailsAboutThisErrorAndHowToRestoreAccessToYourAccountPleaseVisitHttpsLearnPointmicrosoftPointcomEnNegativeusAzureCosmosNegativedbCmkNegativetroubleshootingNegativeguideInternalNegativeunwrappingNegativeprocedureNegativeerrorFourZeroZeroFivePoint,

    [Description("Access to your account is currently revoked because the Azure Key Vault DNS name specified by the account's keyvaultkeyuri property could not be resolved; for more details about this error and how to restore access to your account please visit https://learn.microsoft.com/en-us/azure/cosmos-db/cmk-troubleshooting-guide#unable-to-resolve-the-key-vaults-dns (4009).")]
    AccessToYourAccountIsCurrentlyRevokedBecauseTheAzureKeyVaultDNSNameSpecifiedByTheAccountSKeyvaultkeyuriPropertyCouldNotBeResolvedForMoreDetailsAboutThisErrorAndHowToRestoreAccessToYourAccountPleaseVisitHttpsLearnPointmicrosoftPointcomEnNegativeusAzureCosmosNegativedbCmkNegativetroubleshootingNegativeguideUnableNegativetoNegativeresolveNegativetheNegativekeyNegativevaultsNegativednsFourZeroZeroNinePoint,

    [Description("Access to your account is currently revoked because the correspondent Azure Key Vault was not found; for more details about this error and how to restore access to your account please visit https://learn.microsoft.com/en-us/azure/cosmos-db/cmk-troubleshooting-guide#azure-key-vault-resource-not-found (4017).")]
    AccessToYourAccountIsCurrentlyRevokedBecauseTheCorrespondentAzureKeyVaultWasNotFoundForMoreDetailsAboutThisErrorAndHowToRestoreAccessToYourAccountPleaseVisitHttpsLearnPointmicrosoftPointcomEnNegativeusAzureCosmosNegativedbCmkNegativetroubleshootingNegativeguideAzureNegativekeyNegativevaultNegativeresourceNegativenotNegativefoundFourZeroOneSevenPoint,

    [Description("Access to your account is currently revoked because the correspondent key is not found on the specified Key Vault; for more details about this error and how to restore access to your account please visit https://learn.microsoft.com/en-us/azure/cosmos-db/cmk-troubleshooting-guide#azure-key-vault-resource-not-found (4003).")]
    AccessToYourAccountIsCurrentlyRevokedBecauseTheCorrespondentKeyIsNotFoundOnTheSpecifiedKeyVaultForMoreDetailsAboutThisErrorAndHowToRestoreAccessToYourAccountPleaseVisitHttpsLearnPointmicrosoftPointcomEnNegativeusAzureCosmosNegativedbCmkNegativetroubleshootingNegativeguideAzureNegativekeyNegativevaultNegativeresourceNegativenotNegativefoundFourZeroZeroThreePoint,

    [Description("Access to your account is currently revoked because the current default identity no longer has permission to the associated Key Vault key; for more details about this error and how to restore access to your account please visit https://learn.microsoft.com/en-us/azure/cosmos-db/cmk-troubleshooting-guide#default-identity-is-unauthorized-to-access-the-azure-key-vault-key (4002).")]
    AccessToYourAccountIsCurrentlyRevokedBecauseTheCurrentDefaultIdentityNoLongerHasPermissionToTheAssociatedKeyVaultKeyForMoreDetailsAboutThisErrorAndHowToRestoreAccessToYourAccountPleaseVisitHttpsLearnPointmicrosoftPointcomEnNegativeusAzureCosmosNegativedbCmkNegativetroubleshootingNegativeguideDefaultNegativeidentityNegativeisNegativeunauthorizedNegativetoNegativeaccessNegativetheNegativeazureNegativekeyNegativevaultNegativekeyFourZeroZeroTwoPoint,

    [Description("Access to your account is currently revoked; for more details about this error and how to restore access to your account please visit https://learn.microsoft.com/en-us/azure/cosmos-db/cmk-troubleshooting-guide")]
    AccessToYourAccountIsCurrentlyRevokedForMoreDetailsAboutThisErrorAndHowToRestoreAccessToYourAccountPleaseVisitHttpsLearnPointmicrosoftPointcomEnNegativeusAzureCosmosNegativedbCmkNegativetroubleshootingNegativeguide,
}
