using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATE
{
	public class Printer_Golem : EntityPrinter
	{
        public EntityGolem entity;
        public GolemBlueprint blueprint;

        public bool printOnStart = false;


        [ContextMenu("Spawn Golem")]
        public override GameEntity SpawnEntity()
        {
            EntityGolem printed = Instantiate(entity, transform.position, Quaternion.identity);
            printed.ApplyBlueprint(blueprint);

            return printed;
        }


        void Start()
        {
            if (printOnStart)
                SpawnEntity();
        }

    }
}