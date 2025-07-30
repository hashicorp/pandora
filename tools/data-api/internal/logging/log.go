// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package logging

import (
	"fmt"
	"os"

	"github.com/hashicorp/go-hclog"
)

var Log hclog.Logger

func init() {
	Log = hclog.NewNullLogger()
}

func Fatalf(msg string, args ...interface{}) {
	Log.Error(fmt.Sprintf(msg, args...))
	os.Exit(1)
}

func Fatal(msg string) {
	Log.Error(msg)
	os.Exit(1)
}

func Debugf(msg string, args ...interface{}) {
	Log.Debug(fmt.Sprintf(msg, args...))
}

func Debug(msg string) {
	Log.Debug(msg)
}

func Errorf(msg string, args ...interface{}) {
	Log.Error(fmt.Sprintf(msg, args...))
}

func Error(msg string) {
	Log.Error(msg)
}

func Tracef(msg string, args ...interface{}) {
	Log.Trace(fmt.Sprintf(msg, args...))
}

func Trace(msg string) {
	Log.Trace(msg)
}

func Infof(msg string, args ...interface{}) {
	Log.Info(fmt.Sprintf(msg, args...))
}

func Info(msg string) {
	Log.Info(msg)
}

func Warnf(msg string, args ...interface{}) {
	Log.Warn(fmt.Sprintf(msg, args...))
}

func Warn(msg string) {
	Log.Warn(msg)
}
