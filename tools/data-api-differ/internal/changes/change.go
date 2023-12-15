package changes

// Change defines the type of Change between one set of API Definitions and another.
// Each implementation of Change contains additional information about the change
// for example, ConstantKeyValueAdded / ResourceIdRemoved which is useful elsewhere.
type Change interface {
	// IsBreaking returns whether this Change is considered a Breaking Change.
	IsBreaking() bool
}
