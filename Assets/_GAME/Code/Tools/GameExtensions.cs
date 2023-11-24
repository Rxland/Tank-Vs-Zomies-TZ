using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _GAME.Code.Tools
{
    public static class GameExtensions
    {
        private static System.Random random = new System.Random();
        
        public static float CalculatePercentageOfTheNumber(int percentage, int number)
        {
            float cof = number / 100f;
            
            return cof * percentage;
        }

        public static bool CheckIfAgentReachedDestination(NavMeshAgent agent)
        {
            if (!agent.pathPending && !agent.isStopped)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static void CopyValues<T>(T formBase, T copy)
        {
            Type type = formBase.GetType();

            foreach (FieldInfo field in type.GetFields())
            {
                field.SetValue(copy, field.GetValue(formBase));
            }
        }
        
        public static bool IsLayerInMask(LayerMask mask, int layer)
        {
            return (mask.value & (1 << layer)) != 0;
        }
        
        public static Vector3 GetNavMeshPosition(Vector3 targetPosition, float maxDistance)
        {
            NavMeshHit navMeshHit;

            if (NavMesh.SamplePosition(targetPosition, out navMeshHit, maxDistance, NavMesh.AllAreas))
            {
                return navMeshHit.position;
            }

            return targetPosition;
        }
        
        public static bool IsSceneExists(string sceneName)
        {
            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
                string sceneNameInBuildSettings = System.IO.Path.GetFileNameWithoutExtension(scenePath);

                if (sceneNameInBuildSettings == sceneName)
                {
                    return true;
                }
            }
            return false;
        }
        public static T GetRandomEnumValue<T>()
        {
            Array values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(random.Next(values.Length));
        }
        
        public static float RoundToDecimalPlaces(float value, int decimalPlaces)
        {
            float multiplier = (float)Math.Pow(10, decimalPlaces);

            return (float)Math.Round(value * multiplier) / multiplier;
        }
        
        public static bool IsInsideImageArea(Image uiImage, Vector2 inputPos)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(uiImage.rectTransform, inputPos))
            {
                return true;
            }
            return false;
        }
        
        public static Collider FindNearestCollider(Transform checkFrom, Collider[] objectsToCheck)
        {
            Collider nearestObject = null;
            float shortestDistance = float.MaxValue;

            foreach (Collider obj in objectsToCheck)
            {
                if (obj != null)
                {
                    float distance = Vector3.Distance(checkFrom.position, obj.transform.position);

                    if (distance < shortestDistance)
                    {
                        shortestDistance = distance;
                        nearestObject = obj;
                    }
                }
            }

            if (nearestObject != null)
            {
                return nearestObject;
            }

            return objectsToCheck[0];
        }
        
        public static bool IsPointerOverUIObject()
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            return results.Count > 0;
        }
        
        public static string FormatNumber(float number)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US").NumberFormat;
            nfi.NumberDecimalSeparator = ",";
            
            if (number >= 1000000000000)
            {
                // Trillion
                return (number / 1000000000000.0).ToString("0.00TH", nfi);
            }
            else if (number >= 1000000000)
            {
                // Billion
                return (number / 1000000000.0).ToString("0.00B", nfi);
            }
            else if (number >= 1000000)
            {
                // Million
                return (number / 1000000.0).ToString("0.00M", nfi);
            }
            else if (number >= 1000)
            {
                // Thousand
                return (number / 1000.0).ToString("0.00K", nfi);
            }
            else
            {
                // Less than a thousand
                return number.ToString("0", nfi);
            }
        }
    }
}