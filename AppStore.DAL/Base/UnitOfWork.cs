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
        
     

        private BaseBs<ProductImage> productImageRepository;
        public BaseBs<ProductImage> ProductImageRepository
        {
            get
            {

                if (productImageRepository == null)
                    productImageRepository = new BaseBs<ProductImage>(context);


                return productImageRepository;
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

        private BaseBs<UserDownload> userDownloadRepository;

        public BaseBs<UserDownload> UserDownloadRepository
        {
            get
            {

                if (userDownloadRepository == null)
                    userDownloadRepository = new BaseBs<UserDownload>(context);


                return userDownloadRepository;
            }
        }
        private BaseBs<BookMark> bookMarksRepository;

        public BaseBs<BookMark> BookMarksRepository
        {
            get
            {

                if (bookMarksRepository == null)
                    bookMarksRepository = new BaseBs<BookMark>(context);


                return bookMarksRepository;
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
