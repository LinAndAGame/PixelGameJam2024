using System;
using DefaultNamespace.UI;
using DG.Tweening;
using Enemy;
using MyGameUtility;
using Player;
using UnityEngine;

namespace DefaultNamespace {
    public class GameManager : MonoSingletonSimple<GameManager> {
        public Panel_Defeat PanelDefeat;
        public Panel_Win    PanelWin;
        public BossCtrl     BossCtrlRef;
        public PlayerCtrl   PlayerCtrlRef;
        public Transform    Trans_BossPos;
        public Transform    Trans_PlayerPos;

        private void Start() {
            PanelDefeat.Init();
            PanelWin.Init();
            BossCtrlRef.Init();
            Restart();
        }

        public void Restart() {
            DOTween.KillAll();
            BossCtrlRef.Restart();
            PanelDefeat.Hide();
            PanelWin.Hide();
            BossCtrlRef.transform.position   = Trans_BossPos.position;
            PlayerCtrlRef.transform.position = Trans_PlayerPos.position;
        }

        public void Defeat() {
            PanelDefeat.Display();
        }

        public void Win() {
            PanelWin.Display();
        }
    }
}