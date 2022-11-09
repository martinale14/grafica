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
        public Image imageUI;

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

		private void OnCollisionEnter(Collision other)
		{
			 if (other.gameObject.CompareTag("Meteoro"))
            {

                Destroy(other.gameObject);
                entity.life--;
                Debug.Log(entity.life);
                imageUI = GameObject.Find("lifeBar").GetComponent<Image>();
                if (entity.life == 2)
                {
                    imageUI.sprite = Resources.Load<Sprite>("hud/yellowLife");
                }
                if (entity.life == 1)
                {
                    imageUI.sprite = Resources.Load<Sprite>("hud/redLife");
                }
                if (entity.life == 0)
                {
                    imageUI.sprite = Resources.Load<Sprite>("hud/noLife");
                    /*
                     * 
                     * Aqui va lo del GameOver
                     * 
                     */
                }
            }
		}



	}

}