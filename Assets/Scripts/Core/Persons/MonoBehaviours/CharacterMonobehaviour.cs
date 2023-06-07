using Application = MonstersSurvival.Application;
using System.Collections;
using Leopotam.Ecs;
using UnityEngine;
using Components;

namespace Core.Monobehaviour
{
    public sealed class CharacterMonobehaviour : MonoBehaviour
    {
        //[SerializeField] private LayerMask _dealingDamageLayers;

        //private bool _isGettingDamage;

        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    if ((_dealingDamageLayers.value & collision.gameObject.layer) == 0)
        //    {
        //        if (collision.gameObject.TryGetComponent<EnemyMonoBehaviour>(out var enemyMono))
        //            StartCoroutine(GetDamageRoutine(enemyMono.Enemy.DamageAmount));

        //        _isGettingDamage = true;
        //    }
        //}

        //private void OnTriggerExit2D(Collider2D collision)
        //{
        //    if ((_dealingDamageLayers.value & collision.gameObject.layer) == 0)
        //    {
        //        if (collision.gameObject.TryGetComponent<EnemyMonoBehaviour>(out var enemyMono))
        //            _isGettingDamage = false;
        //    }
        //}

        //private IEnumerator GetDamageRoutine(int value)
        //{
        //    while (_isGettingDamage)
        //    {
        //        Application.Model.GetCharacterEntity().Replace(new HealthDecComponent
        //        {
        //            Value = value
        //        });

        //        yield return new WaitForSecondsRealtime(2f);
        //    }

        //    yield break;
        //}
    }
}
