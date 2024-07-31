namespace TronScan
{
    public class Worker
    {
        public Worker(ITronScan tronScan) 
        {
            _tronScan = tronScan;
        }

        public async Task Run()
        {
            Console.WriteLine("Введите хеш транзакции...");
            var transactionHash = Console.ReadLine();
            var transaction = await _tronScan.GetTransactionDetails(transactionHash);

            if(transaction != null)
            {
                Console.WriteLine($"Hash: {transaction.Hash}\n" +
                    $"RiskTransaction: {transaction.IsRisk}");
            }
            else
            {
                Console.WriteLine("Transaction is null");
            }
        }

        private readonly ITronScan _tronScan;
    }
}
