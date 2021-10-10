using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(w => w.WriterName).NotEmpty().WithMessage("Yazar adı soyadı kısmı boş geçilemez.");
            RuleFor(w => w.WriterMail).NotEmpty().WithMessage("Mail adresi boş geçilemez.");
            RuleFor(w => w.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez.");
            RuleFor(w => w.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karekter girişi yapınız.");
            RuleFor(w => w.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karekter girişi yapınz.");

            RuleFor(w => w.WriterPassword).Must(upperCaseControl).WithMessage("Parolanın içerisinde en az bir tane büyük harf olmalıdır.");
            RuleFor(w => w.WriterPassword).Must(lowerCaseControl).WithMessage("Parolanın içerisinde en az bir tane küçük harf olmalıdır.");
            RuleFor(w => w.WriterPassword).Must(digitControl).WithMessage("Parolanın içerisinde en az bir tane rakam olmalıdır.");
        }

        private bool digitControl(string arg)
        {
            foreach (var letter in arg)
            {
                if (Char.IsDigit(letter))
                {
                    return true;
                }
            }
            return false;
        }

        private bool lowerCaseControl(string arg)
        {
            foreach (var letter in arg)
            {
                if (Char.IsLower(letter))
                {
                    return true;
                }
            }
            return false;
        }

        private bool upperCaseControl(string arg)
        {
            foreach (var letter in arg)
            {
                if (Char.IsUpper(letter))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
