using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataSourceLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    administratorId = table.Column<long>(type: "INTEGER", nullable: false),
                    identifier = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    NRIC = table.Column<string>(type: "TEXT", nullable: false),
                    fullName = table.Column<string>(type: "TEXT", nullable: false),
                    nationality = table.Column<string>(type: "TEXT", nullable: false),
                    phoneNumber = table.Column<long>(type: "INTEGER", nullable: false),
                    emailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    preferredNotificationPlatform = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.administratorId);
                    table.UniqueConstraint("AK_Administrator_emailAddress", x => x.emailAddress);
                });

            migrationBuilder.CreateTable(
                name: "Chatbot",
                columns: table => new
                {
                    chatId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    timestamp = table.Column<string>(type: "TEXT", nullable: false),
                    prompt = table.Column<string>(type: "TEXT", nullable: false),
                    response = table.Column<string>(type: "TEXT", nullable: false),
                    GPTAPIKeyId = table.Column<string>(type: "TEXT", nullable: false),
                    toggleGPT = table.Column<long>(type: "INTEGER", nullable: false),
                    userinput = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chatbot", x => x.chatId);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    doctorId = table.Column<long>(type: "INTEGER", nullable: false),
                    identifier = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    NRIC = table.Column<string>(type: "TEXT", nullable: false),
                    fullName = table.Column<string>(type: "TEXT", nullable: false),
                    nationality = table.Column<string>(type: "TEXT", nullable: false),
                    phoneNumber = table.Column<long>(type: "INTEGER", nullable: false),
                    emailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    preferredNotificationPlatform = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.doctorId);
                });

            migrationBuilder.CreateTable(
                name: "Documentation",
                columns: table => new
                {
                    documentationId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    safetyChecklist = table.Column<long>(type: "INTEGER", nullable: false),
                    patientId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentation", x => x.documentationId);
                });

            migrationBuilder.CreateTable(
                name: "DrugRecords",
                columns: table => new
                {
                    DrugRecordID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    patientId = table.Column<long>(type: "INTEGER", nullable: false),
                    DrugID = table.Column<long>(type: "INTEGER", nullable: false),
                    drugRecordDesc = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugRecords", x => x.DrugRecordID);
                });

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    drugId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    drugName = table.Column<string>(type: "TEXT", nullable: false),
                    drugInformation = table.Column<string>(type: "TEXT", nullable: false),
                    inventory = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.drugId);
                });

            migrationBuilder.CreateTable(
                name: "FollowUp Appointment Records",
                columns: table => new
                {
                    followUpAppointmentId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    followUpAppointmentDate = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowUp Appointment Records", x => x.followUpAppointmentId);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    messageId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    chatId = table.Column<long>(type: "INTEGER", nullable: false),
                    senderId = table.Column<long>(type: "INTEGER", nullable: false),
                    dialog = table.Column<string>(type: "TEXT", nullable: false),
                    timestamp = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.messageId);
                });

            migrationBuilder.CreateTable(
                name: "Nurse",
                columns: table => new
                {
                    nurseId = table.Column<long>(type: "INTEGER", nullable: false),
                    identifier = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    NRIC = table.Column<string>(type: "TEXT", nullable: false),
                    fullName = table.Column<string>(type: "TEXT", nullable: false),
                    nationality = table.Column<string>(type: "TEXT", nullable: false),
                    phoneNumber = table.Column<long>(type: "INTEGER", nullable: false),
                    emailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    preferredNotificationPlatform = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurse", x => x.nurseId);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    patientId = table.Column<long>(type: "INTEGER", nullable: false),
                    identifier = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    NRIC = table.Column<string>(type: "TEXT", nullable: false),
                    fullName = table.Column<string>(type: "TEXT", nullable: false),
                    nationality = table.Column<string>(type: "TEXT", nullable: false),
                    phoneNumber = table.Column<long>(type: "INTEGER", nullable: false),
                    emailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    preferredNotificationPlatform = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.patientId);
                });

            migrationBuilder.CreateTable(
                name: "Patient Caregiver",
                columns: table => new
                {
                    patientCaregiverId = table.Column<long>(type: "INTEGER", nullable: false),
                    identifier = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    NRIC = table.Column<string>(type: "TEXT", nullable: false),
                    fullName = table.Column<string>(type: "TEXT", nullable: false),
                    nationality = table.Column<string>(type: "TEXT", nullable: false),
                    phoneNumber = table.Column<long>(type: "INTEGER", nullable: false),
                    emailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    preferredNotificationPlatform = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient Caregiver", x => x.patientCaregiverId);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    photoId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    photoImage = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.photoId);
                });

            migrationBuilder.CreateTable(
                name: "Pre-discharge Service",
                columns: table => new
                {
                    serviceId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    serviceName = table.Column<string>(type: "TEXT", nullable: false),
                    serviceDescription = table.Column<string>(type: "TEXT", nullable: false),
                    serviceDuration = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pre-discharge Service", x => x.serviceId);
                });

            migrationBuilder.CreateTable(
                name: "Safety Checklist",
                columns: table => new
                {
                    safetyChecklistId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    locationCategory = table.Column<string>(type: "TEXT", nullable: false),
                    riskTitle = table.Column<string>(type: "TEXT", nullable: false),
                    riskDescription = table.Column<string>(type: "TEXT", nullable: false),
                    riskComment = table.Column<string>(type: "TEXT", nullable: false),
                    photoId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Safety Checklist", x => x.safetyChecklistId);
                });

            migrationBuilder.CreateTable(
                name: "Audit",
                columns: table => new
                {
                    actionId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    actionType = table.Column<string>(type: "TEXT", nullable: false),
                    actionPerformed = table.Column<string>(type: "TEXT", nullable: false),
                    actionTimestamp = table.Column<string>(type: "TEXT", nullable: false),
                    actionBy = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit", x => x.actionId);
                    table.ForeignKey(
                        name: "FK_Audit_Administrator_actionBy",
                        column: x => x.actionBy,
                        principalTable: "Administrator",
                        principalColumn: "administratorId");
                });

            migrationBuilder.CreateTable(
                name: "Notification Log",
                columns: table => new
                {
                    notifcationId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    notificationTopic = table.Column<string>(type: "TEXT", nullable: false),
                    notificationContent = table.Column<string>(type: "TEXT", nullable: false),
                    notificationStatus = table.Column<string>(type: "TEXT", nullable: false),
                    notificationType = table.Column<string>(type: "TEXT", nullable: false),
                    notifcationDateTime = table.Column<string>(type: "TEXT", nullable: false),
                    administratorEmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    administratorPreferredNotification = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification Log", x => x.notifcationId);
                    table.ForeignKey(
                        name: "FK_Notification Log_Administrator_administratorEmailAddress",
                        column: x => x.administratorEmailAddress,
                        principalTable: "Administrator",
                        principalColumn: "emailAddress");
                });

            migrationBuilder.CreateTable(
                name: "DrugDrugRecord",
                columns: table => new
                {
                    DrugRecordsDrugRecordID = table.Column<long>(type: "INTEGER", nullable: false),
                    DrugsDrugId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugDrugRecord", x => new { x.DrugRecordsDrugRecordID, x.DrugsDrugId });
                    table.ForeignKey(
                        name: "FK_DrugDrugRecord_DrugRecords_DrugRecordsDrugRecordID",
                        column: x => x.DrugRecordsDrugRecordID,
                        principalTable: "DrugRecords",
                        principalColumn: "DrugRecordID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrugDrugRecord_Drugs_DrugsDrugId",
                        column: x => x.DrugsDrugId,
                        principalTable: "Drugs",
                        principalColumn: "drugId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrugRecordDrugs",
                columns: table => new
                {
                    DrugRecordDrugID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DrugId = table.Column<long>(type: "INTEGER", nullable: false),
                    DrugRecordDescription = table.Column<string>(type: "TEXT", nullable: true),
                    PatientID = table.Column<long>(type: "INTEGER", nullable: false),
                    DrugRecordID = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugRecordDrugs", x => x.DrugRecordDrugID);
                    table.ForeignKey(
                        name: "FK_DrugRecordDrugs_DrugRecords_DrugRecordID",
                        column: x => x.DrugRecordID,
                        principalTable: "DrugRecords",
                        principalColumn: "DrugRecordID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrugRecordDrugs_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "drugId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medication Tracker",
                columns: table => new
                {
                    trackingId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    timesPerDay = table.Column<int>(type: "INTEGER", nullable: false),
                    beforeMeals = table.Column<bool>(type: "INTEGER", nullable: false),
                    day = table.Column<string>(type: "TEXT", nullable: false),
                    hasNotified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DrugId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medication Tracker", x => x.trackingId);
                    table.ForeignKey(
                        name: "FK_Medication Tracker_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "drugId");
                });

            migrationBuilder.CreateTable(
                name: "In-Patient History",
                columns: table => new
                {
                    inPatientId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    stayStartDate = table.Column<string>(type: "TEXT", nullable: false),
                    stayEndDate = table.Column<string>(type: "TEXT", nullable: false),
                    stayDuration = table.Column<long>(type: "INTEGER", nullable: false),
                    patientId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_In-Patient History", x => x.inPatientId);
                    table.ForeignKey(
                        name: "FK_In-Patient History_Patient_patientId",
                        column: x => x.patientId,
                        principalTable: "Patient",
                        principalColumn: "patientId");
                });

            migrationBuilder.CreateTable(
                name: "Medication Counselling",
                columns: table => new
                {
                    medicationCounsellingId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    medicationCounsellingChoice = table.Column<byte[]>(type: "NUMERIC", nullable: false),
                    medicationCounsellingDescription = table.Column<string>(type: "TEXT", nullable: false),
                    patientId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medication Counselling", x => x.medicationCounsellingId);
                    table.ForeignKey(
                        name: "FK_Medication Counselling_Patient_patientId",
                        column: x => x.patientId,
                        principalTable: "Patient",
                        principalColumn: "patientId");
                });

            migrationBuilder.CreateTable(
                name: "Patient Medical Plan",
                columns: table => new
                {
                    planId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    accountId = table.Column<long>(type: "INTEGER", nullable: false),
                    patientId = table.Column<long>(type: "INTEGER", nullable: false),
                    planNotes = table.Column<string>(type: "TEXT", nullable: false),
                    planStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    planEnd = table.Column<DateTime>(type: "TEXT", nullable: false),
                    trackPlan = table.Column<bool>(type: "INTEGER", nullable: false),
                    assignedByNurseId = table.Column<long>(type: "INTEGER", nullable: false),
                    DrugId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient Medical Plan", x => x.planId);
                    table.ForeignKey(
                        name: "FK_Patient Medical Plan_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "drugId");
                    table.ForeignKey(
                        name: "FK_Patient Medical Plan_Patient_patientId",
                        column: x => x.patientId,
                        principalTable: "Patient",
                        principalColumn: "patientId");
                });

            migrationBuilder.CreateTable(
                name: "Patient Medical Record",
                columns: table => new
                {
                    medicalRecordId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    medicationCurrent = table.Column<string>(type: "TEXT", nullable: false),
                    medicationPast = table.Column<string>(type: "TEXT", nullable: false),
                    diagnosisCurrent = table.Column<string>(type: "TEXT", nullable: false),
                    diagnosisPast = table.Column<string>(type: "TEXT", nullable: false),
                    immunizationStatus = table.Column<string>(type: "TEXT", nullable: false),
                    allergies = table.Column<string>(type: "TEXT", nullable: false),
                    erratum = table.Column<byte[]>(type: "BLOB", nullable: false),
                    healthImprovementProgress = table.Column<string>(type: "TEXT", nullable: false),
                    illnessName = table.Column<string>(type: "TEXT", nullable: false),
                    patientId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient Medical Record", x => x.medicalRecordId);
                    table.ForeignKey(
                        name: "FK_Patient Medical Record_Patient_patientId",
                        column: x => x.patientId,
                        principalTable: "Patient",
                        principalColumn: "patientId");
                });

            migrationBuilder.CreateTable(
                name: "Patient Caregiver Assignment",
                columns: table => new
                {
                    patientCaregiverAssignmentId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    timeAssigned = table.Column<string>(type: "TEXT", nullable: false),
                    patientId = table.Column<long>(type: "INTEGER", nullable: false),
                    patientCaregiverId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient Caregiver Assignment", x => x.patientCaregiverAssignmentId);
                    table.ForeignKey(
                        name: "FK_Patient Caregiver Assignment_Patient Caregiver_patientCaregiverId",
                        column: x => x.patientCaregiverId,
                        principalTable: "Patient Caregiver",
                        principalColumn: "patientCaregiverId");
                    table.ForeignKey(
                        name: "FK_Patient Caregiver Assignment_Patient_patientId",
                        column: x => x.patientId,
                        principalTable: "Patient",
                        principalColumn: "patientId");
                });

            migrationBuilder.CreateTable(
                name: "Safety Checklist Assessment",
                columns: table => new
                {
                    assessmentId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    patientHomeEnvPhotos = table.Column<byte[]>(type: "BLOB", nullable: false),
                    riskRating = table.Column<string>(type: "TEXT", nullable: false),
                    riskDescription = table.Column<string>(type: "TEXT", nullable: false),
                    patientCaregiverId = table.Column<long>(type: "INTEGER", nullable: false),
                    patientId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Safety Checklist Assessment", x => x.assessmentId);
                    table.ForeignKey(
                        name: "FK_Safety Checklist Assessment_Patient Caregiver_patientCaregiverId",
                        column: x => x.patientCaregiverId,
                        principalTable: "Patient Caregiver",
                        principalColumn: "patientCaregiverId");
                    table.ForeignKey(
                        name: "FK_Safety Checklist Assessment_Patient_patientId",
                        column: x => x.patientId,
                        principalTable: "Patient",
                        principalColumn: "patientId");
                });

            migrationBuilder.CreateTable(
                name: "Pre-discharge Service Assignment",
                columns: table => new
                {
                    assignmentId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    assignmentDate = table.Column<string>(type: "TEXT", nullable: false),
                    appointmentDate = table.Column<string>(type: "TEXT", nullable: false),
                    serviceId = table.Column<long>(type: "INTEGER", nullable: false),
                    patientId = table.Column<long>(type: "INTEGER", nullable: false),
                    doctorId = table.Column<long>(type: "INTEGER", nullable: false),
                    nurseId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pre-discharge Service Assignment", x => x.assignmentId);
                    table.ForeignKey(
                        name: "FK_Pre-discharge Service Assignment_Doctor_doctorId",
                        column: x => x.doctorId,
                        principalTable: "Doctor",
                        principalColumn: "doctorId");
                    table.ForeignKey(
                        name: "FK_Pre-discharge Service Assignment_Nurse_nurseId",
                        column: x => x.nurseId,
                        principalTable: "Nurse",
                        principalColumn: "nurseId");
                    table.ForeignKey(
                        name: "FK_Pre-discharge Service Assignment_Nurse_patientId",
                        column: x => x.patientId,
                        principalTable: "Nurse",
                        principalColumn: "nurseId");
                    table.ForeignKey(
                        name: "FK_Pre-discharge Service Assignment_Pre-discharge Service_serviceId",
                        column: x => x.serviceId,
                        principalTable: "Pre-discharge Service",
                        principalColumn: "serviceId");
                });

            migrationBuilder.CreateTable(
                name: "ConsumedDateTime",
                columns: table => new
                {
                    medicationTrackerId = table.Column<long>(type: "INTEGER", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumedDateTime", x => new { x.medicationTrackerId, x.DateTime });
                    table.ForeignKey(
                        name: "FK_ConsumedDateTime_Medication Tracker_medicationTrackerId",
                        column: x => x.medicationTrackerId,
                        principalTable: "Medication Tracker",
                        principalColumn: "trackingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discharge Records",
                columns: table => new
                {
                    dischargeId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    dischargeDate = table.Column<string>(type: "TEXT", nullable: false),
                    dischargeSummary = table.Column<string>(type: "TEXT", nullable: false),
                    followUpAppointmentId = table.Column<long>(type: "INTEGER", nullable: false),
                    medicalPlanId = table.Column<long>(type: "INTEGER", nullable: false),
                    documentationId = table.Column<long>(type: "INTEGER", nullable: false),
                    InPatientId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discharge Records", x => x.dischargeId);
                    table.ForeignKey(
                        name: "FK_Discharge Records_Documentation_documentationId",
                        column: x => x.documentationId,
                        principalTable: "Documentation",
                        principalColumn: "documentationId");
                    table.ForeignKey(
                        name: "FK_Discharge Records_FollowUp Appointment Records_followUpAppointmentId",
                        column: x => x.followUpAppointmentId,
                        principalTable: "FollowUp Appointment Records",
                        principalColumn: "followUpAppointmentId");
                    table.ForeignKey(
                        name: "FK_Discharge Records_In-Patient History_InPatientId",
                        column: x => x.InPatientId,
                        principalTable: "In-Patient History",
                        principalColumn: "inPatientId");
                    table.ForeignKey(
                        name: "FK_Discharge Records_Patient Medical Plan_medicalPlanId",
                        column: x => x.medicalPlanId,
                        principalTable: "Patient Medical Plan",
                        principalColumn: "planId");
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    DrugId = table.Column<long>(type: "INTEGER", nullable: false),
                    MedicationTrackerId = table.Column<long>(type: "INTEGER", nullable: false),
                    PatientMedicalPlanId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => new { x.DrugId, x.MedicationTrackerId, x.PatientMedicalPlanId });
                    table.ForeignKey(
                        name: "FK_Prescription_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "drugId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Medication Tracker_MedicationTrackerId",
                        column: x => x.MedicationTrackerId,
                        principalTable: "Medication Tracker",
                        principalColumn: "trackingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Patient Medical Plan_PatientMedicalPlanId",
                        column: x => x.PatientMedicalPlanId,
                        principalTable: "Patient Medical Plan",
                        principalColumn: "planId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pre-discharge Service Schedule",
                columns: table => new
                {
                    scheduleId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    appointmentDateTime = table.Column<string>(type: "TEXT", nullable: false),
                    assignmentStatus = table.Column<string>(type: "TEXT", nullable: false),
                    assignmentId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pre-discharge Service Schedule", x => x.scheduleId);
                    table.ForeignKey(
                        name: "FK_Pre-discharge Service Schedule_Pre-discharge Service Assignment_assignmentId",
                        column: x => x.assignmentId,
                        principalTable: "Pre-discharge Service Assignment",
                        principalColumn: "assignmentId");
                });

            migrationBuilder.CreateTable(
                name: "Pre-discharge Service Logs",
                columns: table => new
                {
                    serviceLogId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    postAppointmentNotes = table.Column<string>(type: "TEXT", nullable: false),
                    postAppointmentObservation = table.Column<string>(type: "TEXT", nullable: false),
                    scheduleId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pre-discharge Service Logs", x => x.serviceLogId);
                    table.ForeignKey(
                        name: "FK_Pre-discharge Service Logs_Pre-discharge Service Schedule_scheduleId",
                        column: x => x.scheduleId,
                        principalTable: "Pre-discharge Service Schedule",
                        principalColumn: "scheduleId");
                });

            migrationBuilder.CreateTable(
                name: "Reschedule Request",
                columns: table => new
                {
                    resceduleId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    appointmentDateTime = table.Column<string>(type: "TEXT", nullable: false),
                    requestStatus = table.Column<long>(type: "INTEGER", nullable: false),
                    rescheduleReason = table.Column<string>(type: "TEXT", nullable: false),
                    scheduleId = table.Column<long>(type: "INTEGER", nullable: false),
                    patientId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reschedule Request", x => x.resceduleId);
                    table.ForeignKey(
                        name: "FK_Reschedule Request_Patient_patientId",
                        column: x => x.patientId,
                        principalTable: "Patient",
                        principalColumn: "patientId");
                    table.ForeignKey(
                        name: "FK_Reschedule Request_Pre-discharge Service Schedule_scheduleId",
                        column: x => x.scheduleId,
                        principalTable: "Pre-discharge Service Schedule",
                        principalColumn: "scheduleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_administratorId",
                table: "Administrator",
                column: "administratorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_emailAddress",
                table: "Administrator",
                column: "emailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_identifier",
                table: "Administrator",
                column: "identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_NRIC",
                table: "Administrator",
                column: "NRIC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_phoneNumber",
                table: "Administrator",
                column: "phoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Audit_actionBy",
                table: "Audit",
                column: "actionBy");

            migrationBuilder.CreateIndex(
                name: "IX_Discharge Records_documentationId",
                table: "Discharge Records",
                column: "documentationId");

            migrationBuilder.CreateIndex(
                name: "IX_Discharge Records_followUpAppointmentId",
                table: "Discharge Records",
                column: "followUpAppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Discharge Records_InPatientId",
                table: "Discharge Records",
                column: "InPatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Discharge Records_medicalPlanId",
                table: "Discharge Records",
                column: "medicalPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_doctorId",
                table: "Doctor",
                column: "doctorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_emailAddress",
                table: "Doctor",
                column: "emailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_identifier",
                table: "Doctor",
                column: "identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_NRIC",
                table: "Doctor",
                column: "NRIC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_phoneNumber",
                table: "Doctor",
                column: "phoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DrugDrugRecord_DrugsDrugId",
                table: "DrugDrugRecord",
                column: "DrugsDrugId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugRecordDrugs_DrugId",
                table: "DrugRecordDrugs",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugRecordDrugs_DrugRecordID",
                table: "DrugRecordDrugs",
                column: "DrugRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_In-Patient History_patientId",
                table: "In-Patient History",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_Medication Counselling_patientId",
                table: "Medication Counselling",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_Medication Tracker_DrugId",
                table: "Medication Tracker",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification Log_administratorEmailAddress",
                table: "Notification Log",
                column: "administratorEmailAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Nurse_emailAddress",
                table: "Nurse",
                column: "emailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nurse_identifier",
                table: "Nurse",
                column: "identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nurse_NRIC",
                table: "Nurse",
                column: "NRIC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nurse_nurseId",
                table: "Nurse",
                column: "nurseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nurse_phoneNumber",
                table: "Nurse",
                column: "phoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_emailAddress",
                table: "Patient",
                column: "emailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_identifier",
                table: "Patient",
                column: "identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_NRIC",
                table: "Patient",
                column: "NRIC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_patientId",
                table: "Patient",
                column: "patientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_phoneNumber",
                table: "Patient",
                column: "phoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient Caregiver_emailAddress",
                table: "Patient Caregiver",
                column: "emailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient Caregiver_identifier",
                table: "Patient Caregiver",
                column: "identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient Caregiver_NRIC",
                table: "Patient Caregiver",
                column: "NRIC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient Caregiver_patientCaregiverId",
                table: "Patient Caregiver",
                column: "patientCaregiverId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient Caregiver_phoneNumber",
                table: "Patient Caregiver",
                column: "phoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient Caregiver Assignment_patientCaregiverId",
                table: "Patient Caregiver Assignment",
                column: "patientCaregiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient Caregiver Assignment_patientId",
                table: "Patient Caregiver Assignment",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient Medical Plan_DrugId",
                table: "Patient Medical Plan",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient Medical Plan_patientId",
                table: "Patient Medical Plan",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient Medical Record_patientId",
                table: "Patient Medical Record",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_Pre-discharge Service Assignment_doctorId",
                table: "Pre-discharge Service Assignment",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pre-discharge Service Assignment_nurseId",
                table: "Pre-discharge Service Assignment",
                column: "nurseId");

            migrationBuilder.CreateIndex(
                name: "IX_Pre-discharge Service Assignment_patientId",
                table: "Pre-discharge Service Assignment",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_Pre-discharge Service Assignment_serviceId",
                table: "Pre-discharge Service Assignment",
                column: "serviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Pre-discharge Service Logs_scheduleId",
                table: "Pre-discharge Service Logs",
                column: "scheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Pre-discharge Service Schedule_assignmentId",
                table: "Pre-discharge Service Schedule",
                column: "assignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_MedicationTrackerId",
                table: "Prescription",
                column: "MedicationTrackerId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_PatientMedicalPlanId",
                table: "Prescription",
                column: "PatientMedicalPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Reschedule Request_patientId",
                table: "Reschedule Request",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reschedule Request_scheduleId",
                table: "Reschedule Request",
                column: "scheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Safety Checklist Assessment_patientCaregiverId",
                table: "Safety Checklist Assessment",
                column: "patientCaregiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Safety Checklist Assessment_patientId",
                table: "Safety Checklist Assessment",
                column: "patientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audit");

            migrationBuilder.DropTable(
                name: "Chatbot");

            migrationBuilder.DropTable(
                name: "ConsumedDateTime");

            migrationBuilder.DropTable(
                name: "Discharge Records");

            migrationBuilder.DropTable(
                name: "DrugDrugRecord");

            migrationBuilder.DropTable(
                name: "DrugRecordDrugs");

            migrationBuilder.DropTable(
                name: "Medication Counselling");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Notification Log");

            migrationBuilder.DropTable(
                name: "Patient Caregiver Assignment");

            migrationBuilder.DropTable(
                name: "Patient Medical Record");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Pre-discharge Service Logs");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Reschedule Request");

            migrationBuilder.DropTable(
                name: "Safety Checklist");

            migrationBuilder.DropTable(
                name: "Safety Checklist Assessment");

            migrationBuilder.DropTable(
                name: "Documentation");

            migrationBuilder.DropTable(
                name: "FollowUp Appointment Records");

            migrationBuilder.DropTable(
                name: "In-Patient History");

            migrationBuilder.DropTable(
                name: "DrugRecords");

            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "Medication Tracker");

            migrationBuilder.DropTable(
                name: "Patient Medical Plan");

            migrationBuilder.DropTable(
                name: "Pre-discharge Service Schedule");

            migrationBuilder.DropTable(
                name: "Patient Caregiver");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Pre-discharge Service Assignment");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Nurse");

            migrationBuilder.DropTable(
                name: "Pre-discharge Service");
        }
    }
}
