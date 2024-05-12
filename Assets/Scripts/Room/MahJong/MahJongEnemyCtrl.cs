using DG.Tweening;
using MoreMountains.Feedbacks;
using MyGameExpand;
using Player;
using UnityEngine;

namespace Room {
    public class MahJongEnemyCtrl : MonoBehaviour {
        public MMF_Player    Effect_Attack;
        public Transform     Trans_Model;
        public BoxCollider2D BoxCollider2DRef;

        public float JumpToSkyDuration    = 0.5f;
        public float DownToAttackDelay    = 1;
        public float DownToAttackDuration = 0.5f;
        public float DownHeight           = 10;

        private Vector3 _DownTargetPos;
        private Tweener _CurTweener;

        public MahJongEnemyState CurState { get; private set; }

        public void Init() {
            CurState = MahJongEnemyState.OnSky;
        }
        
        public void JumpToSky() {
            _CurTweener?.Kill();
            CurState                 = MahJongEnemyState.OnSky;
            BoxCollider2DRef.enabled = false;
            
            _CurTweener = this.transform.DOScale(Vector3.zero, JumpToSkyDuration);
            _CurTweener.SetEase(Ease.OutSine);
        }

        public void DownToAttack() {
            _CurTweener?.Kill();
            CurState                 = MahJongEnemyState.OnGround;
            BoxCollider2DRef.enabled = true;
            
            this.transform.localScale = Vector3.one;
            _DownTargetPos            = PlayerCtrl.I.Trans_Model.position;
            this.transform.position   = _DownTargetPos.SetY(DownHeight);
            _CurTweener               = this.transform.DOMove(_DownTargetPos, DownToAttackDuration);
            _CurTweener.SetDelay(DownToAttackDelay);
            _CurTweener.SetEase(Ease.OutSine);
            _CurTweener.onComplete += () => {
                Effect_Attack.PlayFeedbacks();
            };
        }
    }
}