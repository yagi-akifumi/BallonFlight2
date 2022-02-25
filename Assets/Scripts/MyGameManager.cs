using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelectCharacter
{

    public class MyGameManager : MonoBehaviour
    {
        //　世界に一つだけのMyGameManager
        private static MyGameManager myGameManager;
        //　ゲーム全体で管理するデータ
        [SerializeField]
        private MyGameManagerData myGameManagerData = null;

        private void Awake()
        {
            //　世界に一つだけのMyGameManagerにする処理
            if (myGameManager == null)
            {
                myGameManager = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        //　MyGameManagerDataを返す
        public MyGameManagerData GetMyGameManagerData()
        {
            return myGameManagerData;
        }
    }
}