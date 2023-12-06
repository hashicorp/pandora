package changes

var _ Change = ResourceIdAdded{}

// ResourceIdAdded defines information about a new Resource ID.
type ResourceIdAdded struct {
	// ServiceName specifies the name of the Service which contains this
	// Resource ID.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this
	// Resource ID.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this
	// Resource ID.
	ResourceName string

	// ResourceIdName specifies the name of the Resource ID which has been added.
	ResourceIdName string

	// ResourceIdValue specifies the value used for this Resource ID e.g. `/foo/{bar}`
	ResourceIdValue string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (ResourceIdAdded) IsBreaking() bool {
	return false
}
