using AbsolutTest.Model;
using AbsolutTest.Model.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsolutTest.ViewModel
{
    public class CustomerViewModel
    {
        private SqlServerOfWork serverOfWork;

        public CustomerViewModel()
        {
            serverOfWork = new SqlServerOfWork();
        }

        public async Task<string> UpdateCustomerInfo(Customer NewCustomer)
        {
            try
            {
                serverOfWork.Customers.Update(NewCustomer);
                await serverOfWork.Save();
                return "successfully updated";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string> SaveCustomer(Customer Customer)
        {
            try
            {
                serverOfWork.Customers.Create(Customer);
                await serverOfWork.Save();
                return "successfully saved";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string> SaveAddress(int CustomerId, string AddressRegister, string AddressAlive)
        {
            try
            {
                var changedCustomer = serverOfWork.Customers.GetItem(CustomerId);
                
                changedCustomer.RegisterAddress = AddressRegister;
                changedCustomer.AliveAddress = AddressAlive;

                serverOfWork.Customers.Update(changedCustomer);
                await serverOfWork.Save();
                return "successfully updated address";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string> SaveDocs(int CustomerId, List<Document> Documents)
        {
            try
            {
                var changedCustomer = serverOfWork.Customers.GetItem(CustomerId);
                if (Documents != null)
                    changedCustomer.Documents = Documents;

                serverOfWork.Customers.Update(changedCustomer);
                await serverOfWork.Save();
                return "successfully added documents";
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
    }
}
