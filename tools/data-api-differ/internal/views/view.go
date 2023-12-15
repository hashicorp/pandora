package views

type View interface {
	// RenderMarkdown renders the View using Markdown, intended for both display
	// in a Terminal and to be output as a GitHub Comment.
	RenderMarkdown() (*string, error)
}
