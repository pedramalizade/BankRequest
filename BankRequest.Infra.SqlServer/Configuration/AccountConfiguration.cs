namespace BankRequest.Infra.SqlServer.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.ShebaNumber)
                   .HasMaxLength(24)
                   .IsRequired();

            builder.Property(a => a.AvailableBalance)
                   .IsRequired();

            builder.HasData
            (
                new Account
                {
                    Id = 1,
                    ShebaNumber = "IR9801234567890123456780",
                    AvailableBalance = 10000000 
                },
                new Account
                {
                    Id = 2,
                    ShebaNumber = "IR9809876543210123456700",
                    AvailableBalance = 10000000 
                },
                new Account
                {
                    Id = 3,
                    ShebaNumber = "IR9801234567890123456790",
                    AvailableBalance = 10000000 
                },
                new Account
                {
                    Id = 4,
                    ShebaNumber = "IR9809876543210123456000",
                    AvailableBalance = 10000000
                }
            );
        }
    }
}
