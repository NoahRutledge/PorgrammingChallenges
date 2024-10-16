using System;
using System.Collections.Generic;

namespace CodeChecker.Models;

public partial class ChallengeTestCase
{
    public int Id { get; set; }

    public string TestCases { get; set; } = null!;

    public virtual ChallengeFullInfo IdNavigation { get; set; } = null!;
}
