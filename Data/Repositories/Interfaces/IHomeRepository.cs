using WebDevAss2.Models;
namespace WebDevAss2.Data.Repositories;

public interface IHomeRepository{

   void InitialiseDB();
   List<AccountViewModel> FetchAccounts(int customerID);
   void ValidateAndStoreTransaction(Transaction transaction);
   bool ConfirmDestinationAccountExists(int accountNumber);
   Customer FetchCustomerById(int customerId);
   bool StoreCustomerDetails(Customer customer);
    
};