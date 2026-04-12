using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;

    bool m_IsPlayerInRange;

    void OnTriggerEnter (Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update ()
    {
        Vector3 disVec = transform.parent.position - player.position;
        float distSq = Vector3.Dot(disVec, disVec);    
        Vector3 targetScale = (distSq < 20f) ? new Vector3(0.5f, 0.5f, 0.5f) : new Vector3(3f, 3f, 3f);

        transform.parent.localScale = Vector3.Lerp(transform.parent.localScale, targetScale, 0.5f * Time.deltaTime);

        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            
            if (Physics.Raycast (ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer ();
                }
            }
        }
    }
}
