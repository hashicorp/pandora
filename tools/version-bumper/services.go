// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package main

type ServiceLocator interface {
	AvailableServices() (*[]AvailableService, error)
}

type AvailableService struct {
	Name      string
	Directory string
	Version   []string
}
