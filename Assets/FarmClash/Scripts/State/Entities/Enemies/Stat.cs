using R3;

namespace MergePlants.State.Entities.Enemies
{
    public class Stat<T>
    {
        public ReactiveProperty<T> Current;
        public T Max;

        public Stat(T current, T max)
        {
            Current = new(current);
            Max = max;
        }
    }
}
