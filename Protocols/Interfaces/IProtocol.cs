namespace EncryptionProtocols
{
    public interface IProtocol
    {
        public string Decrypt(byte[] encryptedMessage);
    }
}