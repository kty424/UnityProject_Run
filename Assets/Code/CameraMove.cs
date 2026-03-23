using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player_posistion;

    Vector3 offSetPosistion;
    private void Start()
    {
        offSetPosistion = transform.position - player_posistion.position;
    }
    private void FixedUpdate()
    {
        if (player_posistion != null)
        {
            Vector3 dir = new Vector3(offSetPosistion.x + player_posistion.position.x - transform.position.x,
               offSetPosistion.y + player_posistion.position.y - transform.position.y, 0);

            transform.position += dir;
        }
    }

}
