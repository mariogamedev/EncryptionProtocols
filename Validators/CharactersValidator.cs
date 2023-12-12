using System.Text.RegularExpressions;

namespace EncryptionProtocols
{
    public class CharactersValidator : IEncryptionValidator
    {
        public FormatError Error => FormatError.CHARACTERS;

        public bool IsValid(string message)
        {
            if (Regex.IsMatch(message, "^[0-9a-fA-F]*$"))
            {
                return true;
            }

            return false;
        }
    }
}