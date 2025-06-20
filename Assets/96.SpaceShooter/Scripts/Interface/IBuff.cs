using UnityEngine;

namespace SpaceShooter
{
    public interface IBuff
    {
        public void Buff(BuffType type, float value);
    }
}