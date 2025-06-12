using UnityEngine;

public class ObjectFindTest : MonoBehaviour
{
    //게임이 시작되기 전에 씬에서 참조 할 수 있는 오브젝트는 인스펙터에서 할당하여 참조할 수 있음.
    public GameObject target;
    //근데, 오브젝트를 찾기는 해야하는데, public이면 안됨. 이런경우는?
    private GameObject privateTarget;
    private FindMe findTarget;
    private GameObject newTarget;
    private GameObject namedNewTarget;
    private GameObject componentAttachedTarget;

    void Start()
    {
        //Debug.Log(target.name);
        //privateTarget을 찾는 방법.
        //1. 전체 씬에서 이름으로 타겟을 찾는다.
        privateTarget = GameObject.Find("PrivateTarget");
        Debug.Log(privateTarget.transform.position);
        //씬에 오브젝트가 많을 수록 부하(오버헤드)가 크고,
        //같은 이름의 오브젝트가 여러개 있을 경우, 어떤 오브젝트가 탐색될지 확신 할 수 없음.
        //이런 이유로 Start함수에서만 제한적으로 쓰임.

        //2. 전체 씬에서 특정 컴포넌트를 가지고 있는 객체를 찾는다.
        findTarget = FindAnyObjectByType<FindMe>(); //기존 FindObjectOfType()과 같은 동작 => 여러개일 경우 뭐가 올지 모름
        findTarget = FindFirstObjectByType<FindMe>(); //Hierarchy상 가장 위에 있는 오브젝트를 찾음
        Debug.Log(findTarget.message);

        //3. 아예 게임오브젝트를 직접 생성하고 해당 객체의 참조를 유지한다.
        newTarget = new GameObject(); //Component등 유니티의 오브젝트들은 기본적으로 new 키워드를 통한 객체 생성을 막음(지원하지 않는다)
        //예외적으로 GameObject는 new를 통한 객체 생성이 가능. 생성자에서 transform을 비롯한 필요한 컴포넌트를 붙인 객체를 생성함.
        //(Hierarchy에서 Create Empty를 한것과 같음)

        namedNewTarget = new GameObject("Named Target");
        componentAttachedTarget = new GameObject("Component Attached GameObject", typeof(FindMe));
        
        //객체를 생성할 땐 new GameObject() 보다는 Instantiate를 쓰게될 것.
    }
}