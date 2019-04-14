﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Models;
using AppStore.DAL;

namespace AppStore.Biz
{
    public class CommentBiz
    {
        public IEnumerable<Comment> Get(int id)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
               return unit.CommentReppository.GetAllItems.Where(x => x.Product.Id == id).ToList();
            }
        }
    }
}