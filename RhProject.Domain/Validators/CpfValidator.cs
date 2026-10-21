namespace RhProject.Domain.Validators
{
    public static class CpfValidator
    {
        public static bool EhValido(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
                return false;

            // Rejeita CPFs como 11111111111, 22222222222 etc.
            if (cpf.Distinct().Count() == 1)
                return false;

            var soma = 0;

            for (var i = 0; i < 9; i++)
            {
                soma += (cpf[i] - '0') * (10 - i);
            }

            var resto = soma % 11;
            var primeiroDigito = resto < 2 ? 0 : 11 - resto;

            if ((cpf[9] - '0') != primeiroDigito)
                return false;

            soma = 0;

            for (var i = 0; i < 10; i++)
            {
                soma += (cpf[i] - '0') * (11 - i);
            }

            resto = soma % 11;
            var segundoDigito = resto < 2 ? 0 : 11 - resto;

            return (cpf[10] - '0') == segundoDigito;
        }
    }
}