// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package models

// TODO: document these

type ResourceBuildInfo struct {
	Overrides []Override
}

type Override struct {
	Name        string
	UpdatedName *string
	Description *string
}
