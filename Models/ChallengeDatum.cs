using System;
using System.Collections.Generic;

namespace CodeChecker.Models;

public partial class ChallengeDatum
{
    public int Id { get; set; }

    public string ChallengeName { get; set; } = null!;

    public double Difficulty { get; set; }

    public string AuthorName { get; set; } = null!;

    public string Description { get; set; } = null!;
}
