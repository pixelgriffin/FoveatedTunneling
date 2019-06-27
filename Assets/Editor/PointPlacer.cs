using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Placer))]
public class PointPlacer : Editor
{
    private Placer placer;

    private bool leftShifting = false;

    void OnEnable() {
        placer = (Placer)target;
    }

    void OnSceneGUI (){
        Event e = Event.current;
        int controlID = GUIUtility.GetControlID (FocusType.Passive);
        switch (e.GetTypeForControl (controlID)) {
        case EventType.MouseDown:
            if(e.button == 0)
            {
                GUIUtility.hotControl = controlID;
            
                Ray ray = HandleUtility.GUIPointToWorldRay(e.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit, 100f))
                {
                    GameObject point = Instantiate(placer.pointPrefab, hit.point, Quaternion.identity);

                    int n = placer.transform.childCount + 1;
                    if(n > 1)
                    {
                        Transform previous = placer.transform.GetChild(placer.transform.childCount - 1);
                        
                        Vector3 dir = (hit.point - previous.position).normalized;
                        point.transform.position = previous.position + dir * placer.distanceBetweenPoints;
                    }

                    point.name += "(" + n + ")";
                    point.transform.parent = placer.transform;

                    ConsumableWaypoint currentWaypoint = point.GetComponent<ConsumableWaypoint>();
                    currentWaypoint.parentPlacer = placer;
                }
                


                e.Use ();
            }
            break;
        case EventType.MouseUp:
            if(e.button == 0)
            {
                GUIUtility.hotControl = 0;
                e.Use();
            }
            break;
        case EventType.KeyDown:
            if( e.keyCode == KeyCode.LeftShift ){
                leftShifting = true;
            }
            break;
        case EventType.KeyUp:
            if(e.keyCode == KeyCode.LeftShift){
                leftShifting = false;
            }
            break;
        }
        //AllDrawingStuff();
    }
}
