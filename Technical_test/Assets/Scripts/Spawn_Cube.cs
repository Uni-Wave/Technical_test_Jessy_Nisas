using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawn_Cube : MonoBehaviour
{
    [SerializeField]
    Material mat_Cube;
    [SerializeField]
    Camera cam;

    private void Start()
    {
        // In Editor or here
        if(cam == null)
            cam = Camera.main;
    }

    void Update()
    {
       if(Input.touchCount > 0 && !EventSystem.current.currentSelectedGameObject)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = cam.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    Renderer cube = GameObject.CreatePrimitive(PrimitiveType.Cube).GetComponent<Renderer>();

                    cube.material = mat_Cube;

                    Vector3 position = hit.point;
                    position.y += cube.transform.localScale.y / 2;
                    cube.transform.position = position;
                }
            }
        }

#if UNITY_EDITOR // Test in EDITOR
        else if (Input.GetMouseButtonDown(0) && !EventSystem.current.currentSelectedGameObject)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Renderer cube = GameObject.CreatePrimitive(PrimitiveType.Cube).GetComponent<Renderer>();

                cube.material = mat_Cube;

                Vector3 position = hit.point;
                position.y += cube.transform.localScale.y / 2;
                cube.transform.position = position;
            }
            else
            {
                Debug.Log("No Collision");
            }
        }
#endif
    }
}
