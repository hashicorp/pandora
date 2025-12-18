// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package views

type View interface {
	// RenderMarkdown renders the View using Markdown, intended for both display
	// in a Terminal and to be output as a GitHub Comment.
	RenderMarkdown() (*string, error)
}
