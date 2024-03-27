namespace SherplexTickets.Core.Contracts
{
    public interface ITheaterManagerService
    {
        Task<bool> ExistsТheaterМanagerByIdAsync(string userId);
        Task<int?> GetТheaterМanagerIdAsync(string userId);
        Task<bool> ExistsUserByIdAsync(string userName);
    }
}
