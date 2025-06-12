using UnityEngine;

public class CreateAndDestroyTest : MonoBehaviour
{
    public GameObject original;
    public FindMe originalComponent;

    private GameObject clone;
    private GameObject childClone;
    private GameObject movedClone;
    private FindMe clonedComponent;
    
    private void Start()
    {
        //original이랑 똑같이 생긴 객체를 하나 생성하고 싶다.
        // GameObject clone = new GameObject();
        // MeshFilter mf = clone.AddComponent<MeshFilter>();
        // MeshRenderer mr = clone.AddComponent<MeshRenderer>();
        // BoxCollider bc = clone.AddComponent<BoxCollider>();
        //
        // mf.mesh = original.GetComponent<MeshFilter>().mesh;
        // mr.material = original.GetComponent<MeshRenderer>().material;
        // bc.center = original.GetComponent<BoxCollider>().center;
        // bc.size = original.GetComponent<BoxCollider>().size;
        // ===========================================================
        
        //그냥 Instantiate 씁시다.
        //그냥 복제
        clone = Instantiate(original);
        //Transform을 파라미터로 전달할 경우, 해당 파라미터의 "자식"으로 생성
        childClone = Instantiate(original, transform);
        childClone.name = "Child Clone";
        //Vector3와 Quaternion을 파라미터로 전달할 경우, 해당 위치와 각도를 가진 상태로 생성
        movedClone = Instantiate(original, new Vector3(3, 2, 1), Quaternion.Euler(45,30,90));
        movedClone.name = "Moved Clone";
        //만약 Original이 Component일 경우, 해당 컴포넌트가 붙어있는 gameObject와 같은 형태로 게임 오브젝트를 생성하고,
        //original과 같은 컴포넌트를 반환.
        
        clonedComponent = Instantiate(originalComponent);
        clonedComponent.name = "Cloned Component";
        clonedComponent.message = "이것은 클론입니다.";
        
        Invoke(nameof(DestroyClones),0f);

    }

    private void DestroyClones()
    {
        //클론 4종을 파괴하자
        //게임 오브젝트를 없앨 경우.
        Destroy(clone); //clone이라는 오브젝트가 파괴될 것인데.
        Debug.Log($"{clone.name} Destroy함");//NullReferenceException이 떠야할것 같은데?
        //Destroy메소드는 파라미터를 삭제되야할 객체로 등록을 한다.
        //해당 프레임이 끝날때 삭제된다.
        
        Destroy(childClone, 3f); //3초 후에 childClone 삭제, 마찬가지로 해당 프레임의 가장 마지막에 일괄 삭제
        
        Destroy(clonedComponent); //만약 파라미터가 GameObject 가 아니면, 해당 오브젝트만 딱 삭제.
        //이 경우, clonedComponent가 Cube(Clone)에 부착된 FindMe 컴포넌트이므로, 해당 컴포넌트만 삭제.
        
        //이번 프레임이 아니라 지금 즉시 객체가 파괴되어야 할 경우가 가끔 있음.
        //에를들면 유니티에서 싱글톤 패턴을 구현한다던가...
        
        DestroyImmediate(movedClone);

        if (movedClone == null)
        {
            Debug.Log("movedClone은 이제 없음");
        }
    }
}
