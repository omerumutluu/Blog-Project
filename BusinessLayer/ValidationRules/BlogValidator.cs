using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(b => b.BlogTitle).NotEmpty().WithMessage("Blog başlığını boş geçemezsiniz.");
            RuleFor(b => b.BlogContent).NotEmpty().WithMessage("Blog içeriğini boş geçemezsiniz.");
            RuleFor(b => b.BlogImage).NotEmpty().WithMessage("Blog görselini boş geçemezsiniz.");
            RuleFor(b => b.BlogTitle).MaximumLength(150).WithMessage("Blog başlığı için 150 karekterden fazla karekter girilemez.");
            RuleFor(b => b.BlogTitle).MinimumLength(5).WithMessage("Blog başlığı için 5 karekterden az karekter girilemez.");
        }
    }
}
