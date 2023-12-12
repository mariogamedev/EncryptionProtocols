namespace EncryptionProtocols
{
    public class GapsEncryptionFormatter : IFormatter
    {
        public string Format(string encryptedMessage)
        {
            return encryptedMessage.Replace(" ", "");
        }
    }
}