namespace WoWSpect.MVVM.Models.Players.Stats;

public record CharacterStatisticData
    {
        public Links _links { get; set; }
        public int health { get; set; }
        public int power { get; set; }
        public PowerType power_type { get; set; }
        public Speed speed { get; set; }
        public Strength strength { get; set; }
        public Agility agility { get; set; }
        public Intellect intellect { get; set; }
        public Stamina stamina { get; set; }
        public MeleeCrit melee_crit { get; set; }
        public MeleeHaste melee_haste { get; set; }
        public Mastery mastery { get; set; }
        public int bonus_armor { get; set; }
        public Lifesteal lifesteal { get; set; }
        public double versatility { get; set; }
        public double versatility_damage_done_bonus { get; set; }
        public double versatility_healing_done_bonus { get; set; }
        public double versatility_damage_taken_bonus { get; set; }
        public Avoidance avoidance { get; set; }
        public int attack_power { get; set; }
        public double main_hand_damage_min { get; set; }
        public double main_hand_damage_max { get; set; }
        public double main_hand_speed { get; set; }
        public double main_hand_dps { get; set; }
        public double off_hand_damage_min { get; set; }
        public double off_hand_damage_max { get; set; }
        public double off_hand_speed { get; set; }
        public double off_hand_dps { get; set; }
        public int spell_power { get; set; }
        public int spell_penetration { get; set; }
        public SpellCrit spell_crit { get; set; }
        public double mana_regen { get; set; }
        public double mana_regen_combat { get; set; }
        public Armor armor { get; set; }
        public Dodge dodge { get; set; }
        public Parry parry { get; set; }
        public Block block { get; set; }
        public RangedCrit ranged_crit { get; set; }
        public RangedHaste ranged_haste { get; set; }
        public SpellHaste spell_haste { get; set; }
        public Character character { get; set; }
    }