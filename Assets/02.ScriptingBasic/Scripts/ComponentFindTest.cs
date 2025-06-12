using UnityEngine;

public class ComponentFindTest : MonoBehaviour
{
    //게임 오브젝트를 알고 있는 상태에서, 그 오브젝트에 부착된 특정 컴포넌트를 찾으려 할 경우
    public GameObject target;
    public Sprite someSprite;
    
    
    private void Start()
    {
        //target 오브젝트에서 FindMe 컴포넌트를 가져오려면
        FindMe findMe = target.GetComponent<FindMe>();
        Debug.Log(findMe.message);
        
        bool isFinded = target.TryGetComponent(out SpriteRenderer spriteRenderer);

        if (isFinded)
        {
            spriteRenderer.sprite = someSprite; //스프라이트 교체
            //컴포넌트를 찾는데 성공
        }
        else
        {
            Debug.Log("찾는 컴포넌트가 없습니다.");
            //컴포넌트를 못찾음.
        }
        
        isFinded = target.TryGetComponent(out Collider2D collider2D);
        
        if (isFinded)
        {
            Debug.Log(collider2D.offset);
            //컴포넌트를 찾는데 성공
        }
        else
        {
            Debug.Log("찾는 컴포넌트가 없습니다.");
            //컴포넌트를 못찾음.
        }
        
        //Hierarchy상 자식 오브젝트들에 붙어있는 컴포넌트들도 찾을 수 있다.
        FindMe[] children = target.GetComponentsInChildren<FindMe>(); 
        //자기 자신에 부착된 컴포넌트를 포함한다.
        //오버로드 된 메소드 중, includeInactive를 true로 전달하면 비활성화 된 자식도 포함. (기본값은 false)

        foreach (var child in children)
        {
            Debug.Log(child.message);
        }

        FindMe newFindMe = target.AddComponent<FindMe>();
        newFindMe.message = "새롭게 나를 찾아주셨군요!";
    }
}
