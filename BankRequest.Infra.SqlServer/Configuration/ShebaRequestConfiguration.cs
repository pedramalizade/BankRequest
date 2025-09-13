namespace BankRequest.Infra.SqlServer.Configuration
{
    public class ShebaRequestConfiguration : IEntityTypeConfiguration<ShebaRequest>
    {
        public void Configure(EntityTypeBuilder<ShebaRequest> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasData
            (
                new ShebaRequest
                {
                    Id = 1,
                    Price = 100000,
                    FromShebaNumber = "IR9801234567890123456780",
                    ToShebaNumber = "IR9801234567890123456790",
                    Note = "Test request 1",
                    Status = RequestStatus.Pending,
                    CreatedAt = new DateTime(2024, 2, 5)
                },
                new ShebaRequest
                {
                    Id = 2,
                    Price = 200000,
                    FromShebaNumber = "IR9809876543210123456700",
                    ToShebaNumber = "IR9809876543210123456000",
                    Note = "Test request 2",
                    Status = RequestStatus.Pending,
                    CreatedAt = new DateTime(2024, 5, 2)
                }
            );
        }
    }
}
