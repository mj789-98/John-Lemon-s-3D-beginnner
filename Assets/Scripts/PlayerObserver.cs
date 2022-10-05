using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerObserver : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;

   public  bool mIsPlayerInRange;

    void OnTriggerEnter (Collider other)
    {
        if (other.transform == player)
        {
            mIsPlayerInRange = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.transform == player)
        {
            mIsPlayerInRange = false;
        }
    }

    void Update ()
    {
        if (mIsPlayerInRange)
        {
            var position = transform.position;
            Vector3 direction = player.position - position + Vector3.up;
            Ray ray = new Ray(position, direction);
            RaycastHit raycastHit;

            if(Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
