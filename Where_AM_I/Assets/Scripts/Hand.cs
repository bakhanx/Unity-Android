using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public string handName; // 근접
    public float range; // 공격 범위
    public int damage; // 공격력
    public float workSpeed; // 작업 속도
    public float attackDelay; // 연속 공격 딜레이
    public float attackDelayA; // 공격 활성화
    public float attackDelayB; // 공격 비활성화

    public Animator anim; // 애니메이션
 
}
