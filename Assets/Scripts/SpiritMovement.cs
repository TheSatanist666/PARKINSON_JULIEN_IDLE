using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritMovement : MonoBehaviour
{
    private Vector3 positionA;
    private Vector3 positionB;
    private Transform originalPosition;
    private float t = 0;
    private float xPosNew, yPosNew, xPosOld, yPosOld;
    private bool canMove = true;
    [SerializeField]
    private int _offset = 0;
    private float slowUpgrade = 0;
    
    void Start()
    {
        xPosOld = transform.position.x;
        yPosOld = transform.position.y;
    }

    void Update()
    {
        SpiritMoving();
    }
    void SpiritMoving()
    {
        if(t >= 1)
        {
            t = 0;
            xPosOld = xPosNew;
            yPosOld = yPosNew;
            xPosNew = Random.Range(-100f,650f);
            yPosNew = Random.Range(0f,400f);
        }
        else if(canMove == true)
        {
            t += 0.01f - slowUpgrade/10;
            transform.position = Vector3.Lerp(new Vector3(xPosOld + _offset, yPosOld + _offset, 0), new Vector3(xPosNew + _offset, yPosNew + _offset, 0), t);
            canMove = false;
            StartCoroutine(MaCoroutine());
        }
    }

    public void SlowUp()
    {
        slowUpgrade += 0.005f;
    }

    private IEnumerator MaCoroutine()
    {
        yield return new WaitForSeconds(0.01f + slowUpgrade);
        canMove = true;
    }

    public void SizeUp()
    {
        transform.localScale = transform.localScale * 1.2f;
    }
}
