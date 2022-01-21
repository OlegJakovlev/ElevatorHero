namespace Components.Health.PlayerHealth
{
    public class PlayerHealth : EntityHealth
    {
        public override void LoseHealth(int amount)
        {
            base.LoseHealth(amount);
            if (_deathClip) Animator.Play(_deathClip.name);
        }
    }
}