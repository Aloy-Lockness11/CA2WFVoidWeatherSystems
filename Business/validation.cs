using System.Text.RegularExpressions;

namespace CA2WFVoidWeatherSystems.Business
{
    public class validation
    {
        public static String ValidateLocation(string location, String selectedOption)
        {
            String validationErrorMessage = string.Empty;
            switch (selectedOption)
            {
                case "city":
                    if (string.IsNullOrWhiteSpace(location))
                    {
                        validationErrorMessage = "City name cannot be empty.";
                    }
                    else if (!Regex.IsMatch(location, @"^[a-zA-Z\s]+$"))
                    {
                        validationErrorMessage = "City name must contain only letters and spaces.";
                    }
                    break;

                case "coordinates":
                    if (string.IsNullOrWhiteSpace(location))
                    {
                        validationErrorMessage = "Coordinates cannot be empty.";
                    }
                    else if (!Regex.IsMatch(location, @"^-?\d+(\.\d+)?,\s?-?\d+(\.\d+)?$"))
                    {
                        validationErrorMessage = "Invalid coordinates format. Use 'Longitude, Latitude'.";
                    }
                    break;

                case "ip":
                    if (string.IsNullOrWhiteSpace(location))
                    {
                        validationErrorMessage = "IP Address cannot be empty.";
                    }
                    else if (!Regex.IsMatch(location, @"^\d{1,3}(\.\d{1,3}){3}$"))
                    {
                        validationErrorMessage = "Invalid IP Address format. Use 'xxx.xxx.xxx.xxx'.";
                    }
                    break;

            }
            return validationErrorMessage;
        }
        public static string ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return "Email cannot be empty.";
            }

            // Regex for email validation
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                return "Invalid email format.";
            }

            return string.Empty; // No errors
        }
    }
}
