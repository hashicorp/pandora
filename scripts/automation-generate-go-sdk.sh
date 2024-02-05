#!/bin/bash
# Copyright (c) HashiCorp, Inc.
# SPDX-License-Identifier: MPL-2.0


set -e

DIR="$(cd "$(dirname "$0")" && pwd)/.."

function buildAndInstallDependencies {
  echo "Outputting Go Version.."
  go version

  echo "Installing the Data API V2 onto the GOBIN.."
  cd "${DIR}/tools/data-api"
  go install .
  cd "${DIR}"

  echo "Installing the Go SDK Generator into the GOBIN.."
  cd "${DIR}/tools/generator-go-sdk"
  go install .
  cd "${DIR}"

  echo "Building Wrapper.."
  cd "${DIR}/tools/wrapper-automation"
  go build -o wrapper-automation
  cd "${DIR}"
}

function runWrapper {
  local apiDefinitionsDirectory=$1
  local outputDirectory=$2

  echo "Running Wrapper.."
  cd "${DIR}/tools/wrapper-automation"
  ./wrapper-automation go-sdk \
    --api-definitions-dir="../../$apiDefinitionsDirectory"\
    --output-dir="../../$outputDirectory"

  cd "${DIR}"

  echo "Running 'make tools' within the SDK codebase.."
  cd "${outputDirectory}"
  make tools

  echo "Running 'make fmt' on the generated code.."
  make fmt

  echo "Running 'make imports' on the generated code.."
  make imports

  cd "${DIR}"
}

function runGoSDKUnitTests {
  local outputDirectory=$1

  cd "${DIR}"

  echo "Running 'make test' within the SDK codebase.."
  cd "${outputDirectory}"
  make test
}

function prepareGoSdk {
  local workingDirectory=$1
  local sdkRepo=$2

  echo "Removing any existing working directory.."
  cd "${DIR}"
  rm -rf "$workingDirectory"

  echo "Cloning SDK Repository into $workingDirectory.."
  git clone "$sdkRepo" "$workingDirectory"

  echo "Preparing the repository for generation"
  cd "${DIR}"
  cd "${workingDirectory}"
  make prepare

  cd "${DIR}"
}

function getSwaggerSubmoduleSha {
  local submodulePath=$1

  cd "${DIR}"
  cd "$submodulePath"
  git rev-parse --short HEAD
}

function cleanup {
  local outputDirectory=$1

  cd "${DIR}"
  echo "Removing temporary working directory $outputDirectory.."
  rm -rf "$outputDirectory"
}

function main {
  local apiDefinitionsDirectory="./api-definitions"
  local swaggerSubmodule="./submodules/rest-api-specs"
  local outputDirectory="tmp/go-azure-sdk"
  local sdkRepo="https://github.com/hashicorp/go-azure-sdk.git"
  local sha

  buildAndInstallDependencies
  sha=$(getSwaggerSubmoduleSha "$swaggerSubmodule")
  prepareGoSdk "$outputDirectory" "$sdkRepo"
  runWrapper "$apiDefinitionsDirectory" "$outputDirectory"
  runGoSDKUnitTests "$outputDirectory"
  cleanup "$outputDirectory"
}

main
