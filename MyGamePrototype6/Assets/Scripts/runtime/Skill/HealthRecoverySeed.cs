namespace Skill
{
    public class HealthRecoverySpeed: IGeneticSkill
    {
        public int Id => (int)GeneticSkillIds.HealthRecoverySpeed;
        public int Level { get; set; }
        public GeneticSkillType GeneticSkillType => GeneticSkillType.Status;
        public string Name => "Health Recovery Speed";
        public string Description => $"体力の回復量が{Amount}上がります";
        public int Amount => Level * 1;
        public void Apply(CharctorParameters charctorParameters)
        {
            charctorParameters.HealthRecoverySpeed = Amount;
        }
    }
}