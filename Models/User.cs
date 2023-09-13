#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.Globalization;
namespace DateValidator.Models;

public class User
{
[Required]
[NoDate]
public string Time {get;set;} 
}

public class NoDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        string pattern = "yyyy-MM-dd";
        DateTime parsedDate;
        DateTime.TryParseExact(value.ToString(),pattern,null,DateTimeStyles.None, out parsedDate);
        DateTime dt1 = DateTime.Today;
        int result = DateTime.Compare(parsedDate,dt1);
        if (result > 0)
            return new ValidationResult("Date surpass the current date !!!");
        return ValidationResult.Success;
    }
}