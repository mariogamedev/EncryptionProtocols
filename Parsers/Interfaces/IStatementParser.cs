namespace EncryptionProtocols
{
	public interface IStatementParser
	{
        public Byte[] Key { get;}
        public string EncryptedMessage { get;}
        public int Iterations { get;}
		public void Parse();
	}
}