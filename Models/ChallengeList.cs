namespace CodeChecker.Models
{
    public class ChallengeList
    {
        private List<Challenge> _allChallenges = new List<Challenge>();

        public List<Challenge> GetRefreshedChallengeList()
        {
            if(_allChallenges.Count() == 0)
                _allChallenges.Add(new Challenge("Noah", "Fizzbuzz", "1.0", "You know fizzbuzz"));
            //DB grab
            return _allChallenges;
        }

        public void PostNewChallenge(Challenge aNewChallenge)
        {
            //DB post
        }
    }
}
