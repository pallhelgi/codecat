using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCat.Models;
using System.Data.Entity;
using FakeDbSet;

namespace CodeCat.Tests
{
    class MockDatabase : IAppDataContext
    {
        public MockDatabase()
        {
            DocumentModel = new InMemoryDbSet<DocumentModel>();
            ProjectModel = new InMemoryDbSet<ProjectModel>();
            UserProjectModel = new InMemoryDbSet<UserProjectModel>();
            Users = new InMemoryDbSet<ApplicationUser>();
        }
        public IDbSet<DocumentModel> DocumentModel { get; set; }
        public IDbSet<ProjectModel> ProjectModel { get; set; }
        public IDbSet<UserProjectModel> UserProjectModel { get; set; }
        public IDbSet<ApplicationUser> Users { get; set; }

        public int SaveChanges() {

            // Pretend that each entity gets a database id when we hit save.

            int changes = 0;
          //  changes += DbSetHelper.IncrementPrimaryKey<UserProjectModel>(x => x.User_ID, this.UserProjectModel);
         //   changes += DbSetHelper.IncrementPrimaryKey<Book>(x => x.BookId, this.Books);

            return changes;
        }

       

        public void Dispose()
        {
            // Do nothing!
        }


    }
}
