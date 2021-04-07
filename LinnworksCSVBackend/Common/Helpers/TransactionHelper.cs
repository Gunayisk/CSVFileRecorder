using LinnworksCSVBackend.LinnworksAppModels;
using System;


namespace LinnworksCSVBackend.Common.Helpers
{
    public class TransactionHelper
    {
        public static long GetTransactionId ()
        {
            using (var db = new LinnworksAppContext())
            {
                Transaction transaction = new Transaction()
                {
                    
                    CreateDate = DateTime.Now,
                    
                };

                db.Transactions.Add(transaction);
                db.SaveChanges();
                return transaction.Id;
            }
        }
    }
}
