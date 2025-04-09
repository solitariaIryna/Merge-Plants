using FarnClash.Infrastructure.StateMachine;

namespace FarnClash.Infrastructure.Application.StatesMachine
{
    public class ApplicationStateMachine : BaseStateMachine
    {
        private ApplicationStatesFactory _applicationStatesFactory;

        public ApplicationStateMachine(ApplicationStatesFactory applicationStatesFactory)
        {
            _applicationStatesFactory = applicationStatesFactory;
        }

        public override void Initialize()
        {
            _states = _applicationStatesFactory.CreateStates();
        }
    }

}
