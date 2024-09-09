using UnityEngine;
using System.Collections;

public class RotationCharacter : MonoBehaviour
{

    public GameObject Character;

    void Update()
    {
        transform.Rotate(new Vector3(0, 1f, 0));
    }
}
