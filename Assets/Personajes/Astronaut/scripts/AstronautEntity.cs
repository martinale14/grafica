using System.Collections;
using UnityEngine;

namespace Assets.Personajes.Astronaut.scripts
{
    public class AstronautEntity : MonoBehaviour
    {
        public float speed = 1.0f;
        public float jumpForce = 1.0f;
        public readonly float gravityScale = 0.8f;
        public Rigidbody rb;
        public int plankCount = 0;
        public int life = 3;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

    }
}