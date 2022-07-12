namespace RestauratesAvaliacoes.Api.Domain.Enums
{
    public enum ECozinha
    {
        Brasileira =1,
        Italiana = 2,
        Arabe = 3,
        Japosena =4,
        FastFood = 5
    }

    public static class ECozinhaHelper
    {
        public static ECozinha ConverterDeInteiro(int valor)
        {
            if (Enum.TryParse(valor.ToString(), out ECozinha cozinha))
                return cozinha;

            throw new ArgumentOutOfRangeException("cozinha");
        }
    }
}
