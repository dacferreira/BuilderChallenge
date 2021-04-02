using System;

namespace Builders.Dominio.Extensions
{
    public static class StringExtension
    {
        public static bool IsPalindrome(this string frase)
        {
            frase = frase.Replace(" ", "");

            char[] letters = frase.ToCharArray();
            Array.Reverse(letters);

            string reverseWord = new string(letters);

            if (frase.RemoverAcentos().ToLower() == reverseWord.RemoverAcentos().ToLower())
                return true;
            else
                return false;
        }

        private static string RemoverAcentos(this string texto)
        {
            string comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            string semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

            for (int i = 0; i < comAcentos.Length; i++)
            {
                texto = texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
            }
            return texto;
        }
    }
}
