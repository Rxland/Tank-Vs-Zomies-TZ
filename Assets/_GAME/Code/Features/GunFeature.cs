using _GAME.Code.Configs_Data;
using _GAME.Code.Types;
using Zenject;

namespace _GAME.Code.Features
{
    public class GunFeature
    {
        [Inject] private ConfigsFeature _configsFeature;
        
        public GunConfigData GetGunConfig(GunType gunType)
        {
            return _configsFeature.TankConfigData.Guns.Find(x => x.GunType == gunType);
        }
    }
}