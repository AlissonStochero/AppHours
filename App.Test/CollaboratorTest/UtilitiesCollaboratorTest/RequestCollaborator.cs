using App.Domain.Entities;
using App.Domain.ValueObjects;
using Bogus;

namespace App.Test.CollaboratorTest.UtilitiesCollaboratorTest;

public class RequestCollaborator
{
    public static Collaborator MakeCollaboratorRequest(int lenthPassword = 6)
    {
        return new Faker<Collaborator>()
            .RuleFor(c => c.Name, f => new Name(f.Person.FirstName, f.Person.LastName))
            .RuleFor(c => c.Email, f => new Email(f.Internet.Email()))
            .RuleFor(c => c.KeyPassword, f => new Password(GenerateRandomPassword(lenthPassword)))
            .Generate();
    }
    public static string GenerateRandomPassword(int length)
    {
        string specialCharacters = "!@#$%^&*()";
        string uppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string lowercaseLetters = "abcdefghijklmnopqrstuvwxyz";

        string password = "";

        Random random = new Random();

        // Ensure at least one character from each category
        password += specialCharacters[random.Next(specialCharacters.Length)];
        password += uppercaseLetters[random.Next(uppercaseLetters.Length)];
        password += lowercaseLetters[random.Next(lowercaseLetters.Length)];

        // Fill the remaining characters randomly
        int remainingLength = length - password.Length;

        for (int i = 0; i < remainingLength; i++)
        {
            int characterType = random.Next(3);

            if (characterType == 0)
            {
                password += specialCharacters[random.Next(specialCharacters.Length)];
            }
            else if (characterType == 1)
            {
                password += uppercaseLetters[random.Next(uppercaseLetters.Length)];
            }
            else if (characterType == 2)
            {
                password += lowercaseLetters[random.Next(lowercaseLetters.Length)];
            }
        }

        // Shuffle the password characters
        password = new string(password.ToCharArray().OrderBy(c => random.Next()).ToArray());

        return password;
    }
}
