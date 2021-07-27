using Assets.Code.Ability;
using Assets.Code.Data;
using Assets.Code.Tools;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Ui
{
    class GunAbility: IAbility
    {
        private Rigidbody2D _viewPrefab;
        private AbilityItemConfig _config;

        public GunAbility(
            [NotNull] AbilityItemConfig config)
        {
            _config = config;

        }

        public void Apply(IAbilityActivator activator)
        {
            var projectile = UnityEngine.Object.Instantiate(_viewPrefab);
            projectile.AddForce(activator.GetViewObject().transform.right * _config._value,
                ForceMode2D.Force);
        }
    }
}
