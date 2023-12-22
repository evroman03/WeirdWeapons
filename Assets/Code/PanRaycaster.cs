using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanRaycaster : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    Ray panRange;

    // Start is called before the first frame update
    void Start()
    {
        Ray ray = new Ray(transform.position, transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(panRange, out RaycastHit hit, 5, layerMask, QueryTriggerInteraction.Ignore))
        {
            Debug.Log(hit.collider.gameObject.name + " Was Hit!");
            Debug.DrawRay(transform.position, transform.forward, Color.green);
        }
    }
}
