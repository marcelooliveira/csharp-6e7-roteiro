using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace csharp7.R08.antes
{
    public class FormatadorCNPJ : IFormatador
    {
        protected readonly string formatado;
        protected readonly string substituicaoFormatado;
        protected readonly string desformatado;
        protected readonly string susbtituicaoDesformatado;

        public FormatadorCNPJ()
            : this(@"(\d{2})[.](\d{3})[.](\d{3})\/(\d{4})-(\d{2})", "$1.$2.$3/$4-$5", @"(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})", "$1$2$3$4$5")
        {
        }

        public FormatadorCNPJ(string formatado, string substituicaoFormatado, string desformatado, string susbtituicaoDesformatado)
        {
            this.formatado = formatado;
            this.substituicaoFormatado = substituicaoFormatado;
            this.desformatado = desformatado;
            this.susbtituicaoDesformatado = susbtituicaoDesformatado;
        }

        public string Formatar(string valorDesformatado)
        {
            if (valorDesformatado == null)
            {
                throw new ArgumentNullException(nameof(valorDesformatado), "Valor não pode ser nulo.");
            }
            return new Regex(desformatado).Replace(valorDesformatado, substituicaoFormatado);
        }

        public string Desformatar(string valorFormatado)
        {
            if (valorFormatado == null)
            {
                throw new ArgumentNullException(nameof(valorFormatado), "Valor não pode ser nulo.");
            }

            if (new Regex(desformatado).IsMatch(valorFormatado))
                return valorFormatado;

            return new Regex(formatado).Replace(valorFormatado, susbtituicaoDesformatado);
        }

        public bool EstaFormatado(String valor)
        {
            return new Regex(formatado).IsMatch(valor);
        }

        public bool PodeSerFormatado(String valor)
        {
            return new Regex(desformatado).IsMatch(valor);
        }
    }
}
