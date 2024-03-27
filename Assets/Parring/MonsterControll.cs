using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControll : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;
    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Invoke("Think", 5f);
    }

    void FixedUpdate() 
    {
        //Move
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);    
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.3f , rigid.position.y);
        
        //Platform Layer Check
        Debug.DrawRay(frontVec,Vector3.down,new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1,LayerMask.GetMask("Platform"));
        if (rayHit.collider == null)
        {
            nextMove *= -1;
            CancelInvoke();
            Invoke("Think", 5);
        }
        
    }

    void Think()
    {
        nextMove = Random.Range(-1,2);
        if (nextMove <0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // 왼쪽 바라보기
        }
        else if (nextMove >0)
        {
            transform.localScale = new Vector3(1, 1, 1); // 오른쪽 바라보기
        }

        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);

    }
}