using Assets.Code.Ability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Ui
{
    class StubAbility : IAbility
    {
        public static IAbility Default = new StubAbility();

        public void Apply(IAbilityActivator activator)
        {
        }
    }
}
