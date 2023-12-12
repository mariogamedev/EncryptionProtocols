namespace EncryptionProtocols
{
    public class Decrypter
    {
        private IFormatter _formatter;
        private IProtocol _protocol;

        public Decrypter(IProtocol protocol, IFormatter formatter)
        {
            _protocol = protocol;
            _formatter = formatter;
        }

        public void Decrypt(string encryptedData)
        {
            byte[] formattedEncryption = Convert.FromHexString(_formatter.Format(encryptedData));
            string decryptedMessage = _protocol.Decrypt(formattedEncryption);
            Console.WriteLine(decryptedMessage);
        }
    }
}