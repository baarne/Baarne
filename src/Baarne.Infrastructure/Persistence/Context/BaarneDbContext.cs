using Baarne.Domain.Entities.Admin;
using Baarne.Domain.Entities.Common;
using Baarne.Domain.Entities.Companies;
using Baarne.Domain.Entities.CurrentUser;
using Baarne.Domain.Entities.Feature;
using Baarne.Domain.Entities.Integration;
using Baarne.Domain.Entities.KpiLibrary;
using Baarne.Domain.Entities.Notification;
using Baarne.Domain.Entities.Organization;
using Baarne.Domain.Entities.Plan;
using Baarne.Domain.Entities.Question;
using Microsoft.EntityFrameworkCore;

namespace Baarne.Persistence.Contexts
{
    public class BaarneDbContext : DbContext
    {
        public BaarneDbContext(DbContextOptions<BaarneDbContext> options) : base(options)
        {
        }

        // Admin Aggregate
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminRole> AdminRoles { get; set; }
        public DbSet<AdminRolePermission> AdminRolePermissions { get; set; }
        public DbSet<AdminAction> AdminActions { get; set; }
        public DbSet<AdminPageAction> AdminPageActions { get; set; }
        public DbSet<AdminCompany> AdminCompanies { get; set; }
        public DbSet<AdminPlanDefinition> AdminPlanDefinitions { get; set; }
        public DbSet<AdminPlanPermission> AdminPlanPermissions { get; set; }

        // CurrentUser Aggregate
        public DbSet<User> Users { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<UserKpiPermission> UserKpiPermissions { get; set; }
        public DbSet<UserFeedback> UserFeedbacks { get; set; }
        public DbSet<UserSelection> UserSelections { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        // Companies Aggregate
        public DbSet<Company> Companies { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<History> Histories { get; set; }

        // Plan Aggregate
        public DbSet<CustomPlanDefinition> CustomPlanDefinitions { get; set; }
        public DbSet<PlanPermission> PlanPermissions { get; set; }
        public DbSet<Payment> Payments { get; set; }

        // KpiLibrary Aggregate
        public DbSet<KpiLibrary> KpiLibraries { get; set; }
        public DbSet<KpiSelection> KpiSelections { get; set; }
        public DbSet<SelectedKpi> SelectedKpis { get; set; }
        public DbSet<KpiTarget> KpiTargets { get; set; }
        public DbSet<ForecastingMetric> ForecastingMetrics { get; set; }

        // Organization Aggregate
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<CustomBranchDetail> CustomBranchDetails { get; set; }
        public DbSet<CustomDepartmentDetail> CustomDepartmentDetails { get; set; }
        public DbSet<CustomEmployeeDetail> CustomEmployeeDetails { get; set; }

        // Question Aggregate
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionCategory> QuestionCategories { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }

        // Feature Aggregate
        public DbSet<FeatureControl> FeatureControls { get; set; }
        public DbSet<PageInteraction> PageInteractions { get; set; }

        // Notification Aggregate
        public DbSet<AlarmNotification> AlarmNotifications { get; set; }

        // Integration Aggregate
        public DbSet<ApiIntegration> ApiIntegrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}