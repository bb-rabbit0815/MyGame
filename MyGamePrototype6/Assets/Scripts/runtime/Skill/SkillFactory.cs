
using System.Collections.Generic;

namespace Skill
{
    public static class SkillFactory
    {
        public static IGeneticSkill CreateSkill(GeneticSkillIds id) => id switch
        {
            GeneticSkillIds.None => null,
            GeneticSkillIds.MaxLevel => new MaxLevel(),
            GeneticSkillIds.MaxHealth => new MaxHealth(),
            GeneticSkillIds.InfectionResistance => new InfectionResistance(),
            GeneticSkillIds.HealthRecoverySpeed => new HealthRecoverySpeed(),
            GeneticSkillIds.Charm => new Charm(),
            GeneticSkillIds.Infertility => new Infertility(),
            GeneticSkillIds.Pregnancy => new Pregnancy(),
            GeneticSkillIds.Prolific => new Prolific(),
            GeneticSkillIds.Slut => new Slut(),
            _ => null,
        };
    }
}