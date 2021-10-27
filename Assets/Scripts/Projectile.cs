using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Ez;
using Syrinj;

public class Projectile : MonoBehaviour, IProjectile
{
    // [Inject("PlayerShip")]             // <= Dependency Injection from Syrinj
    // private GameObject PlayerShip;     // <= For the Singleton Pattern
    private GameObject _firingGameObject; // <= For the Messaging Pattern (superior)
    
    [SerializeField]private int Damage = 10;
    //[SerializeField]private float Lifetime = 2f;
    [SerializeField]private float MoveSpeed = 5f;

    // When a message or request takes a parameter, we may use a property to define the message and shorten its usage code
    private EzMsg.EventAction<IArmor> ApplyDamageMsg {
        get {return _=>_.ApplyDamage(Damage);}
    }
    
    // If a message or request takes no parameter, we may simply declare it as static
    public static EzMsg.EventFunc<IArmor,int?> GetArmorHealth = _=>_.GetHealth();
    
    public void OnCollisionEnter2D(Collision2D other) {
        _firingGameObject.Send<IWeapon>(_ => _.Reload());  //Messaging Pattern
        Destroy(gameObject); //, 0.01f), if safe delay is to be introduced;

        // ** Message Chaining usage example:
        // EzMsg.Send<IArmor>(other.gameObject, _ => _.ApplyDamage(Damage))
        //     .Wait(2f)
        //     .Send<IWeapon>(gameObject, _=>_.Reload())
        //     .Run();
    }

    void Start()
    {
        //Invoke(nameof(SelfDestroy), Lifetime);    //For lifetime
    }

    void SelfDestroy()
    {
        //Destroy(gameObject);                      //For lifetime
    }

    public void Update()
    {
        transform.Translate(0f, MoveSpeed * Time.deltaTime, 0f);
    }

    public IEnumerable SetFiringGameObject(GameObject firingGameObject)
    {
        _firingGameObject = firingGameObject;
        yield return null;
    }

}