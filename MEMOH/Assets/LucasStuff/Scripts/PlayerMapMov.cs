using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMapMov : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 1;

    public bool hasToMove;
    public Transform whereToGo;

    private void Start()
    {
        hasToMove = false;
    }

    private void Update()
    {
        if (hasToMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, whereToGo.position, moveSpeed * Time.deltaTime);

            if (transform.position == whereToGo.position)
            {
                whereToGo = null;
                hasToMove = false;
            }
        }
    }
}