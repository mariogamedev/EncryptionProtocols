
namespace EncryptionProtocols
{
    public class Solver
    {
        private static IStatementParser _statementParser;
        private static Decrypter _decrypter;

        static void Main(string[] args)
        {                
            _statementParser = new DecryptionStatementParser(args);
            _statementParser.Parse();
            List<IEncryptionValidator> validators = new List<IEncryptionValidator>();
            validators.Add(new GapsValidator());
            
            IEncryptionSetValidator setValidator = new FormatValidator(validators);

            Dictionary<FormatError, IFormatter> formatters = new  
            Dictionary<FormatError, IFormatter>();
            formatters.Add(FormatError.GAPS, new GapsEncryptionFormatter());

            IFormatter encryptionFormatter = new BasicEncryptionFormatter
            (setValidator,formatters);
            _decrypter = new Decrypter(new CipherSaber(_statementParser.Key, _statementParser.Iterations), encryptionFormatter);

            _decrypter.Decrypt(_statementParser.EncryptedMessage);
        }
    }
}