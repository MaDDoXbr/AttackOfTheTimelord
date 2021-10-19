using System.Collections;
using UnityEngine.EventSystems;

public interface IProjectile : IEventSystemHandler
{
    IEnumerable SetFiringWeapon(IWeapon weapon);
}