using System.Collections;
using UnityEngine;

namespace Assets.Personajes.Astronaut.scripts
{
    public class AstronautEntity : MonoBehaviour
    {
        public float speed = 1.0f;
        public float jumpForce = 1.0f;
        public readonly float gravityScale = 0.6f;
        public Rigidbody rb;
        public int plankCount = 0;
        public int rockCount = 0;
        public int sandCount = 0;
        public int life = 0;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

    }
}