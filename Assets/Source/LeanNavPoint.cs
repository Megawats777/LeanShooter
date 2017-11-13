using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanNavPoint : MonoBehaviour
{
    // Draw debug shapes
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 0.35f);
    }
}
