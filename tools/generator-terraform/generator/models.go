package generator

type OperationDetails struct {
	// CustomTimeoutInMinutes is a custom timeout which should be used for the context instead of the default
	// timeout when this method is being called - this can be useful in extremely quick, or extremely slow
	// operations
	CustomTimeoutInMinutes *int

	// Generate defines whether or not this should be generated this is useful for Read functions
	// which are needed for other functions but may not be explicitly generated.
	Generate bool

	// SDKMethodIsLongRunning specifies whether the SDK Method is a Long Running/Polling Operation
	SDKMethodIsLongRunning bool

	// SDKMethodName is the name of the method within the SDK which should be called
	SDKMethodName string

	// SDKModelName is the name of the model used in the SDK by this operation
	SDKModelName *string
}
