using System;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;

    
    private GameStatus _gameStatus;
    private Ball _ball;

    private void Start()
    {
        _gameStatus = FindObjectOfType<GameStatus>();
        _ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    { 
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (_gameStatus.isActiveAndEnabled)
        {
            return _ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
