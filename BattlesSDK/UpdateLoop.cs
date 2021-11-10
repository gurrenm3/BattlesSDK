using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BattlesSDK.Api;
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
                //Task.Delay(100);
                Thread.Sleep(1);
            }
        }

        public void StartUpdateLoopAsync()
        {
            Task.Factory.StartNew(() => StartUpdateLoop());
        }

        private void FireUpdate()
        {
            for (int i = 0; i < battlesMods.Count; i++)
            {
                battlesMods[i].Update();
            }
        }


        /*public async void StartUpdateLoop()
        {
            while (true)
            {
                await FireUpdate();
                //Thread.Sleep(1);
            }
        }

        public void StartUpdateLoopAsync()
        {
            Task.Factory.StartNew(() => StartUpdateLoop());
        }

        private async Task FireUpdate()
        {
            //await Task.Factory.StartNew(() => battlesMods.ForEach(mod => mod.Update()));
            await Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < battlesMods.Count; i++)
                {
                    battlesMods[i].Update();
                }
            });
        }*/
    }
}
