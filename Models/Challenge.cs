using System;
using System.Collections.Generic;
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

    public class ChallengeBaseInfo
    {
        public int Id { get; set; }
        public string ChallengeName { get; set; } = null;
        public double Difficulty { get; set; }


        public ChallengeBaseInfo() { }

        public ChallengeBaseInfo(int anId, string aChallengeName, double aDifficulty)
        {
            Id = anId;
            ChallengeName = aChallengeName;
            Difficulty = aDifficulty;
        }

        public string DifficultyFancyFormat()
        {
            return string.Format("{0:0.0}", Difficulty);
        }
    }

    public class ChallengeFullInfo : ChallengeBaseInfo
    {
        public string AuthorName { get; set; } = null!;

        public string Description { get; set; } = null!;
    }

    public class ChallengeSubmission
    {
        public int Id { get; set; }
        public required IFormFile File { get; set; }
    }
}