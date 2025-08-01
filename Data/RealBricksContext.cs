using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using realbricks_user_dotnet_backend.Models;

namespace realbricks_user_dotnet_backend.Data;

public partial class RealBricksContext : DbContext
{
    public RealBricksContext(DbContextOptions<RealBricksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminUser> AdminUsers { get; set; }

    public virtual DbSet<Amenity> Amenities { get; set; }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<BuilderLeadAction> BuilderLeadActions { get; set; }

    public virtual DbSet<BuilderUser> BuilderUsers { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<DeveloperCore> DeveloperCores { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<EmailEvent> EmailEvents { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Lead> Leads { get; set; }

    public virtual DbSet<ProjectAmenity> ProjectAmenities { get; set; }

    public virtual DbSet<ProjectCore> ProjectCores { get; set; }

    public virtual DbSet<ProjectLegalDocument> ProjectLegalDocuments { get; set; }

    public virtual DbSet<ProjectMedium> ProjectMedia { get; set; }

    public virtual DbSet<ProjectSpecification> ProjectSpecifications { get; set; }

    public virtual DbSet<ProjectUnit> ProjectUnits { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<SubDistrict> SubDistricts { get; set; }

    public virtual DbSet<UserAuth> UserAuths { get; set; }

    public virtual DbSet<VwBuilderStat> VwBuilderStats { get; set; }

    public virtual DbSet<VwEmailEventStatus> VwEmailEventStatuses { get; set; }

    public virtual DbSet<VwInvoiceSummary> VwInvoiceSummaries { get; set; }

    public virtual DbSet<VwLeadBillingSummary> VwLeadBillingSummaries { get; set; }

    public virtual DbSet<VwLeadDetail> VwLeadDetails { get; set; }

    public virtual DbSet<VwLeadStatusDistribution> VwLeadStatusDistributions { get; set; }

    public virtual DbSet<VwLegalDocumentStatus> VwLegalDocumentStatuses { get; set; }

    public virtual DbSet<VwPlatformStat> VwPlatformStats { get; set; }

    public virtual DbSet<VwProjectDetail> VwProjectDetails { get; set; }

    public virtual DbSet<VwProjectSummary> VwProjectSummaries { get; set; }

    public virtual DbSet<VwRecentActivity> VwRecentActivities { get; set; }

    public virtual DbSet<VwRecentEnquiry> VwRecentEnquiries { get; set; }

    public virtual DbSet<VwUnitAvailability> VwUnitAvailabilities { get; set; }

    public virtual DbSet<VwUserStat> VwUserStats { get; set; }
    
    public DbSet<ProjectNearbyLocation> ProjectNearbyLocations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AdminUser>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PRIMARY");

            entity.ToTable("admin_user");

            entity.HasIndex(e => e.Email, "uk_admin_email").IsUnique();

            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Role)
                .HasDefaultValueSql("'super_admin'")
                .HasColumnType("enum('super_admin','moderator')")
                .HasColumnName("role");
        });

        modelBuilder.Entity<Amenity>(entity =>
        {
            entity.HasKey(e => e.AmenityId).HasName("PRIMARY");

            entity.ToTable("amenities");

            entity.HasIndex(e => e.Name, "uk_amenity_name").IsUnique();

            entity.Property(e => e.AmenityId).HasColumnName("amenity_id");
            entity.Property(e => e.Category)
                .HasDefaultValueSql("'utility'")
                .HasColumnType("enum('recreation','security','utility','community')")
                .HasColumnName("category");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PRIMARY");

            entity.ToTable("area");

            entity.HasIndex(e => new { e.SubDistrictId, e.Name }, "uk_area_name").IsUnique();

            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Pincode)
                .HasMaxLength(10)
                .HasColumnName("pincode");
            entity.Property(e => e.SubDistrictId).HasColumnName("sub_district_id");

            entity.HasOne(d => d.SubDistrict).WithMany(p => p.Areas)
                .HasForeignKey(d => d.SubDistrictId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("area_ibfk_1");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PRIMARY");

            entity.ToTable("audit_log");

            entity.Property(e => e.LogId).HasColumnName("log_id");
            entity.Property(e => e.EventTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("event_time");
            entity.Property(e => e.EventType)
                .HasColumnType("enum('login','logout')")
                .HasColumnName("event_type");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserType)
                .HasColumnType("enum('super_admin','builder','user')")
                .HasColumnName("user_type");
        });

        modelBuilder.Entity<BuilderLeadAction>(entity =>
        {
            entity.HasKey(e => e.ActionId).HasName("PRIMARY");

            entity.ToTable("builder_lead_actions");

            entity.HasIndex(e => e.DeveloperId, "developer_id");

            entity.HasIndex(e => e.LeadId, "lead_id");

            entity.Property(e => e.ActionId).HasColumnName("action_id");
            entity.Property(e => e.ActionType)
                .HasColumnType("enum('call','email','meeting','follow_up','other')")
                .HasColumnName("action_type");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeveloperId).HasColumnName("developer_id");
            entity.Property(e => e.LeadId).HasColumnName("lead_id");
            entity.Property(e => e.Notes)
                .HasColumnType("text")
                .HasColumnName("notes");

            entity.HasOne(d => d.Developer).WithMany(p => p.BuilderLeadActions)
                .HasForeignKey(d => d.DeveloperId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("builder_lead_actions_ibfk_2");

            entity.HasOne(d => d.Lead).WithMany(p => p.BuilderLeadActions)
                .HasForeignKey(d => d.LeadId)
                .HasConstraintName("builder_lead_actions_ibfk_1");
        });

        modelBuilder.Entity<BuilderUser>(entity =>
        {
            entity.HasKey(e => e.BuilderUserId).HasName("PRIMARY");

            entity.ToTable("builder_users");

            entity.HasIndex(e => e.DeveloperId, "developer_id");

            entity.HasIndex(e => e.Email, "uk_builder_email").IsUnique();

            entity.HasIndex(e => e.ReraId, "uk_builder_rera_id").IsUnique();

            entity.Property(e => e.BuilderUserId).HasColumnName("builder_user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeveloperId).HasColumnName("developer_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.ReraId)
                .HasMaxLength(50)
                .HasColumnName("rera_id");

            entity.HasOne(d => d.Developer).WithMany(p => p.BuilderUsers)
                .HasForeignKey(d => d.DeveloperId)
                .HasConstraintName("builder_users_ibfk_1");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PRIMARY");

            entity.ToTable("city");

            entity.HasIndex(e => new { e.StateId, e.Name }, "uk_city_name").IsUnique();

            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.StateId).HasColumnName("state_id");

            entity.HasOne(d => d.State).WithMany(p => p.Cities)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("city_ibfk_1");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PRIMARY");

            entity.ToTable("country");

            entity.HasIndex(e => e.Name, "uk_country_name").IsUnique();

            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DeveloperCore>(entity =>
        {
            entity.HasKey(e => e.DeveloperId).HasName("PRIMARY");

            entity.ToTable("developer_core");

            entity.HasIndex(e => e.Email, "uk_developer_email").IsUnique();

            entity.HasIndex(e => e.ReraId, "uk_developer_rera_id").IsUnique();

            entity.Property(e => e.DeveloperId).HasColumnName("developer_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
            entity.Property(e => e.ReraId)
                .HasMaxLength(50)
                .HasColumnName("rera_id");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.DistrictId).HasName("PRIMARY");

            entity.ToTable("district");

            entity.HasIndex(e => new { e.CityId, e.Name }, "uk_district_name").IsUnique();

            entity.Property(e => e.DistrictId).HasColumnName("district_id");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.City).WithMany(p => p.Districts)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("district_ibfk_1");
        });

        modelBuilder.Entity<EmailEvent>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PRIMARY");

            entity.ToTable("email_event");

            entity.HasIndex(e => e.LeadId, "lead_id");

            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.Body)
                .HasColumnType("text")
                .HasColumnName("body");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.EmailType)
                .HasColumnType("enum('welcome','follow_up','reminder','confirmation','other','promotion','offer')")
                .HasColumnName("email_type");
            entity.Property(e => e.ErrorMessage)
                .HasColumnType("text")
                .HasColumnName("error_message");
            entity.Property(e => e.LeadId).HasColumnName("lead_id");
            entity.Property(e => e.RecipientEmail)
                .HasMaxLength(100)
                .HasColumnName("recipient_email");
            entity.Property(e => e.RetryCount)
                .HasDefaultValueSql("'0'")
                .HasColumnName("retry_count");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'pending'")
                .HasColumnType("enum('sent','failed','pending')")
                .HasColumnName("status");
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .HasColumnName("subject");

