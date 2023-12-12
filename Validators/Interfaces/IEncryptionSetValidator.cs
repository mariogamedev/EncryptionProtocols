namespace EncryptionProtocols
{
    public interface IEncryptionSetValidator
    {
        public List<FormatError> Errors { get; }
        public bool IsValid(string message);
    }
}