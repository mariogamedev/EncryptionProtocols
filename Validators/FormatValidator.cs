namespace EncryptionProtocols
{
    public class FormatValidator : IEncryptionSetValidator
    {
        private List<IEncryptionValidator> _validators;
        private List<FormatError> _errors;

        public List<FormatError> Errors => _errors;

        public FormatValidator(List<IEncryptionValidator> validators)
        {
            _validators = validators;
            _errors = new List<FormatError>();
        }

        public bool IsValid(string message)
        {
            bool isValid = true;
            foreach (IEncryptionValidator validator in _validators)
            {
                if (!validator.IsValid(message))
                {
                    _errors.Add(validator.Error);
                    isValid = false;
                }
            }

            if (isValid)
            {
                return true;
            }
            
            return false;
        }
    }
}