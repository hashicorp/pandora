package models

type ValidationDefinition interface {
}

var _ ValidationDefinition = FixedValuesDefinition[float64]{}
var _ ValidationDefinition = FixedValuesDefinition[int64]{}
var _ ValidationDefinition = FixedValuesDefinition[string]{}

type FixedValuesDefinition[T any] struct {
	AllowsValues []T
}
