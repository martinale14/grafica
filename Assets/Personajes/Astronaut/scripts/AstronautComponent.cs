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
            
            if(other.gameObject.CompareTag("Plank"))
            {
                Destroy(other.gameObject);
                entity.plankCount++;
                if(entity.plankCount >= 5)
                {
                    GameObject.Find("RawImageRecompensa").GetComponent<RawImage>().enabled = true;
                    GameObject.Find("RawImageRecompensa").GetComponent<VideoPlayer>().Play();
                }
            }
            if (other.gameObject.CompareTag("Rock"))
            {
                Destroy(other.gameObject);
                entity.rockCount++;
                if (entity.plankCount >= 8)
                {
                    //GameObject.Find("RawImageRecompensa").GetComponent<RawImage>().enabled = true;
                    //.Find("RawImageRecompensa").GetComponent<VideoPlayer>().Play();
                }
            }
            if (other.gameObject.CompareTag("Sand"))
            {
                Destroy(other.gameObject);
                entity.sandCount++;
                if (entity.plankCount >= 10)
                {
                    //GameObject.Find("RawImageRecompensa").GetComponent<RawImage>().enabled = true;
                    //GameObject.Find("RawImageRecompensa").GetComponent<VideoPlayer>().Play();
                }
            }
        }

    }

}