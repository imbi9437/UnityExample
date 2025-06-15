using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Sample : MonoBehaviour
{
    private List<Transform> transforms;
    private List<float> distances;

    private Transform selectPlanet;
    private Camera mainCam;
    private Vector3 cursorPos;
    
    public Camera followCam;
    
    private void Awake()
    {
        transforms = GetComponentsInChildren<Collider>().Select(col => col.transform).ToList();
        distances = transforms.Select(t => Vector3.Distance(Vector3.zero, t.position)).ToList();
    }

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit, Mathf.Infinity))
        {
            cursorPos = hit.point;
            cursorPos.y = 0;
        }
        
        float distance = Vector3.Distance(Vector3.zero, cursorPos);

        for (int i = 0; i < distances.Count; i++)
        {
            if (distance > distances[i]) continue;
            ChangeInfo(i);
            break;
        }

        FollowCam();
    }

    private void ChangeInfo(int index)
    {
        if (selectPlanet == transforms[index]) return;
        selectPlanet = transforms[index];
        followCam.transform.SetParent(transforms[index].parent);
    }

    private void FollowCam()
    {
        Vector3 forward = selectPlanet.position - followCam.transform.position;

        float distance = selectPlanet.lossyScale.x + 5;
        followCam.transform.position = selectPlanet.position + new Vector3(distance, 0, 0);
        followCam.transform.rotation = Quaternion.LookRotation(forward);
    }
}
