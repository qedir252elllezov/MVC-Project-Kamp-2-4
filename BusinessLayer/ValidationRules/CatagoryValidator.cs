using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
   public class CatagoryValidator:AbstractValidator<Catagory>
    {
        public CatagoryValidator()
        {
            RuleFor(x => x.CatagoryName).NotEmpty().WithMessage("Kategori Adini Bos girmissiniz!");
            RuleFor(x => x.CatagoryDescription).NotEmpty().WithMessage("Bu hisse bos gecilmez");
            RuleFor(x => x.CatagoryName).MaximumLength(20).WithMessage("ad 20 den cox olammaz");
            RuleFor(x => x.CatagoryName).MinimumLength(3).WithMessage("ad 3 den az olammaz!");
        }
    }
}
