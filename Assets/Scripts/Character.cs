using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { CERBERUS, MAGIC_SKELETON, NORMAL_SKELETON};
public abstract class Character
{

    private string _name;
    private Sprite _sprite;
    protected float damage;
    public float health ;
    private float maxHealth;
    public Character() { }
    public Character(string name, float damage, float health, Sprite sprite) // para que todos los hijos del character tengan nombre daño y un sprite  
    {
        this._name = name;
        this.damage = damage;
        _sprite = sprite;
        this.health = health;
        health = maxHealth; 
    }


    public Sprite GetSprite() // el metodo que aparecera en los hijos para los sprites  
    {
        return _sprite;
    }
    public float GetDamage()  // el metodo que aparecera en los hijos para el daño 
    {
        return damage;
    }

    public string GetName() // el metodo que aparecera en los hijos para el nombre 

    {
        return _name;
    }
    public virtual float Heal() //el metodo que aparecera en los hijos para la vida 

    {
        health = Mathf.Clamp(health, 0, maxHealth); // con esto podemos hacer que se cure cualquiera clampeandose al maximo de vida que tenga 
        return health;
    }
    public abstract float Attack();
}
