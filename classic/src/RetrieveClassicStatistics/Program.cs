using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using static NumeraiApi.Numerai;

namespace RetrieveClassicStatistics
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine($"C# function executed at: {DateTime.Now}");

            //initialize variables
            string api_tournament_url = "https://api-tournament.numer.ai";

            // initialize graphQL
            var graphQLClient = new GraphQLHttpClient(api_tournament_url, new NewtonsoftJsonSerializer());
            var roundRequest = new GraphQLRequest { Query = roundRequestQuery, Variables = new { tournament = 8 } };
            var roundResponse = graphQLClient.SendQueryAsync<RoundRoot>(roundRequest).Result;

            //Retrieve Round Details
            List<RoundDetails> roundDetails = new List<RoundDetails>();

            //iterate through round entries
            foreach (var entry in roundResponse.Data.rounds)
            {
                var roundDetailsRequest = new GraphQLRequest
                {
                    Query = roundDetailsRequestQuery,
                    Variables = new
                    {
                        roundNumber = entry.number,
                        tournament = 8
                    }
                };
                var roundDetailsResponse = graphQLClient.SendQueryAsync<RoundDetailsRoot>(roundDetailsRequest).Result;
                roundDetails.Add(roundDetailsResponse.Data.roundDetails);
            }

            //Retrieve Leaderboard
            var v2LeaderboardRequest = new GraphQLRequest
            {
                Query = v2LeaderBoardRequestQuery,
                Variables = new
                {
                    limit = 10000,
                    offset = 0
                }
            };

            var v2LeaderboardResponse = graphQLClient.SendQueryAsync<V2LeaderboardRoot>(v2LeaderboardRequest).Result;

            List<V3BasicUserProfile> userProfiles = new List<V3BasicUserProfile>();
            List<DailyModelPerformance> allDailyModelPerformances = new List<DailyModelPerformance>();
            List<RoundModelPerformance> allRoundModelPerformances = new List<RoundModelPerformance>();

            //iterate through leaderboard entries
            int i = 1;
            foreach (var entry in v2LeaderboardResponse.Data.v2Leaderboard)
            {
                int retry = 15;
                bool succeeded = false;
                while (retry > 0 && !succeeded)
                {
                    retry -= 1;
                    try
                    {
                        var user = entry.username;

                        Console.WriteLine("processing number {0} : user {1}", i, entry.username);
                        i += 1;
                        var V3userprofileRequest = new GraphQLRequest { Query = V3userprofileRequestQuery, Variables = new { modelName = user } };

                        var V3userprofileResponse = graphQLClient.SendQueryAsync<V3UserProfileRoot>(V3userprofileRequest).Result;
                        V3BasicUserProfile userProfile = new V3BasicUserProfile()
                        {
                            bio = V3userprofileResponse.Data.v3UserProfile.bio == null ? string.Empty : V3userprofileResponse.Data.v3UserProfile.bio.ToString().Replace(";", ""),
                            computeEnabled = V3userprofileResponse.Data.v3UserProfile.computeEnabled,
                            control = V3userprofileResponse.Data.v3UserProfile.control,
                            id = V3userprofileResponse.Data.v3UserProfile.id,
                            isActive = V3userprofileResponse.Data.v3UserProfile.isActive,
                            corr = V3userprofileResponse.Data.v3UserProfile.latestRanks == null ? 0 : V3userprofileResponse.Data.v3UserProfile.latestRanks.corr,
                            corr20d = null,
                            corr20dRank = null,
                            fnc = V3userprofileResponse.Data.v3UserProfile.latestRanks == null ? 0 : V3userprofileResponse.Data.v3UserProfile.latestRanks.fnc,
                            fncRank = null,
                            mmc = V3userprofileResponse.Data.v3UserProfile.latestRanks == null ? 0 : V3userprofileResponse.Data.v3UserProfile.latestRanks.mmc,
                            mmcRank = null,
                            prevCorr20dRank = null,
                            prevFncRank = null,
                            prevMmcRank = null,
                            prevRank = null,
                            rank = V3userprofileResponse.Data.v3UserProfile.latestRanks == null ? 0 : V3userprofileResponse.Data.v3UserProfile.latestRanks.rank,
                            oneDay = V3userprofileResponse.Data.v3UserProfile.latestReturns.oneDay,
                            oneYear = V3userprofileResponse.Data.v3UserProfile.latestReturns.oneYear,
                            threeMonths = V3userprofileResponse.Data.v3UserProfile.latestReturns.threeMonths,
                            linkText = V3userprofileResponse.Data.v3UserProfile.linkText,
                            linkUrl = V3userprofileResponse.Data.v3UserProfile.linkUrl,
                            corrMultiplier = V3userprofileResponse.Data.v3UserProfile.stakeInfo == null || V3userprofileResponse.Data.v3UserProfile.stakeInfo.corrMultiplier == null ? string.Empty : V3userprofileResponse.Data.v3UserProfile.stakeInfo.corrMultiplier,
                            mmcMultiplier = V3userprofileResponse.Data.v3UserProfile.stakeInfo == null || V3userprofileResponse.Data.v3UserProfile.stakeInfo.corrMultiplier == null ? string.Empty : V3userprofileResponse.Data.v3UserProfile.stakeInfo.mmcMultiplier,
                            takeProfit = V3userprofileResponse.Data.v3UserProfile.stakeInfo == null || V3userprofileResponse.Data.v3UserProfile.stakeInfo.corrMultiplier == null ? false : V3userprofileResponse.Data.v3UserProfile.stakeInfo.takeProfit,
                            startDate = V3userprofileResponse.Data.v3UserProfile.startDate,
                            team = V3userprofileResponse.Data.v3UserProfile.team,
                            username = user
                        };

                        //User Profiles
                        userProfiles.Add(userProfile);

                        //Daily Model Performances
                        var dailyModelPerformances = V3userprofileResponse.Data.v3UserProfile.dailyModelPerformances;// .dailySubmissionPerformances;
                        foreach (var perf in dailyModelPerformances) { perf.username = userProfile.username; }

                        allDailyModelPerformances.AddRange(dailyModelPerformances);

                        //Round Model Performances
                        var roundModelPerformances = V3userprofileResponse.Data.v3UserProfile.roundModelPerformances;

                        foreach (var perf in roundModelPerformances) { perf.username = userProfile.username; }
                        allRoundModelPerformances.AddRange(roundModelPerformances);
                        succeeded = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception {0}", e.Message);
                        Console.WriteLine("try again after 60 seconds....");
                        Thread.Sleep(60000);
                    }
                }

                if (!succeeded) { throw new Exception("Retry attempts didnt succeed..."); }
            }

            //create csv dir, cleanup
            if (!System.IO.Directory.Exists("csv")) { System.IO.Directory.CreateDirectory("csv"); }
            DirectoryInfo dir = new DirectoryInfo("csv");
            foreach (FileInfo fi in dir.GetFiles()) { fi.Delete(); }

            //write to csv
            CsvHelper.WriteCsv(roundResponse.Data.rounds, "csv/rounds.csv");
            CsvHelper.WriteCsv(roundDetails, "csv/roundDetails.csv");
            CsvHelper.WriteCsv(v2LeaderboardResponse.Data.v2Leaderboard, "csv/v2leaderboard.csv");
            CsvHelper.WriteCsv(userProfiles, "csv/userProfiles.csv");
            CsvHelper.WriteCsv(allRoundModelPerformances, "csv/allRoundModelPerformances.csv");
            CsvHelper.WriteCsv(allDailyModelPerformances, "csv/allDailyModelPerformances.csv");
        }
    }
}