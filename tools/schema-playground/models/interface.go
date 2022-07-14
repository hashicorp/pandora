package models

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type OperationMetaData struct {
	Name   string
	Method resourcemanager.ApiOperation
}

type FieldMapping struct {
	SchemaFieldPath    string
	CreateModelMapping *string
	UpdateModelMapping *string
	ReadModelMapping   *string
}

type DataSourceCandidate struct {
	Singular   bool
	Plural     bool
	ResourceId resourcemanager.ResourceIdDefinition
}

func (d DataSourceCandidate) String() string {
	return fmt.Sprintf("Singular %t / Plural %t - %q", d.Singular, d.Plural, d.ResourceId.Id)
}

type ResourceCandidate struct {
	HasSuffixedMethods bool
	ResourceId         resourcemanager.ResourceIdDefinition

	CreateMethod *OperationMetaData
	UpdateMethod *OperationMetaData
	DeleteMethod *OperationMetaData
	GetMethod    *OperationMetaData
}

func (r ResourceCandidate) HasUpdate() bool {
	return r.UpdateMethod != nil
}

func (r ResourceCandidate) String() string {
	return fmt.Sprintf("Has Suffixed %t / Has Updated %t - %q", r.HasSuffixedMethods, r.HasUpdate(), r.ResourceId.Id)
}
