using System;
using UnityEngine;

namespace Cooker
{
    public class CookLevel1 : MonoBehaviour
    {
        [SerializeField] private Vector3 _forceFridgeDirection;
        [SerializeField] private GameObject _fridge;
        [SerializeField] private GameObject _fridgePrefab;
        
        private ForceMode _forceMode = ForceMode.Impulse;
        private float _force = 15;

        private void Start()
        {
            GetComponent<Animator>().SetInteger("level", 1);
        }

        public void ThrowTheFridge()
        {
            var localPosition = _fridge.transform.position;
            var localRotation = _fridge.transform.rotation;
            var scale = _fridge.transform.lossyScale;
        
            Destroy(_fridge);

            var newFridge = Instantiate(_fridgePrefab, localPosition, localRotation);
            newFridge.transform.localScale = scale;

            var rb = newFridge.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(_forceFridgeDirection * _force, _forceMode);
        }
    }
}
