namespace Skill
{
    public class Infertility : IGeneticSkill
    {
        public int Id => (int)GeneticSkillIds.Infertility;
        public int Level { get; set; }
        public GeneticSkillType GeneticSkillType => GeneticSkillType.Debuff;
        public string Name => "Infertility";
        public string Description => $"妊娠率が{Amount}%下がる";
        public float Amount => Level * 3f;
        public void Apply(CharctorParameters charctorParameters)
        {
            
        }
    }
}