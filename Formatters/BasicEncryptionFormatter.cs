namespace EncryptionProtocols
{
    public class BasicEncryptionFormatter : IFormatter
    {
        private IEncryptionSetValidator _encryptionSetValidator;
        private Dictionary<FormatError, IFormatter> _formatErrorsSolvers;
        private string _encryptedMessage;

        public BasicEncryptionFormatter(IEncryptionSetValidator encryptionSetValidator, Dictionary<FormatError, IFormatter> formatErrorSolvers)
        {
            _encryptionSetValidator = encryptionSetValidator;
            _formatErrorsSolvers = formatErrorSolvers;
            _encryptedMessage = string.Empty;
        }

        public string Format(string encryptedMessage)
        {
            _encryptedMessage = encryptedMessage;

            if (!_encryptionSetValidator.IsValid(_encryptedMessage))
            {
                List<FormatError> errors = _encryptionSetValidator.Errors;
                SolveFormatErrors(errors);
            }

            return _encryptedMessage;
        }

        private void SolveFormatErrors(List<FormatError> errors)
        {
            foreach (FormatError error in errors)
            {
                _encryptedMessage = _formatErrorsSolvers[error].Format(_encryptedMessage);
            }
        }
    }
}