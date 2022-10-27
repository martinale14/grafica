using System.Collections;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace Assets.Personajes.Astronaut.scripts
{
    public class GravitySystem : MonoBehaviour
    {
        public static void SetGravityScale(float gravityScale, Rigidbody rb)
        {
            rb.AddForce(9.8f * gravityScale * Vector3.down);

        }
    }
}