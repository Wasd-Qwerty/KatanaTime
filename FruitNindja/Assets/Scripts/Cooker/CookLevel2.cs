using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cooker
{
    public class CookLevel2 : MonoBehaviour
    {
        [Header("ExplosionSettings")] [SerializeField]
        private List<GameObject> _gameObjectsForExplosion;

        [SerializeField] private float _explosionForce;
        [SerializeField] private Transform _explosionTransform;
        [SerializeField] private float _explosionRadius;
        [SerializeField] private float _upwardsModifier;
        [SerializeField] private ForceMode _expMode;

        [Header("TableSettings")] [SerializeField]
        private Rigidbody _rbTable;

        [SerializeField] private Vector3 _forcePosition;
        [SerializeField] private float _force;
        [SerializeField] private ForceMode _tableMode;

        private void Start()
        {
            GetComponent<Animator>().SetInteger("level", 2);
        }

        public void ThrowTable()
        {
            _rbTable.AddForce(_forcePosition * _force, _tableMode);
            foreach (var gObject in _gameObjectsForExplosion)
            {
                gObject.AddComponent<SphereCollider>();
                gObject.AddComponent<Rigidbody>().AddExplosionForce(_explosionForce, _explosionTransform.position,
                    _explosionRadius, _upwardsModifier, _expMode);
                Destroy(gObject, 4);
            }
        }
    }
}