namespace Skill
{
    public class Pregnancy : IGeneticSkill
    {
        public int Id => (int)GeneticSkillIds.Pregnancy;
        public int Level { get; set; }
        public GeneticSkillType GeneticSkillType => GeneticSkillType.Buff;
        public string Name => "Pregnancy";
        public string Description => $"妊娠率が{Amount}%上がる";
        public float Amount => Level * 3f;
        public void Apply(CharctorParameters charctorParameters)
        {

        }

    }
}