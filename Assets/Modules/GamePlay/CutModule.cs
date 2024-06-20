using System;
using UnityEngine;

namespace Modules.GamePlay
{
    public class CutModule: MonoBehaviour
    {
        private readonly ObjectAppearanceManager _objectAppearanceManager = new ObjectAppearanceManager();
        public GameObject gameObject0;
        public GameObject gameObject1;
        public GameObject gameObject2;
        public GameObject position1;
        public GameObject position2;
        public new string tag = "networkcable";

        void Start()
        {
            Debug.Log("Hello");
            _objectAppearanceManager.SetActive(gameObject2, true);
            _objectAppearanceManager.TransferChildren(gameObject2, gameObject0);
            _objectAppearanceManager.SetActive(gameObject1, false);
            _objectAppearanceManager.SetActive(gameObject2, false);
        }
        
        private void OnTriggerStay(Collider other)
        {
            if (!other.CompareTag(tag) || !InputDevicesManagement.Instance.IsTriggerPressed()) return;
            // _objectAppearanceManager.TransferChildren(gameObject1, gameObject0);
            _objectAppearanceManager.SetActive(gameObject1, position1, true);
            _objectAppearanceManager.SetActive(gameObject2, position2, true);
            _objectAppearanceManager.TransferChildren(gameObject2, gameObject0);
        }
        
    }
}