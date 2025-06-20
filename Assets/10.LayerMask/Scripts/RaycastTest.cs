using UnityEngine;

namespace _10.LayerMask
{
    public class RaycastTest : MonoBehaviour
    {   // Raycast : Physics 클래스의 기능.
        // Rigidbody가 없이도 콜라이더를 검출할 수 있는 기능

        public UnityEngine.LayerMask targetLayer;
        public RaycastHit[] hits;
        
        private void Start()
        {
            Debug.Log($"Enemy Layer : {UnityEngine.LayerMask.NameToLayer("Enemy")}");   //7
            Debug.Log($"Target Layer Value : {targetLayer.value}"); //1 >> 7
            
            hits = new RaycastHit[2];
        }

        private void Update()
        {
            Ray ray = new Ray(transform.position, Vector3.right);   //내 위치에서 오른쪽으로 향하는 Ray 생성
            // bool hasCollider = Physics.Raycast(ray, 3, 1 << UnityEngine.LayerMask.NameToLayer("Enemy")); //Ray 구조체의 데이터대로 3만큼의 거리까지 콜라이더를 검출하는 Ray를 시전함
            // bool hasCollider = Physics.Raycast(ray, 3, 1 << UnityEngine.LayerMask.NameToLayer("Enemy") + 1 << UnityEngine.LayerMask.NameToLayer("Player"));
            bool hasCollider = Physics.Raycast(ray, out RaycastHit hit, 3, targetLayer);
            
            //Debug.DrawRay(ray.origin,ray.direction * 3, Color.blue);    //오른쪽으로 3만큼 레이를 그려주는 Debug 함수
            
            if (hasCollider)
            {
                Debug.Log("콜라이더 검출됨");
                Debug.Log($"{hit.collider.name}가 오른쪽 3미터 내에 있음");
                Debug.DrawLine(ray.origin,hit.point, Color.red,2);
            }
            
            //box, sphere, capsule등 기타 도형 형태로 개스트
            Ray sphereRay = new Ray(transform.position + Vector3.forward * 3, Vector3.forward); 
            RaycastHit[] hits = Physics.SphereCastAll(sphereRay,1f,0,targetLayer);   //구형의 영역에 콜라이더가 있는지 검출할 수 있도록 가상의 구체를 시전함

            foreach (var sphereHit in hits)
            {
                Debug.Log($"{sphereHit.collider.name}가 sphere 안에 들어옴");
            }

            //XXCastNonAlloc : XXCastAll이 update에서 호출될 시에 매 프레이마다 배열을 생성하기 때문에 과도한 오버헤드가 발생할 수 잇으므로
            //update에서 사용할 시에는 NonAlloc 캐스트를 사용하는게 좋다.
            Vector3 center = transform.position + Vector3.left * 3;
            Vector3 halfExtend = Vector3.one * 0.5f;
            int count = Physics.BoxCastNonAlloc(center, halfExtend, Vector3.up, hits, Quaternion.identity, 0f, targetLayer);
            
            Debug.Log($"BoxCast결과 {count}개 검출됨");

            for (int i = 0; i < count; i++)
            {
                Debug.Log($"{hits[i].collider.name}가 박스에 검출됨");
            }
        }

        //Gizmo에 (Scene창 에서만 보이는) 구체 또는 큐브 등 특정 도형을 그려주고 싶을 때.
        private void OnDrawGizmos()
        {
            //Gizmos.DrawSphere : 면이 차있는 구체
            Gizmos.color = Color.red;   //Gizmos는 Draw를 호출하기 전에 색을 지정해 줘야 함.
            Gizmos.DrawWireSphere(transform.position + Vector3.forward * 3, 1f);
            
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(transform.position + Vector3.left *3,Vector3.one);
        }

    }
}
