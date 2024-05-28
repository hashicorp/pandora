package parser

func pointerTo[T any](input T) *T {
	return &input
}
