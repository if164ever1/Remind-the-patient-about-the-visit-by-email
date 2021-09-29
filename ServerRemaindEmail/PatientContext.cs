using Microsoft.EntityFrameworkCore;


namespace ServerRemaindEmail
{
    partial class PatientContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public PatientContext()
        {
        }
        public PatientContext(DbContextOptions<PatientContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-8QKHHQU\\MSSQLSERVER01;Initial Catalog=AppointmentCRUDDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
