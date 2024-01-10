package changes

var _ Change = OperationLongRunningAdded{}

// OperationLongRunningAdded defines when an existing Operation is now Long Running.
type OperationLongRunningAdded struct {
	// ServiceName specifies the name of the Service which contains this Operation.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Operation.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Operation.
	ResourceName string

	// OperationName specifies the name of the Operation which is now a Long Running Operation.
	OperationName string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (OperationLongRunningAdded) IsBreaking() bool {
	return true
}
