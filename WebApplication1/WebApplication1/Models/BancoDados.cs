namespace WebApplication1.Models
{
    public static class BancoDados
    {
        public static List<Resposta> respostas = new List<Resposta>();

        public static bool VerificaContem(string r)
        {
            for (int i = 0; i < respostas.Count; i++)
            {
                if (respostas[i].Email.Equals(r))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
