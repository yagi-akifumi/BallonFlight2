using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //New!

public class StageCtrl : MonoBehaviour
{
    [Header("プレイヤーゲームオブジェクト")] public GameObject playerObj;
    [Header("コンティニュー位置")] public GameObject[] continuePoint;
    [Header("ゲームオーバー")] public GameObject gameOverObj;
    [Header("フェード")] public FadeImage fade;
    [Header("ゲームオーバー時に鳴らすSE")] public AudioClip gameOverSE;
    [Header("リトライ時に鳴らすSE")] public AudioClip retrySE;

    private Player p;
    private int nextStageNum;
    private bool startFade = false;
    private bool doGameOver = false;
    private bool retryGame = false;
    private bool doSceneChange = false;

    // Start is called before the first frame update
    void Start()
    {
        if (playerObj != null && continuePoint != null && continuePoint.Length > 0 && gameOverObj != null && fade != null)
        {
            gameOverObj.SetActive(false); // New!
            playerObj.transform.position = continuePoint[0].transform.position;
            p = playerObj.GetComponent<Player>();
            if (p == null)
            {
                Debug.Log("プレイヤーじゃない物がアタッチされているよ！");
            }
        }
        else
        {
            Debug.Log("設定が足りてないよ！");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームオーバー時の処理
        if (GManager.instance.isGameOver && !doGameOver) //New!
        {
            gameOverObj.SetActive(true);
            GManager.instance.PlaySE(gameOverSE);
            doGameOver = true;
        }
        //プレイヤーがやられた時の処理
        else if (p != null && p.IsContinueWaiting() && !doGameOver)  //New!
        {
            if (continuePoint.Length > GManager.instance.continueNum)
            {
                playerObj.transform.position = continuePoint[GManager.instance.continueNum].transform.position;
                p.ContinuePlayer();
            }
            else
            {
                Debug.Log("コンティニューポイントの設定が足りてないよ！");
            }
        }

        //ステージを切り替える
        if (fade != null && startFade && !doSceneChange)
        {
            if (fade.IsFadeOutComplete())
            {
                //ゲームリトライ
                if (retryGame)
                {
                    GManager.instance.RetryGame();
                }
                //次のステージ
                else
                {
                    GManager.instance.stageNum = nextStageNum;
                }
                SceneManager.LoadScene("stage" + nextStageNum);
                doSceneChange = true;
            }
        }
    }

    /// <summary>
    /// 最初から始める New!
    /// </summary>
    public void Retry()
    {
        GManager.instance.PlaySE(retrySE); //New!
        ChangeScene(1); //最初のステージに戻るので１
        retryGame = true;
    }

    /// <summary>
    /// ステージを切り替えます。 New!
    /// </summary>
    /// <param name="num">ステージ番号</param>
    public void ChangeScene(int num)
    {
        if (fade != null)
        {
            nextStageNum = num;
            fade.StartFadeOut();
            startFade = true;
        }
    }
}