
namespace Skill
{
    public interface IGeneticSkill
    {
        public int Id { get; }
        public int Level { get; set; }
        public GeneticSkillType GeneticSkillType { get; }
        public string Name { get; }
        public string Description { get; }
        public void Apply(CharctorParameters charctor);
    }
}