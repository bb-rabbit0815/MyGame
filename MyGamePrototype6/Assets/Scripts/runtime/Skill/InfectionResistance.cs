namespace Skill
{
    public class InfectionResistance : IGeneticSkill
    {
        public int Id => (int)GeneticSkillIds.InfectionResistance;
        public int Level { get; set; }
        public GeneticSkillType GeneticSkillType => GeneticSkillType.Status;
        public string Name => "Infection Resistance";
        public string Description => $"感染耐性が{InfectionResistanceAmount}%上昇する。";
        public float InfectionResistanceAmount => Level * 2f;
        public void Apply(CharctorParameters charctorParameters)
        {
            charctorParameters.InfectionResistance += InfectionResistanceAmount;
        }
    }
}