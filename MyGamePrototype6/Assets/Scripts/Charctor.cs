using Google.FlatBuffers;
using UnityEngine;

public class Charctor : MonoBehaviour
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
        fbs.Charctor.StartCharctor(fbb);
        fbs.Charctor.AddName(fbb, fbb.CreateString(_name));
        fbs.Charctor.AddSex(fbb, FbsConverter.ToSex(_sex));
        fbs.Charctor.AddSpecies(fbb, FbsConverter.ToSpecies(_species));
        fbs.Charctor.AddMaxParameters(fbb, FbsConverter.ToCharctorParameters(fbb, _maxParameter));
        fbs.Charctor.AddParameters(fbb, FbsConverter.ToCharctorParameters(fbb, _parameter));
        var charctor = fbs.Charctor.EndCharctor(fbb);
        fbs.Charctor.FinishCharctorBuffer(fbb, charctor);
        return fbb.DataBuffer;
    }

    public void FromBinary(ByteBuffer byteBuffer)
    {
        var charctor = fbs.Charctor.GetRootAsCharctor(byteBuffer);
        _name = charctor.Name;
        _sex = FbsConverter.SexFromFbx(charctor.Sex);
        _species = FbsConverter.SpeciesFromFbs(charctor.Species);
        _maxParameter = FbsConverter.CharctorParametersFromFbs(charctor.MaxParameters);
        _parameter = FbsConverter.CharctorParametersFromFbs(charctor.Parameters);
    }
}
