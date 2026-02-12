#!/bin/bash
# Copyright IBM Corp. 2021, 2025
# SPDX-License-Identifier: MPL-2.0


set -e

DIR="$(cd "$(dirname "$0")" && pwd)/.."

function buildAndInstallDependencies {
  echo "Outputting Go Version.."
  go version

  echo "Installing the Data API V2 onto the GOBIN"
  cd "${DIR}/tools/data-api"
  go install .
  cd "${DIR}"

  echo "Installing the Go SDK Generator into the GOBIN"
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

  echo "Running Wrapper for Resource Manager"
  cd "${DIR}/tools/wrapper-automation"
  ./wrapper-automation resource-manager go-sdk \
    --api-definitions-dir="../../$apiDefinitionsDirectory"\
    --output-dir="../../$outputDirectory"

  echo "Running Wrapper for Data Plane"
  cd "${DIR}/tools/wrapper-automation"
  ./wrapper-automation data-plane go-sdk \
    --api-definitions-dir="../../$apiDefinitionsDirectory"\
    --output-dir="../../$outputDirectory"

  echo "Running Wrapper for Microsoft Graph"
  cd "${DIR}/tools/wrapper-automation"
  ./wrapper-automation microsoft-graph go-sdk \
    --api-definitions-dir="../../$apiDefinitionsDirectory"\
    --output-dir="../../$outputDirectory"

  cd "${DIR}"

  echo "Running 'make tools' within the SDK codebase"
  cd "${outputDirectory}"
  make tools

  echo "Running 'make imports' on the generated code"
  make imports
}

function prepareGoSdk {
  local workingDirectory=$1
  local sdkRepo=$2

  echo "Removing any existing working directory"
  cd "${DIR}"
  rm -rf "$workingDirectory"

  echo "Cloning SDK Repository into $workingDirectory"
  git clone "$sdkRepo" "$workingDirectory"

  echo "Preparing the repository for generation"
  cd "${DIR}"
  cd "${workingDirectory}"
  make prepare

  cd "${DIR}"
}

function conditionallyCommitAndPushGoSdk {
  local workingDirectory=$1
  local sha=$2
  local branch="auto-pr/$sha"

  cd "${DIR}"
  cd "$workingDirectory"
  if [[ $(git status --porcelain | wc -l) -gt 0 ]]; then
    echo "Committing and Pushing the changes"

    # commit the generated changes
    git checkout -b "$branch"
    git config user.name "hc-github-team-tf-azure"
    git config user.email "<>"
    git add --all
    git commit -m "Updating based on $sha"

    # Microsoft Graph: conditional update of dependencies
    cd microsoft-graph/
    go mod tidy
    if [[ $(git status --porcelain | wc -l) -gt 0 ]]; then
      git add --all
      git commit -m "microsoft-graph: updating dependencies based on $sha"
    fi
    cd "${DIR}"
    cd "$workingDirectory"

    # Resource Manager: conditional update of dependencies
    cd resource-manager/
    go mod tidy
    if [[ $(git status --porcelain | wc -l) -gt 0 ]]; then
      git add --all
      git commit -m "resource-manager: updating dependencies based on $sha"
    fi

    # Data Plane: conditional update of dependencies
    cd data-plane/
    go mod tidy
    if [[ $(git status --porcelain | wc -l) -gt 0 ]]; then
      git add --all
      git commit -m "data-plane: updating dependencies based on $sha"
    fi

    # NOTE: we're intentionally force-pushing here in-case this PR is
    # open and other changes (e.g. to the generator) get included
    git push origin "$branch" -f
  else
    echo "No changes detected - skipping commit/push"
  fi
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
  local sdkRepo="git@github.com:hashicorp/go-azure-sdk.git"
  local sha

  buildAndInstallDependencies
  sha=$(getSwaggerSubmoduleSha "$swaggerSubmodule")
  prepareGoSdk "$outputDirectory" "$sdkRepo"
  runWrapper "$apiDefinitionsDirectory" "$outputDirectory"
  conditionallyCommitAndPushGoSdk "$outputDirectory" "$sha"
  cleanup "$outputDirectory"
}

main