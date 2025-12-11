#!/bin/bash
# Copyright IBM Corp. 2021, 2025
# SPDX-License-Identifier: MPL-2.0


set -e

DIR="$(cd "$(dirname "$0")" && pwd)/.."

function buildAndInstallDependencies {
  cd "${DIR}"

  echo "Building and Installing the Data API onto the GOPATH"
  cd ./tools/data-api
  go install
  cd "${DIR}"

  echo "Building and Installing the Data API Differ onto the GOPATH"
  cd ./tools/data-api-differ
  go install
  cd "${DIR}"
}

function checkoutAPIDefinitionsFromMainInto {
  local workingDirectory="$1"
  local existingPandoraDirectory="${DIR}"

  cd "${DIR}"

  echo "Fetching the current 'main'.."
  git fetch origin main

  # This is to enable running this script locally as well as in automation
  echo "Removing any temporary existing 'upstream-main' branch.."
  git branch -D upstream-main || true
  echo "Creating a temporary 'upstream-main' branch tracking 'origin/main'.."
  git branch upstream-main origin/main

  echo "Outputting the available branches.."
  git branch

  echo "Outputting git status.."
  git status

  echo "Removing any existing directory at ${workingDirectory}.."
  rm -rf "$workingDirectory"

  echo "Checking out a secondary copy of hashicorp/pandora from this repository.."
  git clone --depth 1 --branch upstream-main "file://$existingPandoraDirectory" "$workingDirectory"
  cd "$workingDirectory"

  echo "Resetting the secondary working directory"
  git reset --hard

  echo "Returning to the original working directory.."
  cd "${DIR}"
}

function ensureDirectoryExists {
  local directory="$1"

  echo "Removing any existing directory at ${directory}.."
  rm -rf "$directory"

  echo "Recreating the directory ${directory}"
  mkdir -p "${directory}"
}

function runBreakingChangeDetector {
  local initialApiDefinitionsDirectory="$1"
  local updatedApiDefinitionsDirectory="$2"
  local sourceDataType="$3"
  local outputFilePath="$4"

  echo "Detecting Breaking Changes between ${initialApiDefinitionsDirectory} and ${updatedApiDefinitionsDirectory}.."
  data-api-differ "${sourceDataType}" detect-breaking-changes --initial-path="${initialApiDefinitionsDirectory}" --updated-path="${updatedApiDefinitionsDirectory}" --output-file-path="${outputFilePath}"
}

function runChangeDetector {
  local initialApiDefinitionsDirectory="$1"
  local updatedApiDefinitionsDirectory="$2"
  local sourceDataType="$3"
  local outputFilePath="$4"

  echo "Detecting Changes between ${initialApiDefinitionsDirectory} and ${updatedApiDefinitionsDirectory}.."
  data-api-differ "${sourceDataType}" detect-changes --initial-path="${initialApiDefinitionsDirectory}" --updated-path="${updatedApiDefinitionsDirectory}" --output-file-path="${outputFilePath}"
}

function runStaticIdentifierDetector {
  local initialApiDefinitionsDirectory="$1"
  local updatedApiDefinitionsDirectory="$2"
  local sourceDataType="$3"
  local outputFilePath="$4"

  echo "Detecting any new Static Identifiers between ${initialApiDefinitionsDirectory} and ${updatedApiDefinitionsDirectory}.."
  data-api-differ "${sourceDataType}" output-resource-id-segments --initial-path="${initialApiDefinitionsDirectory}" --updated-path="${updatedApiDefinitionsDirectory}" --output-file-path="${outputFilePath}"
}

function main {
  local tempDirectory="./pandora-from-main"
  local initialApiDefinitionsDirectory="${tempDirectory}/api-definitions"
  local updatedApiDefinitionsDirectory="${DIR}/api-definitions"
  local sourceDataType="$1"
  local outputDirectory="$2"

  buildAndInstallDependencies
  checkoutAPIDefinitionsFromMainInto "$tempDirectory"
  ensureDirectoryExists "$outputDirectory"

  runBreakingChangeDetector "$initialApiDefinitionsDirectory" "$updatedApiDefinitionsDirectory" "$sourceDataType" "${outputDirectory}/resource-manager-breaking-changes.md"
  runChangeDetector "$initialApiDefinitionsDirectory" "$updatedApiDefinitionsDirectory" "$sourceDataType" "${outputDirectory}/resource-manager-changes.md"
  runStaticIdentifierDetector "$initialApiDefinitionsDirectory" "$updatedApiDefinitionsDirectory" "$sourceDataType" "${outputDirectory}/resource-manager-static-identifiers.md"
}

main "$1" "$2"
