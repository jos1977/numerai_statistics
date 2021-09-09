using System;
using System.Collections.Generic;

namespace NumeraiApi
{
    public class Numerai
    {
        public class V2Leaderboard
        {
            public object averageCorrelationPayout { get; set; }
            public List<string> badges { get; set; }
            public double bonusPerc { get; set; }
            public string leaderboardBonus { get; set; }
            public string nmrStaked { get; set; }
            public object oldStakeValue { get; set; }
            public string payoutPending { get; set; }
            public string payoutSettled { get; set; }
            public int? prevRank { get; set; }
            public int? prevStakedRank { get; set; }
            public int rank { get; set; }
            public string reputation { get; set; }
            public object rolling_score_rep { get; set; }
            public int? stakedRank { get; set; }
            public string tier { get; set; }
            public string username { get; set; }
        }

        public class V2LeaderboardRoot
        {
            public List<V2Leaderboard> v2Leaderboard { get; set; }
        }

        public class DailySubmissionPerformance
        {
            public double? correlation { get; set; }
            public double? correlationWithMetamodel { get; set; }
            public DateTime? date { get; set; }
            public double? fnc { get; set; }
            public double? mmc { get; set; }
            public int roundNumber { get; set; }
            public string username { get; set; }
        }

        public class DailyUserPerformance
        {
            public object averageCorrelation { get; set; }
            public object averageCorrelationPayout { get; set; }
            public DateTime date { get; set; }
            public object finalCorrelation { get; set; }
            public string leaderboardBonus { get; set; }
            public string payoutPending { get; set; }
            public string payoutSettled { get; set; }
            public int rank { get; set; }
            public object reputation { get; set; }
            public string stakeValue { get; set; }
            public string tier { get; set; }
            public string username { get; set; }
            public string apy { get; set; }
            public string corrRep { get; set; }
            public string fncRep { get; set; }
            public string return13Weeks { get; set; }
            public string return52Weeks { get; set; }
            public string totalRep { get; set; }
        }