            entity.HasOne(d => d.Lead).WithMany(p => p.EmailEvents)
                .HasForeignKey(d => d.LeadId)
                .HasConstraintName("email_event_ibfk_1");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PRIMARY");

            entity.ToTable("invoice");

            entity.HasIndex(e => e.DeveloperId, "developer_id");

            entity.HasIndex(e => e.InvoiceNumber, "uk_invoice_number").IsUnique();

            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeveloperId).HasColumnName("developer_id");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(50)
                .HasColumnName("invoice_number");
            entity.Property(e => e.PaymentStatus)
                .HasDefaultValueSql("'pending'")
                .HasColumnType("enum('pending','paid','overdue')")
                .HasColumnName("payment_status");
            entity.Property(e => e.TotalAmount)
                .HasPrecision(15, 2)
                .HasColumnName("total_amount");

            entity.HasOne(d => d.Developer).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.DeveloperId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoice_ibfk_1");
        });

        modelBuilder.Entity<Lead>(entity =>
        {
            entity.HasKey(e => e.LeadId).HasName("PRIMARY");

            entity.ToTable("leads");

            entity.HasIndex(e => e.DeveloperId, "developer_id");

            entity.HasIndex(e => e.ProjectId, "project_id");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.LeadId).HasColumnName("lead_id");
            entity.Property(e => e.BudgetMax)
                .HasPrecision(15, 2)
                .HasColumnName("budget_max");
            entity.Property(e => e.BudgetMin)
                .HasPrecision(15, 2)
                .HasColumnName("budget_min");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeveloperId).HasColumnName("developer_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.LeadScore)
                .HasDefaultValueSql("'50'")
                .HasColumnName("lead_score");
            entity.Property(e => e.LeadStatus)
                .HasDefaultValueSql("'new'")
                .HasColumnType("enum('new','contacted','interested','not_interested','converted')")
                .HasColumnName("lead_status");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Developer).WithMany(p => p.Leads)
                .HasForeignKey(d => d.DeveloperId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("leads_ibfk_2");

            entity.HasOne(d => d.Project).WithMany(p => p.Leads)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("leads_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.Leads)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("leads_ibfk_3");
        });

        modelBuilder.Entity<ProjectAmenity>(entity =>
        {
            entity.HasKey(e => new { e.ProjectId, e.AmenityId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("project_amenities");

            entity.HasIndex(e => e.AmenityId, "amenity_id");

            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.AmenityId).HasColumnName("amenity_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");

            entity.HasOne(d => d.Amenity).WithMany(p => p.ProjectAmenities)
                .HasForeignKey(d => d.AmenityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("project_amenities_ibfk_2");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectAmenities)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("project_amenities_ibfk_1");
        });

        modelBuilder.Entity<ProjectCore>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PRIMARY");

            entity.ToTable("project_core");

            entity.HasIndex(e => e.AreaId, "area_id");

            entity.HasIndex(e => e.DeveloperId, "developer_id");

            entity.HasIndex(e => e.ReraId, "uk_project_rera_id").IsUnique();

            entity.HasIndex(e => e.Slug, "uk_project_slug").IsUnique();

            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.CarpetAreaSqft).HasColumnName("carpet_area_sqft");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DeveloperId).HasColumnName("developer_id");
            entity.Property(e => e.MinPrice)
                .HasPrecision(15, 2)
                .HasColumnName("min_price");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.PropertyType)
                .HasColumnType("enum('apartment','villa','plot','commercial')")
                .HasColumnName("property_type");
            entity.Property(e => e.ReraId)
                .HasMaxLength(50)
                .HasColumnName("rera_id");
            entity.Property(e => e.Slug)
                .HasMaxLength(100)
                .HasColumnName("slug");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'ongoing'")
                .HasColumnType("enum('ongoing','completed','upcoming')")
                .HasColumnName("status");

            entity.HasOne(d => d.Area).WithMany(p => p.ProjectCores)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("project_core_ibfk_2");

            entity.HasOne(d => d.Developer).WithMany(p => p.ProjectCores)
                .HasForeignKey(d => d.DeveloperId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("project_core_ibfk_1");
        });

        modelBuilder.Entity<ProjectLegalDocument>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PRIMARY");

            entity.ToTable("project_legal_documents");

            entity.HasIndex(e => new { e.ProjectId, e.DocumentType }, "uk_project_document_type").IsUnique();

            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.DocumentType)
                .HasColumnType("enum('rera_certificate','title_deed','building_plan_sanction','commencement_certificate','noc_fire','noc_water','noc_pollution','agreement_for_sale','allotment_letter','occupancy_certificate','property_tax_receipt','encumbrance_certificate')")
                .HasColumnName("document_type");
            entity.Property(e => e.DocumentUrl)
                .HasMaxLength(255)
                .HasColumnName("document_url");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.Remarks)
                .HasColumnType("text")
                .HasColumnName("remarks");
            entity.Property(e => e.UploadedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("uploaded_at");
            entity.Property(e => e.VerificationStatus)
                .HasDefaultValueSql("'pending'")
                .HasColumnType("enum('pending','verified','rejected')")
                .HasColumnName("verification_status");
            entity.Property(e => e.VerifiedAt)
                .HasColumnType("timestamp")
                .HasColumnName("verified_at");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectLegalDocuments)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("project_legal_documents_ibfk_1");
        });

        modelBuilder.Entity<ProjectMedium>(entity =>
        {
            entity.HasKey(e => e.MediaId).HasName("PRIMARY");

            entity.ToTable("project_media");

            entity.HasIndex(e => e.ProjectId, "project_id");

            entity.Property(e => e.MediaId).HasColumnName("media_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.FileUrl)
                .HasMaxLength(255)
                .HasColumnName("file_url");
            entity.Property(e => e.MediaType)
                .HasDefaultValueSql("'image'")
                .HasColumnType("enum('image','video','floor_plan')")
                .HasColumnName("media_type");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectMedia)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("project_media_ibfk_1");
        });

        modelBuilder.Entity<ProjectSpecification>(entity =>
        {
            entity.HasKey(e => e.SpecificationId).HasName("PRIMARY");

            entity.ToTable("project_specifications");

            entity.HasIndex(e => new { e.ProjectId, e.DisplayOrder }, "uk_project_spec_order").IsUnique();

            entity.Property(e => e.SpecificationId).HasColumnName("specification_id");
            entity.Property(e => e.BrandName)
                .HasMaxLength(100)
                .HasColumnName("brand_name");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DisplayOrder)
                .HasDefaultValueSql("'0'")
                .HasColumnName("display_order");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.SpecCategory)
                .HasMaxLength(100)
                .HasColumnName("spec_category");
            entity.Property(e => e.SpecName)
                .HasMaxLength(100)
                .HasColumnName("spec_name");
            entity.Property(e => e.SpecValue)
                .HasMaxLength(255)
                .HasColumnName("spec_value");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectSpecifications)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("project_specifications_ibfk_1");
        });

        modelBuilder.Entity<ProjectUnit>(entity =>
        {
            entity.HasKey(e => e.UnitId).HasName("PRIMARY");

            entity.ToTable("project_units");

            entity.HasIndex(e => new { e.ProjectId, e.UnitType }, "uk_project_unit_type").IsUnique();

            entity.Property(e => e.UnitId).HasColumnName("unit_id");
            entity.Property(e => e.CarpetAreaSqft).HasColumnName("carpet_area_sqft");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Floors).HasColumnName("floors");
            entity.Property(e => e.PriceEnd)
                .HasPrecision(15, 2)
                .HasColumnName("price_end");
            entity.Property(e => e.PriceStarting)
                .HasPrecision(15, 2)
                .HasColumnName("price_starting");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.UnitType)
                .HasColumnType("enum('1bhk','2bhk','3bhk','4bhk','4.5bhk','5bhk')")
                .HasColumnName("unit_type");
            entity.Property(e => e.UnitsAvailable).HasColumnName("units_available");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectUnits)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("project_units_ibfk_1");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PRIMARY");

            entity.ToTable("state");

            entity.HasIndex(e => new { e.CountryId, e.Name }, "uk_state_name").IsUnique();

            entity.Property(e => e.StateId).HasColumnName("state_id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.Country).WithMany(p => p.States)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("state_ibfk_1");
        });

        modelBuilder.Entity<SubDistrict>(entity =>
        {
            entity.HasKey(e => e.SubDistrictId).HasName("PRIMARY");

            entity.ToTable("sub_district");

            entity.HasIndex(e => new { e.DistrictId, e.Name }, "uk_sub_district_name").IsUnique();

            entity.Property(e => e.SubDistrictId).HasColumnName("sub_district_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DistrictId).HasColumnName("district_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.District).WithMany(p => p.SubDistricts)
                .HasForeignKey(d => d.DistrictId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sub_district_ibfk_1");
        });

        modelBuilder.Entity<UserAuth>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("user_auth");

            entity.HasIndex(e => e.Email, "uk_user_email").IsUnique();

            entity.HasIndex(e => e.GoogleId, "uk_user_google_id").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.GoogleId)
                .HasMaxLength(100)
                .HasColumnName("google_id");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<VwBuilderStat>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_builder_stats");

            entity.Property(e => e.BuilderUserId).HasColumnName("builder_user_id");
            entity.Property(e => e.DeveloperName)
                .HasMaxLength(100)
                .HasColumnName("developer_name");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.EnquiryCount).HasColumnName("enquiry_count");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.ProjectCount).HasColumnName("project_count");
            entity.Property(e => e.ReraId)
                .HasMaxLength(50)
                .HasColumnName("rera_id");
            entity.Property(e => e.TotalRevenue)
                .HasPrecision(25, 2)
                .HasColumnName("total_revenue");
        });

        modelBuilder.Entity<VwEmailEventStatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_email_event_status");

            entity.Property(e => e.AvgRetryCount)
                .HasPrecision(14, 4)
                .HasColumnName("avg_retry_count");
            entity.Property(e => e.EmailType)
                .HasColumnType("enum('welcome','follow_up','reminder','confirmation','other','promotion','offer')")
                .HasColumnName("email_type");
            entity.Property(e => e.EventCount).HasColumnName("event_count");
            entity.Property(e => e.FailedCount).HasColumnName("failed_count");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'pending'")
                .HasColumnType("enum('sent','failed','pending')")
                .HasColumnName("status");
        });

        modelBuilder.Entity<VwInvoiceSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_invoice_summary");

            entity.Property(e => e.DeveloperId).HasColumnName("developer_id");
            entity.Property(e => e.DeveloperName)
                .HasMaxLength(100)
                .HasColumnName("developer_name");
            entity.Property(e => e.OverdueAmount)
                .HasPrecision(37, 2)
                .HasColumnName("overdue_amount");
            entity.Property(e => e.PaidAmount)
                .HasPrecision(37, 2)
                .HasColumnName("paid_amount");
            entity.Property(e => e.PendingAmount)
                .HasPrecision(37, 2)
                .HasColumnName("pending_amount");
            entity.Property(e => e.TotalAmount)
                .HasPrecision(37, 2)
                .HasColumnName("total_amount");
            entity.Property(e => e.TotalInvoices).HasColumnName("total_invoices");
        });

        modelBuilder.Entity<VwLeadBillingSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_lead_billing_summary");

            entity.Property(e => e.DeveloperId).HasColumnName("developer_id");
            entity.Property(e => e.DeveloperName)
                .HasMaxLength(100)
                .HasColumnName("developer_name");
            entity.Property(e => e.ReraId)
                .HasMaxLength(50)
                .HasColumnName("rera_id");
            entity.Property(e => e.TotalLeads).HasColumnName("total_leads");
            entity.Property(e => e.TotalRevenue)
                .HasPrecision(25, 2)
                .HasColumnName("total_revenue");
        });

        modelBuilder.Entity<VwLeadDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_lead_details");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeveloperName)
                .HasMaxLength(100)
                .HasColumnName("developer_name");
            entity.Property(e => e.DeveloperReraId)
                .HasMaxLength(50)
                .HasColumnName("developer_rera_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.LeadId).HasColumnName("lead_id");
            entity.Property(e => e.LeadScore)
                .HasDefaultValueSql("'50'")
                .HasColumnName("lead_score");
            entity.Property(e => e.LeadStatus)
                .HasDefaultValueSql("'new'")
                .HasColumnType("enum('new','contacted','interested','not_interested','converted')")
                .HasColumnName("lead_status");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(100)
                .HasColumnName("project_name");
            entity.Property(e => e.ProjectReraId)
                .HasMaxLength(50)
                .HasColumnName("project_rera_id");
        });

        modelBuilder.Entity<VwLeadStatusDistribution>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_lead_status_distribution");

            entity.Property(e => e.DeveloperId).HasColumnName("developer_id");
            entity.Property(e => e.DeveloperName)
                .HasMaxLength(100)
                .HasColumnName("developer_name");
            entity.Property(e => e.EstimatedRevenue)
                .HasPrecision(25, 2)
                .HasColumnName("estimated_revenue");
            entity.Property(e => e.LeadCount).HasColumnName("lead_count");
            entity.Property(e => e.LeadStatus)
                .HasDefaultValueSql("'new'")
                .HasColumnType("enum('new','contacted','interested','not_interested','converted')")
                .HasColumnName("lead_status");
        });

        modelBuilder.Entity<VwLegalDocumentStatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_legal_document_status");

            entity.Property(e => e.DeveloperName)
                .HasMaxLength(100)
                .HasColumnName("developer_name");
            entity.Property(e => e.DocumentType)
                .HasColumnType("enum('rera_certificate','title_deed','building_plan_sanction','commencement_certificate','noc_fire','noc_water','noc_pollution','agreement_for_sale','allotment_letter','occupancy_certificate','property_tax_receipt','encumbrance_certificate')")
                .HasColumnName("document_type");
            entity.Property(e => e.DocumentUrl)
                .HasMaxLength(255)
                .HasColumnName("document_url");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(100)
                .HasColumnName("project_name");
            entity.Property(e => e.Remarks)
                .HasColumnType("text")
                .HasColumnName("remarks");
            entity.Property(e => e.ReraId)
                .HasMaxLength(50)
                .HasColumnName("rera_id");
            entity.Property(e => e.UploadedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("uploaded_at");
            entity.Property(e => e.VerificationStatus)
                .HasDefaultValueSql("'pending'")
                .HasColumnType("enum('pending','verified','rejected')")
                .HasColumnName("verification_status");
            entity.Property(e => e.VerifiedAt)
                .HasColumnType("timestamp")
                .HasColumnName("verified_at");
        });

        modelBuilder.Entity<VwPlatformStat>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_platform_stats");

            entity.Property(e => e.CompletedProjects).HasColumnName("completed_projects");
            entity.Property(e => e.OngoingProjects).HasColumnName("ongoing_projects");
            entity.Property(e => e.TotalBuilders).HasColumnName("total_builders");
            entity.Property(e => e.TotalLeads).HasColumnName("total_leads");
            entity.Property(e => e.TotalProjects).HasColumnName("total_projects");
            entity.Property(e => e.TotalRevenue)
                .HasPrecision(25, 2)
                .HasColumnName("total_revenue");
            entity.Property(e => e.TotalUsers).HasColumnName("total_users");
            entity.Property(e => e.UpcomingProjects).HasColumnName("upcoming_projects");
        });

        modelBuilder.Entity<VwProjectDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_project_details");

            entity.Property(e => e.Amenities)
                .HasColumnType("text")
                .HasColumnName("amenities");
            entity.Property(e => e.AreaName)
                .HasMaxLength(100)
                .HasColumnName("area_name");
            entity.Property(e => e.CarpetAreaSqft).HasColumnName("carpet_area_sqft");
            entity.Property(e => e.CityName)
                .HasMaxLength(100)
                .HasColumnName("city_name");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DeveloperName)
                .HasMaxLength(100)
                .HasColumnName("developer_name");
            entity.Property(e => e.DistrictName)
                .HasMaxLength(100)
                .HasColumnName("district_name");
            entity.Property(e => e.DocumentUrls)
                .HasColumnType("text")
                .HasColumnName("document_urls");
            entity.Property(e => e.LegalDocuments)
                .HasColumnType("text")
                .HasColumnName("legal_documents");
            entity.Property(e => e.MaxFloors).HasColumnName("max_floors");
            entity.Property(e => e.MediaUrls)
                .HasColumnType("text")
                .HasColumnName("media_urls");
            entity.Property(e => e.MinPrice)
                .HasPrecision(15, 2)
                .HasColumnName("min_price");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(100)
                .HasColumnName("project_name");
            entity.Property(e => e.PropertyType)
                .HasColumnType("enum('apartment','villa','plot','commercial')")
                .HasColumnName("property_type");
            entity.Property(e => e.ReraId)
                .HasMaxLength(50)
                .HasColumnName("rera_id");
            entity.Property(e => e.Slug)
                .HasMaxLength(100)
                .HasColumnName("slug");
            entity.Property(e => e.StateName)
                .HasMaxLength(100)
                .HasColumnName("state_name");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'ongoing'")
                .HasColumnType("enum('ongoing','completed','upcoming')")
                .HasColumnName("status");
            entity.Property(e => e.SubDistrictName)
                .HasMaxLength(100)
                .HasColumnName("sub_district_name");
            entity.Property(e => e.TotalUnitsAvailable)
                .HasPrecision(32)
                .HasColumnName("total_units_available");
            entity.Property(e => e.UnitTypes)
                .HasColumnType("text")
                .HasColumnName("unit_types");
        });

        modelBuilder.Entity<VwProjectSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_project_summary");

            entity.Property(e => e.AreaName)
                .HasMaxLength(100)
                .HasColumnName("area_name");
            entity.Property(e => e.CarpetAreaSqft).HasColumnName("carpet_area_sqft");
            entity.Property(e => e.CityName)
                .HasMaxLength(100)
                .HasColumnName("city_name");
            entity.Property(e => e.DeveloperName)
                .HasMaxLength(100)
                .HasColumnName("developer_name");
            entity.Property(e => e.LeadsCount).HasColumnName("leads_count");
            entity.Property(e => e.MinPrice)
                .HasPrecision(15, 2)
                .HasColumnName("min_price");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.ReraId)
                .HasMaxLength(50)
                .HasColumnName("rera_id");
            entity.Property(e => e.Slug)
                .HasMaxLength(100)
                .HasColumnName("slug");
            entity.Property(e => e.StateName)
                .HasMaxLength(100)
                .HasColumnName("state_name");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'ongoing'")
                .HasColumnType("enum('ongoing','completed','upcoming')")
                .HasColumnName("status");
        });

        modelBuilder.Entity<VwRecentActivity>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_recent_activity");

            entity.Property(e => e.EventTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("event_time");
            entity.Property(e => e.EventType)
                .HasColumnType("enum('login','logout')")
                .HasColumnName("event_type");
            entity.Property(e => e.LogId).HasColumnName("log_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserType)
                .HasColumnType("enum('super_admin','builder','user')")
                .HasColumnName("user_type");
        });

        modelBuilder.Entity<VwRecentEnquiry>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_recent_enquiries");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeveloperName)
                .HasMaxLength(100)
                .HasColumnName("developer_name");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.LeadId).HasColumnName("lead_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(100)
                .HasColumnName("project_name");
        });

        modelBuilder.Entity<VwUnitAvailability>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_unit_availability");

            entity.Property(e => e.AreaName)
                .HasMaxLength(100)
                .HasColumnName("area_name");
            entity.Property(e => e.CarpetAreaSqft).HasColumnName("carpet_area_sqft");
            entity.Property(e => e.DeveloperName)
                .HasMaxLength(100)
                .HasColumnName("developer_name");
            entity.Property(e => e.Floors).HasColumnName("floors");
            entity.Property(e => e.PriceEnd)
                .HasPrecision(15, 2)
                .HasColumnName("price_end");
            entity.Property(e => e.PriceStarting)
                .HasPrecision(15, 2)
                .HasColumnName("price_starting");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(100)
                .HasColumnName("project_name");
            entity.Property(e => e.ReraId)
                .HasMaxLength(50)
                .HasColumnName("rera_id");
            entity.Property(e => e.TotalUnits)
                .HasPrecision(32)
                .HasColumnName("total_units");
            entity.Property(e => e.UnitType)
                .HasColumnType("enum('1bhk','2bhk','3bhk','4bhk','4.5bhk','5bhk')")
                .HasColumnName("unit_type");
            entity.Property(e => e.UnitsAvailable).HasColumnName("units_available");
        });
        
        modelBuilder.Entity<ProjectNearbyLocation>(entity =>
        {
            entity.ToTable("project_nearby_locations");

            entity.HasKey(e => e.LocationId);

            entity.Property(e => e.LocationId).HasColumnName("location_id"); // Explicitly map to location_id
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.LocationType).HasColumnName("location_type").HasConversion<string>();
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.DistanceKm).HasColumnName("distance_km").HasColumnType("decimal(5,2)");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Latitude).HasColumnName("latitude").HasColumnType("decimal(9,6)");
            entity.Property(e => e.Longitude).HasColumnName("longitude").HasColumnType("decimal(9,6)");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasIndex(e => new { e.ProjectId, e.Name }).IsUnique();

            entity.HasOne(e => e.Project)
                .WithMany(p => p.ProjectNearbyLocations) // Ensure ProjectCore has this collection
                .HasForeignKey(e => e.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<VwUserStat>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_user_stats");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.EnquiryCount).HasColumnName("enquiry_count");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
