using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models.Repository;

namespace AbsolutTest.Model.Repository
{
    class CustomerRepository : IRepository<Customer>
    {
        private AbsolutBankDb db;
        public CustomerRepository(AbsolutBankDb db)
        {
            this.db = db;
        }

        public void Create(Customer item)
        {
            db.Customer.Add(item);
        }

        public void Delete(int id)
        {
            Customer customer = db.Customer.Find(id);
            if (customer != null)
                db.Customer.Remove(customer);
        }

        public IEnumerable<Customer> GetAll()
        {
            return db.Customer;
        }

        public Customer GetItem(int id)
        {
            return db.Customer.Find(id);
        }

        public void Update(Customer item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
