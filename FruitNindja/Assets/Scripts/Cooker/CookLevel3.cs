using System;
using UnityEngine;

namespace Cooker
{
    public class CookLevel3 : MonoBehaviour
    {
        [SerializeField] private Vector3 _forceFridgeDirection;
        [SerializeField] private GameObject _spanch;
        [SerializeField] private GameObject _spanchPrefab;
        
        private ForceMode _forceMode = ForceMode.Impulse;
        private float _force = 15;

        private void Start()
        {
            GetComponent<Animator>().SetInteger("level", 3);
            AudioManager.Instance.PlayMusic("Spanch");
        }

        public void ThrowTheSpanch()
        {
            var localPosition = _spanch.transform.position;
            var localRotation = _spanch.transform.rotation;
            var scale = _spanch.transform.lossyScale;
        
            Destroy(_spanch);

            var newSpanch = Instantiate(_spanchPrefab, localPosition, localRotation);
            newSpanch.transform.localScale = scale;

            var rb = newSpanch.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(_forceFridgeDirection * _force, _forceMode);
        }
    }
}
