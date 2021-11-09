using System;
using System.Collections.Generic;

namespace BattlesSDK.Api
{
    #region Battles Event (No Parameters)

    /// <summary>
    /// A custom event type that allows for multiple "listeners" and can easily invoke all of them
    /// </summary>
    public class BattlesEvent
    {
        /// <summary>
        /// All of the current listeners
        /// </summary>
        public List<Action> Listeners { get; private set; }

        /// <summary>
        /// Add a new listener
        /// </summary>
        /// <param name="action"></param>
        public void AddListener(Action action)
        {
            if (Listeners == null)
                Listeners = new List<Action>();

            Listeners.Add(action);
        }

        /// <summary>
        /// Remove a listener
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool RemoveListener(Action action)
        {
            return (Listeners != null) ?  Listeners.Remove(action) : false;
        }

        /// <summary>
        /// Invoke this event
        /// </summary>
        public void Invoke()
        {
            Listeners?.InvokeAll();
        }
    }

    #endregion



    #region Battles Event (One Parameter)

    /// <summary>
    /// A custom event type that allows for multiple "listeners" and can easily invoke all of them
    /// </summary>
    public class BattlesEvent<T>
    {
        /// <summary>
        /// All of the current listeners
        /// </summary>
        public List<Action<T>> Listeners { get; set; }

        /// <summary>
        /// Add a new listener
        /// </summary>
        /// <param name="action"></param>
        public void AddListener(Action<T> action)
        {
            if (Listeners == null)
                Listeners = new List<Action<T>>();

            Listeners.Add(action);
        }

        /// <summary>
        /// Remove a listener
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool RemoveListener(Action<T> action)
        {
            return (Listeners != null) ? Listeners.Remove(action) : false;
        }

        /// <summary>
        /// Invoke this event
        /// </summary>
        public void Invoke(T value)
        {
            Listeners?.InvokeAll(value);
        }
    }

    #endregion



    #region Battles Event (Two Parameters)

    /// <summary>
    /// A custom event type that allows for multiple "listeners" and can easily invoke all of them
    /// </summary>
    public class BattlesEvent<T1, T2>
    {
        /// <summary>
        /// All of the current listeners
        /// </summary>
        public List<Action<T1, T2>> Listeners { get; set; }

        /// <summary>
        /// Add a new listener
        /// </summary>
        /// <param name="action"></param>
        public void AddListener(Action<T1, T2> action)
        {
            if (Listeners == null)
                Listeners = new List<Action<T1, T2>>();

            Listeners.Add(action);
        }

        /// <summary>
        /// Remove a listener
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool RemoveListener(Action<T1, T2> action)
        {
            return (Listeners != null) ? Listeners.Remove(action) : false;
        }

        /// <summary>
        /// Invoke this event
        /// </summary>
        public void Invoke(T1 value1, T2 value2)
        {
            Listeners?.InvokeAll(value1, value2);
        }
    }

    #endregion



    #region Battles Event (Three Parameters)

    /// <summary>
    /// A custom event type that allows for multiple "listeners" and can easily invoke all of them
    /// </summary>
    public class BattlesEvent<T1, T2, T3>
    {
        /// <summary>
        /// All of the current listeners
        /// </summary>
        public List<Action<T1, T2, T3>> Listeners { get; set; }

        /// <summary>
        /// Add a new listener
        /// </summary>
        /// <param name="action"></param>
        public void AddListener(Action<T1, T2, T3> action)
        {
            if (Listeners == null)
                Listeners = new List<Action<T1, T2, T3>>();

            Listeners.Add(action);
        }

        /// <summary>
        /// Remove a listener
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool RemoveListener(Action<T1, T2, T3> action)
        {
            return (Listeners != null) ? Listeners.Remove(action) : false;
        }

        /// <summary>
        /// Invoke this event
        /// </summary>
        public void Invoke(T1 value1, T2 value2, T3 value3)
        {
            Listeners?.InvokeAll(value1, value2, value3);
        }
    }

    #endregion



    #region Battles Event (Four Parameters)

    /// <summary>
    /// A custom event type that allows for multiple "listeners" and can easily invoke all of them
    /// </summary>
    public class BattlesEvent<T1, T2, T3, T4>
    {
        /// <summary>
        /// All of the current listeners
        /// </summary>
        public List<Action<T1, T2, T3, T4>> Listeners { get; set; }

        /// <summary>
        /// Add a new listener
        /// </summary>
        /// <param name="action"></param>
        public void AddListener(Action<T1, T2, T3, T4> action)
        {
            if (Listeners == null)
                Listeners = new List<Action<T1, T2, T3, T4>>();

            Listeners.Add(action);
        }

        /// <summary>
        /// Remove a listener
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool RemoveListener(Action<T1, T2, T3, T4> action)
        {
            return (Listeners != null) ? Listeners.Remove(action) : false;
        }

        /// <summary>
        /// Invoke this event
        /// </summary>
        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            Listeners?.InvokeAll(value1, value2, value3, value4);
        }
    }

    #endregion
}
