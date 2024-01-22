// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package models

type DataSourceInput struct {
	// ApiVersion is the version of the API used for this Data Source.
	ApiVersion string

	// ProviderPrefix is the prefix used for the Resources within this Terraform Provider.
	ProviderPrefix string

	// ResourceLabel is the label of this Resource without the Provider Prefix.
	ResourceLabel string

	// RootDirectory is the path to the directory where generated files should be output.
	RootDirectory string

	// ServicePackageName is the name of the Service Package within the Terraform Provider repository.
	ServicePackageName string
}
