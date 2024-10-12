using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

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

    /// <summary>
    /// Minimal info needed to display and find a challenge.  Shown on main page.
    /// </summary>
    public class ChallengeBasicInfo
    { 
        public ChallengeBasicInfo(int anId, string aChallengeName, string aDifficulty)
        {
            Id = anId;
            Name = aChallengeName;
            Difficulty = aDifficulty;
        }

        public string Name { get; private set; } = "";
        // Enforce being a number in field
        public string Difficulty { get; private set; } = "0.0";
        public int Id = 0;

        // This is to make initial testing easier and should be individualized to the user and not a value associated with the challenge
        public ChallengeStatus Status { get; private set; } = ChallengeStatus.NotSubmitted;
    }

    /// <summary>
    /// The full class info needed to show the user how to complete the challenge
    /// </summary>
    public class ChallengeFullInfo : ChallengeBasicInfo
    {
        public ChallengeFullInfo(int anId, string aChallengeName, string aDifficulty, string anAuthor, string aDescription) : base(anId, aChallengeName, aDifficulty)
        {
            Author = anAuthor;
            Description = aDescription;
        }

        public string Author { get; private set; } = "";
        public string Description { get; private set; } = "";
    }
}
