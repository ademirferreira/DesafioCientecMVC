using FluentValidation;

namespace DesafioCientec.Business.Models.Validations
{
    public class FundacaoValidation : AbstractValidator<Fundacao>
    {
        public FundacaoValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 400)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLenght} e {MaxLenght} caracteres");

            RuleFor(f => f.Documento.Length)
                .Equal(CnpjValidacao.TamanhoCnpj)
                .WithMessage(
                    "O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
            RuleFor(f => CnpjValidacao.Validar(f.Documento))
                .Equal(true).WithMessage("O documento fornecido é inválido");

            RuleFor(f => f.Email)
                .EmailAddress()
                .WithMessage("E-mail inválido");
        }
    }
}