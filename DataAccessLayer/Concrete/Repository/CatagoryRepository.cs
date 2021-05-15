﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.Repository
{
    public class CatagoryRepository : ICatagoryDal
    {
        Context c = new Context();
        DbSet<Catagory> _object;
        public void Delete(Catagory p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public Catagory Get(Expression<Func<Catagory, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Catagory p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<Catagory> List()
        {
            return _object.ToList();
        }

        public List<Catagory> List(Expression<Func<Catagory, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Catagory p)
        {
            c.SaveChanges(); 
        }
    }

       
        }
       
        
          
       

        
           

