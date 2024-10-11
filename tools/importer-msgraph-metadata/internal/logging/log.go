// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package logging

import (
	"fmt"

	"github.com/hashicorp/go-hclog"
)

var Log hclog.Logger

func init() {
	Log = hclog.NewNullLogger()
}

func Debugf(msg string, args ...interface{}) {
	Log.Debug(fmt.Sprintf(msg, args...))
}

func Errorf(msg string, args ...interface{}) {
	Log.Error(fmt.Sprintf(msg, args...))
}

func Tracef(msg string, args ...interface{}) {
	Log.Trace(fmt.Sprintf(msg, args...))
}

func Infof(msg string, args ...interface{}) {
	Log.Info(fmt.Sprintf(msg, args...))
}

func Warnf(msg string, args ...interface{}) {
	Log.Warn(fmt.Sprintf(msg, args...))
}
