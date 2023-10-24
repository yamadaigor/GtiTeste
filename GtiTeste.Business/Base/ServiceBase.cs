using FluentValidation;
using System.Collections.Generic;

namespace GtiTeste.Business.Base
{
    public abstract class ServiceBase
    {
        protected List<string> MensagensErro { get; set; }
        protected ServiceBase()
        {
            MensagensErro = new List<string>();
        }
        protected bool Validar<Ent, Val>(Ent entidade, Val validador) where Val : AbstractValidator<Ent> where Ent : EntidadeBase
        {
            var resultadoValidacao = validador.Validate(entidade);
           
            if (!resultadoValidacao.IsValid)
            {
                foreach (var error in resultadoValidacao.Errors)
                {
                    MensagensErro.Add(error.ErrorMessage);
                }
            }

            return resultadoValidacao.IsValid;
        }
    }
}
