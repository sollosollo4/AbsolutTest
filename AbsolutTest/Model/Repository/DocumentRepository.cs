using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models.Repository;

namespace AbsolutTest.Model.Repository
{
    class DocumentRepository : IRepository<Document>
    {
        private AbsolutBankDb db;
        public DocumentRepository(AbsolutBankDb db)
        {
            this.db = db;
        }

        public void Create(Document item)
        {
            db.Document.Add(item);
        }

        public void Delete(int id)
        {
            Document ducoment = db.Document.Find(id);
            if (ducoment != null)
                db.Document.Remove(ducoment);
        }

        public IEnumerable<Document> GetAll()
        {
            return db.Document;
        }

        public Document GetItem(int id)
        {
            return db.Document.Find(id);
        }

        public void Update(Document item)
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
