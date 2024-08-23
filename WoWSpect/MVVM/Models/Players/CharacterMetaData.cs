namespace WoWSpect.MVVM.Models.Players;

public record CharacterMetaData
    {
        public Links _links { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public Gender gender { get; set; }
        public Faction faction { get; set; }
        public Race race { get; set; }
        public CharacterClass character_class { get; set; }
        public ActiveSpec active_spec { get; set; }
        public Realm realm { get; set; }
        public int level { get; set; }
        public int experience { get; set; }
        public int achievement_points { get; set; }
        public Achievements achievements { get; set; }
        public Titles titles { get; set; }
        public PvpSummary pvp_summary { get; set; }
        public Encounters encounters { get; set; }
        public Media media { get; set; }
        public long last_login_timestamp { get; set; }
        public int average_item_level { get; set; }
        public int equipped_item_level { get; set; }
        public Specializations specializations { get; set; }
        public Statistics statistics { get; set; }
        public MythicKeystoneProfile mythic_keystone_profile { get; set; }
        public Equipment equipment { get; set; }
        public Appearance appearance { get; set; }
        public Collections collections { get; set; }
        public ActiveTitle active_title { get; set; }
        public Reputations reputations { get; set; }
        public Quests quests { get; set; }
        public AchievementsStatistics achievements_statistics { get; set; }
        public Professions professions { get; set; }
        public CovenantProgress covenant_progress { get; set; }
        public string name_search { get; set; }
    }