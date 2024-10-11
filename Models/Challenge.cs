using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CodeChecker.Models
{
    public enum ChallengeStatus
    {
        [Description("Not Submitted")]
        NotSubmitted,
        [Description("In Progress")]
        InProgress,
        Failed,
        Pass
    }

    public static class Extensions
    {
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string? name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo? field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute? attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
                return name;
            }
            return "";
        }
    }

    public class Challenge
    {
        public Challenge(string anAuthorName, string aChallengeName, string aDifficulty, string aDescription)
        {
            Author = anAuthorName;
            Name = aChallengeName;
            Difficulty = aDifficulty;
            Description = aDescription;
        }
        public string Name { get; private set; } = "";
        
        // Enforce being a number in field
        public string Difficulty { get; private set; } = "0.0";

        // This is to make initial testing easier and should be individualized to the user and not a value associated with the challenge
        public ChallengeStatus Status { get; private set; } = ChallengeStatus.NotSubmitted;
        
        public string Author { get; private set; } = "";
        public string Description { get; private set; } = "";
    }
}
