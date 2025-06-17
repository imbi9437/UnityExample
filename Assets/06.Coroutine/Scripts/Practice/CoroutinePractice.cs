using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

namespace _06.CoroutineTest
{
    public class CoroutinePractice : MonoBehaviour
    {
        public CoroutineEnemy[] enemies;
        public float damage;

        private YieldInstruction yieldInstruction;
        private void Start()
        {
            yieldInstruction = new WaitForSeconds(1f);
            //모든 적에게 초마다 damage만큼 hp를 깎아서 hp가 0보다 작아지면 코루틴을 종료하도록 해보세요.

            foreach (CoroutineEnemy enemy in enemies)
            {
                StartCoroutine(HitCo(enemy));
            }
        }

        IEnumerator HitCo(CoroutineEnemy enemy)
        {
            while (enemy.hp > 0)
            {
                yield return yieldInstruction;
                enemy.hp -= damage;
                Debug.Log($"{enemy.name}이 {damage}만큼의 데미지를 입음 현재 남은 체력 {enemy.hp}");
            }
            
            Debug.Log($"{enemy.name} 쓰러트림");
        }
    }
}