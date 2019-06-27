using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableWaypoint : MonoBehaviour
{
    public Placer parentPlacer;

    private void Start()
    {
        this.gameObject.SetActive(this.transform.GetSiblingIndex() == 0);
    }

    void Update()
    {
        if(Vector2.Distance(new Vector2(parentPlacer.player.position.x, parentPlacer.player.position.z), new Vector2(this.transform.position.x, this.transform.position.z)) < 0.75f)
        {
            parentPlacer.OnPointConsumed.Invoke();
            Destroy(this.gameObject);

            int ourIndex = this.transform.GetSiblingIndex();
            if (ourIndex + 1 < parentPlacer.transform.childCount)
            {
                Transform next = parentPlacer.transform.GetChild(ourIndex + 1);
                next.gameObject.SetActive(true);
            }
        }
    }
}
