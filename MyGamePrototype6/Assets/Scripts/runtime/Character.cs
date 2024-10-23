using Google.FlatBuffers;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private Sex _sex = Sex.None;
    [SerializeField]
    private Species _species = Species.None;
    [SerializeField]
    private CharctorParameters _maxParameter;
    [SerializeField, Tooltip("Readonly")]
    private CharctorParameters _parameter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public ByteBuffer ToBinary()
    {
        var fbb = new FlatBufferBuilder(1);
        fbs.Character.StartCharacter(fbb);
        fbs.Character.AddName(fbb, fbb.CreateString(_name));
        fbs.Character.AddSex(fbb, FbsConverter.ToSex(_sex));
        fbs.Character.AddSpecies(fbb, FbsConverter.ToSpecies(_species));
        fbs.Character.AddMaxParameters(fbb, FbsConverter.ToCharctorParameters(fbb, _maxParameter));
        fbs.Character.AddParameters(fbb, FbsConverter.ToCharctorParameters(fbb, _parameter));
        var charctor = fbs.Character.EndCharacter(fbb);
        fbs.Character.FinishCharacterBuffer(fbb, charctor);
        return fbb.DataBuffer;
    }

    public void FromBinary(ByteBuffer byteBuffer)
    {
        var charctor = fbs.Character.GetRootAsCharacter(byteBuffer);
        _name = charctor.Name;
        _sex = FbsConverter.SexFromFbx(charctor.Sex);
        _species = FbsConverter.SpeciesFromFbs(charctor.Species);
        _maxParameter = FbsConverter.CharctorParametersFromFbs(charctor.MaxParameters);
        _parameter = FbsConverter.CharctorParametersFromFbs(charctor.Parameters);
    }
}
