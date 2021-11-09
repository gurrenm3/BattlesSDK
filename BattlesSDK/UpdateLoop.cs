using System.Collections.Generic;
using System.Threading.Tasks;
using BattlesSDK.Interfaces;

namespace BattlesSDK
{
    class UpdateLoop
    {
        List<IBattlesMod> battlesMods = new List<IBattlesMod>();

        public UpdateLoop(List<IBattlesMod> battlesMods)
        {
            this.battlesMods = battlesMods;
        }

        public void StartUpdateLoop()
        {
            while (true)
            {
                FireUpdate();
            }
        }

        public void StartUpdateLoopAsync()
        {
            Task.Factory.StartNew(() => StartUpdateLoop());
        }

        private void FireUpdate()
        {
            battlesMods.ForEach(mod => mod.Update());
        }
    }
}
