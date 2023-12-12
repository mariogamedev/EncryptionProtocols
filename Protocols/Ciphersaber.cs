using System.Text;

namespace EncryptionProtocols
{
    public class CipherSaber : IProtocol
    {
        private const int INITIALIZATION_VECTOR_LENGTH = 10;
        private readonly byte[] _key;
        private readonly int _iterations;

        private byte[] S;    
        private byte[] _initializationVector;
        private byte[] _ciphertext;
        private byte[] _keySetupInput;

        public CipherSaber(byte[] key, int iterations)
        {
            _key = key;
            _iterations = iterations;
        }

        public string Decrypt(byte[] encryptedMessage)
        {
            string decryptedMessage = string.Empty;

            FindInitializationVectorFromEncryption(encryptedMessage);
            FindCipherTextFromEncryption(encryptedMessage);
            BuildKeySetupInput();
            KeySetup();
            byte[] decryption = Process();
            decryptedMessage = Encoding.UTF8.GetString(decryption);

            return decryptedMessage;
        }

        private void FindInitializationVectorFromEncryption(byte[] encryptedMessage)
        {
            _initializationVector = new byte[INITIALIZATION_VECTOR_LENGTH];
            Array.Copy(encryptedMessage, 0, _initializationVector, 0, _initializationVector.Length);
        }

        private void FindCipherTextFromEncryption(byte[] encryptedMessage)
        {
            _ciphertext = new byte[encryptedMessage.Length - _initializationVector.Length];
            Array.Copy(encryptedMessage, _initializationVector.Length, _ciphertext, 0, _ciphertext.Length);     
        }

        private void BuildKeySetupInput()
        {
            _keySetupInput = new byte[_key.Length + _initializationVector.Length];
            Array.Copy(_key, 0, _keySetupInput, 0, _key.Length);
            Array.Copy(_initializationVector, 0, _keySetupInput, _key.Length, _initializationVector.Length);
        }

        public void KeySetup()
        {
            InitializeS();

            int i = 0;
            for (int iteration = 0; iteration < _iterations; iteration++)
            {
                for (int j = 0; j < 256; j++)
                {
                    i = (i + S[j] + _keySetupInput[j % _keySetupInput.Length]) % 256;
                    Swap(ref S[j], ref S[i]);
                }
            }
        }

        private void InitializeS()
        {
            S = new byte[256];
            for (int i = 0; i < 256; i++)
            {
                S[i] = (byte) i;
            }
        }

        public byte[] Process()
        {
            int i = 0, j = 0;
            byte[] result = new byte[_ciphertext.Length];

            for (int k = 0; k < _ciphertext.Length; k++)
            {
                i = (i + 1) % 256;
                j = (j + S[i]) % 256;
                Swap(ref S[i], ref S[j]);
                result[k] = (byte) (S[(S[i] + S[j]) % 256] ^ _ciphertext[k]);
            }
            return result; 
        }

        private void Swap(ref byte a, ref byte b)
        {
            if (a != b)
            {
                byte aux = new byte(); 
                aux = a;
                a = b; 
                b = aux;
            }
        }
    }
}