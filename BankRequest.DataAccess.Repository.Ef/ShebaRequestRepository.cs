namespace BankRequest.DataAccess.Repository.Ef
{
    public class ShebaRequestRepository : IShebaRequestRepository
    {
        private readonly AppDbContext _context;

        public ShebaRequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ShebaRequest request, CancellationToken cancellationToken)
        {
            await _context.ShebaRequests.AddAsync(request, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Account> GetAccountByShebaNumberAsync(string shebaNumber, CancellationToken cancellationToken)
        {
            return await _context.Accounts
                .SingleOrDefaultAsync(a => a.ShebaNumber == shebaNumber, cancellationToken);
        }

        public async Task<List<ShebaRequest>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.ShebaRequests
            .OrderBy(r => r.CreatedAt) 
            .ToListAsync(cancellationToken);
        }

        public async Task<ShebaRequest?> UpdateStatusAsync(int id, RequestStatus status, string note, CancellationToken cancellationToken)
        {
            var request = await _context.ShebaRequests
                .SingleOrDefaultAsync(r => r.Id == id, cancellationToken);

            if (request == null)
            {
                return null;
            }

            request.Status = status;
            request.Note = note;
            await _context.SaveChangesAsync(cancellationToken);

            return request;
        }
    }
}
