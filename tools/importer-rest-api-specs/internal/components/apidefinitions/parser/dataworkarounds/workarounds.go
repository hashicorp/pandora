// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

var workarounds = []workaround{
	// These workarounds are related to issues with the upstream API Definitions
	workaroundAlertsManagement{},
	workaroundAuthorization25080{},
	workaroundDigitalTwins25120{},
	workaroundAutomation25108{},
	workaroundAutomation25435{},
	workaroundBatch21291{},
	workaroundBotService27351{},
	workaroundContainerService21394{},
	workaroundDataFactory23013{},
	workaroundHDInsight26838{},
	workaroundLoadTest20961{},
	workaroundRedis22407{},
	workaroundMachineLearning25142{},
	workaroundNewRelic29256{},
	workaroundOperationalinsights27524{},
	workaroundRecoveryServicesSiteRecovery26680{},
	workaroundStreamAnalytics27577{},
	workaroundSubscriptions20254{},
	workaroundNetwork29303{},

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
