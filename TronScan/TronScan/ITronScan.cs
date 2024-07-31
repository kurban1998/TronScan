using TronScan.Models;

namespace TronScan
{
    public interface ITronScan
    {
        public Task<TransactionData> GetTransactionDetails(string transactionHash);
    }
}