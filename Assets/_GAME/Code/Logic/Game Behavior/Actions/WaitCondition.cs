using NodeCanvas.Framework;
using UnityEngine;

namespace _GAME.Code.Logic.Game_Behavior.Actions
{
    public class WaitCondition : ConditionTask
    {
        private float _fireTime;
        public BBParameter<float> WaitTime;

        protected override bool OnCheck()
        {
            if (_fireTime < WaitTime.value)
            {
                _fireTime += Time.deltaTime;
                return false;
            }

            _fireTime = 0f;
            return true;
        }
    }
}