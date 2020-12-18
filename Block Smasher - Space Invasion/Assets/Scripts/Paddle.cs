using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minX = 1.25f;
    [SerializeField] float maxX = 14.75f;
    [SerializeField] float screenwidhthInUnits = 16f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXpos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXpos()
    {
        if(FindObjectOfType<GameStatus>().IsAutoPlayOn())
        {
            return FindObjectOfType<Ball1>().transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenwidhthInUnits;
        }
    }
}
