
namespace EncryptionProtocols
{
    public class LengthValidator : IEncryptionValidator
    {
        public FormatError Error => FormatError.GAPS;

        public bool IsValid(string message)
        {
            if (message.Length % 2 == 0)
            {
                return true;
            }

            return false;
        }
    }
}