namespace WoWSpect.MVVM.Models.Players.MythicSeason;

public record MythicSeasonPerformanceData
    {
        public Links _links { get; set; }
        public Season season { get; set; }
        public List<BestRun> best_runs { get; set; }
        public Character character { get; set; }
        public MythicRating mythic_rating { get; set; }
    }