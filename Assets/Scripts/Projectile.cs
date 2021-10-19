using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Ez; //Ez2=Ez.Msg;

public class Projectile : MonoBehaviour, IProjectile
{
    private Weapon FiringWeapon;
    [SerializeField]private int Damage = 10;
    [SerializeField]private float Lifetime = 2f;
    private float MoveSpeed = 10f;

    // When a message or request takes a parameter, we may use a property to define the message and shorten its usage code
    private EzMsg.EventAction<IArmor> ApplyDamageMsg {
        get {return _=>_.ApplyDamage(Damage);}
    }
    
    // If a message or request takes no parameter, we may simply declare it as static
    public static EzMsg.EventFunc<IArmor,int?> GetArmorHealth = _=>_.GetHealth();
    
    public void OnTriggerEnter(Collider other) {
        EzMsg.Send<IArmor>(other.gameObject, _ => _.ApplyDamage(Damage))
            .Wait(2f)
            .Send<IWeapon>(gameObject, _=>_.Reload())
            .Run();
    }

    public IEnumerable SetFiringWeapon(IWeapon firingWeapon)
    {
        FiringWeapon = firingWeapon as Weapon;
        yield return null;
    }

    public void Start()
    {
        Invoke(nameof(SelfDestroy), Lifetime);
    }
    public void Update()
    {
        transform.Translate(0f, MoveSpeed * Time.deltaTime, 0f);
    }

    void SelfDestroy()
    {
        Destroy(gameObject);
    }
}