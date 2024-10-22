namespace Skill
{
    public class Slut : IGeneticSkill
    {
        public int Id => (int)GeneticSkillIds.Slut;
        public int Level { get; set; }
        public GeneticSkillType GeneticSkillType => GeneticSkillType.Buff;
        public string Name => "Slut";
        public string Description => $"性スキルのレベルが上がりやすくなる";
        public float Amount => Level * 10f;
        public void Apply(CharctorParameters charctorParameters)
        {

        }
    }
}