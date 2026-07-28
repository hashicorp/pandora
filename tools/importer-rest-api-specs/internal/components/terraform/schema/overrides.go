// Copyright IBM Corp. 2023, 2026
// SPDX-License-Identifier: MPL-2.0

package schema

var fieldsWhichShouldBeIgnoredExactMatch = []string{
	"Kind",
	"ProvisioningState",
	"ResourceState",
	"Type",
	"InstanceView",
}

var fieldsWhichShouldBeIgnoredIfContains = []string{
	"ConnectionState",
	"Kind",
	"ProvisioningState",
	"ResourceState",
	"Type",
}
