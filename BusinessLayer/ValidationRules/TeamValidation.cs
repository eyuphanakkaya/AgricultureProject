using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class TeamValidation : AbstractValidator<Team>
    {
        public TeamValidation()
        {
            RuleFor(x => x.PersonName).NotEmpty().WithMessage("Takım Arkadaş kısmını boş geçemezsiniz");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Görevler Boş geçilemez");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim yolu boş geçilemez");

        }
    }
}
