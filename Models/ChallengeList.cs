namespace CodeChecker.Models
{
    public class ChallengeList
    {
        private List<ChallengeBasicInfo> _allChallengesBasicInfo = new List<ChallengeBasicInfo>();

        public List<ChallengeBasicInfo> GetRefreshedChallengeBasicInfoList()
        {
            if(_allChallengesBasicInfo.Count() == 0)
                _allChallengesBasicInfo.Add(new ChallengeBasicInfo(1, "Fizzbuzz", "1.0"));
            //DB grab
            return _allChallengesBasicInfo;
        }

        public void PostNewChallenge(ChallengeFullInfo aNewChallenge)
        {
            //DB post
        }
    }
}
