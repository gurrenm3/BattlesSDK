using System;
using System.Collections.Generic;

namespace BattlesSDK.Api
{
    /// <summary>
    /// Extension methods for System.Action
    /// </summary>
    public static class ActionExtensions
    {
        /// <summary>
        /// Invoke all actions in the list
        /// </summary>
        /// <param name="actions">list of actions to invoke</param>
        public static void InvokeAll(this List<Action> actions)
        {
            actions.ForEach(action => action.Invoke());
        }

        /// <summary>
        /// Invoke all actions in the list
        /// </summary>
        /// <typeparam name="T">argument type</typeparam>
        /// <param name="actions">list of actions to invoke</param>
        /// <param name="argument">argument to pass in while invoking</param>
        public static void InvokeAll<T>(this List<Action<T>> actions, T argument)
        {
            actions.ForEach(action => action.Invoke(argument));
        }
    }
}