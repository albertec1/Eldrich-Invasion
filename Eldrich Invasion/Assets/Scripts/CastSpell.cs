using System.Runtime.CompilerServices;
using System.Collections;
using UnityEngine;

public class CastSpell : LaunchProjectile
{
    public enum SpellType
    {
        FIREBALL,
        METEORITE,
        FREEZING_CONE,
    
        NONE
    }
    
    public class Spell
    { 
       public SpellType type { get; }
       public float damage { get; }
       public float AOE { get; }           //0 means single target
      
       public Spell(SpellType type)        //Constructor, sets the corresponding values to every parameter of the spell.
       {
          switch(type)
            {
                case (SpellType.FIREBALL):
                    {
                        this.type = type;
                        damage = 1.0f;
                        AOE = 0.0f;
                    }
                    break;
            }
       }
    }

}

//public class CastSpell : MonoBehaviour
//{
//    [Tooltip("The projectile that's created")]
//    public GameObject projectilePrefab = null;

//    [Tooltip("The point that the project is created")]
//    public Transform startPoint = null;

//    [Tooltip("The speed at which the projectile is launched")]
//    public float launchSpeed = 1.0f;

//    public void Fire()
//    {
//        GameObject newObject = Instantiate(projectilePrefab, startPoint.position, startPoint.rotation);

//        if (newObject.TryGetComponent(out Rigidbody rigidBody))
//            ApplyForce(rigidBody);
//    }

//    private void ApplyForce(Rigidbody rigidBody)
//    {
//        Vector3 force = startPoint.forward * launchSpeed;
//        rigidBody.AddForce(force);
//    }
//}
