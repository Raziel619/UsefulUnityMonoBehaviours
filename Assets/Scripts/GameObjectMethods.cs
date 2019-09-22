using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helpers
{
    //This particular class only contains static methods that can be called from other monobehaviours
    public static class GameObjectMethods
    {
        public static void DisableAllGameObjectsInArray(GameObject[] gameObjects)
        {
            foreach (GameObject go in gameObjects)
            {
                go.SetActive(false);
            }
        }

        public static void EnableAllGameObjectsInArray(GameObject[] gameObjects)
        {

            foreach (GameObject go in gameObjects)
            {
                go.SetActive(true);
            }
        }

        public static void EnableGameObjectByName(GameObject[] gameObjects, string name)
        {
            foreach (GameObject go in gameObjects)
            {
                if (go.name != name)
                {
                    go.SetActive(false);
                }
                else
                {
                    go.SetActive(true);
                }
            }
        }

        public static GameObject FindGameObjectInArray(GameObject[] gameObjects, string name)
        {
            foreach (GameObject go in gameObjects)
            {
                if (go.name == name)
                {
                    return go;
                }
            }
            return null;
        }
    }
}