package logging

import "github.com/hashicorp/go-hclog"

var Log hclog.Logger

func init() {
	Log = hclog.NewNullLogger()
}
