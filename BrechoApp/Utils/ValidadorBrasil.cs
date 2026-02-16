using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BrechoApp.Utils
{
    public static class ValidadorBrasil
    {
        // ✅ CPF
        public static bool CPFValido(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = Regex.Replace(cpf, "[^0-9]", "");

            if (cpf.Length != 11)
                return false;

            if (new string(cpf[0], cpf.Length) == cpf)
                return false;

            int[] mult1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * mult1[i];

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            string digito = resto.ToString();
            tempCpf += digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * mult2[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }

        // ✅ CNPJ
        public static bool CNPJValido(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return false;

            cnpj = Regex.Replace(cnpj, "[^0-9]", "");

            if (cnpj.Length != 14)
                return false;

            // Verifica se todos os dígitos são iguais
            if (new string(cnpj[0], cnpj.Length) == cnpj)
                return false;

            // Calcula primeiro dígito verificador
            int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(cnpj[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            string digito = resto.ToString();

            // Calcula segundo dígito verificador
            int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(cnpj[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito += resto.ToString();

            return cnpj.EndsWith(digito);
        }

        // ✅ Detecta se o documento é CPF, CNPJ ou inválido
        public static string DetectarTipoDocumento(string documento)
        {
            if (string.IsNullOrWhiteSpace(documento))
                return "Inválido";

            documento = Regex.Replace(documento, "[^0-9]", "");

            if (documento.Length == 11)
                return CPFValido(documento) ? "CPF" : "Inválido";

            if (documento.Length == 14)
                return CNPJValido(documento) ? "CNPJ" : "Inválido";

            return "Inválido";
        }

        // ✅ Valida CPF ou CNPJ automaticamente
        public static bool DocumentoValido(string documento)
        {
            if (string.IsNullOrWhiteSpace(documento))
                return false;

            documento = Regex.Replace(documento, "[^0-9]", "");

            if (documento.Length == 11)
                return CPFValido(documento);

            if (documento.Length == 14)
                return CNPJValido(documento);

            return false;
        }

        // ✅ E-mail
        public static bool EmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase);
        }

        // ✅ Telefone brasileiro (com DDD)
        public static bool TelefoneValido(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
                return false;

            telefone = Regex.Replace(telefone, "[^0-9]", "");

            return telefone.Length == 10 || telefone.Length == 11;
        }

        // ✅ PIX (CPF, CNPJ, e-mail, telefone ou chave aleatória)
        public static bool PixValido(string pix)
        {
            if (string.IsNullOrWhiteSpace(pix))
                return false;

            pix = pix.Trim();

            if (CPFValido(pix)) return true;

            if (CNPJValido(pix)) return true;

            if (EmailValido(pix)) return true;

            if (TelefoneValido(pix)) return true;

            if (Guid.TryParse(pix, out _)) return true;

            return false;
        }

        // ✅ Agência bancária (4 dígitos)
        public static bool AgenciaValida(string agencia)
        {
            if (string.IsNullOrWhiteSpace(agencia))
                return false;

            return Regex.IsMatch(agencia, @"^\d{4}$");
        }

        // ✅ Conta bancária (6 a 12 dígitos)
        public static bool ContaValida(string conta)
        {
            if (string.IsNullOrWhiteSpace(conta))
                return false;

            return Regex.IsMatch(conta, @"^\d{6,12}$");
        }
    }
}
