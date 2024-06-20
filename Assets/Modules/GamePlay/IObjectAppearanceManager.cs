using UnityEngine;

namespace Modules.GamePlay
{
    public interface IObjectAppearanceManager
    {
        void SetActive(GameObject obj, GameObject position, bool isActive);
        void SetActive(GameObject obj, bool isActive);

        
        public void TransferChildren(GameObject fromObj, GameObject toObj);
    }
}
