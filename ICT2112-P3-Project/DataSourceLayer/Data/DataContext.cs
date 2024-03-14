using System;
using System.Collections.Generic;
using DomainLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataSourceLayer.Data;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Administrator> Administrators => Set<Administrator>();

    public virtual DbSet<Audit> Audits => Set<Audit>();

    public virtual DbSet<Chatbot> Chatbots => Set<Chatbot>();

    public virtual DbSet<DischargeRecord> DischargeRecords => Set<DischargeRecord>();

    public virtual DbSet<Doctor> Doctors => Set<Doctor>();

    public virtual DbSet<Documentation> Documentations => Set<Documentation>();

    public virtual DbSet<Drug> Drugs => Set<Drug>();

    public virtual DbSet<FollowUpAppointmentRecord> FollowUpAppointmentRecords => Set<FollowUpAppointmentRecord>();

    public virtual DbSet<InPatientHistory> InPatientHistories => Set<InPatientHistory>();

    public virtual DbSet<MedicationCounselling> MedicationCounsellings => Set<MedicationCounselling>();

    public virtual DbSet<Message> Messages => Set<Message>();

    public virtual DbSet<NotificationLog> NotificationLogs => Set<NotificationLog>();

    public virtual DbSet<Nurse> Nurses => Set<Nurse>();

    public virtual DbSet<Patient> Patients => Set<Patient>();

    public virtual DbSet<PatientCaregiver> PatientCaregivers => Set<PatientCaregiver>();

    public virtual DbSet<PatientCaregiverAssignment> PatientCaregiverAssignments => Set<PatientCaregiverAssignment>();

    public virtual DbSet<PatientMedicalPlan> PatientMedicalPlans => Set<PatientMedicalPlan>();

    public virtual DbSet<PatientMedicalRecord> PatientMedicalRecords => Set<PatientMedicalRecord>();

    public virtual DbSet<Photo> Photos => Set<Photo>();

    public virtual DbSet<PreDischargeService> PreDischargeServices => Set<PreDischargeService>();

    public virtual DbSet<PreDischargeServiceAssignment> PreDischargeServiceAssignments => Set<PreDischargeServiceAssignment>();

    public virtual DbSet<PreDischargeServiceLog> PreDischargeServiceLogs => Set<PreDischargeServiceLog>();

    public virtual DbSet<PreDischargeServiceSchedule> PreDischargeServiceSchedules => Set<PreDischargeServiceSchedule>();

    public virtual DbSet<RescheduleRequest> RescheduleRequests => Set<RescheduleRequest>();

    public virtual DbSet<SafetyChecklist> SafetyChecklists => Set<SafetyChecklist>();

    public virtual DbSet<SafetyChecklistAssessment> SafetyChecklistAssessments => Set<SafetyChecklistAssessment>();

    public virtual DbSet<MedicationTracker> MedicationTrackers => Set<MedicationTracker>();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("DataSource=..\\database.db;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.ToTable("Administrator");

            entity.HasIndex(e => e.AdministratorId, "IX_Administrator_administratorId").IsUnique();

            entity.HasIndex(e => e.EmailAddress, "IX_Administrator_emailAddress").IsUnique();

            entity.HasIndex(e => e.Identifier, "IX_Administrator_identifier").IsUnique();

            entity.HasIndex(e => e.Nric, "IX_Administrator_NRIC").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "IX_Administrator_phoneNumber").IsUnique();

            entity.Property(e => e.AdministratorId)
                .ValueGeneratedNever()
                .HasColumnName("administratorId");
            entity.Property(e => e.EmailAddress).HasColumnName("emailAddress");
            entity.Property(e => e.FullName).HasColumnName("fullName");
            entity.Property(e => e.Identifier).HasColumnName("identifier");
            entity.Property(e => e.Nationality).HasColumnName("nationality");
            entity.Property(e => e.Nric).HasColumnName("NRIC");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");
            entity.Property(e => e.PreferredNotificationPlatform).HasColumnName("preferredNotificationPlatform");
        });

        modelBuilder.Entity<Audit>(entity =>
        {
            entity.HasKey(e => e.ActionId);

            entity.ToTable("Audit");

            entity.Property(e => e.ActionId).HasColumnName("actionId");
            entity.Property(e => e.ActionBy).HasColumnName("actionBy");
            entity.Property(e => e.ActionPerformed).HasColumnName("actionPerformed");
            entity.Property(e => e.ActionTimestamp).HasColumnName("actionTimestamp");
            entity.Property(e => e.ActionType).HasColumnName("actionType");

            entity.HasOne(d => d.ActionByNavigation).WithMany(p => p.Audits)
                .HasForeignKey(d => d.ActionBy)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Chatbot>(entity =>
        {
            entity.HasKey(e => e.ChatId);

            entity.ToTable("Chatbot");

            entity.Property(e => e.ChatId).HasColumnName("chatId");
            entity.Property(e => e.GptapikeyId).HasColumnName("GPTAPIKeyId");
            entity.Property(e => e.Prompt).HasColumnName("prompt");
            entity.Property(e => e.Response).HasColumnName("response");
            entity.Property(e => e.Timestamp).HasColumnName("timestamp");
            entity.Property(e => e.ToggleGpt).HasColumnName("toggleGPT");
            entity.Property(e => e.Userinput).HasColumnName("userinput");
        });

        modelBuilder.Entity<DischargeRecord>(entity =>
        {
            entity.HasKey(e => e.DischargeId);

            entity.ToTable("Discharge Records");

            entity.Property(e => e.DischargeId).HasColumnName("dischargeId");
            entity.Property(e => e.DischargeDate).HasColumnName("dischargeDate");
            entity.Property(e => e.DischargeSummary).HasColumnName("dischargeSummary");
            entity.Property(e => e.DocumentationId).HasColumnName("documentationId");
            entity.Property(e => e.FollowUpAppointmentId).HasColumnName("followUpAppointmentId");
            entity.Property(e => e.MedicalPlanId).HasColumnName("medicalPlanId");

            entity.HasOne(d => d.Documentation).WithMany(p => p.DischargeRecords)
                .HasForeignKey(d => d.DocumentationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.FollowUpAppointment).WithMany(p => p.DischargeRecords)
                .HasForeignKey(d => d.FollowUpAppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.InPatient).WithMany(p => p.DischargeRecords)
                .HasForeignKey(d => d.InPatientId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.MedicalPlan).WithMany(p => p.DischargeRecords)
                .HasForeignKey(d => d.MedicalPlanId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.ToTable("Doctor");

            entity.HasIndex(e => e.DoctorId, "IX_Doctor_doctorId").IsUnique();

            entity.HasIndex(e => e.EmailAddress, "IX_Doctor_emailAddress").IsUnique();

            entity.HasIndex(e => e.Identifier, "IX_Doctor_identifier").IsUnique();

            entity.HasIndex(e => e.Nric, "IX_Doctor_NRIC").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "IX_Doctor_phoneNumber").IsUnique();

            entity.Property(e => e.DoctorId)
                .ValueGeneratedNever()
                .HasColumnName("doctorId");
            entity.Property(e => e.EmailAddress).HasColumnName("emailAddress");
            entity.Property(e => e.FullName).HasColumnName("fullName");
            entity.Property(e => e.Identifier).HasColumnName("identifier");
            entity.Property(e => e.Nationality).HasColumnName("nationality");
            entity.Property(e => e.Nric).HasColumnName("NRIC");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");
            entity.Property(e => e.PreferredNotificationPlatform).HasColumnName("preferredNotificationPlatform");
        });

        modelBuilder.Entity<Documentation>(entity =>
        {
            entity.ToTable("Documentation");

            entity.Property(e => e.DocumentationId).HasColumnName("documentationId");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.SafetyChecklist).HasColumnName("safetyChecklist");
        });

        modelBuilder.Entity<Drug>(entity =>
        {
            entity.Property(e => e.DrugId).HasColumnName("drugId");
            entity.Property(e => e.DrugInformation).HasColumnName("drugInformation");
            entity.Property(e => e.DrugName).HasColumnName("drugName");
            entity.Property(e => e.Inventory).HasColumnName("inventory");
        });

        modelBuilder.Entity<FollowUpAppointmentRecord>(entity =>
        {
            entity.HasKey(e => e.FollowUpAppointmentId);

            entity.ToTable("FollowUp Appointment Records");

            entity.Property(e => e.FollowUpAppointmentId).HasColumnName("followUpAppointmentId");
            entity.Property(e => e.FollowUpAppointmentDate).HasColumnName("followUpAppointmentDate");
        });

        modelBuilder.Entity<InPatientHistory>(entity =>
        {
            entity.HasKey(e => e.InPatientId);

            entity.ToTable("In-Patient History");

            entity.Property(e => e.InPatientId).HasColumnName("inPatientId");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.StayDuration).HasColumnName("stayDuration");
            entity.Property(e => e.StayEndDate).HasColumnName("stayEndDate");
            entity.Property(e => e.StayStartDate).HasColumnName("stayStartDate");

            entity.HasOne(d => d.Patient).WithMany(p => p.InPatientHistories)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<MedicationCounselling>(entity =>
        {
            entity.ToTable("Medication Counselling");

            entity.Property(e => e.MedicationCounsellingId).HasColumnName("medicationCounsellingId");
            entity.Property(e => e.MedicationCounsellingChoice)
                .HasColumnType("NUMERIC")
                .HasColumnName("medicationCounsellingChoice");
            entity.Property(e => e.MedicationCounsellingDescription).HasColumnName("medicationCounsellingDescription");
            entity.Property(e => e.PatientId).HasColumnName("patientId");

            entity.HasOne(d => d.Patient).WithMany(p => p.MedicationCounsellings)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.Property(e => e.MessageId).HasColumnName("messageId");
            entity.Property(e => e.ChatId).HasColumnName("chatId");
            entity.Property(e => e.Dialog).HasColumnName("dialog");
            entity.Property(e => e.SenderId).HasColumnName("senderId");
            entity.Property(e => e.Timestamp).HasColumnName("timestamp");
        });

        modelBuilder.Entity<NotificationLog>(entity =>
        {
            entity.HasKey(e => e.NotifcationId);

            entity.ToTable("Notification Log");

            entity.Property(e => e.NotifcationId).HasColumnName("notifcationId");
            entity.Property(e => e.AdministratorEmailAddress).HasColumnName("administratorEmailAddress");
            entity.Property(e => e.AdministratorPreferredNotification).HasColumnName("administratorPreferredNotification");
            entity.Property(e => e.NotifcationDateTime).HasColumnName("notifcationDateTime");
            entity.Property(e => e.NotificationContent).HasColumnName("notificationContent");
            entity.Property(e => e.NotificationStatus).HasColumnName("notificationStatus");
            entity.Property(e => e.NotificationTopic).HasColumnName("notificationTopic");
            entity.Property(e => e.NotificationType).HasColumnName("notificationType");

            entity.HasOne(d => d.AdministratorEmailAddressNavigation).WithMany(p => p.NotificationLogs)
                .HasPrincipalKey(p => p.EmailAddress)
                .HasForeignKey(d => d.AdministratorEmailAddress)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Nurse>(entity =>
        {
            entity.ToTable("Nurse");

            entity.HasIndex(e => e.EmailAddress, "IX_Nurse_emailAddress").IsUnique();

            entity.HasIndex(e => e.Identifier, "IX_Nurse_identifier").IsUnique();

            entity.HasIndex(e => e.Nric, "IX_Nurse_NRIC").IsUnique();

            entity.HasIndex(e => e.NurseId, "IX_Nurse_nurseId").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "IX_Nurse_phoneNumber").IsUnique();

            entity.Property(e => e.NurseId)
                .ValueGeneratedNever()
                .HasColumnName("nurseId");
            entity.Property(e => e.EmailAddress).HasColumnName("emailAddress");
            entity.Property(e => e.FullName).HasColumnName("fullName");
            entity.Property(e => e.Identifier).HasColumnName("identifier");
            entity.Property(e => e.Nationality).HasColumnName("nationality");
            entity.Property(e => e.Nric).HasColumnName("NRIC");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");
            entity.Property(e => e.PreferredNotificationPlatform).HasColumnName("preferredNotificationPlatform");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("Patient");

            entity.HasIndex(e => e.EmailAddress, "IX_Patient_emailAddress").IsUnique();

            entity.HasIndex(e => e.Identifier, "IX_Patient_identifier").IsUnique();

            entity.HasIndex(e => e.Nric, "IX_Patient_NRIC").IsUnique();

            entity.HasIndex(e => e.PatientId, "IX_Patient_patientId").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "IX_Patient_phoneNumber").IsUnique();

            entity.Property(e => e.PatientId)
                .ValueGeneratedNever()
                .HasColumnName("patientId");
            entity.Property(e => e.EmailAddress).HasColumnName("emailAddress");
            entity.Property(e => e.FullName).HasColumnName("fullName");
            entity.Property(e => e.Identifier).HasColumnName("identifier");
            entity.Property(e => e.Nationality).HasColumnName("nationality");
            entity.Property(e => e.Nric).HasColumnName("NRIC");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");
            entity.Property(e => e.PreferredNotificationPlatform).HasColumnName("preferredNotificationPlatform");
        });

        modelBuilder.Entity<PatientCaregiver>(entity =>
        {
            entity.ToTable("Patient Caregiver");

            entity.HasIndex(e => e.EmailAddress, "IX_Patient Caregiver_emailAddress").IsUnique();

            entity.HasIndex(e => e.Identifier, "IX_Patient Caregiver_identifier").IsUnique();

            entity.HasIndex(e => e.Nric, "IX_Patient Caregiver_NRIC").IsUnique();

            entity.HasIndex(e => e.PatientCaregiverId, "IX_Patient Caregiver_patientCaregiverId").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "IX_Patient Caregiver_phoneNumber").IsUnique();

            entity.Property(e => e.PatientCaregiverId)
                .ValueGeneratedNever()
                .HasColumnName("patientCaregiverId");
            entity.Property(e => e.EmailAddress).HasColumnName("emailAddress");
            entity.Property(e => e.FullName).HasColumnName("fullName");
            entity.Property(e => e.Identifier).HasColumnName("identifier");
            entity.Property(e => e.Nationality).HasColumnName("nationality");
            entity.Property(e => e.Nric).HasColumnName("NRIC");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");
            entity.Property(e => e.PreferredNotificationPlatform).HasColumnName("preferredNotificationPlatform");
        });

        modelBuilder.Entity<PatientCaregiverAssignment>(entity =>
        {
            entity.ToTable("Patient Caregiver Assignment");

            entity.Property(e => e.PatientCaregiverAssignmentId).HasColumnName("patientCaregiverAssignmentId");
            entity.Property(e => e.PatientCaregiverId).HasColumnName("patientCaregiverId");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.TimeAssigned).HasColumnName("timeAssigned");

            entity.HasOne(d => d.PatientCaregiver).WithMany(p => p.PatientCaregiverAssignments)
                .HasForeignKey(d => d.PatientCaregiverId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Patient).WithMany(p => p.PatientCaregiverAssignments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PatientMedicalPlan>(entity =>
        {
            entity.HasKey(e => e.PlanId);

            entity.ToTable("Patient Medical Plan");

            entity.Property(e => e.PlanId).HasColumnName("planId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.PlanNotes).HasColumnName("planNotes");
            entity.Property(e => e.PlanStart).HasColumnName("planStart");
            entity.Property(e => e.PlanEnd).HasColumnName("planEnd");
            entity.Property(e => e.TrackPlan).HasColumnName("trackPlan");
            entity.Property(e => e.AssignedByNurseId).HasColumnName("assignedByNurseId");

            entity.HasOne(d => d.Patient).WithMany(p => p.PatientMedicalPlans)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(p => new { p.DrugId, p.MedicationTrackerId, p.PatientMedicalPlanId }); // Composite key, if there's no unique PrescriptionId

            entity.HasOne(p => p.Drug)
                  .WithMany(d => d.Prescriptions)
                  .HasForeignKey(p => p.DrugId);

            entity.HasOne(p => p.MedicationTracker)
                  .WithMany(mt => mt.Prescriptions)
                  .HasForeignKey(p => p.MedicationTrackerId);

            entity.HasOne(p => p.PatientMedicalPlan)
                  .WithMany(mp => mp.Prescriptions)
                  .HasForeignKey(p => p.PatientMedicalPlanId);
        });

        modelBuilder.Entity<MedicationTracker>(entity =>
        {
            entity.HasKey(mt => mt.TrackingId);

            entity.ToTable("Medication Tracker");

            entity.Property(mt => mt.TrackingId).HasColumnName("trackingId");
            entity.Property(mt => mt.TimesPerDay).HasColumnName("timesPerDay");
            entity.Property(mt => mt.BeforeMeals).HasColumnName("beforeMeals");
            entity.Property(mt => mt.Day).HasColumnName("day");
            entity.Property(mt => mt.HasNotified).HasColumnName("hasNotified");
        });

        modelBuilder.Entity<ConsumedDateTime>(entity =>
        {
            entity.HasKey(cd => new { cd.MedicationTrackerId, cd.DateTime });

            entity.Property(cd => cd.MedicationTrackerId).HasColumnName("medicationTrackerId");
            entity.Property(cd => cd.DateTime).HasColumnName("DateTime");

            modelBuilder.Entity<ConsumedDateTime>()
                .HasOne(cd => cd.MedicationTracker)
                .WithMany(mt => mt.ConsumedOn)
                .HasForeignKey(cd => cd.MedicationTrackerId);
        });

        modelBuilder.Entity<PatientMedicalRecord>(entity =>
        {
            entity.HasKey(e => e.MedicalRecordId);

            entity.ToTable("Patient Medical Record");

            entity.Property(e => e.MedicalRecordId).HasColumnName("medicalRecordId");
            entity.Property(e => e.Allergies).HasColumnName("allergies");
            entity.Property(e => e.DiagnosisCurrent).HasColumnName("diagnosisCurrent");
            entity.Property(e => e.DiagnosisPast).HasColumnName("diagnosisPast");
            entity.Property(e => e.Erratum).HasColumnName("erratum");
            entity.Property(e => e.HealthImprovementProgress).HasColumnName("healthImprovementProgress");
            entity.Property(e => e.IllnessName).HasColumnName("illnessName");
            entity.Property(e => e.ImmunizationStatus).HasColumnName("immunizationStatus");
            entity.Property(e => e.MedicationCurrent).HasColumnName("medicationCurrent");
            entity.Property(e => e.MedicationPast).HasColumnName("medicationPast");
            entity.Property(e => e.PatientId).HasColumnName("patientId");

            entity.HasOne(d => d.Patient).WithMany(p => p.PatientMedicalRecords)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.ToTable("Photo");

            entity.Property(e => e.PhotoId).HasColumnName("photoId");
            entity.Property(e => e.PhotoImage).HasColumnName("photoImage");
        });

        modelBuilder.Entity<PreDischargeService>(entity =>
        {
            entity.HasKey(e => e.ServiceId);

            entity.ToTable("Pre-discharge Service");

            entity.Property(e => e.ServiceId).HasColumnName("serviceId");
            entity.Property(e => e.ServiceDescription).HasColumnName("serviceDescription");
            entity.Property(e => e.ServiceDuration).HasColumnName("serviceDuration");
            entity.Property(e => e.ServiceName).HasColumnName("serviceName");
        });

        modelBuilder.Entity<PreDischargeServiceAssignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId);

            entity.ToTable("Pre-discharge Service Assignment");

            entity.Property(e => e.AssignmentId).HasColumnName("assignmentId");
            entity.Property(e => e.AppointmentDate).HasColumnName("appointmentDate");
            entity.Property(e => e.AssignmentDate).HasColumnName("assignmentDate");
            entity.Property(e => e.DoctorId).HasColumnName("doctorId");
            entity.Property(e => e.NurseId).HasColumnName("nurseId");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.ServiceId).HasColumnName("serviceId");

            entity.HasOne(d => d.Doctor).WithMany(p => p.PreDischargeServiceAssignments)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Nurse).WithMany(p => p.PreDischargeServiceAssignmentNurses)
                .HasForeignKey(d => d.NurseId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Patient).WithMany(p => p.PreDischargeServiceAssignmentPatients)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Service).WithMany(p => p.PreDischargeServiceAssignments)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PreDischargeServiceLog>(entity =>
        {
            entity.HasKey(e => e.ServiceLogId);

            entity.ToTable("Pre-discharge Service Logs");

            entity.Property(e => e.ServiceLogId).HasColumnName("serviceLogId");
            entity.Property(e => e.PostAppointmentNotes).HasColumnName("postAppointmentNotes");
            entity.Property(e => e.PostAppointmentObservation).HasColumnName("postAppointmentObservation");
            entity.Property(e => e.ScheduleId).HasColumnName("scheduleId");

            entity.HasOne(d => d.Schedule).WithMany(p => p.PreDischargeServiceLogs)
                .HasForeignKey(d => d.ScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PreDischargeServiceSchedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId);

            entity.ToTable("Pre-discharge Service Schedule");

            entity.Property(e => e.ScheduleId).HasColumnName("scheduleId");
            entity.Property(e => e.AppointmentDateTime).HasColumnName("appointmentDateTime");
            entity.Property(e => e.AssignmentId).HasColumnName("assignmentId");
            entity.Property(e => e.AssignmentStatus).HasColumnName("assignmentStatus");

            entity.HasOne(d => d.Assignment).WithMany(p => p.PreDischargeServiceSchedules)
                .HasForeignKey(d => d.AssignmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<RescheduleRequest>(entity =>
        {
            entity.HasKey(e => e.ResceduleId);

            entity.ToTable("Reschedule Request");

            entity.Property(e => e.ResceduleId).HasColumnName("resceduleId");
            entity.Property(e => e.AppointmentDateTime).HasColumnName("appointmentDateTime");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.RequestStatus).HasColumnName("requestStatus");
            entity.Property(e => e.RescheduleReason).HasColumnName("rescheduleReason");
            entity.Property(e => e.ScheduleId).HasColumnName("scheduleId");

            entity.HasOne(d => d.Patient).WithMany(p => p.RescheduleRequests)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Schedule).WithMany(p => p.RescheduleRequests)
                .HasForeignKey(d => d.ScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SafetyChecklist>(entity =>
        {
            entity.ToTable("Safety Checklist");

            entity.Property(e => e.SafetyChecklistId).HasColumnName("safetyChecklistId");
            entity.Property(e => e.LocationCategory).HasColumnName("locationCategory");
            entity.Property(e => e.PhotoId).HasColumnName("photoId");
            entity.Property(e => e.RiskComment).HasColumnName("riskComment");
            entity.Property(e => e.RiskDescription).HasColumnName("riskDescription");
            entity.Property(e => e.RiskTitle).HasColumnName("riskTitle");
        });

        modelBuilder.Entity<SafetyChecklistAssessment>(entity =>
        {
            entity.HasKey(e => e.AssessmentId);

            entity.ToTable("Safety Checklist Assessment");

            entity.Property(e => e.AssessmentId).HasColumnName("assessmentId");
            entity.Property(e => e.PatientCaregiverId).HasColumnName("patientCaregiverId");
            entity.Property(e => e.PatientHomeEnvPhotos).HasColumnName("patientHomeEnvPhotos");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.RiskDescription).HasColumnName("riskDescription");
            entity.Property(e => e.RiskRating).HasColumnName("riskRating");

            entity.HasOne(d => d.PatientCaregiver).WithMany(p => p.SafetyChecklistAssessments)
                .HasForeignKey(d => d.PatientCaregiverId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Patient).WithMany(p => p.SafetyChecklistAssessments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}