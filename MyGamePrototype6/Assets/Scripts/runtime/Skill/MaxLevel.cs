
namespace Skill
{
    public class MaxLevel : IGeneticSkill
    {
        public int Id => (int)GeneticSkillIds.MaxLevel;
        public int Level { get; set; }
        public GeneticSkillType GeneticSkillType => GeneticSkillType.Status;
        public string Name => "Max Level";
        public string Description => $"レベルの上限を{LevelAmount}上げる。";
        public int LevelAmount => Level * 10;
        public void Apply(CharctorParameters charctorParameters)
        {
            charctorParameters.Level += LevelAmount;
        }
    }
}