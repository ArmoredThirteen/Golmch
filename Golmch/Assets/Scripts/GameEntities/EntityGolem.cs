using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATE
{
    public class EntityGolem : GameEntity, ITargetable, IDamageable
    {
        public List<Ability_Activated> activatedAbilities = new List<Ability_Activated> ();

        public int MaxHealth { get; private set; }
        public int Health { get; private set; }
        public int MaxMana { get; private set; }
        public int Mana { get; private set; }
        public int Armor { get; private set; }

        public bool IsDown { get => this.Health <= 0; }

        public float TotalWeight { get; private set; }
        public float ManaPerMove { get; private set; }


        public void ApplyDamage(Damage damage)
        {
            if (IsDown)
                return;

            //TODO: Actual damage math with armor and all that
            Health -= Mathf.CeilToInt (damage.amount);

            if (IsDown)
                OnDowned ();
        }

        public void OnDowned()
        {
            Debug.Log("Golem Downed: " + gameObject.name);
        }


        public void OnTarget()
        {
            throw new System.NotImplementedException ();
        }


        public void ApplyBlueprint(GolemBlueprint blueprint)
        {
            //TODO: Mana, health, and maybe armor can be modified by gears
            MaxHealth = blueprint.StartHealth;
            Health    = blueprint.StartHealth;
            MaxMana   = blueprint.StartMana;
            Mana      = blueprint.StartMana;
            Armor     = blueprint.armorCount;

            TotalWeight = blueprint.TotalWeight;
            ManaPerMove = blueprint.ManaPerMove;

            activatedAbilities.Clear ();
            //TODO: The rest of the owl's ability list
            // For each activated ability, apply appropriate modifiers
            // Then take the finished ability and add that to this list
        }
    }
}