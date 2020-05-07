using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]

    /// <summary>
    /// Velocidad a la que se mueve el personaje
    /// </summary>
    [SerializeField]
    private float movementSpeed = 10F;

    [Header("Shoot")]

    /// <summary>
    /// Fuerza a la que se dispara la bala
    /// </summary>
    [SerializeField]
    private float bulletForce;

    /// <summary>
    /// Tiempo que demora el jugador sin poder disparar después de un disparo efectivo
    /// </summary>
    [SerializeField]
    private float shootCooldown=0.2F;

    /// <summary>
    /// El punto en el que se instancia la bala
    /// </summary>
    [SerializeField]
    private Transform bulletSpawnPosition;

    [Header("Bullet Prefabs")]

    /// <summary>
    /// Prefab del primer tipo de bala
    /// </summary>
    [SerializeField]
    private GameObject redBulletGO;

    /// <summary>
    /// Prefab del segundo tipo de bala
    /// </summary>
    [SerializeField]
    private GameObject yellowBulletGO;

    /// <summary>
    /// Bala seleccionada para disparar
    /// </summary>
    [SerializeField]
    private GameObject selectedBullet;

    private bool canShoot = true;

    private int puntajeAm;
    private int puntajeRojo;

    public int PuntajeAm { get => puntajeAm; set => puntajeAm = value; }
    public int PuntajeRojo { get => puntajeRojo; set => puntajeRojo = value; }

    private void Start()
    {
        selectedBullet = redBulletGO;
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontalMovement = Input.GetAxis("Mouse X");
        Debug.Log(PuntajeRojo);
        Debug.Log(PuntajeAm);
        

        if (horizontalMovement != 0)
        {
            transform.Translate(transform.right * horizontalMovement * movementSpeed * Time.deltaTime);
        }
        if (canShoot && Input.GetKeyDown(KeyCode.Space))
        {
            canShoot = false;
            Invoke("ResetCanShoot", shootCooldown);
            
            GameObject bulletClone = Instantiate(
                selectedBullet, bulletSpawnPosition.position, transform.rotation);

            Rigidbody bulletRB = bulletClone.GetComponent<Rigidbody>();

            if (bulletRB != null)
            {
                bulletRB.AddForce(bulletClone.transform.forward * bulletForce, ForceMode.Impulse);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            
            selectedBullet = yellowBulletGO;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedBullet = redBulletGO;
        }
    }

    private void ResetCanShoot()
    {
        canShoot = true;
    }
    public void aumentarPuntajeAm()
    {
        PuntajeAm += 1;
    }
    public void aumentarPuntajeRojo()
    {
        PuntajeRojo += 1;
    }
}