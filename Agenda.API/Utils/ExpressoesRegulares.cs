namespace Agenda.API.Utils
{
    public static class ExpressoesRegulares
    {
        // samuel@teste.io
        public const string EMAIL = @"[a-zA-Z0-9\._-]{3,}@[a-zA-Z0-9\._-]{3,}\.[a-zA-Z]{2,}";

        // (54) 99988.7766 ou +55 (54) 99955.4433
        public const string TELEFONE = @"[0-9\+\(\)\.\ -]{8,}";
    }
}