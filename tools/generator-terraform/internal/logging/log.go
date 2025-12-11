// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package logging

import "github.com/hashicorp/go-hclog"

var Log hclog.Logger

func init() {
	Log = hclog.NewNullLogger()
}
