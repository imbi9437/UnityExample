using System;
using System.Runtime.Serialization;
using UnityEngine;

//C# 어트리뷰트(Attribute) : 코드를 구성하는 특정 요소 (클래스, 필드, 메소드)에 대한 메터테이터를 정의

[Serializable] //이 뒤에 오는 클래스는 직렬화 기능을 부여한다는 의미
public class MyClass //: ISerializable
{
    public string name;
    public int id;
    public Sprite sprite;

    // public void GetObjectData(SerializationInfo info, StreamingContext context)
    // {
    //     throw new NotImplementedException();
    // }
}

public class ReferenceVariableTest : MonoBehaviour
{
    public MyClass myClass; //개발자가 직접 작성한 참조형태의 데이터는 어떻게 Inspector에서 수정할 수 있을까?
                            //직렬화가 필요함.

    private void Start()
    {
        print(myClass.name);
        print(myClass.id);
        print(myClass.sprite);
    }
}