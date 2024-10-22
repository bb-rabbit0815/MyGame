namespace Skill
{
    public class Prolific : IGeneticSkill
    {
        public int Id => (int)GeneticSkillIds.Prolific;
        public int Level { get; set; }
        public GeneticSkillType GeneticSkillType => GeneticSkillType.Buff;
        public string Name => "Prolific";
        public string Description => $"1度に妊娠できる最大人数が{Amount}人増える。";
        public float Amount => Level * 0.5f;
        public void Apply(CharctorParameters charctorParameters)
        {

        }
    }
}