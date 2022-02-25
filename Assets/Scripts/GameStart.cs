using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SelectCharacter
{
    public class GameStartButton : MonoBehaviour
    {
        private SceneTransition sceneTransition;

        private void Start()
        {
            sceneTransition = FindObjectOfType<SceneTransition>();
        }

        public void OnGameStart()
        {
            //　MyGameManagerDataに保存されている次のシーンに移動する
            sceneTransition.GameStart();
        }
    }
}
