using itApp.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Validators.Products
{
    public class CreateProductValidator:AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen urun adını bos gecmeyiniz")
                .MaximumLength(100)
                .MinimumLength(3)
                    .WithMessage("lutfen urun adını 5 ile 130 arasında girin");
            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("lütfen stok bilgisni vos gecmeyiniz")
                .Must(s => s >= 0).WithMessage("stok bilgisni 0dan buyuk girin");

            RuleFor(p => p.Price).NotEmpty().NotNull().WithMessage("lütfen fiyat bilgisni vos gecmeyiniz")
                .Must(s => s >= 0).WithMessage("fiyat bilgisni 0dan buyuk girin");
        }
    }
}
