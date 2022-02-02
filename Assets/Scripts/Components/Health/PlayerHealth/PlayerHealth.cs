namespace Components.Health.PlayerHealth
{
    public class PlayerHealth : EntityHealth
    {
        public override void LoseHealth(int amount)
        {
            base.LoseHealth(amount);
            print(4);
            if (_deathClip) Animator.Play(_deathClip.name);
            print(5);
        }
    }
}