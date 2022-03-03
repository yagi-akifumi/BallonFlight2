using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("加算スコア")] public int myScore;
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("画面外でも行動するか")] public bool nonVisible;
    [Header("接触判定")] public EnemyCollisionCheck checkCollision;
    [Header("敵を踏んだ時に鳴らすSE")] public AudioClip enemySE;

    #endregion

    #region//プライベート変数
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private Animator anim = null;
    private ObjectCollision oc = null;
    private CapsuleCollider2D col = null;
    private bool rightTleftF = false;
    private bool isDead = false;
    private Vector3 defaultScale;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        oc = GetComponent<ObjectCollision>();
        col = GetComponent<CapsuleCollider2D>();
        defaultScale = transform.localScale;//初期の大きさを保存する
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (!oc.playerStepOn)
        {
            if (sr.isVisible || nonVisible)
            {
                if (checkCollision.isOn)
                {
                    rightTleftF = !rightTleftF;
                }
                
                int xVecter = -1;
                if (rightTleftF)
                {
                    xVecter = 1;
                    transform.localScale = new Vector3(-defaultScale.x, defaultScale.y, defaultScale.z);
                }
                else
                {
                    transform.localScale = new Vector3(defaultScale.x, defaultScale.y, defaultScale.z);
                }
                rb.velocity = new Vector2(xVecter * speed, -gravity);
            }
            else
            {
                rb.Sleep();
            }
        }
        else
        {
            if (!isDead)
            {
                GManager.instance.PlaySE(enemySE);
                anim.Play("Death");
                rb.velocity = new Vector2(0, -gravity);
                isDead = true;
                col.enabled = false;
                if (GManager.instance != null)
                {
                    GManager.instance.score += myScore;
                }
                Destroy(gameObject, 3f);
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, 5));
            }
        }
    }
}