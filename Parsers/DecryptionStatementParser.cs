using System.Text;

namespace EncryptionProtocols
{
	public class DecryptionStatementParser : IStatementParser
    {
        private string[] _input;

        private string _encryptedMessage;
        private Byte[] _key;
        private int _iterations;

        public Byte[] Key { get { return _key; } }
        public string EncryptedMessage { get { return _encryptedMessage; } }
        public int Iterations { get { return _iterations; } }

        public DecryptionStatementParser(string[] input)
        {
            _input = input;
        }

        public void Parse()
        {
            _key = Encoding.UTF8.GetBytes(_input[0]);
            _encryptedMessage = _input[1];
            _iterations = int.Parse(_input[2]);
        }
    }
}