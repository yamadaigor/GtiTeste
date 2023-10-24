using FluentValidation;
using GtiTeste.Business.Entidades;

namespace GtiTeste.Business.Validacoes
{
    public class EnderecoValidation : AbstractValidator<Endereco>
    {
        public EnderecoValidation()
        {
            RuleFor(c => c.Cep)
             .NotEmpty().WithMessage("O Campo {PropertyName} é obrigatório");

            RuleFor(c => c.Logradouro)
             .NotEmpty().WithMessage("O Campo {PropertyName} é obrigatório");

            RuleFor(c => c.Numero)
             .NotEmpty().WithMessage("O Campo {PropertyName} é obrigatório");

            RuleFor(c => c.Bairro)
             .NotEmpty().WithMessage("O Campo {PropertyName} é obrigatório");

            RuleFor(c => c.Cidade)
             .NotEmpty().WithMessage("O Campo {PropertyName} é obrigatório");

            RuleFor(c => c.UF)
             .NotEmpty().WithMessage("O Campo {PropertyName} é obrigatório");
        }
    }
}
