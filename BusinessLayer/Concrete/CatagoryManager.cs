using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CatagoryManager :ICatagoryService
    {
        ICatagoryDal _catagorydal;

        public CatagoryManager(ICatagoryDal catagorydal)
        {
            _catagorydal = catagorydal;
        }
     

        public void CatagoryAddBL(Catagory catagory)
        {
            _catagorydal.Insert(catagory);
        }

        public void CatagoryDelete(Catagory catagory)
        {
               _catagorydal.Delete(catagory);
        }

        public void CatagoryUpdate(Catagory catagory)
        {
            _catagorydal.Update(catagory);
        }

        public Catagory GetID(int id)
        {
            return _catagorydal.Get(x => x.CatagoryID == id);
        }

        public List<Catagory> GetList()
        {
            return _catagorydal.List();
        }
    }
}

