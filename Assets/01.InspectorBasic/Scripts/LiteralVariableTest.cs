using System;
using UnityEngine;

public class LiteralVariableTest : MonoBehaviour
{
    private const uint MonsterHp = 100;
    
    //정수
    public byte byteVar = byte.MaxValue;
    public sbyte sbyteVar;
    public short shortVar;
    public ushort ushortVar;
    public int intVar = 1;
    public uint uintVar = MonsterHp;
    public long longVar;
    public ulong ulongVar;
    
    //실수
    public float floatVar = 1.1f;
    public double doubleVar = 1.4d;
    public decimal decimalVar;  //decimal 데이터 타입은 유니티의 Inspector창에서 데이터 입력을 지원하지 않음
    
    //그 외
    public bool boolVar;
    public char charVar;
    public string stringVar;
    
    void Start()
    {
        Debug.Log(intVar);   
    }

    private void Reset()
    {
        Debug.Log($"{nameof(LiteralVariableTest)}의 Reset호출됨");
        floatVar = 1.3f;
    }
}
