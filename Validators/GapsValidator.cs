
namespace EncryptionProtocols
{
    public class GapsValidator : IEncryptionValidator
    {
        private const char SPACE_CHARACTER = ' ';

        public FormatError Error => FormatError.GAPS;

        public bool IsValid(string message)
        {
            if (!message.Contains(SPACE_CHARACTER))
            {
                return true;
            }

            return false;
        }
    }
}