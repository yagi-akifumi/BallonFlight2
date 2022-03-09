using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBoss : MonoBehaviour
{
    private enum BossState
    {
        StartEnsyutu,
        Battle,
        ClearEnsyutu
    }

    private BossState bossState = BossState.StartEnsyutu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //  switch (nowState)
        //  {
        //     case BossState.StartEnsyutu:
        // 登場演出時の処理をここに書く
        //break;
        //  case BossState.Battle:
        // 登場演出時の処理をここに書く
        //break;
        //  case BossState.ClearEnsyutu:
        // クリア時の処理をここに書く
        //break;
    }
}

//private void StartEnsyutu()
//{
//演出の処理を書く
//
//if (演出の処理が終わったら)
//{
//nowState = BossState.Battle;
//        }
//    }

//private void Battle()
//{
//--hp;
//if (hp <= 0)
//{
//    nowState = BossState.ClearEnsyutu:
//}
//else
//{
//点滅してしばらく無敵になるとか
//（点滅のやり方はプレイヤーのスクリプト参照）
//}
//}

//private void ClearEnsyutu()
//{
//演出の処理を書く

//if (演出の処理が終わったら)
//{
//SceneManager.LoadScene("");
//        }
//    }

//}

