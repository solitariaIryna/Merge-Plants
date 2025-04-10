using R3;

namespace MergePlants.State.GameResources
{
    public class Resource
    {
        public readonly ResourceData Data;
        public readonly ReactiveProperty<int> Amount;

        public ResourceType ResourceType => Data.ResourceType;

        public Resource(ResourceData data)
        {
            Data = data;
            Amount = new ReactiveProperty<int>(data.Amount);

            Amount.Subscribe(newValue => data.Amount = newValue);
        }

    }
}
