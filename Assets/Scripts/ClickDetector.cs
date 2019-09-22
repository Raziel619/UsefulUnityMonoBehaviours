using UnityEngine;

namespace Assets.Scripts
{
    //Call DetectClickedObject in Update() method to get the string name of the game object clicked by player
    //Only returns the topmost gameobject clicked
    //----------------------------------------------------------
    //This class is quite old, can be improved to be a static method instead
    //------------------------------------------------------
    public class ClickDetector : MonoBehaviour {

        private readonly RuntimePlatform _platform = Application.platform;
        
        private bool _isActive = true;

        public void SetActiveState(bool state)
        {
            _isActive = state;
        }

        public string DetectClickedObject()
        {
            if (!_isActive)
            {
                return null;
            }

            if (_platform == RuntimePlatform.WindowsEditor)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    return ReturnClickedObjectName(Input.mousePosition);
                }

            }

            else if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    return ReturnClickedObjectName(Input.GetTouch(0).position);
                }
            }
            else if (Input.GetKey(KeyCode.Mouse0))
            {
                return ReturnClickedObjectName(Input.mousePosition);
            }
        
            return null;
        }

        private string ReturnClickedObjectName(Vector3 pos)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
            Vector2 touchPos = new Vector2(wp.x, wp.y);
            var cols = Physics2D.OverlapPointAll(touchPos);

            if (cols.Length != 0)
            {
                var temp = cols[0].transform.gameObject;
                
                foreach (var hit in cols)
                {
                    if (temp.GetComponent<SpriteRenderer>().sortingOrder <
                        hit.GetComponent<SpriteRenderer>().sortingOrder)
                        temp = hit.transform.gameObject;
                }
                //Debug.Log(temp.transform.gameObject.name);
                return temp.transform.gameObject.name;
            }

            return null;            
            
        }
    }
}
