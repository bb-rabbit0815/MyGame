namespace Skill
{
    public class MaxHealth : IGeneticSkill
    {
        public int Id => (int)GeneticSkillIds.MaxHealth;
        public int Level { get; set; }
        public GeneticSkillType GeneticSkillType => GeneticSkillType.Status;
        public string Name => "Max Health";
        public string Description => $"体力の上限を{HealthAmount}上げる。";
        public int HealthAmount => Level * 100;
        public void Apply(CharctorParameters charctorParameters)
        {
            charctorParameters.Helth += HealthAmount;
        }
    }
}