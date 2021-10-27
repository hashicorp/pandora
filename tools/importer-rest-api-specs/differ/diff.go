package differ

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"

type Result struct {
	Proposed parser.ParsedData
	Diff     interface{} // TODO: make sure this has `ContainsBreakingChanges()` so we can raise it if needed
}

func (d Differ) Diff(existing parser.ParsedData, parsed parser.ParsedData) (*Result, error) {
	// TODO: implement me
	return nil, nil
}
