using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public  interface ICatagoryService
    {
        List<Catagory> GetList();
        void CatagoryAddBL(Catagory catagory);
        Catagory GetID(int id);
        void CatagoryDelete(Catagory catagory);
        void CatagoryUpdate(Catagory catagory);
    }
}
