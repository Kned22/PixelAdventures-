using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.Windows;

public class Enemymove : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private Vector3 input;
    [SerializeField] private SpriteRenderer EnemySprite;
    [SerializeField] private float startMovementTime;
    private float movementTime;
    void Start()
    {
        movementTime = startMovementTime / 2;
    }
    void FixedUpdate()
    {
        if (movementTime > 0)
        {
            movementTime -= Time.deltaTime;
        }
        else
        {
            movementSpeed = -movementSpeed;
            movementTime = startMovementTime;
        }

        Vector2 movementVec = new Vector2(1f, 0f);

        transform.Translate(movementVec * movementSpeed * Time.deltaTime);

    }
}
