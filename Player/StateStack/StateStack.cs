using System.Collections.Generic;

namespace Player.StateStack
{
    public class StateStack
    {
        private Stack<IState> mStack = new Stack<IState>();

        public void Update(float elapsedTime)
        {
            if (mStack?.Count == 0)
                return;

            var top = mStack.Peek();
            if (!top.Update(elapsedTime))
            {
                var state = mStack.Pop();
                state.OnClose();
            }
        }

        public void Draw()
        {
            if (mStack?.Count == 0)
                return;

            var top = mStack.Peek();
            top.Draw();
        }

        public void Push(IState state)
        {
            mStack.Push(state);
            state.OnLoad();
        }

        public IState Pop()
        {
            if (mStack?.Count == 0)
                return null;

            var state = mStack.Pop();
            state.OnClose();
            return state;
        }

        public bool Empty()
        {
            return mStack?.Count == 0;
        }
    }
}