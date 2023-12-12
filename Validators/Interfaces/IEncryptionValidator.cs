namespace EncryptionProtocols
{
    public interface IEncryptionValidator
    {
        public FormatError Error { get; }
        public bool IsValid(string message);
    }
}