        public class V2UserProfile
        {
            public object bio { get; set; }
            public List<DailySubmissionPerformance> dailySubmissionPerformances { get; set; }
            public List<DailyUserPerformance> dailyUserPerformances { get; set; }
            public List<HistoricStakeValue> historicStakeValues { get; set; }
            public MedalCounts medals { get; set; }
            public Returns latestReturns { get; set; }
            public string id { get; set; }
            public object netEarnings { get; set; }
            public DateTime startDate { get; set; }
            public string totalStake { get; set; }
            public string username { get; set; }
            public string payoutSelection { get; set; }
            public string control { get; set; }
            public string linkText { get; set; }
            public string linkUrl { get; set; }
            public bool computeEnabled { get; set; }
            public bool team { get; set; }
            public string? takeProfit { get; set; }

        }
        public class V2BasicUserProfile
        {
            public string bio { get; set; }
            public string historicalStakeValue { get; set; }
            public string id { get; set; }
            public string netEarnings { get; set; }
            public DateTime startDate { get; set; }
            public string totalStake { get; set; }
            public string username { get; set; }
            public string payoutSelection { get; set; }
            public string control { get; set; }
            public string linkText { get; set; }
            public string linkUrl { get; set; }
            public bool computeEnabled { get; set; }
            public bool team { get; set; }
            public string? takeProfit { get; set; }
            public string gold { get; set; }
            public string silver { get; set; }
            public string bronze { get; set; }
            public string oneDay { get; set; }
            public string oneYear { get; set; }
            public string threeMonths { get; set; }

        }
        public class V3BasicUserProfile
        {
            public string bio { get; set; }
            public bool computeEnabled { get; set; }
            public string control { get; set; }
            public string id { get; set; }
            public bool isActive { get; set; }
            public int corr { get; set; }
            public int? corr20d { get; set; }
            public int? corr20dRank { get; set; }
            public int fnc { get; set; }
            public int? fncRank { get; set; }
            public int mmc { get; set; }
            public int? mmcRank { get; set; }
            public int? prevCorr20dRank { get; set; }
            public int? prevFncRank { get; set; }
            public int? prevMmcRank { get; set; }
            public int? prevRank { get; set; }
            public int? rank { get; set; }
            public string oneDay { get; set; }
            public string oneYear { get; set; }
            public string threeMonths { get; set; }
            public string linkText { get; set; }
            public string linkUrl { get; set; }
            public string bronze { get; set; }
            public string gold { get; set; }
            public string silver { get; set; }
            public string? corrMultiplier { get; set; }
            public string? mmcMultiplier { get; set; }
            public bool? takeProfit { get; set; }
            public DateTime startDate { get; set; }
            public bool team { get; set; }
            public string username { get; set; }
        }
        public class V3UserProfile
        {
            public string bio { get; set; }
            public bool computeEnabled { get; set; }
            public string control { get; set; }
            public List<DailyModelPerformance> dailyModelPerformances { get; set; }
            public string id { get; set; }
            public bool isActive { get; set; }
            public Ranks latestRanks { get; set; }
            public Reps latestReps { get; set; }
            public Returns latestReturns { get; set; }
            public string linkText { get; set; }
            public string linkUrl { get; set; }
            public MedalCounts medals { get; set; }
            public string nmrStaked { get; set; }
            public string profileUrl { get; set; }
            public List<RoundModelPerformance> roundModelPerformances { get; set; }
            public StakeInfo stakeInfo { get; set; }
            public DateTime startDate { get; set; }
            public bool team { get; set; }
            public string username { get; set; }
        }
        public class StakeInfo
        {
            public string corrMultiplier { get; set; }
            public string mmcMultiplier { get; set; }
            public bool takeProfit { get; set; }
        }
        public class RoundModelPerformance
        {
            public float? corr { get; set; }
            public float? corr20d { get; set; }
            public float? corr20dPercentile { get; set; }
            public float? corrMultiplier { get; set; }
            public float? corrPercentile { get; set; }
            public float? corrWMetamodel { get; set; }
            public float? fnc { get; set; }
            public float? fncPercentile { get; set; }
            public float? mmc { get; set; }
            public float? mmcMultiplier { get; set; }
            public float? mmcPercentile { get; set; }
            public string? payout { get; set; }
            public int? roundNumber { get; set; }
            public DateTime roundOpenTime { get; set; }
            public float? roundPayoutFactor { get; set; }
            public DateTime roundResolveTime { get; set; }
            public bool? roundResolved { get; set; }
            public string? selectedStakeValue { get; set; }
            public string username { get; set; }
        }
        public class DailyModelPerformance
        {
            public string apy { get; set; }
            public int corrRank { get; set; }
            public string corrRep { get; set; }
            public DateTime date { get; set; }
            public int? fncRank { get; set; }
            public string fncRep { get; set; }
            public int? mmcRank { get; set; }
            public string mmcRep { get; set; }
            public string? return13Weeks { get; set; }
            public string? return52Weeks { get; set; }
            public string username { get; set; }

        }
        public class Ranks
        {
            public int corr { get; set; }
            public int? corr20d { get; set; }
            public int? corr20dRank { get; set; }
            public int fnc { get; set; }
            public int? fncRank { get; set; }
            public int mmc { get; set; }
            public int? mmcRank { get; set; }
            public int? prevCorr20dRank { get; set; }
            public int? prevFncRank { get; set; }
            public int? prevMmcRank { get; set; }
            public int? prevRank { get; set; }
            public int? rank { get; set; }
        }
        public class Reps
        {
            public string corr { get; set; }
            public string corr20d { get; set; }
            public string fnc { get; set; }
            public string mmc { get; set; }

        }
        public class HistoricStakeValue
        {
            public int round { get; set; }
            public string stakeValue { get; set; }
        }
        public class MedalCounts
        {
            public string bronze { get; set; }
            public string gold { get; set; }
            public string silver { get; set; }
        }
        public class Returns
        {
            public string oneDay { get; set; }
            public string oneYear { get; set; }
            public string threeMonths { get; set; }
        }
        public class V3UserProfileRoot
        {
            public V3UserProfile v3UserProfile { get; set; }
        }
        public class V2UserProfileRoot
        {
            public V2UserProfile v2UserProfile { get; set; }
        }
        public class Round
        {
            public string id { get; set; }
            public int number { get; set; }
            public DateTime scoreTime { get; set; }
            public DateTime openTime { get; set; }
            public DateTime closeTime { get; set; }
            public DateTime resolveTime { get; set; }
            public DateTime closeStakingTime { get; set; }
            public bool resolvedGeneral { get; set; }
            public bool resolvedStaking { get; set; }
            public object ruleset { get; set; }
            public int? numValidationEras { get; set; }
            public float? payoutFactor { get; set; }
            public string? stakeThreshold { get; set; }
        }
        public class RoundDetailsRoot
        {
            public RoundDetails roundDetails { get; set; }
        }
        public class RoundDetails
        {
            public float? averageReturn { get; set; }
            public DateTime openTime { get; set; }
            public float? payoutFactor { get; set; }
            public string roundId { get; set; }
            public string roundNumber { get; set; }
            public DateTime roundResolveTime { get; set; }
            public string? roundTarget { get; set; }
            public DateTime scoresUpdatedTime { get; set; }
            public string? status { get; set; }
            public float? totalAtStake { get; set; }
            public float? totalPayout { get; set; }
            public int? totalStakes { get; set; }
        }
        public class RoundRoot
        {
            public List<Round> rounds { get; set; }
        }
        public class ContentResponseType
        {
            public string content { get; set; }
            public string encoding { get; set; }
            public string url { get; set; }
            public string sha { get; set; }
            public long size { get; set; }
        }
        public class DataObject
        {
            public string Oid;
        }
        public class Repository
        {
            public DataObject Object;
        }
        public class ResponseType
        {
            public Repository Repository { get; set; }
        }

