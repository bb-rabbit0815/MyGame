// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace fbs
{

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct Charctor : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_24_3_25(); }
  public static Charctor GetRootAsCharctor(ByteBuffer _bb) { return GetRootAsCharctor(_bb, new Charctor()); }
  public static Charctor GetRootAsCharctor(ByteBuffer _bb, Charctor obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public static bool VerifyCharctor(ByteBuffer _bb) {Google.FlatBuffers.Verifier verifier = new Google.FlatBuffers.Verifier(_bb); return verifier.VerifyBuffer("", false, CharctorVerify.Verify); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public Charctor __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string Name { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetNameBytes() { return __p.__vector_as_span<byte>(4, 1); }
#else
  public ArraySegment<byte>? GetNameBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public byte[] GetNameArray() { return __p.__vector_as_array<byte>(4); }
  public fbs.Sex Sex { get { int o = __p.__offset(6); return o != 0 ? (fbs.Sex)__p.bb.GetSbyte(o + __p.bb_pos) : fbs.Sex.None; } }
  public fbs.Species Species { get { int o = __p.__offset(8); return o != 0 ? (fbs.Species)__p.bb.GetSbyte(o + __p.bb_pos) : fbs.Species.None; } }
  public fbs.CharctorParameters? MaxParameters { get { int o = __p.__offset(10); return o != 0 ? (fbs.CharctorParameters?)(new fbs.CharctorParameters()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public fbs.CharctorParameters? Parameters { get { int o = __p.__offset(12); return o != 0 ? (fbs.CharctorParameters?)(new fbs.CharctorParameters()).__assign(o + __p.bb_pos, __p.bb) : null; } }

  public static void StartCharctor(FlatBufferBuilder builder) { builder.StartTable(5); }
  public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset) { builder.AddOffset(0, nameOffset.Value, 0); }
  public static void AddSex(FlatBufferBuilder builder, fbs.Sex sex) { builder.AddSbyte(1, (sbyte)sex, 0); }
  public static void AddSpecies(FlatBufferBuilder builder, fbs.Species species) { builder.AddSbyte(2, (sbyte)species, 0); }
  public static void AddMaxParameters(FlatBufferBuilder builder, Offset<fbs.CharctorParameters> maxParametersOffset) { builder.AddStruct(3, maxParametersOffset.Value, 0); }
  public static void AddParameters(FlatBufferBuilder builder, Offset<fbs.CharctorParameters> parametersOffset) { builder.AddStruct(4, parametersOffset.Value, 0); }
  public static Offset<fbs.Charctor> EndCharctor(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<fbs.Charctor>(o);
  }
  public static void FinishCharctorBuffer(FlatBufferBuilder builder, Offset<fbs.Charctor> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedCharctorBuffer(FlatBufferBuilder builder, Offset<fbs.Charctor> offset) { builder.FinishSizePrefixed(offset.Value); }
}


static public class CharctorVerify
{
  static public bool Verify(Google.FlatBuffers.Verifier verifier, uint tablePos)
  {
    return verifier.VerifyTableStart(tablePos)
      && verifier.VerifyString(tablePos, 4 /*Name*/, false)
      && verifier.VerifyField(tablePos, 6 /*Sex*/, 1 /*fbs.Sex*/, 1, false)
      && verifier.VerifyField(tablePos, 8 /*Species*/, 1 /*fbs.Species*/, 1, false)
      && verifier.VerifyField(tablePos, 10 /*MaxParameters*/, 16 /*fbs.CharctorParameters*/, 4, false)
      && verifier.VerifyField(tablePos, 12 /*Parameters*/, 16 /*fbs.CharctorParameters*/, 4, false)
      && verifier.VerifyTableEnd(tablePos);
  }
}

}