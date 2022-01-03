namespace Entity.Health
{
    public interface IHealth
    {
        void AddHealth(int amount = 1);
        void LoseHealth(int amount = 1);
        void Die();
    }
}