using AbsolutTest.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsolutTest.Model.UnitOfWork
{
    class SqlServerOfWork : IDisposable
    {
        private AbsolutBankDb db = new AbsolutBankDb();

        // sql server repositories
        private CustomerRepository CustomerRepository;
        private DocumentRepository DocumentRepository;

        public CustomerRepository Customers
        {
            get
            {
                if (CustomerRepository == null)
                    CustomerRepository = new CustomerRepository(db);
                return CustomerRepository;
            }
        }

        public DocumentRepository Documents
        {
            get
            {
                if (DocumentRepository == null)
                    DocumentRepository = new DocumentRepository(db);
                return DocumentRepository;
            }
        }

        public SqlServerOfWork()
        {
        }

        public Task<int> Save()
        {
            return db.SaveChangesAsync();
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
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
