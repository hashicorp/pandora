// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrinterProcessingStateDetailConstant
{
    [Description("Paused")]
    @paused,

    [Description("MediaJam")]
    @mediaJam,

    [Description("MediaNeeded")]
    @mediaNeeded,

    [Description("MediaLow")]
    @mediaLow,

    [Description("MediaEmpty")]
    @mediaEmpty,

    [Description("CoverOpen")]
    @coverOpen,

    [Description("InterlockOpen")]
    @interlockOpen,

    [Description("OutputTrayMissing")]
    @outputTrayMissing,

    [Description("OutputAreaFull")]
    @outputAreaFull,

    [Description("MarkerSupplyLow")]
    @markerSupplyLow,

    [Description("MarkerSupplyEmpty")]
    @markerSupplyEmpty,

    [Description("InputTrayMissing")]
    @inputTrayMissing,

    [Description("OutputAreaAlmostFull")]
    @outputAreaAlmostFull,

    [Description("MarkerWasteAlmostFull")]
    @markerWasteAlmostFull,

    [Description("MarkerWasteFull")]
    @markerWasteFull,

    [Description("FuserOverTemp")]
    @fuserOverTemp,

    [Description("FuserUnderTemp")]
    @fuserUnderTemp,

    [Description("Other")]
    @other,

    [Description("None")]
    @none,

    [Description("MovingToPaused")]
    @movingToPaused,

    [Description("Shutdown")]
    @shutdown,

    [Description("ConnectingToDevice")]
    @connectingToDevice,

    [Description("TimedOut")]
    @timedOut,

    [Description("Stopping")]
    @stopping,

    [Description("StoppedPartially")]
    @stoppedPartially,

    [Description("TonerLow")]
    @tonerLow,

    [Description("TonerEmpty")]
    @tonerEmpty,

    [Description("SpoolAreaFull")]
    @spoolAreaFull,

    [Description("DoorOpen")]
    @doorOpen,

    [Description("OpticalPhotoConductorNearEndOfLife")]
    @opticalPhotoConductorNearEndOfLife,

    [Description("OpticalPhotoConductorLifeOver")]
    @opticalPhotoConductorLifeOver,

    [Description("DeveloperLow")]
    @developerLow,

    [Description("DeveloperEmpty")]
    @developerEmpty,

    [Description("InterpreterResourceUnavailable")]
    @interpreterResourceUnavailable,

    [Description("AlertRemovalOfBinaryChangeEntry")]
    @alertRemovalOfBinaryChangeEntry,

    [Description("BanderAdded")]
    @banderAdded,

    [Description("BanderAlmostEmpty")]
    @banderAlmostEmpty,

    [Description("BanderAlmostFull")]
    @banderAlmostFull,

    [Description("BanderAtLimit")]
    @banderAtLimit,

    [Description("BanderClosed")]
    @banderClosed,

    [Description("BanderConfigurationChange")]
    @banderConfigurationChange,

    [Description("BanderCoverClosed")]
    @banderCoverClosed,

    [Description("BanderCoverOpen")]
    @banderCoverOpen,

    [Description("BanderEmpty")]
    @banderEmpty,

    [Description("BanderFull")]
    @banderFull,

    [Description("BanderInterlockClosed")]
    @banderInterlockClosed,

    [Description("BanderInterlockOpen")]
    @banderInterlockOpen,

    [Description("BanderJam")]
    @banderJam,

    [Description("BanderLifeAlmostOver")]
    @banderLifeAlmostOver,

    [Description("BanderLifeOver")]
    @banderLifeOver,

    [Description("BanderMemoryExhausted")]
    @banderMemoryExhausted,

    [Description("BanderMissing")]
    @banderMissing,

    [Description("BanderMotorFailure")]
    @banderMotorFailure,

    [Description("BanderNearLimit")]
    @banderNearLimit,

    [Description("BanderOffline")]
    @banderOffline,

    [Description("BanderOpened")]
    @banderOpened,

    [Description("BanderOverTemperature")]
    @banderOverTemperature,

    [Description("BanderPowerSaver")]
    @banderPowerSaver,

    [Description("BanderRecoverableFailure")]
    @banderRecoverableFailure,

    [Description("BanderRecoverableStorage")]
    @banderRecoverableStorage,

    [Description("BanderRemoved")]
    @banderRemoved,

    [Description("BanderResourceAdded")]
    @banderResourceAdded,

    [Description("BanderResourceRemoved")]
    @banderResourceRemoved,

    [Description("BanderThermistorFailure")]
    @banderThermistorFailure,

    [Description("BanderTimingFailure")]
    @banderTimingFailure,

    [Description("BanderTurnedOff")]
    @banderTurnedOff,

    [Description("BanderTurnedOn")]
    @banderTurnedOn,

    [Description("BanderUnderTemperature")]
    @banderUnderTemperature,

    [Description("BanderUnrecoverableFailure")]
    @banderUnrecoverableFailure,

    [Description("BanderUnrecoverableStorageError")]
    @banderUnrecoverableStorageError,

    [Description("BanderWarmingUp")]
    @banderWarmingUp,

    [Description("BinderAdded")]
    @binderAdded,

    [Description("BinderAlmostEmpty")]
    @binderAlmostEmpty,

    [Description("BinderAlmostFull")]
    @binderAlmostFull,

    [Description("BinderAtLimit")]
    @binderAtLimit,

    [Description("BinderClosed")]
    @binderClosed,

    [Description("BinderConfigurationChange")]
    @binderConfigurationChange,

    [Description("BinderCoverClosed")]
    @binderCoverClosed,

    [Description("BinderCoverOpen")]
    @binderCoverOpen,

    [Description("BinderEmpty")]
    @binderEmpty,

    [Description("BinderFull")]
    @binderFull,

    [Description("BinderInterlockClosed")]
    @binderInterlockClosed,

    [Description("BinderInterlockOpen")]
    @binderInterlockOpen,

    [Description("BinderJam")]
    @binderJam,

    [Description("BinderLifeAlmostOver")]
    @binderLifeAlmostOver,

    [Description("BinderLifeOver")]
    @binderLifeOver,

    [Description("BinderMemoryExhausted")]
    @binderMemoryExhausted,

    [Description("BinderMissing")]
    @binderMissing,

    [Description("BinderMotorFailure")]
    @binderMotorFailure,

    [Description("BinderNearLimit")]
    @binderNearLimit,

    [Description("BinderOffline")]
    @binderOffline,

    [Description("BinderOpened")]
    @binderOpened,

    [Description("BinderOverTemperature")]
    @binderOverTemperature,

    [Description("BinderPowerSaver")]
    @binderPowerSaver,

    [Description("BinderRecoverableFailure")]
    @binderRecoverableFailure,

    [Description("BinderRecoverableStorage")]
    @binderRecoverableStorage,

    [Description("BinderRemoved")]
    @binderRemoved,

    [Description("BinderResourceAdded")]
    @binderResourceAdded,

    [Description("BinderResourceRemoved")]
    @binderResourceRemoved,

    [Description("BinderThermistorFailure")]
    @binderThermistorFailure,

    [Description("BinderTimingFailure")]
    @binderTimingFailure,

    [Description("BinderTurnedOff")]
    @binderTurnedOff,

    [Description("BinderTurnedOn")]
    @binderTurnedOn,

    [Description("BinderUnderTemperature")]
    @binderUnderTemperature,

    [Description("BinderUnrecoverableFailure")]
    @binderUnrecoverableFailure,

    [Description("BinderUnrecoverableStorageError")]
    @binderUnrecoverableStorageError,

    [Description("BinderWarmingUp")]
    @binderWarmingUp,

    [Description("CameraFailure")]
    @cameraFailure,

    [Description("ChamberCooling")]
    @chamberCooling,

    [Description("ChamberFailure")]
    @chamberFailure,

    [Description("ChamberHeating")]
    @chamberHeating,

    [Description("ChamberTemperatureHigh")]
    @chamberTemperatureHigh,

    [Description("ChamberTemperatureLow")]
    @chamberTemperatureLow,

    [Description("CleanerLifeAlmostOver")]
    @cleanerLifeAlmostOver,

    [Description("CleanerLifeOver")]
    @cleanerLifeOver,

    [Description("ConfigurationChange")]
    @configurationChange,

    [Description("Deactivated")]
    @deactivated,

    [Description("Deleted")]
    @deleted,

    [Description("DieCutterAdded")]
    @dieCutterAdded,

    [Description("DieCutterAlmostEmpty")]
    @dieCutterAlmostEmpty,

    [Description("DieCutterAlmostFull")]
    @dieCutterAlmostFull,

    [Description("DieCutterAtLimit")]
    @dieCutterAtLimit,

    [Description("DieCutterClosed")]
    @dieCutterClosed,

    [Description("DieCutterConfigurationChange")]
    @dieCutterConfigurationChange,

    [Description("DieCutterCoverClosed")]
    @dieCutterCoverClosed,

    [Description("DieCutterCoverOpen")]
    @dieCutterCoverOpen,

    [Description("DieCutterEmpty")]
    @dieCutterEmpty,

    [Description("DieCutterFull")]
    @dieCutterFull,

    [Description("DieCutterInterlockClosed")]
    @dieCutterInterlockClosed,

    [Description("DieCutterInterlockOpen")]
    @dieCutterInterlockOpen,

    [Description("DieCutterJam")]
    @dieCutterJam,

    [Description("DieCutterLifeAlmostOver")]
    @dieCutterLifeAlmostOver,

    [Description("DieCutterLifeOver")]
    @dieCutterLifeOver,

    [Description("DieCutterMemoryExhausted")]
    @dieCutterMemoryExhausted,

    [Description("DieCutterMissing")]
    @dieCutterMissing,

    [Description("DieCutterMotorFailure")]
    @dieCutterMotorFailure,

    [Description("DieCutterNearLimit")]
    @dieCutterNearLimit,

    [Description("DieCutterOffline")]
    @dieCutterOffline,

    [Description("DieCutterOpened")]
    @dieCutterOpened,

    [Description("DieCutterOverTemperature")]
    @dieCutterOverTemperature,

    [Description("DieCutterPowerSaver")]
    @dieCutterPowerSaver,

    [Description("DieCutterRecoverableFailure")]
    @dieCutterRecoverableFailure,

    [Description("DieCutterRecoverableStorage")]
    @dieCutterRecoverableStorage,

    [Description("DieCutterRemoved")]
    @dieCutterRemoved,

    [Description("DieCutterResourceAdded")]
    @dieCutterResourceAdded,

    [Description("DieCutterResourceRemoved")]
    @dieCutterResourceRemoved,

    [Description("DieCutterThermistorFailure")]
    @dieCutterThermistorFailure,

    [Description("DieCutterTimingFailure")]
    @dieCutterTimingFailure,

    [Description("DieCutterTurnedOff")]
    @dieCutterTurnedOff,

    [Description("DieCutterTurnedOn")]
    @dieCutterTurnedOn,

    [Description("DieCutterUnderTemperature")]
    @dieCutterUnderTemperature,

    [Description("DieCutterUnrecoverableFailure")]
    @dieCutterUnrecoverableFailure,

    [Description("DieCutterUnrecoverableStorageError")]
    @dieCutterUnrecoverableStorageError,

    [Description("DieCutterWarmingUp")]
    @dieCutterWarmingUp,

    [Description("ExtruderCooling")]
    @extruderCooling,

    [Description("ExtruderFailure")]
    @extruderFailure,

    [Description("ExtruderHeating")]
    @extruderHeating,

    [Description("ExtruderJam")]
    @extruderJam,

    [Description("ExtruderTemperatureHigh")]
    @extruderTemperatureHigh,

    [Description("ExtruderTemperatureLow")]
    @extruderTemperatureLow,

    [Description("FanFailure")]
    @fanFailure,

    [Description("FaxModemLifeAlmostOver")]
    @faxModemLifeAlmostOver,

    [Description("FaxModemLifeOver")]
    @faxModemLifeOver,

    [Description("FaxModemMissing")]
    @faxModemMissing,

    [Description("FaxModemTurnedOff")]
    @faxModemTurnedOff,

    [Description("FaxModemTurnedOn")]
    @faxModemTurnedOn,

    [Description("FolderAdded")]
    @folderAdded,

    [Description("FolderAlmostEmpty")]
    @folderAlmostEmpty,

    [Description("FolderAlmostFull")]
    @folderAlmostFull,

    [Description("FolderAtLimit")]
    @folderAtLimit,

    [Description("FolderClosed")]
    @folderClosed,

    [Description("FolderConfigurationChange")]
    @folderConfigurationChange,

    [Description("FolderCoverClosed")]
    @folderCoverClosed,

    [Description("FolderCoverOpen")]
    @folderCoverOpen,

    [Description("FolderEmpty")]
    @folderEmpty,

    [Description("FolderFull")]
    @folderFull,

    [Description("FolderInterlockClosed")]
    @folderInterlockClosed,

    [Description("FolderInterlockOpen")]
    @folderInterlockOpen,

    [Description("FolderJam")]
    @folderJam,

    [Description("FolderLifeAlmostOver")]
    @folderLifeAlmostOver,

    [Description("FolderLifeOver")]
    @folderLifeOver,

    [Description("FolderMemoryExhausted")]
    @folderMemoryExhausted,

    [Description("FolderMissing")]
    @folderMissing,

    [Description("FolderMotorFailure")]
    @folderMotorFailure,

    [Description("FolderNearLimit")]
    @folderNearLimit,

    [Description("FolderOffline")]
    @folderOffline,

    [Description("FolderOpened")]
    @folderOpened,

    [Description("FolderOverTemperature")]
    @folderOverTemperature,

    [Description("FolderPowerSaver")]
    @folderPowerSaver,

    [Description("FolderRecoverableFailure")]
    @folderRecoverableFailure,

    [Description("FolderRecoverableStorage")]
    @folderRecoverableStorage,

    [Description("FolderRemoved")]
    @folderRemoved,

    [Description("FolderResourceAdded")]
    @folderResourceAdded,

    [Description("FolderResourceRemoved")]
    @folderResourceRemoved,

    [Description("FolderThermistorFailure")]
    @folderThermistorFailure,

    [Description("FolderTimingFailure")]
    @folderTimingFailure,

    [Description("FolderTurnedOff")]
    @folderTurnedOff,

    [Description("FolderTurnedOn")]
    @folderTurnedOn,

    [Description("FolderUnderTemperature")]
    @folderUnderTemperature,

    [Description("FolderUnrecoverableFailure")]
    @folderUnrecoverableFailure,

    [Description("FolderUnrecoverableStorageError")]
    @folderUnrecoverableStorageError,

    [Description("FolderWarmingUp")]
    @folderWarmingUp,

    [Description("Hibernate")]
    @hibernate,

    [Description("HoldNewJobs")]
    @holdNewJobs,

    [Description("IdentifyPrinterRequested")]
    @identifyPrinterRequested,

    [Description("ImprinterAdded")]
    @imprinterAdded,

    [Description("ImprinterAlmostEmpty")]
    @imprinterAlmostEmpty,

    [Description("ImprinterAlmostFull")]
    @imprinterAlmostFull,

    [Description("ImprinterAtLimit")]
    @imprinterAtLimit,

    [Description("ImprinterClosed")]
    @imprinterClosed,

    [Description("ImprinterConfigurationChange")]
    @imprinterConfigurationChange,

    [Description("ImprinterCoverClosed")]
    @imprinterCoverClosed,

    [Description("ImprinterCoverOpen")]
    @imprinterCoverOpen,

    [Description("ImprinterEmpty")]
    @imprinterEmpty,

    [Description("ImprinterFull")]
    @imprinterFull,

    [Description("ImprinterInterlockClosed")]
    @imprinterInterlockClosed,

    [Description("ImprinterInterlockOpen")]
    @imprinterInterlockOpen,

    [Description("ImprinterJam")]
    @imprinterJam,

    [Description("ImprinterLifeAlmostOver")]
    @imprinterLifeAlmostOver,

    [Description("ImprinterLifeOver")]
    @imprinterLifeOver,

    [Description("ImprinterMemoryExhausted")]
    @imprinterMemoryExhausted,

    [Description("ImprinterMissing")]
    @imprinterMissing,

    [Description("ImprinterMotorFailure")]
    @imprinterMotorFailure,

    [Description("ImprinterNearLimit")]
    @imprinterNearLimit,

    [Description("ImprinterOffline")]
    @imprinterOffline,

    [Description("ImprinterOpened")]
    @imprinterOpened,

    [Description("ImprinterOverTemperature")]
    @imprinterOverTemperature,

    [Description("ImprinterPowerSaver")]
    @imprinterPowerSaver,

    [Description("ImprinterRecoverableFailure")]
    @imprinterRecoverableFailure,

    [Description("ImprinterRecoverableStorage")]
    @imprinterRecoverableStorage,

    [Description("ImprinterRemoved")]
    @imprinterRemoved,

    [Description("ImprinterResourceAdded")]
    @imprinterResourceAdded,

    [Description("ImprinterResourceRemoved")]
    @imprinterResourceRemoved,

    [Description("ImprinterThermistorFailure")]
    @imprinterThermistorFailure,

    [Description("ImprinterTimingFailure")]
    @imprinterTimingFailure,

    [Description("ImprinterTurnedOff")]
    @imprinterTurnedOff,

    [Description("ImprinterTurnedOn")]
    @imprinterTurnedOn,

    [Description("ImprinterUnderTemperature")]
    @imprinterUnderTemperature,

    [Description("ImprinterUnrecoverableFailure")]
    @imprinterUnrecoverableFailure,

    [Description("ImprinterUnrecoverableStorageError")]
    @imprinterUnrecoverableStorageError,

    [Description("ImprinterWarmingUp")]
    @imprinterWarmingUp,

    [Description("InputCannotFeedSizeSelected")]
    @inputCannotFeedSizeSelected,

    [Description("InputManualInputRequest")]
    @inputManualInputRequest,

    [Description("InputMediaColorChange")]
    @inputMediaColorChange,

    [Description("InputMediaFormPartsChange")]
    @inputMediaFormPartsChange,

    [Description("InputMediaSizeChange")]
    @inputMediaSizeChange,

    [Description("InputMediaTrayFailure")]
    @inputMediaTrayFailure,

    [Description("InputMediaTrayFeedError")]
    @inputMediaTrayFeedError,

    [Description("InputMediaTrayJam")]
    @inputMediaTrayJam,

    [Description("InputMediaTypeChange")]
    @inputMediaTypeChange,

    [Description("InputMediaWeightChange")]
    @inputMediaWeightChange,

    [Description("InputPickRollerFailure")]
    @inputPickRollerFailure,

    [Description("InputPickRollerLifeOver")]
    @inputPickRollerLifeOver,

    [Description("InputPickRollerLifeWarn")]
    @inputPickRollerLifeWarn,

    [Description("InputPickRollerMissing")]
    @inputPickRollerMissing,

    [Description("InputTrayElevationFailure")]
    @inputTrayElevationFailure,

    [Description("InputTrayPositionFailure")]
    @inputTrayPositionFailure,

    [Description("InserterAdded")]
    @inserterAdded,

    [Description("InserterAlmostEmpty")]
    @inserterAlmostEmpty,

    [Description("InserterAlmostFull")]
    @inserterAlmostFull,

    [Description("InserterAtLimit")]
    @inserterAtLimit,

    [Description("InserterClosed")]
    @inserterClosed,

    [Description("InserterConfigurationChange")]
    @inserterConfigurationChange,

    [Description("InserterCoverClosed")]
    @inserterCoverClosed,

    [Description("InserterCoverOpen")]
    @inserterCoverOpen,

    [Description("InserterEmpty")]
    @inserterEmpty,

    [Description("InserterFull")]
    @inserterFull,

    [Description("InserterInterlockClosed")]
    @inserterInterlockClosed,

    [Description("InserterInterlockOpen")]
    @inserterInterlockOpen,

    [Description("InserterJam")]
    @inserterJam,

    [Description("InserterLifeAlmostOver")]
    @inserterLifeAlmostOver,

    [Description("InserterLifeOver")]
    @inserterLifeOver,

    [Description("InserterMemoryExhausted")]
    @inserterMemoryExhausted,

    [Description("InserterMissing")]
    @inserterMissing,

    [Description("InserterMotorFailure")]
    @inserterMotorFailure,

    [Description("InserterNearLimit")]
    @inserterNearLimit,

    [Description("InserterOffline")]
    @inserterOffline,

    [Description("InserterOpened")]
    @inserterOpened,

    [Description("InserterOverTemperature")]
    @inserterOverTemperature,

    [Description("InserterPowerSaver")]
    @inserterPowerSaver,

    [Description("InserterRecoverableFailure")]
    @inserterRecoverableFailure,

    [Description("InserterRecoverableStorage")]
    @inserterRecoverableStorage,

    [Description("InserterRemoved")]
    @inserterRemoved,

    [Description("InserterResourceAdded")]
    @inserterResourceAdded,

    [Description("InserterResourceRemoved")]
    @inserterResourceRemoved,

    [Description("InserterThermistorFailure")]
    @inserterThermistorFailure,

    [Description("InserterTimingFailure")]
    @inserterTimingFailure,

    [Description("InserterTurnedOff")]
    @inserterTurnedOff,

    [Description("InserterTurnedOn")]
    @inserterTurnedOn,

    [Description("InserterUnderTemperature")]
    @inserterUnderTemperature,

    [Description("InserterUnrecoverableFailure")]
    @inserterUnrecoverableFailure,

    [Description("InserterUnrecoverableStorageError")]
    @inserterUnrecoverableStorageError,

    [Description("InserterWarmingUp")]
    @inserterWarmingUp,

    [Description("InterlockClosed")]
    @interlockClosed,

    [Description("InterpreterCartridgeAdded")]
    @interpreterCartridgeAdded,

    [Description("InterpreterCartridgeDeleted")]
    @interpreterCartridgeDeleted,

    [Description("InterpreterComplexPageEncountered")]
    @interpreterComplexPageEncountered,

    [Description("InterpreterMemoryDecrease")]
    @interpreterMemoryDecrease,

    [Description("InterpreterMemoryIncrease")]
    @interpreterMemoryIncrease,

    [Description("InterpreterResourceAdded")]
    @interpreterResourceAdded,

    [Description("InterpreterResourceDeleted")]
    @interpreterResourceDeleted,

    [Description("LampAtEol")]
    @lampAtEol,

    [Description("LampFailure")]
    @lampFailure,

    [Description("LampNearEol")]
    @lampNearEol,

    [Description("LaserAtEol")]
    @laserAtEol,

    [Description("LaserFailure")]
    @laserFailure,

    [Description("LaserNearEol")]
    @laserNearEol,

    [Description("MakeEnvelopeAdded")]
    @makeEnvelopeAdded,

    [Description("MakeEnvelopeAlmostEmpty")]
    @makeEnvelopeAlmostEmpty,

    [Description("MakeEnvelopeAlmostFull")]
    @makeEnvelopeAlmostFull,

    [Description("MakeEnvelopeAtLimit")]
    @makeEnvelopeAtLimit,

    [Description("MakeEnvelopeClosed")]
    @makeEnvelopeClosed,

    [Description("MakeEnvelopeConfigurationChange")]
    @makeEnvelopeConfigurationChange,

    [Description("MakeEnvelopeCoverClosed")]
    @makeEnvelopeCoverClosed,

    [Description("MakeEnvelopeCoverOpen")]
    @makeEnvelopeCoverOpen,

    [Description("MakeEnvelopeEmpty")]
    @makeEnvelopeEmpty,

    [Description("MakeEnvelopeFull")]
    @makeEnvelopeFull,

    [Description("MakeEnvelopeInterlockClosed")]
    @makeEnvelopeInterlockClosed,

    [Description("MakeEnvelopeInterlockOpen")]
    @makeEnvelopeInterlockOpen,

    [Description("MakeEnvelopeJam")]
    @makeEnvelopeJam,

    [Description("MakeEnvelopeLifeAlmostOver")]
    @makeEnvelopeLifeAlmostOver,

    [Description("MakeEnvelopeLifeOver")]
    @makeEnvelopeLifeOver,

    [Description("MakeEnvelopeMemoryExhausted")]
    @makeEnvelopeMemoryExhausted,

    [Description("MakeEnvelopeMissing")]
    @makeEnvelopeMissing,

    [Description("MakeEnvelopeMotorFailure")]
    @makeEnvelopeMotorFailure,

    [Description("MakeEnvelopeNearLimit")]
    @makeEnvelopeNearLimit,

    [Description("MakeEnvelopeOffline")]
    @makeEnvelopeOffline,

    [Description("MakeEnvelopeOpened")]
    @makeEnvelopeOpened,

    [Description("MakeEnvelopeOverTemperature")]
    @makeEnvelopeOverTemperature,

    [Description("MakeEnvelopePowerSaver")]
    @makeEnvelopePowerSaver,

    [Description("MakeEnvelopeRecoverableFailure")]
    @makeEnvelopeRecoverableFailure,

    [Description("MakeEnvelopeRecoverableStorage")]
    @makeEnvelopeRecoverableStorage,

    [Description("MakeEnvelopeRemoved")]
    @makeEnvelopeRemoved,

    [Description("MakeEnvelopeResourceAdded")]
    @makeEnvelopeResourceAdded,

    [Description("MakeEnvelopeResourceRemoved")]
    @makeEnvelopeResourceRemoved,

    [Description("MakeEnvelopeThermistorFailure")]
    @makeEnvelopeThermistorFailure,

    [Description("MakeEnvelopeTimingFailure")]
    @makeEnvelopeTimingFailure,

    [Description("MakeEnvelopeTurnedOff")]
    @makeEnvelopeTurnedOff,

    [Description("MakeEnvelopeTurnedOn")]
    @makeEnvelopeTurnedOn,

    [Description("MakeEnvelopeUnderTemperature")]
    @makeEnvelopeUnderTemperature,

    [Description("MakeEnvelopeUnrecoverableFailure")]
    @makeEnvelopeUnrecoverableFailure,

    [Description("MakeEnvelopeUnrecoverableStorageError")]
    @makeEnvelopeUnrecoverableStorageError,

    [Description("MakeEnvelopeWarmingUp")]
    @makeEnvelopeWarmingUp,

    [Description("MarkerAdjustingPrintQuality")]
    @markerAdjustingPrintQuality,

    [Description("MarkerCleanerMissing")]
    @markerCleanerMissing,

    [Description("MarkerDeveloperAlmostEmpty")]
    @markerDeveloperAlmostEmpty,

    [Description("MarkerDeveloperEmpty")]
    @markerDeveloperEmpty,

    [Description("MarkerDeveloperMissing")]
    @markerDeveloperMissing,

    [Description("MarkerFuserMissing")]
    @markerFuserMissing,

    [Description("MarkerFuserThermistorFailure")]
    @markerFuserThermistorFailure,

    [Description("MarkerFuserTimingFailure")]
    @markerFuserTimingFailure,

    [Description("MarkerInkAlmostEmpty")]
    @markerInkAlmostEmpty,

    [Description("MarkerInkEmpty")]
    @markerInkEmpty,

    [Description("MarkerInkMissing")]
    @markerInkMissing,

    [Description("MarkerOpcMissing")]
    @markerOpcMissing,

    [Description("MarkerPrintRibbonAlmostEmpty")]
    @markerPrintRibbonAlmostEmpty,

    [Description("MarkerPrintRibbonEmpty")]
    @markerPrintRibbonEmpty,

    [Description("MarkerPrintRibbonMissing")]
    @markerPrintRibbonMissing,

    [Description("MarkerSupplyAlmostEmpty")]
    @markerSupplyAlmostEmpty,

    [Description("MarkerSupplyMissing")]
    @markerSupplyMissing,

    [Description("MarkerTonerCartridgeMissing")]
    @markerTonerCartridgeMissing,

    [Description("MarkerTonerMissing")]
    @markerTonerMissing,

    [Description("MarkerWasteInkReceptacleAlmostFull")]
    @markerWasteInkReceptacleAlmostFull,

    [Description("MarkerWasteInkReceptacleFull")]
    @markerWasteInkReceptacleFull,

    [Description("MarkerWasteInkReceptacleMissing")]
    @markerWasteInkReceptacleMissing,

    [Description("MarkerWasteMissing")]
    @markerWasteMissing,

    [Description("MarkerWasteTonerReceptacleAlmostFull")]
    @markerWasteTonerReceptacleAlmostFull,

    [Description("MarkerWasteTonerReceptacleFull")]
    @markerWasteTonerReceptacleFull,

    [Description("MarkerWasteTonerReceptacleMissing")]
    @markerWasteTonerReceptacleMissing,

    [Description("MaterialEmpty")]
    @materialEmpty,

    [Description("MaterialLow")]
    @materialLow,

    [Description("MaterialNeeded")]
    @materialNeeded,

    [Description("MediaDrying")]
    @mediaDrying,

    [Description("MediaPathCannotDuplexMediaSelected")]
    @mediaPathCannotDuplexMediaSelected,

    [Description("MediaPathFailure")]
    @mediaPathFailure,

    [Description("MediaPathInputEmpty")]
    @mediaPathInputEmpty,

    [Description("MediaPathInputFeedError")]
    @mediaPathInputFeedError,

    [Description("MediaPathInputJam")]
    @mediaPathInputJam,

    [Description("MediaPathInputRequest")]
    @mediaPathInputRequest,

    [Description("MediaPathJam")]
    @mediaPathJam,

    [Description("MediaPathMediaTrayAlmostFull")]
    @mediaPathMediaTrayAlmostFull,

    [Description("MediaPathMediaTrayFull")]
    @mediaPathMediaTrayFull,

    [Description("MediaPathMediaTrayMissing")]
    @mediaPathMediaTrayMissing,

    [Description("MediaPathOutputFeedError")]
    @mediaPathOutputFeedError,

    [Description("MediaPathOutputFull")]
    @mediaPathOutputFull,

    [Description("MediaPathOutputJam")]
    @mediaPathOutputJam,

    [Description("MediaPathPickRollerFailure")]
    @mediaPathPickRollerFailure,

    [Description("MediaPathPickRollerLifeOver")]
    @mediaPathPickRollerLifeOver,

    [Description("MediaPathPickRollerLifeWarn")]
    @mediaPathPickRollerLifeWarn,

    [Description("MediaPathPickRollerMissing")]
    @mediaPathPickRollerMissing,

    [Description("MotorFailure")]
    @motorFailure,

    [Description("OutputMailboxSelectFailure")]
    @outputMailboxSelectFailure,

    [Description("OutputMediaTrayFailure")]
    @outputMediaTrayFailure,

    [Description("OutputMediaTrayFeedError")]
    @outputMediaTrayFeedError,

    [Description("OutputMediaTrayJam")]
    @outputMediaTrayJam,

    [Description("PerforaterAdded")]
    @perforaterAdded,

    [Description("PerforaterAlmostEmpty")]
    @perforaterAlmostEmpty,

    [Description("PerforaterAlmostFull")]
    @perforaterAlmostFull,

    [Description("PerforaterAtLimit")]
    @perforaterAtLimit,

    [Description("PerforaterClosed")]
    @perforaterClosed,

    [Description("PerforaterConfigurationChange")]
    @perforaterConfigurationChange,

    [Description("PerforaterCoverClosed")]
    @perforaterCoverClosed,

    [Description("PerforaterCoverOpen")]
    @perforaterCoverOpen,

    [Description("PerforaterEmpty")]
    @perforaterEmpty,

    [Description("PerforaterFull")]
    @perforaterFull,

    [Description("PerforaterInterlockClosed")]
    @perforaterInterlockClosed,

    [Description("PerforaterInterlockOpen")]
    @perforaterInterlockOpen,

    [Description("PerforaterJam")]
    @perforaterJam,

    [Description("PerforaterLifeAlmostOver")]
    @perforaterLifeAlmostOver,

    [Description("PerforaterLifeOver")]
    @perforaterLifeOver,

    [Description("PerforaterMemoryExhausted")]
    @perforaterMemoryExhausted,

    [Description("PerforaterMissing")]
    @perforaterMissing,

    [Description("PerforaterMotorFailure")]
    @perforaterMotorFailure,

    [Description("PerforaterNearLimit")]
    @perforaterNearLimit,

    [Description("PerforaterOffline")]
    @perforaterOffline,

    [Description("PerforaterOpened")]
    @perforaterOpened,

    [Description("PerforaterOverTemperature")]
    @perforaterOverTemperature,

    [Description("PerforaterPowerSaver")]
    @perforaterPowerSaver,

    [Description("PerforaterRecoverableFailure")]
    @perforaterRecoverableFailure,

    [Description("PerforaterRecoverableStorage")]
    @perforaterRecoverableStorage,

    [Description("PerforaterRemoved")]
    @perforaterRemoved,

    [Description("PerforaterResourceAdded")]
    @perforaterResourceAdded,

    [Description("PerforaterResourceRemoved")]
    @perforaterResourceRemoved,

    [Description("PerforaterThermistorFailure")]
    @perforaterThermistorFailure,

    [Description("PerforaterTimingFailure")]
    @perforaterTimingFailure,

    [Description("PerforaterTurnedOff")]
    @perforaterTurnedOff,

    [Description("PerforaterTurnedOn")]
    @perforaterTurnedOn,

    [Description("PerforaterUnderTemperature")]
    @perforaterUnderTemperature,

    [Description("PerforaterUnrecoverableFailure")]
    @perforaterUnrecoverableFailure,

    [Description("PerforaterUnrecoverableStorageError")]
    @perforaterUnrecoverableStorageError,

    [Description("PerforaterWarmingUp")]
    @perforaterWarmingUp,

    [Description("PlatformCooling")]
    @platformCooling,

    [Description("PlatformFailure")]
    @platformFailure,

    [Description("PlatformHeating")]
    @platformHeating,

    [Description("PlatformTemperatureHigh")]
    @platformTemperatureHigh,

    [Description("PlatformTemperatureLow")]
    @platformTemperatureLow,

    [Description("PowerDown")]
    @powerDown,

    [Description("PowerUp")]
    @powerUp,

    [Description("PrinterManualReset")]
    @printerManualReset,

    [Description("PrinterNmsReset")]
    @printerNmsReset,

    [Description("PrinterReadyToPrint")]
    @printerReadyToPrint,

    [Description("PuncherAdded")]
    @puncherAdded,

    [Description("PuncherAlmostEmpty")]
    @puncherAlmostEmpty,

    [Description("PuncherAlmostFull")]
    @puncherAlmostFull,

    [Description("PuncherAtLimit")]
    @puncherAtLimit,

    [Description("PuncherClosed")]
    @puncherClosed,

    [Description("PuncherConfigurationChange")]
    @puncherConfigurationChange,

    [Description("PuncherCoverClosed")]
    @puncherCoverClosed,

    [Description("PuncherCoverOpen")]
    @puncherCoverOpen,

    [Description("PuncherEmpty")]
    @puncherEmpty,

    [Description("PuncherFull")]
    @puncherFull,

    [Description("PuncherInterlockClosed")]
    @puncherInterlockClosed,

    [Description("PuncherInterlockOpen")]
    @puncherInterlockOpen,

    [Description("PuncherJam")]
    @puncherJam,

    [Description("PuncherLifeAlmostOver")]
    @puncherLifeAlmostOver,

    [Description("PuncherLifeOver")]
    @puncherLifeOver,

    [Description("PuncherMemoryExhausted")]
    @puncherMemoryExhausted,

    [Description("PuncherMissing")]
    @puncherMissing,

    [Description("PuncherMotorFailure")]
    @puncherMotorFailure,

    [Description("PuncherNearLimit")]
    @puncherNearLimit,

    [Description("PuncherOffline")]
    @puncherOffline,

    [Description("PuncherOpened")]
    @puncherOpened,

    [Description("PuncherOverTemperature")]
    @puncherOverTemperature,

    [Description("PuncherPowerSaver")]
    @puncherPowerSaver,

    [Description("PuncherRecoverableFailure")]
    @puncherRecoverableFailure,

    [Description("PuncherRecoverableStorage")]
    @puncherRecoverableStorage,

    [Description("PuncherRemoved")]
    @puncherRemoved,

    [Description("PuncherResourceAdded")]
    @puncherResourceAdded,

    [Description("PuncherResourceRemoved")]
    @puncherResourceRemoved,

    [Description("PuncherThermistorFailure")]
    @puncherThermistorFailure,

    [Description("PuncherTimingFailure")]
    @puncherTimingFailure,

    [Description("PuncherTurnedOff")]
    @puncherTurnedOff,

    [Description("PuncherTurnedOn")]
    @puncherTurnedOn,

    [Description("PuncherUnderTemperature")]
    @puncherUnderTemperature,

    [Description("PuncherUnrecoverableFailure")]
    @puncherUnrecoverableFailure,

    [Description("PuncherUnrecoverableStorageError")]
    @puncherUnrecoverableStorageError,

    [Description("PuncherWarmingUp")]
    @puncherWarmingUp,

    [Description("Resuming")]
    @resuming,

    [Description("ScanMediaPathFailure")]
    @scanMediaPathFailure,

    [Description("ScanMediaPathInputEmpty")]
    @scanMediaPathInputEmpty,

    [Description("ScanMediaPathInputFeedError")]
    @scanMediaPathInputFeedError,

    [Description("ScanMediaPathInputJam")]
    @scanMediaPathInputJam,

    [Description("ScanMediaPathInputRequest")]
    @scanMediaPathInputRequest,

    [Description("ScanMediaPathJam")]
    @scanMediaPathJam,

    [Description("ScanMediaPathOutputFeedError")]
    @scanMediaPathOutputFeedError,

    [Description("ScanMediaPathOutputFull")]
    @scanMediaPathOutputFull,

    [Description("ScanMediaPathOutputJam")]
    @scanMediaPathOutputJam,

    [Description("ScanMediaPathPickRollerFailure")]
    @scanMediaPathPickRollerFailure,

    [Description("ScanMediaPathPickRollerLifeOver")]
    @scanMediaPathPickRollerLifeOver,

    [Description("ScanMediaPathPickRollerLifeWarn")]
    @scanMediaPathPickRollerLifeWarn,

    [Description("ScanMediaPathPickRollerMissing")]
    @scanMediaPathPickRollerMissing,

    [Description("ScanMediaPathTrayAlmostFull")]
    @scanMediaPathTrayAlmostFull,

    [Description("ScanMediaPathTrayFull")]
    @scanMediaPathTrayFull,

    [Description("ScanMediaPathTrayMissing")]
    @scanMediaPathTrayMissing,

    [Description("ScannerLightFailure")]
    @scannerLightFailure,

    [Description("ScannerLightLifeAlmostOver")]
    @scannerLightLifeAlmostOver,

    [Description("ScannerLightLifeOver")]
    @scannerLightLifeOver,

    [Description("ScannerLightMissing")]
    @scannerLightMissing,

    [Description("ScannerSensorFailure")]
    @scannerSensorFailure,

    [Description("ScannerSensorLifeAlmostOver")]
    @scannerSensorLifeAlmostOver,

    [Description("ScannerSensorLifeOver")]
    @scannerSensorLifeOver,

    [Description("ScannerSensorMissing")]
    @scannerSensorMissing,

    [Description("SeparationCutterAdded")]
    @separationCutterAdded,

    [Description("SeparationCutterAlmostEmpty")]
    @separationCutterAlmostEmpty,

    [Description("SeparationCutterAlmostFull")]
    @separationCutterAlmostFull,

    [Description("SeparationCutterAtLimit")]
    @separationCutterAtLimit,

    [Description("SeparationCutterClosed")]
    @separationCutterClosed,

    [Description("SeparationCutterConfigurationChange")]
    @separationCutterConfigurationChange,

    [Description("SeparationCutterCoverClosed")]
    @separationCutterCoverClosed,

    [Description("SeparationCutterCoverOpen")]
    @separationCutterCoverOpen,

    [Description("SeparationCutterEmpty")]
    @separationCutterEmpty,

    [Description("SeparationCutterFull")]
    @separationCutterFull,

    [Description("SeparationCutterInterlockClosed")]
    @separationCutterInterlockClosed,

    [Description("SeparationCutterInterlockOpen")]
    @separationCutterInterlockOpen,

    [Description("SeparationCutterJam")]
    @separationCutterJam,

    [Description("SeparationCutterLifeAlmostOver")]
    @separationCutterLifeAlmostOver,

    [Description("SeparationCutterLifeOver")]
    @separationCutterLifeOver,

    [Description("SeparationCutterMemoryExhausted")]
    @separationCutterMemoryExhausted,

    [Description("SeparationCutterMissing")]
    @separationCutterMissing,

    [Description("SeparationCutterMotorFailure")]
    @separationCutterMotorFailure,

    [Description("SeparationCutterNearLimit")]
    @separationCutterNearLimit,

    [Description("SeparationCutterOffline")]
    @separationCutterOffline,

    [Description("SeparationCutterOpened")]
    @separationCutterOpened,

    [Description("SeparationCutterOverTemperature")]
    @separationCutterOverTemperature,

    [Description("SeparationCutterPowerSaver")]
    @separationCutterPowerSaver,

    [Description("SeparationCutterRecoverableFailure")]
    @separationCutterRecoverableFailure,

    [Description("SeparationCutterRecoverableStorage")]
    @separationCutterRecoverableStorage,

    [Description("SeparationCutterRemoved")]
    @separationCutterRemoved,

    [Description("SeparationCutterResourceAdded")]
    @separationCutterResourceAdded,

    [Description("SeparationCutterResourceRemoved")]
    @separationCutterResourceRemoved,

    [Description("SeparationCutterThermistorFailure")]
    @separationCutterThermistorFailure,

    [Description("SeparationCutterTimingFailure")]
    @separationCutterTimingFailure,

    [Description("SeparationCutterTurnedOff")]
    @separationCutterTurnedOff,

    [Description("SeparationCutterTurnedOn")]
    @separationCutterTurnedOn,

    [Description("SeparationCutterUnderTemperature")]
    @separationCutterUnderTemperature,

    [Description("SeparationCutterUnrecoverableFailure")]
    @separationCutterUnrecoverableFailure,

    [Description("SeparationCutterUnrecoverableStorageError")]
    @separationCutterUnrecoverableStorageError,

    [Description("SeparationCutterWarmingUp")]
    @separationCutterWarmingUp,

    [Description("SheetRotatorAdded")]
    @sheetRotatorAdded,

    [Description("SheetRotatorAlmostEmpty")]
    @sheetRotatorAlmostEmpty,

    [Description("SheetRotatorAlmostFull")]
    @sheetRotatorAlmostFull,

    [Description("SheetRotatorAtLimit")]
    @sheetRotatorAtLimit,

    [Description("SheetRotatorClosed")]
    @sheetRotatorClosed,

    [Description("SheetRotatorConfigurationChange")]
    @sheetRotatorConfigurationChange,

    [Description("SheetRotatorCoverClosed")]
    @sheetRotatorCoverClosed,

    [Description("SheetRotatorCoverOpen")]
    @sheetRotatorCoverOpen,

    [Description("SheetRotatorEmpty")]
    @sheetRotatorEmpty,

    [Description("SheetRotatorFull")]
    @sheetRotatorFull,

    [Description("SheetRotatorInterlockClosed")]
    @sheetRotatorInterlockClosed,

    [Description("SheetRotatorInterlockOpen")]
    @sheetRotatorInterlockOpen,

    [Description("SheetRotatorJam")]
    @sheetRotatorJam,

    [Description("SheetRotatorLifeAlmostOver")]
    @sheetRotatorLifeAlmostOver,

    [Description("SheetRotatorLifeOver")]
    @sheetRotatorLifeOver,

    [Description("SheetRotatorMemoryExhausted")]
    @sheetRotatorMemoryExhausted,

    [Description("SheetRotatorMissing")]
    @sheetRotatorMissing,

    [Description("SheetRotatorMotorFailure")]
    @sheetRotatorMotorFailure,

    [Description("SheetRotatorNearLimit")]
    @sheetRotatorNearLimit,

    [Description("SheetRotatorOffline")]
    @sheetRotatorOffline,

    [Description("SheetRotatorOpened")]
    @sheetRotatorOpened,

    [Description("SheetRotatorOverTemperature")]
    @sheetRotatorOverTemperature,

    [Description("SheetRotatorPowerSaver")]
    @sheetRotatorPowerSaver,

    [Description("SheetRotatorRecoverableFailure")]
    @sheetRotatorRecoverableFailure,

    [Description("SheetRotatorRecoverableStorage")]
    @sheetRotatorRecoverableStorage,

    [Description("SheetRotatorRemoved")]
    @sheetRotatorRemoved,

    [Description("SheetRotatorResourceAdded")]
    @sheetRotatorResourceAdded,

    [Description("SheetRotatorResourceRemoved")]
    @sheetRotatorResourceRemoved,

    [Description("SheetRotatorThermistorFailure")]
    @sheetRotatorThermistorFailure,

    [Description("SheetRotatorTimingFailure")]
    @sheetRotatorTimingFailure,

    [Description("SheetRotatorTurnedOff")]
    @sheetRotatorTurnedOff,

    [Description("SheetRotatorTurnedOn")]
    @sheetRotatorTurnedOn,

    [Description("SheetRotatorUnderTemperature")]
    @sheetRotatorUnderTemperature,

    [Description("SheetRotatorUnrecoverableFailure")]
    @sheetRotatorUnrecoverableFailure,

    [Description("SheetRotatorUnrecoverableStorageError")]
    @sheetRotatorUnrecoverableStorageError,

    [Description("SheetRotatorWarmingUp")]
    @sheetRotatorWarmingUp,

    [Description("SlitterAdded")]
    @slitterAdded,

    [Description("SlitterAlmostEmpty")]
    @slitterAlmostEmpty,

    [Description("SlitterAlmostFull")]
    @slitterAlmostFull,

    [Description("SlitterAtLimit")]
    @slitterAtLimit,

    [Description("SlitterClosed")]
    @slitterClosed,

    [Description("SlitterConfigurationChange")]
    @slitterConfigurationChange,

    [Description("SlitterCoverClosed")]
    @slitterCoverClosed,

    [Description("SlitterCoverOpen")]
    @slitterCoverOpen,

    [Description("SlitterEmpty")]
    @slitterEmpty,

    [Description("SlitterFull")]
    @slitterFull,

    [Description("SlitterInterlockClosed")]
    @slitterInterlockClosed,

    [Description("SlitterInterlockOpen")]
    @slitterInterlockOpen,

    [Description("SlitterJam")]
    @slitterJam,

    [Description("SlitterLifeAlmostOver")]
    @slitterLifeAlmostOver,

    [Description("SlitterLifeOver")]
    @slitterLifeOver,

    [Description("SlitterMemoryExhausted")]
    @slitterMemoryExhausted,

    [Description("SlitterMissing")]
    @slitterMissing,

    [Description("SlitterMotorFailure")]
    @slitterMotorFailure,

    [Description("SlitterNearLimit")]
    @slitterNearLimit,

    [Description("SlitterOffline")]
    @slitterOffline,

    [Description("SlitterOpened")]
    @slitterOpened,

    [Description("SlitterOverTemperature")]
    @slitterOverTemperature,

    [Description("SlitterPowerSaver")]
    @slitterPowerSaver,

    [Description("SlitterRecoverableFailure")]
    @slitterRecoverableFailure,

    [Description("SlitterRecoverableStorage")]
    @slitterRecoverableStorage,

    [Description("SlitterRemoved")]
    @slitterRemoved,

    [Description("SlitterResourceAdded")]
    @slitterResourceAdded,

    [Description("SlitterResourceRemoved")]
    @slitterResourceRemoved,

    [Description("SlitterThermistorFailure")]
    @slitterThermistorFailure,

    [Description("SlitterTimingFailure")]
    @slitterTimingFailure,

    [Description("SlitterTurnedOff")]
    @slitterTurnedOff,

    [Description("SlitterTurnedOn")]
    @slitterTurnedOn,

    [Description("SlitterUnderTemperature")]
    @slitterUnderTemperature,

    [Description("SlitterUnrecoverableFailure")]
    @slitterUnrecoverableFailure,

    [Description("SlitterUnrecoverableStorageError")]
    @slitterUnrecoverableStorageError,

    [Description("SlitterWarmingUp")]
    @slitterWarmingUp,

    [Description("StackerAdded")]
    @stackerAdded,

    [Description("StackerAlmostEmpty")]
    @stackerAlmostEmpty,

    [Description("StackerAlmostFull")]
    @stackerAlmostFull,

    [Description("StackerAtLimit")]
    @stackerAtLimit,

    [Description("StackerClosed")]
    @stackerClosed,

    [Description("StackerConfigurationChange")]
    @stackerConfigurationChange,

    [Description("StackerCoverClosed")]
    @stackerCoverClosed,

    [Description("StackerCoverOpen")]
    @stackerCoverOpen,

    [Description("StackerEmpty")]
    @stackerEmpty,

    [Description("StackerFull")]
    @stackerFull,

    [Description("StackerInterlockClosed")]
    @stackerInterlockClosed,

    [Description("StackerInterlockOpen")]
    @stackerInterlockOpen,

    [Description("StackerJam")]
    @stackerJam,

    [Description("StackerLifeAlmostOver")]
    @stackerLifeAlmostOver,

    [Description("StackerLifeOver")]
    @stackerLifeOver,

    [Description("StackerMemoryExhausted")]
    @stackerMemoryExhausted,

    [Description("StackerMissing")]
    @stackerMissing,

    [Description("StackerMotorFailure")]
    @stackerMotorFailure,

    [Description("StackerNearLimit")]
    @stackerNearLimit,

    [Description("StackerOffline")]
    @stackerOffline,

    [Description("StackerOpened")]
    @stackerOpened,

    [Description("StackerOverTemperature")]
    @stackerOverTemperature,

    [Description("StackerPowerSaver")]
    @stackerPowerSaver,

    [Description("StackerRecoverableFailure")]
    @stackerRecoverableFailure,

    [Description("StackerRecoverableStorage")]
    @stackerRecoverableStorage,

    [Description("StackerRemoved")]
    @stackerRemoved,

    [Description("StackerResourceAdded")]
    @stackerResourceAdded,

    [Description("StackerResourceRemoved")]
    @stackerResourceRemoved,

    [Description("StackerThermistorFailure")]
    @stackerThermistorFailure,

    [Description("StackerTimingFailure")]
    @stackerTimingFailure,

    [Description("StackerTurnedOff")]
    @stackerTurnedOff,

    [Description("StackerTurnedOn")]
    @stackerTurnedOn,

    [Description("StackerUnderTemperature")]
    @stackerUnderTemperature,

    [Description("StackerUnrecoverableFailure")]
    @stackerUnrecoverableFailure,

    [Description("StackerUnrecoverableStorageError")]
    @stackerUnrecoverableStorageError,

    [Description("StackerWarmingUp")]
    @stackerWarmingUp,

    [Description("Standby")]
    @standby,

    [Description("StaplerAdded")]
    @staplerAdded,

    [Description("StaplerAlmostEmpty")]
    @staplerAlmostEmpty,

    [Description("StaplerAlmostFull")]
    @staplerAlmostFull,

    [Description("StaplerAtLimit")]
    @staplerAtLimit,

    [Description("StaplerClosed")]
    @staplerClosed,

    [Description("StaplerConfigurationChange")]
    @staplerConfigurationChange,

    [Description("StaplerCoverClosed")]
    @staplerCoverClosed,

    [Description("StaplerCoverOpen")]
    @staplerCoverOpen,

    [Description("StaplerEmpty")]
    @staplerEmpty,

    [Description("StaplerFull")]
    @staplerFull,

    [Description("StaplerInterlockClosed")]
    @staplerInterlockClosed,

    [Description("StaplerInterlockOpen")]
    @staplerInterlockOpen,

    [Description("StaplerJam")]
    @staplerJam,

    [Description("StaplerLifeAlmostOver")]
    @staplerLifeAlmostOver,

    [Description("StaplerLifeOver")]
    @staplerLifeOver,

    [Description("StaplerMemoryExhausted")]
    @staplerMemoryExhausted,

    [Description("StaplerMissing")]
    @staplerMissing,

    [Description("StaplerMotorFailure")]
    @staplerMotorFailure,

    [Description("StaplerNearLimit")]
    @staplerNearLimit,

    [Description("StaplerOffline")]
    @staplerOffline,

    [Description("StaplerOpened")]
    @staplerOpened,

    [Description("StaplerOverTemperature")]
    @staplerOverTemperature,

    [Description("StaplerPowerSaver")]
    @staplerPowerSaver,

    [Description("StaplerRecoverableFailure")]
    @staplerRecoverableFailure,

    [Description("StaplerRecoverableStorage")]
    @staplerRecoverableStorage,

    [Description("StaplerRemoved")]
    @staplerRemoved,

    [Description("StaplerResourceAdded")]
    @staplerResourceAdded,

    [Description("StaplerResourceRemoved")]
    @staplerResourceRemoved,

    [Description("StaplerThermistorFailure")]
    @staplerThermistorFailure,

    [Description("StaplerTimingFailure")]
    @staplerTimingFailure,

    [Description("StaplerTurnedOff")]
    @staplerTurnedOff,

    [Description("StaplerTurnedOn")]
    @staplerTurnedOn,

    [Description("StaplerUnderTemperature")]
    @staplerUnderTemperature,

    [Description("StaplerUnrecoverableFailure")]
    @staplerUnrecoverableFailure,

    [Description("StaplerUnrecoverableStorageError")]
    @staplerUnrecoverableStorageError,

    [Description("StaplerWarmingUp")]
    @staplerWarmingUp,

    [Description("StitcherAdded")]
    @stitcherAdded,

    [Description("StitcherAlmostEmpty")]
    @stitcherAlmostEmpty,

    [Description("StitcherAlmostFull")]
    @stitcherAlmostFull,

    [Description("StitcherAtLimit")]
    @stitcherAtLimit,

    [Description("StitcherClosed")]
    @stitcherClosed,

    [Description("StitcherConfigurationChange")]
    @stitcherConfigurationChange,

    [Description("StitcherCoverClosed")]
    @stitcherCoverClosed,

    [Description("StitcherCoverOpen")]
    @stitcherCoverOpen,

    [Description("StitcherEmpty")]
    @stitcherEmpty,

    [Description("StitcherFull")]
    @stitcherFull,

    [Description("StitcherInterlockClosed")]
    @stitcherInterlockClosed,

    [Description("StitcherInterlockOpen")]
    @stitcherInterlockOpen,

    [Description("StitcherJam")]
    @stitcherJam,

    [Description("StitcherLifeAlmostOver")]
    @stitcherLifeAlmostOver,

    [Description("StitcherLifeOver")]
    @stitcherLifeOver,

    [Description("StitcherMemoryExhausted")]
    @stitcherMemoryExhausted,

    [Description("StitcherMissing")]
    @stitcherMissing,

    [Description("StitcherMotorFailure")]
    @stitcherMotorFailure,

    [Description("StitcherNearLimit")]
    @stitcherNearLimit,

    [Description("StitcherOffline")]
    @stitcherOffline,

    [Description("StitcherOpened")]
    @stitcherOpened,

    [Description("StitcherOverTemperature")]
    @stitcherOverTemperature,

    [Description("StitcherPowerSaver")]
    @stitcherPowerSaver,

    [Description("StitcherRecoverableFailure")]
    @stitcherRecoverableFailure,

    [Description("StitcherRecoverableStorage")]
    @stitcherRecoverableStorage,

    [Description("StitcherRemoved")]
    @stitcherRemoved,

    [Description("StitcherResourceAdded")]
    @stitcherResourceAdded,

    [Description("StitcherResourceRemoved")]
    @stitcherResourceRemoved,

    [Description("StitcherThermistorFailure")]
    @stitcherThermistorFailure,

    [Description("StitcherTimingFailure")]
    @stitcherTimingFailure,

    [Description("StitcherTurnedOff")]
    @stitcherTurnedOff,

    [Description("StitcherTurnedOn")]
    @stitcherTurnedOn,

    [Description("StitcherUnderTemperature")]
    @stitcherUnderTemperature,

    [Description("StitcherUnrecoverableFailure")]
    @stitcherUnrecoverableFailure,

    [Description("StitcherUnrecoverableStorageError")]
    @stitcherUnrecoverableStorageError,

    [Description("StitcherWarmingUp")]
    @stitcherWarmingUp,

    [Description("SubunitAdded")]
    @subunitAdded,

    [Description("SubunitAlmostEmpty")]
    @subunitAlmostEmpty,

    [Description("SubunitAlmostFull")]
    @subunitAlmostFull,

    [Description("SubunitAtLimit")]
    @subunitAtLimit,

    [Description("SubunitClosed")]
    @subunitClosed,

    [Description("SubunitCoolingDown")]
    @subunitCoolingDown,

    [Description("SubunitEmpty")]
    @subunitEmpty,

    [Description("SubunitFull")]
    @subunitFull,

    [Description("SubunitLifeAlmostOver")]
    @subunitLifeAlmostOver,

    [Description("SubunitLifeOver")]
    @subunitLifeOver,

    [Description("SubunitMemoryExhausted")]
    @subunitMemoryExhausted,

    [Description("SubunitMissing")]
    @subunitMissing,

    [Description("SubunitMotorFailure")]
    @subunitMotorFailure,

    [Description("SubunitNearLimit")]
    @subunitNearLimit,

    [Description("SubunitOffline")]
    @subunitOffline,

    [Description("SubunitOpened")]
    @subunitOpened,

    [Description("SubunitOverTemperature")]
    @subunitOverTemperature,

    [Description("SubunitPowerSaver")]
    @subunitPowerSaver,

    [Description("SubunitRecoverableFailure")]
    @subunitRecoverableFailure,

    [Description("SubunitRecoverableStorage")]
    @subunitRecoverableStorage,

    [Description("SubunitRemoved")]
    @subunitRemoved,

    [Description("SubunitResourceAdded")]
    @subunitResourceAdded,

    [Description("SubunitResourceRemoved")]
    @subunitResourceRemoved,

    [Description("SubunitThermistorFailure")]
    @subunitThermistorFailure,

    [Description("SubunitTimingFailure")]
    @subunitTimingFailure,

    [Description("SubunitTurnedOff")]
    @subunitTurnedOff,

    [Description("SubunitTurnedOn")]
    @subunitTurnedOn,

    [Description("SubunitUnderTemperature")]
    @subunitUnderTemperature,

    [Description("SubunitUnrecoverableFailure")]
    @subunitUnrecoverableFailure,

    [Description("SubunitUnrecoverableStorage")]
    @subunitUnrecoverableStorage,

    [Description("SubunitWarmingUp")]
    @subunitWarmingUp,

    [Description("Suspend")]
    @suspend,

    [Description("Testing")]
    @testing,

    [Description("TrimmerAdded")]
    @trimmerAdded,

    [Description("TrimmerAlmostEmpty")]
    @trimmerAlmostEmpty,

    [Description("TrimmerAlmostFull")]
    @trimmerAlmostFull,

    [Description("TrimmerAtLimit")]
    @trimmerAtLimit,

    [Description("TrimmerClosed")]
    @trimmerClosed,

    [Description("TrimmerConfigurationChange")]
    @trimmerConfigurationChange,

    [Description("TrimmerCoverClosed")]
    @trimmerCoverClosed,

    [Description("TrimmerCoverOpen")]
    @trimmerCoverOpen,

    [Description("TrimmerEmpty")]
    @trimmerEmpty,

    [Description("TrimmerFull")]
    @trimmerFull,

    [Description("TrimmerInterlockClosed")]
    @trimmerInterlockClosed,

    [Description("TrimmerInterlockOpen")]
    @trimmerInterlockOpen,

    [Description("TrimmerJam")]
    @trimmerJam,

    [Description("TrimmerLifeAlmostOver")]
    @trimmerLifeAlmostOver,

    [Description("TrimmerLifeOver")]
    @trimmerLifeOver,

    [Description("TrimmerMemoryExhausted")]
    @trimmerMemoryExhausted,

    [Description("TrimmerMissing")]
    @trimmerMissing,

    [Description("TrimmerMotorFailure")]
    @trimmerMotorFailure,

    [Description("TrimmerNearLimit")]
    @trimmerNearLimit,

    [Description("TrimmerOffline")]
    @trimmerOffline,

    [Description("TrimmerOpened")]
    @trimmerOpened,

    [Description("TrimmerOverTemperature")]
    @trimmerOverTemperature,

    [Description("TrimmerPowerSaver")]
    @trimmerPowerSaver,

    [Description("TrimmerRecoverableFailure")]
    @trimmerRecoverableFailure,

    [Description("TrimmerRecoverableStorage")]
    @trimmerRecoverableStorage,

    [Description("TrimmerRemoved")]
    @trimmerRemoved,

    [Description("TrimmerResourceAdded")]
    @trimmerResourceAdded,

    [Description("TrimmerResourceRemoved")]
    @trimmerResourceRemoved,

    [Description("TrimmerThermistorFailure")]
    @trimmerThermistorFailure,

    [Description("TrimmerTimingFailure")]
    @trimmerTimingFailure,

    [Description("TrimmerTurnedOff")]
    @trimmerTurnedOff,

    [Description("TrimmerTurnedOn")]
    @trimmerTurnedOn,

    [Description("TrimmerUnderTemperature")]
    @trimmerUnderTemperature,

    [Description("TrimmerUnrecoverableFailure")]
    @trimmerUnrecoverableFailure,

    [Description("TrimmerUnrecoverableStorageError")]
    @trimmerUnrecoverableStorageError,

    [Description("TrimmerWarmingUp")]
    @trimmerWarmingUp,

    [Description("Unknown")]
    @unknown,

    [Description("WrapperAdded")]
    @wrapperAdded,

    [Description("WrapperAlmostEmpty")]
    @wrapperAlmostEmpty,

    [Description("WrapperAlmostFull")]
    @wrapperAlmostFull,

    [Description("WrapperAtLimit")]
    @wrapperAtLimit,

    [Description("WrapperClosed")]
    @wrapperClosed,

    [Description("WrapperConfigurationChange")]
    @wrapperConfigurationChange,

    [Description("WrapperCoverClosed")]
    @wrapperCoverClosed,

    [Description("WrapperCoverOpen")]
    @wrapperCoverOpen,

    [Description("WrapperEmpty")]
    @wrapperEmpty,

    [Description("WrapperFull")]
    @wrapperFull,

    [Description("WrapperInterlockClosed")]
    @wrapperInterlockClosed,

    [Description("WrapperInterlockOpen")]
    @wrapperInterlockOpen,

    [Description("WrapperJam")]
    @wrapperJam,

    [Description("WrapperLifeAlmostOver")]
    @wrapperLifeAlmostOver,

    [Description("WrapperLifeOver")]
    @wrapperLifeOver,

    [Description("WrapperMemoryExhausted")]
    @wrapperMemoryExhausted,

    [Description("WrapperMissing")]
    @wrapperMissing,

    [Description("WrapperMotorFailure")]
    @wrapperMotorFailure,

    [Description("WrapperNearLimit")]
    @wrapperNearLimit,

    [Description("WrapperOffline")]
    @wrapperOffline,

    [Description("WrapperOpened")]
    @wrapperOpened,

    [Description("WrapperOverTemperature")]
    @wrapperOverTemperature,

    [Description("WrapperPowerSaver")]
    @wrapperPowerSaver,

    [Description("WrapperRecoverableFailure")]
    @wrapperRecoverableFailure,

    [Description("WrapperRecoverableStorage")]
    @wrapperRecoverableStorage,

    [Description("WrapperRemoved")]
    @wrapperRemoved,

    [Description("WrapperResourceAdded")]
    @wrapperResourceAdded,

    [Description("WrapperResourceRemoved")]
    @wrapperResourceRemoved,

    [Description("WrapperThermistorFailure")]
    @wrapperThermistorFailure,

    [Description("WrapperTimingFailure")]
    @wrapperTimingFailure,

    [Description("WrapperTurnedOff")]
    @wrapperTurnedOff,

    [Description("WrapperTurnedOn")]
    @wrapperTurnedOn,

    [Description("WrapperUnderTemperature")]
    @wrapperUnderTemperature,

    [Description("WrapperUnrecoverableFailure")]
    @wrapperUnrecoverableFailure,

    [Description("WrapperUnrecoverableStorageError")]
    @wrapperUnrecoverableStorageError,

    [Description("WrapperWarmingUp")]
    @wrapperWarmingUp,
}
