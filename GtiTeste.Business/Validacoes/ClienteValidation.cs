using FluentValidation;
using GtiTeste.Business.Entidades;
using GtiTeste.Business.Utils;

namespace GtiTeste.Business.Validacoes
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(c => c.Cpf)
              .NotEmpty()
              .NotNull().WithMessage("O Campo {PropertyName} é obrigatório");

            RuleFor(c => c.Cpf == null ? 0 : c.Cpf.Length).Equal(CpfValidacao.TamanhoCpf)
            .WithMessage("O campo CPF precisa ter tamanho {ComparisonValue}");

            RuleFor(c => CpfValidacao.Validar(c.Cpf == null ? "" : c.Cpf)).Equal(true)
                .WithMessage("Cpf Inválido.");
            
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O Campo {PropertyName} é obrigatório");

            RuleFor(c => c.DataNascimento)
             .NotEmpty().WithMessage("O Campo {PropertyName} é obrigatório");

            RuleFor(c => c.DataNascimento != System.DateTime.MinValue).Equal(true)
             .NotEmpty().WithMessage("O Campo {PropertyName} é obrigatório");

            RuleFor(c => c.DataExpedicao)
             .NotEmpty().WithMessage("O Campo {PropertyName} é obrigatório");

            RuleFor(c => c.DataExpedicao != System.DateTime.MinValue).Equal(true)
            .NotEmpty().WithMessage("O Campo {PropertyName} é obrigatório");

            RuleFor(c => c.Sexo)
              .NotEmpty().WithMessage("O Campo {PropertyName} é obrigatório");

            RuleFor(c => c.EstadoCivil)
              .NotEmpty().WithMessage("O Campo {PropertyName} é obrigatório");
        }
    }
}
