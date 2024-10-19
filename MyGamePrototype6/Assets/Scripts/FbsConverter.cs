using Google.FlatBuffers;

public static class FbsConverter
{
    public static fbs.Sex ToSex(Sex sex) => sex switch
    {
        Sex.None => fbs.Sex.None,
        Sex.Male => fbs.Sex.Male,
        Sex.Woman => fbs.Sex.Woman,
        Sex.Futanari => fbs.Sex.Futanari,
        _ => fbs.Sex.None,
    };

    public static Sex SexFromFbx(fbs.Sex sex) => sex switch
    {
        fbs.Sex.None => Sex.None,
        fbs.Sex.Male => Sex.Male,
        fbs.Sex.Woman => Sex.Woman,
        fbs.Sex.Futanari => Sex.Futanari,
        _ => Sex.None,
    };

    public static fbs.Species ToSpecies(Species species) => species switch
    {
        Species.None => fbs.Species.None,
        Species.Human => fbs.Species.Human,
        Species.Beastman => fbs.Species.Beastman,
        Species.Dwarf => fbs.Species.Dwarf,
        Species.Elf => fbs.Species.Elf,
        _ => fbs.Species.None,
    };

    public static Species SpeciesFromFbs(fbs.Species species) => species switch
    {
        fbs.Species.None => Species.None,
        fbs.Species.Human => Species.Human,
        fbs.Species.Beastman => Species.Beastman,
        fbs.Species.Dwarf => Species.Dwarf,
        fbs.Species.Elf => Species.Elf,
        _ => Species.None,
    };

    public static Offset<fbs.CharctorParameters> ToCharctorParameters(FlatBufferBuilder fbb, CharctorParameters charctorParameters)
        => fbs.CharctorParameters.CreateCharctorParameters(fbb, charctorParameters.Level, charctorParameters.Helth, charctorParameters.Appearance, charctorParameters.Age);

    public static CharctorParameters CharctorParametersFromFbs(fbs.CharctorParameters? charctorParameters)
        => new CharctorParameters { Level = charctorParameters?.Level ?? 0, Helth = charctorParameters?.Helth ?? 0, Appearance = charctorParameters?.Appearance ?? 0, Age = charctorParameters?.Age ?? 0 };

}