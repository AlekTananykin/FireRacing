using Assets.Code.Ability;
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
        private readonly float _projectileSpeed;

        public GunAbility(
            [NotNull] string viewPath,
            float projectilSpeed)
        {
            _viewPrefab = ResourceLoader.LoadObject<Rigidbody2D>(
                new ResourcePath{PathResource = viewPath});

            if (null == _viewPrefab)
                throw new InvalidOperationException($"{nameof(GunAbility)} " +
                    $"view requires {nameof(Rigidbody2D)} component!");

            _projectileSpeed = projectilSpeed;

        }

        public void Apply(IAbilityActivator activator)
        {
            var projectile = UnityEngine.Object.Instantiate(_viewPrefab);
            projectile.AddForce(activator.GetViewObject().transform.right * _projectileSpeed,
                ForceMode2D.Force);
        }
    }
}
