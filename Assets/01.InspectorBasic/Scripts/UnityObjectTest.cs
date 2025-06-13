using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class UnityObjectTest : MonoBehaviour
{
    public GameObject gameObject;
    public Transform cubeTransform;
    
    public MeshRenderer cubeMeshRenderer;
    public MeshFilter cubeMeshFilter;
    public BoxCollider boxCollider;
    public object systemObject;//C#(DotNet)의 모든 클래스의 부모
    public Object unityObject; //유니티의 Inspector에서 참조할 수 있는 모든 오브젝트의 부모

    private void Start()
    {
        
    }
}
