package generator

func methodsYetToBeImplementedForResource() string {
	return `
// TODO: the methods below this point are yet to be implemented
// but are output purely to keep the compiler for happy in the short-term
// by ensuring that this Resource correctly implements 'sdk.Resource'

func ModelObject() interface{
	// TODO: implement me in the generator
	return nil
}
func ResourceType() string {
	// TODO: implement me in the generator
	return nil
}
func Create() sdk.ResourceFunc {
	// TODO: implement me in the generator
	return sdk.ResourceFunc{}
}
func Read() sdk.ResourceFunc {
	// TODO: implement me in the generator
	return sdk.ResourceFunc{}
}
`
}
