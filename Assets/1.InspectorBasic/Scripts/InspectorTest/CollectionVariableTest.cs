using System.Collections.Generic;
using UnityEngine;

public class CollectionVariableTest : MonoBehaviour
{
    public string[] array;  //초기화를 하지 않아도 유니티에서 새 객체를 주입.
    public List<string> list;
    public LinkedList<string> linkedList;
    public Queue<string> queue;
    public Stack<string> stack;
    public Dictionary<string, int> dictionary;
    
    void Start()
    {
        foreach (string item in array)
        {
            
            Debug.Log(item);
        }
        
        Debug.Log(array.Length);
    }

}
