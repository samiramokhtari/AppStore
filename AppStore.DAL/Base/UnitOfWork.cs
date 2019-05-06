using AppStore.DAL;
using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.DAL
{
    public class UnitOfWork : IDisposable
    {
        static AppStoreDbContext context = new AppStoreDbContext();

        private BaseBs<Product> productRepository;

        public BaseBs<Product> ProductRepository
        {
            get
            {

                if (productRepository == null)
                    productRepository = new BaseBs<Product>(context);
                

                return productRepository;
            }
        }




        private BaseBs<Comment> commentRepository;

        public BaseBs<Comment> CommentReppository
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new BaseBs<Comment>(context);

                return commentRepository;
            }
        }


        private BaseBs<Group> groupRepository;

        public BaseBs<Group> GroupRepository
        {
            get
            {
                if (groupRepository == null)
                    groupRepository = new BaseBs<Group>(context);

                return groupRepository;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //context.Dispose();
                }
            }

            this.disposed = true;
        }
    }
}
