namespace SherplexTickets.Core.Contracts
{
    public interface ITheaterManagerService
    {
        Task<bool> ExistsТheaterМanagerByIdAsync(string userId);
        Task<int?> GetТheaterМanagerIdAsync(string userId);

        Task<string?> GetUserIdTheaterManagerByEmailAsync(string emailManager);
    }
}
