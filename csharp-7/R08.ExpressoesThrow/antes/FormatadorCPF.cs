using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace csharp7.R08.antes
{
    public class FormatadorCPF : IFormatador
    {
        protected readonly string formatado;
        protected readonly string substituicaoFormatado;
        protected readonly string desformatado;
        protected readonly string susbtituicaoDesformatado;

        public FormatadorCPF()
            : this(@"(\d{3})[.](\d{3})[.](\d{3})-(\d{2})", "$1.$2.$3-$4"
                  , @"(\d{3})(\d{3})(\d{3})(\d{2})", "$1$2$3$4")
        {
        }

        public FormatadorCPF(string formatado, string substituicaoFormatado, string desformatado, string susbtituicaoDesformatado)
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
