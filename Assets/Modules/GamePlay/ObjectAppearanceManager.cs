using UnityEngine;

namespace Modules.GamePlay
{
    public class ObjectAppearanceManager: IObjectAppearanceManager
    {
        public void SetActive(GameObject obj, GameObject position, bool isActive)
        {
            obj.SetActive(isActive);
            obj.transform.position = position.transform.position;
            obj.transform.rotation = position.transform.rotation;
        }

        public void SetActive(GameObject obj, bool isActive)
        {
            obj.SetActive(isActive);
        }

        public void TransferChildren(GameObject fromObj, GameObject toObj)
        {
            // setActive các gameobject con của GameObject0 thành false
            foreach (Transform child in toObj.transform)
            {
                child.gameObject.SetActive(false);
            }
            
            // Chuyển hết gameobject con của GameObject1 thành gameobject con của GameObject0
            foreach (Transform child in fromObj.transform)
            {
                child.SetParent(toObj.transform, true);
            }
        }
    }
}