        public static string V3userprofileRequestQuery = @"
                      query($modelName: String!) {
                        v3UserProfile(modelName: $modelName) {
                            bio
                            computeEnabled
                            control

                            id
                            isActive
                            latestReturns {
                                oneDay
                                oneYear
                                threeMonths
                            }
                            linkText
                            linkUrl
                            medals {
                                bronze
                                gold
                                silver
                            }
                            nmrStaked
                            profileUrl
                            latestRanks {
                                corr
                                fnc
                                mmc
                            }
                            latestReps {
                                corr
                                fnc
                                mmc
                            }
                            stakeInfo {
                                corrMultiplier
                                mmcMultiplier
                                    takeProfit
                            }
                            dailyModelPerformances {
                                apy
                                corrRank
                                corrRep
                                date
                                fncRank
                                fncRep
                                mmcRank
                                mmcRep
                                return13Weeks
                                return52Weeks    
                            }
                            roundModelPerformances {
                                corr
                                corrMultiplier
                                corrPercentile
                                corrWMetamodel
                                fnc
                                fncPercentile
                                mmc
                                mmcMultiplier
                                mmcPercentile
                                payout
                                roundNumber
                                roundOpenTime
                                roundPayoutFactor
                                roundResolveTime
                                roundResolved
                                selectedStakeValue
                            }
                            startDate
                            team
                        }
                      

                    }";
        public static string roundRequestQuery = @"
                    query($tournament: Int!) {
                        rounds(tournament: $tournament) {
                            number
                            resolveTime
                            id
                            number
                            scoreTime
                            openTime
                            closeTime
                            resolveTime
                            closeStakingTime
                            numValidationEras
                            payoutFactor
                            stakeThreshold
                            resolvedGeneral
                            resolvedStaking
                        }
                }";
        public static string roundDetailsRequestQuery = @"
                    query($roundNumber: Int!, $tournament: Int!) {
                        roundDetails(roundNumber: $roundNumber,tournament: $tournament) {
                            averageReturn
                            openTime
                            payoutFactor
                            roundId
                            roundNumber
                            roundResolveTime
                            roundTarget
                            scoresUpdatedTime
                            status
                            totalAtStake
                            totalPayout
                            totalStakes
                        }
                }";
        public static string v2LeaderBoardRequestQuery = @"
                    query($limit: Int!
                          $offset: Int!) {
                        v2Leaderboard(limit: $limit
                            offset: $offset) {
                        bonusPerc
                        nmrStaked
                        oldStakeValue
                        prevRank
                        prevStakedRank
                        rank
                        stakedRank
                        reputation
                        rolling_score_rep
                        tier
                        username
                        leaderboardBonus
                        averageCorrelationPayout
                        payoutPending
                        payoutSettled
                        badges
                      }

                }";

    }
}
