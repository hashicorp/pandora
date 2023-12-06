package views

type View interface {
	// TODO: it'd likely be useful to have this information available as JSON in the future, hence the interface

	// RenderMarkdown renders the View using Markdown, intended for both display
	// in a Terminal and to be output as a GitHub Comment.
	RenderMarkdown() (*string, error)
}
