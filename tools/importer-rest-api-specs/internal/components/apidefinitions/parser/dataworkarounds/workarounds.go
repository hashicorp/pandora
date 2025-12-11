// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

var workarounds = []workaround{
	// These workarounds are related to issues with the upstream API Definitions

	// Common workarounds
	// https://github.com/Azure/azure-rest-api-specs/issues/22758
	commonWorkaroundIsLRO{"RecoveryServicesBackup", []string{"2023-02-01", "2025-02-01"}, []string{"ProtectedItems"}, []string{"CreateOrUpdate", "Delete"}},
	// https://github.com/Azure/azure-rest-api-specs/issues/37325
	commonWorkaroundIsLRO{"RecoveryServicesBackup", []string{"2025-02-01"}, []string{"ProtectionContainers"}, []string{"Unregister"}},

	// Workarounds
	workaroundAlertsManagement{},
	workaroundAuthorization25080{},
	workaroundAutomation25108{},
	workaroundAutomation25435{},
	workaroundBatch21291{},
	workaroundBotService27351{},
	workaroundContainerRegistry32154{},
	workaroundContainerService21394{},
	workaroundDataFactory23013{},
	workaroundDataFactory28837{},
	workaroundDataMigration31001{},
	workaroundDigitalTwins25120{},
	workaroundFluidRelay39089{},
	workaroundHDInsight26838{},
	workaroundLoadTest20961{},
	workaroundMachineLearning25142{},
	workaroundMongoCluster38810{},
	workaroundNetwork29303{},
	workaroundNetwork38407{},
	workaroundNewRelic29256{},
	workaroundOperationalinsights27524{},
	workaroundPaloAltoNetworks38348{},
	workaroundRecoveryServicesSiteRecovery26680{},
	workaroundRedis22407{},
	workaroundSql33215{},
	workaroundStorageCache32537{},
	workaroundStreamAnalytics27577{},
	workaroundSubscriptions20254{},
	workaroundWeb31682{},

	// These workarounds relate to Terraform specific overrides we want to apply (for example for Resource Generation)
	workaroundDevCenterIdToRequired{},
	workaroundTempReadOnlyFieldsContainerService{},
	workaroundTempReadOnlyFieldsDevCenter{},
	workaroundTempReadOnlyFieldsLoadTest{},
	workaroundTempReadOnlyFieldsManagedIdentity{},

	// These workarounds relate to data inconsistencies
	workaroundInconsistentlyDefinedSegments{},
	workaroundInvalidGoPackageNames{},

	// These workarounds are for a specific use cases that are not API related issues
	workaroundSqlJobExecutionsCreateNotLRO{},
}
