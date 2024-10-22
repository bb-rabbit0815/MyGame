namespace Skill
{
    public class Charm: IGeneticSkill
    {
        public int Id => (int)GeneticSkillIds.Charm;
        public int Level { get; set; }
        public GeneticSkillType GeneticSkillType => GeneticSkillType.Buff;
        public string Name => "Charm";
        public string Description => $"売春でもらえる金額が{Amount}%アップする。";
        public float Amount => Level * 3;
        public void Apply(CharctorParameters charctorParameters)
        {
            
        }
    }
}