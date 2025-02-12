// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

var workarounds = []workaround{
	// These workarounds are related to issues with the upstream API Definitions
	workaroundAlertsManagement{},
	workaroundAuthorization25080{},
	workaroundAutomation25108{},
	workaroundAutomation25435{},
	workaroundBatch21291{},
	workaroundBotService27351{},
	workaroundContainerRegistry32154{},
	workaroundContainerService21394{},
	workaroundDataFactory23013{},
	workaroundDataFactory27816{},
	workaroundDataMigration31001{},
	workaroundDigitalTwins25120{},
	workaroundHDInsight26838{},
	workaroundLoadTest20961{},
	workaroundMachineLearning25142{},
	workaroundNetwork29303{},
	workaroundNewRelic29256{},
	workaroundOperationalinsights27524{},
	workaroundRecoveryServicesSiteRecovery26680{},
	workaroundRedis22407{},
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
}
