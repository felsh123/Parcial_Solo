using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    string color;
    [SerializeField]
    float autoDestr=3F;
    [SerializeField]
    private ParticleSystem hitParticleSystemAcierto;
    [SerializeField]
    private ParticleSystem hitParticleSystemErrado;

    private void Start()
    {
        //TESTINGTWO
        //TESTINGCALLEJAS
        //testing3
        // Autodestrucción de la bala
        Invoke("Destroy", autoDestr);
    }
    
    private void Destroy()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision) //detectar colisión sólida.
    {
        Target target = collision.gameObject.GetComponent<Target>();
        PlayerController player = (PlayerController)FindObjectOfType(typeof(PlayerController));

        if (target != null)
        {
            if (target.color == "rojo" && color == "rojo")
            {

                player.aumentarPuntajeRojo();
                Destroy(collision.gameObject);
                Destroy(gameObject);
                ParticleSystem psInstance = Instantiate<ParticleSystem>(
                hitParticleSystemAcierto,
                collision.contacts[0].point,
                Quaternion.identity);
                
                Destroy(psInstance.gameObject, 0.5F);

            }
            else if(target.color=="rojo"&& color == "amarillo")
            {
                ParticleSystem psInstance = Instantiate<ParticleSystem>(
                hitParticleSystemErrado,
                collision.contacts[0].point,
                Quaternion.identity);
                Destroy(psInstance.gameObject, 0.5F);

            }
            if (target.color == "amarillo" && color == "amarillo")
            {
                player.aumentarPuntajeAm();
                Destroy(collision.gameObject);
                Destroy(gameObject);
                ParticleSystem psInstance = Instantiate<ParticleSystem>(
                hitParticleSystemAcierto,
                collision.contacts[0].point,
                Quaternion.identity);
                
                Destroy(psInstance.gameObject, 0.5F);
            }
            else if (target.color == "amarillo" && color == "rojo")
            {
                ParticleSystem psInstance = Instantiate<ParticleSystem>(
                hitParticleSystemErrado,
                collision.contacts[0].point,
                Quaternion.identity);
                Destroy(psInstance.gameObject, 0.5F);
            }
            Destroy(gameObject);

        }
    }
}