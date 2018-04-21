CREATE TABLE [dbo].[tbl_PatientInsuranceAuthorizationScheduleTreatmentCycles] (
    [PatientInsuranceAuthorizationScheduleTreatmentCycleID] INT           IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [PatientInsuranceAuthorizationScheduleID]               INT           NOT NULL,
    [TreatmentCycleID]                                      INT           NOT NULL,
    [DateAdded]                                             SMALLDATETIME NULL,
    [RecActive]                                             TINYINT       NULL,
    [LastUpdatedBy]                                         INT           NULL,
    [LastUpdated]                                           SMALLDATETIME NULL,
    CONSTRAINT [PK_tbl_PatientInsuranceAuthorizationScheduleTreatmentCycles] PRIMARY KEY CLUSTERED ([PatientInsuranceAuthorizationScheduleTreatmentCycleID] ASC)
);

