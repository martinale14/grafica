using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Assets.Personajes.Astronaut.scripts
{
    public class AstronautComponent : MonoBehaviour
    {
        private AstronautEntity entity;
        private MovementSystem movementSystem;

        private void Start()
        {
            entity = GetComponent<AstronautEntity>();
            movementSystem = GetComponent<MovementSystem>();
        }

        void Update()
        {
            movementSystem.Move(entity.speed, entity.rb, entity.jumpForce);
        }

        private void FixedUpdate()
        {
            GravitySystem.SetGravityScale(entity.gravityScale, entity.rb);
        }


        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.gameObject.tag);
            if(other.gameObject.CompareTag("Plank"))
            {
                Destroy(other.gameObject);
                entity.plankCount++;
                if(entity.plankCount >= 3)
                {
                    GameObject.Find("RawImageRecompensa").GetComponent<RawImage>().enabled = true;
                    GameObject.Find("RawImageRecompensa").GetComponent<VideoPlayer>().Play();
                }
            }
        }
    }

}