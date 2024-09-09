using UnityEngine;
using System.Collections;

public class WeatherChanger : MonoBehaviour
{

    public GameObject effect1, effect2, effect3, effect4;

    void OnGUI()
    {
        GUILayout.Space(20.0f);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Rain"))
        {
            effect2.SetActive(false);
            effect3.SetActive(false);

            foreach (Transform child in effect4.transform)
            {
                child.gameObject.SetActive(false);
            }

            effect1.SetActive(true);
        }

        if (GUILayout.Button("Snow"))
        {
            effect1.SetActive(false);
            effect3.SetActive(false);

            foreach (Transform child in effect4.transform)
            {
                child.gameObject.SetActive(false);
            }

            effect2.SetActive(true);
        }

        if (GUILayout.Button("Sand Storm"))
        {
            effect1.SetActive(false);
            effect2.SetActive(false);

            foreach (Transform child in effect4.transform)
            {
                child.gameObject.SetActive(false);
            }

            effect3.SetActive(true);
        }

        if (GUILayout.Button("Polar Lights"))
        {
            effect1.SetActive(false);
            effect2.SetActive(false);
            effect3.SetActive(false);

            foreach (Transform child in effect4.transform)
            {
                child.gameObject.SetActive(true);
            }
        }
        GUILayout.EndHorizontal();
    }
}
