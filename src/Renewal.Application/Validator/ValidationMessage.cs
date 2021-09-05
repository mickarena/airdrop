namespace Renewal.Application.Validator
{
    public static class ValidationMessage
    {
        public static string FreeStyle(string propertyName, string message)
        {
            return $"{propertyName} {message}";
        }

        public static string Required(string propertyName)
        {
            return FreeStyle(propertyName, "is required.");
        }

        public static string NotEmpty(string propertyName)
        {
            return FreeStyle(propertyName, "must be not empty.");
        }

        public static string Invalid(string propertyName)
        {
            return FreeStyle(propertyName, "is invalid.");
        }

        public static string Incorrect(string propertyName)
        {
            return FreeStyle(propertyName, "is incorrect.");
        }

        public static string OutOfRange(string propertyName)
        {
            return FreeStyle(propertyName, "is out of acceptable range.");
        }

        public static string MaximumLength(string propertyName, int maxLength)
        {
            return FreeStyle(propertyName, $"cannot be over {maxLength} characters.");
        }

        public static string MinimumLength(string propertyName, int maxLength)
        {
            return FreeStyle(propertyName, $"cannot be less than {maxLength} characters.");
        }

        public static string GreaterValue(string propertyName, int value)
        {
            return FreeStyle(propertyName, $"must be greater than {value}.");
        }

        public static string GreaterOrEqualValue(string propertyName, int value)
        {
            return FreeStyle(propertyName, $"must be greater than or equal {value}.");
        }

        public static string GreaterOrEqualValue(string propertyName, string type, int value)
        {
            return FreeStyle(propertyName, $"must be {type} greater than or equal {value}.");
        }

        public static string NotRecognizedInUK(string propertyName)
        {
            return $"This is not a recognized UK {propertyName.ToLower()} format.";
        }

        public static string MustBePositiveNumberInRange(string propertyName, double from, double to)
        {
            return $"{propertyName} must be a positive number from {from} ~ {to}.";
        }

        public static string Unacceptable(string propertyName)
        {
            return FreeStyle(propertyName, "is unacceptable.");
        }

        public static string MustBeNumber(string propertyName)
        {
            return FreeStyle(propertyName, "must be numbers.");
        }

        public static string MustBeNumberInRange(string propertyName, int start, int end)
        {
            return FreeStyle(propertyName, $"must be a number between {start} and {end}.");
        }

        public static string HasDuplicateItems(string propertyName)
        {
            return FreeStyle(propertyName, "has duplicate items.");
        }

        public static string ElementsMustNotNull(string propertyName)
        {
            return FreeStyle(propertyName, "must not contains null element.");
        }
    }
}
